using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractableObject : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    private GameObject textObject;
    public Tilemap tilemap;
    public TileBase newTile;
    public GameObject objectToCreate;

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
            Vector3Int cellPosition = tilemap.WorldToCell(transform.position);

            // Kiểm tra xem có tile không
            TileBase tile = tilemap.GetTile(cellPosition);
            if (tile != null)
            {
                Vector3 worldPosition = tilemap.GetCellCenterWorld(cellPosition);

                // Tạo đối tượng tại vị trí tile
                Instantiate(objectToCreate, worldPosition, Quaternion.identity);

                // Optional: Xóa tile để ngăn chặn tạo nhiều đối tượng tại cùng một vị trí
                tilemap.SetTile(cellPosition, null);
            }
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
