using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class PlantSeed : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    private GameObject textObject;
    public Tilemap tilemap;
    public GameObject objectToCreate;
    private GameObject objectToSetPosition;
    private Vector3 worldPosition;
    public string textInteraction;
    [SerializeField] private AudioClip sowSeedSoundEffect;
    private AudioSource audioSrc;

    private void Start()
    {
        this.objectToSetPosition = new GameObject("Object Position");
        audioSrc = GetComponent<AudioSource>();
        if (InteractManager.Instance.textObject == null)
        {
            InteractManager.Instance.CreateInteractText();
        }
        textObject = InteractManager.Instance.textObject;
        interactText = InteractManager.Instance.interactText;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            Vector3Int cellPosition = tilemap.WorldToCell(other.transform.position);
            TileBase tile = tilemap.GetTile(cellPosition);
            if (tile != null && tile.name == "Tilled_Dirt_11" && !ObjectExistsAtPosition(cellPosition))
            {
                worldPosition = tilemap.GetCellCenterWorld(cellPosition);
                objectToSetPosition.transform.position = worldPosition;
                interactText.text = textInteraction;
                interactText.gameObject.SetActive(true);
                textObject.transform.SetParent(objectToSetPosition.transform);
                textObject.transform.localPosition = new Vector3(0f, 0.7f, 0f);
            }
        }
    }

    private bool ObjectExistsAtPosition(Vector3Int position)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(tilemap.GetCellCenterWorld(position));

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Plant"))
            {
                return true;
            }
        }

        return false;
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
            if (Input.GetKeyDown(KeyCode.E) && InventoryManager.Instance.selectedItem != null && InventoryManager.Instance.selectedItem.item.variety == Variety.Seed)
            {
                worldPosition.y += 0.2f;
                objectToCreate = InventoryManager.Instance.selectedItem.itemPrefab;
                InventoryManager.Instance.RemoveItem(InventoryManager.Instance.selectedItem, 1);
                GameObject plant = Instantiate(objectToCreate, worldPosition, Quaternion.identity);
                PlantManager.Instance.Plants.plants.Add(plant);
                audioSrc.clip = sowSeedSoundEffect;
                audioSrc.Play();
            }
        }
    }
}
