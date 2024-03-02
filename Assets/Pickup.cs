using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            InventoryManager.Instance.AddItem(gameObject.GetComponent<GameObjectData>());
            Destroy(gameObject);
        }
    }


}
