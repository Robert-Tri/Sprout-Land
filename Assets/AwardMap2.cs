using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwardMap2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //Tăng tiền khi nhặt

            // Khi người chơi chạm vào, ẩn đi đối tượng
            gameObject.SetActive(false);
        }
    }

}
