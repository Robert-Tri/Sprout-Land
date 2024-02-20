using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildModeManager : MonoBehaviour
{
    public GameObject buildObjectPrefab;
    protected Vector3 mousePosition;
    public Color validPlacementColor;
    public Color invalidPlacementColor;
    private SpriteRenderer spriteRenderer;
    protected RaycastHit2D hit;
    private void Awake()
    {
        this.buildObjectPrefab = GameObject.Find("TreePrefab");
        this.mousePosition = new Vector3();
        this.validPlacementColor = Color.white;
        this.invalidPlacementColor = Color.red;
        spriteRenderer = buildObjectPrefab.GetComponent<SpriteRenderer>();

    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        hit = Physics2D.Raycast(mousePosition, Vector2.zero);
        InstantiateMousePointer(mousePosition);
    }

    private void InstantiateMousePointer(Vector3 position)
    {
        if (buildObjectPrefab != null)
        {
            GameObject treePrefabClone = GameObject.Find("TreePrefabClone");

            if (treePrefabClone == null)
            {
                treePrefabClone = Instantiate(buildObjectPrefab, position, Quaternion.identity);
                treePrefabClone.name = "TreePrefabClone";
                spriteRenderer = treePrefabClone.GetComponent<SpriteRenderer>();
            }
            else
            {
                treePrefabClone.transform.position = position;
            }
            this.CheckOnjectInBuildArea();
        }
    }

    private void OnLeftClick(InputValue evt)
    {
        if (hit.collider != null && hit.collider.CompareTag("BuildZone"))
        {
            SetSpriteColor(validPlacementColor);
            Instantiate(buildObjectPrefab, mousePosition, Quaternion.identity);
        } else
        {
            SetSpriteColor(invalidPlacementColor);
        }
    }
    private void CheckOnjectInBuildArea()
    {
        if (hit.collider != null && hit.collider.CompareTag("BuildZone"))
        {
            SetSpriteColor(validPlacementColor);
        }
        else
        {
            SetSpriteColor(invalidPlacementColor);
        }
    }
    private void SetSpriteColor(Color color)
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = color;
        }
    }
}
