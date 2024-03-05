using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mission : MonoBehaviour
{
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    public GameObject panelMission;
    private static Mission instance;
    public Text txtMoney;
    public static Mission Instance { get => instance; set => instance = value; }
    
    // Start is called before the first frame update
    void Start()
    {
        if (InteractManager.Instance.textObject == null)
        {
            InteractManager.Instance.CreateInteractText();
        }
        textObject = InteractManager.Instance.textObject;
        interactText = InteractManager.Instance.interactText;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                panelMission.SetActive(true);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            if (InteractManager.Instance.textObject == null)
            {
                InteractManager.Instance.CreateInteractText();
            }
            textObject = InteractManager.Instance.textObject;
            interactText = InteractManager.Instance.interactText;
            interactText.text = textInteraction;
            interactText.gameObject.SetActive(true);
            textObject.transform.SetParent(transform);
            textObject.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.gameObject.SetActive(false);
        }
    }

    public void CollectReward()
    {
        Resource resource = ResourceManager.Instance.FindResourceByName("Gold");
        resource.Quantity += 500;
        txtMoney.text = resource.Quantity.ToString();
    }
}
