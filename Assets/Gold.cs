using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gold : MonoBehaviour
{
    public Text goldUI; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Resource resource = ResourceManager.Instance.FindResourceByName("Gold");
            resource.Quantity += 1000;
            goldUI.text = resource.Quantity.ToString();
            Destroy(gameObject);
        }
    }
}
