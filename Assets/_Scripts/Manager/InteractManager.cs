using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class InteractManager : MonoBehaviour
{
    public TextMesh interactText;
    public GameObject textObject;
    private static InteractManager instance;

    public static InteractManager Instance { get => instance; set => instance = value; }

    private void Awake()
    {
        InteractManager.instance = this;
    }
    private void Start()
    {
        textObject = new GameObject("InteractText");
        interactText = textObject.AddComponent<TextMesh>();
        textObject.SetActive(false);

        interactText.anchor = TextAnchor.MiddleCenter;
        interactText.alignment = TextAlignment.Center;
        interactText.fontSize = 5;
        interactText.GetComponent<MeshRenderer>().sortingLayerName = "Interact Text";
        interactText.characterSize = 0.14f;
        interactText.fontSize = 20;
        textObject.transform.SetParent(transform);
        textObject.transform.localPosition = new Vector3(0f, 0.5f, 0f);
        }
}
