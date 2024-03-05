using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class TeleportShip : MonoBehaviour
{
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    public GameObject panelTeleport;
    private static TeleportShip instance;
    public static TeleportShip Instance { get => instance; set => instance = value; }
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
                panelTeleport.SetActive(true);
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
