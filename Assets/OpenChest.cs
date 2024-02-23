﻿using Assets._Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false; // Trạng thái hiện tại của chest
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    private List<GameObjectData> items;
    private static OpenChest instance;
    public static OpenChest Instance { get => instance; set => instance = value; }
    [SerializeField] private GameObject dailyItem;
    public float delayBeforeDisappear = 2f;
    public float delayAfterDisappear = 10f;
    public GameObject Chest;

    void Start()
    {
        anim = GetComponent<Animator>();
        
        instance = this;
        this.items = new List<GameObjectData>();
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleChest();
                dailyItem.SetActive(true);
            }
        }
    }

    public void ToggleChest()
    {
        // Nếu chest đang mở, đóng nó
        if (isOpen)
        {
            anim.SetBool("isOpen", false);
            isOpen = false;
            
            Invoke("Appear", delayAfterDisappear);
        }
        // Nếu chest đang đóng, mở nó
        else
        {
            anim.SetBool("isOpen", true);
            isOpen = true;
        }
    }

    

    void Appear()
    {
        // Biến mất đối tượng
        Chest.SetActive(true);
    }

    // Hiển thị chữ khi main vào vùng cảm biến của chest
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
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
