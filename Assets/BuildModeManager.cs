using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Tilemaps;

public class BuildModeManager : MonoBehaviour
{
    public GameObject treePrefab;
    protected Vector3 mousePosition;
    protected Tilemap tilemap;
    private void Awake()
    {
        this.treePrefab = GameObject.Find("TreePrefab");
        this.mousePosition = new Vector3();
    }
    private void Update()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;

        InstantiateMousePointer(mousePosition);
    }

    private void InstantiateMousePointer(Vector3 position)
    {
        if (treePrefab != null)
        {
            GameObject treePrefabClone = GameObject.Find("TreePrefabClone");

            if (treePrefabClone == null)
            {
                treePrefabClone = Instantiate(treePrefab, position, Quaternion.identity);
                treePrefabClone.name = "TreePrefabClone";
            }
            else
            {
                treePrefabClone.transform.position = position;
            }
        }
    }

    private void OnLeftClick(InputValue evt)
    {
        Instantiate(treePrefab, mousePosition, Quaternion.identity);
    }
}
