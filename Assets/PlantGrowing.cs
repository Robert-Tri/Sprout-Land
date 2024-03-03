using Assets._Scripts.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantGrowing : MonoBehaviour
{
    public Animator animator;
    public float growTime = 5f;
    public float totalGrowTime;
    public int maxStage = 4;
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    private GameObject textObject;
    public string textInteraction;
    public GameObjectData productPrefab;
    public GameObjectData seedPrefab;
    public DateTime startTimeToGrow;
    public DateTime endTimeToGrow;
    public int harvestAmount = 1;
    public float doubleChange = 0.2f;
    public Vector3 position;

    private void Start()
    {
        position = transform.position;
        totalGrowTime = growTime * (maxStage - 1);
        startTimeToGrow = DateTime.Now;
        endTimeToGrow = startTimeToGrow.AddSeconds(totalGrowTime);
        if (InteractManager.Instance.textObject == null)
        {
            InteractManager.Instance.CreateInteractText();
        }
        textObject = InteractManager.Instance.textObject;
        interactText = InteractManager.Instance.interactText;
        animator = GetComponent<Animator>();
        StartCoroutine(CountdownAndSwitchAnimation());
    }
    private IEnumerator CountdownAndSwitchAnimation()
    {
        for (int i = 2; i <= maxStage; i++) 
        {
            yield return new WaitForSeconds(growTime);
            animator.SetInteger("Stage", i);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (animator.GetInteger("Stage") == maxStage)
        {
            if (other.CompareTag("Player"))
            {
                if (InteractManager.Instance.textObject == null)
                {
                    InteractManager.Instance.CreateInteractText();
                }
                isPlayerInRange = true;
                interactText.text = textInteraction;
                interactText.gameObject.SetActive(true);
                textObject.transform.SetParent(gameObject.transform);
                textObject.transform.localPosition = new Vector3(0f, 0.7f, 0f);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (animator.GetInteger("Stage") == maxStage)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInRange = false;
                interactText.gameObject.SetActive(false);
            }
        }
    }

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E) && animator.GetInteger("Stage") == maxStage)
            {
                bool receiveDoubleItems = UnityEngine.Random.value < doubleChange; //Khi thu hoạch sẽ có tỉ lệ nhân đôi sản lượng
                if (receiveDoubleItems)
                {
                    for (int i = 1; i <= (harvestAmount * 2);  i++) InventoryManager.Instance.AddItem(productPrefab);
                }
                else
                {
                    InventoryManager.Instance.AddItem(productPrefab);
                }

                foreach (Transform child in transform)
                {
                    child.SetParent(null); //Tháo thằng textObject ra khỏi thằng cha trước khi hủy
                }
                GlobalControl.Instance.plantData.plants.Remove(gameObject);
                Destroy(gameObject);
            }
        }
    }
}
