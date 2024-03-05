using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class CowItem : MonoBehaviour
{
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    [SerializeField] private GameObjectData milk;
    [SerializeField] private GameObject cow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Đảo ngược trạng thái của gameObject (ẩn nếu đang hiện và hiện nếu đang ẩn)
                gameObject.SetActive(false);
                InventoryManager.Instance.AddItem(milk);
                if (cow.name.Equals("Cow"))
                {
                    cow.GetComponent<CowMilk>().ToggleCow();
                }
                if (cow.name.Equals("BabyCow"))
                { 
                    cow.GetComponent<CowBaby>().ToggleMilk();
                }
                

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
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
}
