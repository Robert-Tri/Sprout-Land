using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlantGrowing : MonoBehaviour
{
    protected Animator animator;
    public float growTime = 5f;
    public int maxStage = 4;
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    private GameObject textObject;
    public string textInteraction;
    public GameObjectData productPrefab;
    public int harvestAmount = 1;
    public float doubleChange = 0.2f;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CountdownAndSwitchAnimation());
        textObject = InteractManager.Instance.textObject;
        interactText = InteractManager.Instance.interactText;
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
                bool receiveDoubleItems = Random.value < doubleChange; //Khi thu hoạch sẽ có tỉ lệ nhân đôi sản lượng
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
                Destroy(gameObject);
            }
        }
    }
}
