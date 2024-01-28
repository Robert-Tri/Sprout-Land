using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    private GameObject textObject;

    private void Start()
    {
        textObject = new GameObject("InteractText");
        interactText = textObject.AddComponent<TextMesh>();
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = new Vector3(0f, 1.5f, 0f);
        textObject.SetActive(false);

        interactText.text = "[E] Interact";
        interactText.anchor = TextAnchor.MiddleCenter;
        interactText.alignment = TextAlignment.Center;
        interactText.fontSize = 5;
        interactText.GetComponent<MeshRenderer>().sortingLayerName = "UI";
        interactText.characterSize = 0.14f;
        interactText.fontSize = 20;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            interactText.gameObject.SetActive(true);
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

    private void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Interacting with: " + gameObject.name);
            }
        }
    }
}
