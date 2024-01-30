using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject questionDialog; // Kéo và th? prefab c?a dialog câu h?i vào ?ây t? Editor

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ??m b?o ch? x? lý khi ng??i ch?i va ch?m
        {
            // Hi?n th? dialog câu h?i khi va ch?m
            if (questionDialog != null)
            {
                Instantiate(questionDialog, transform.position, Quaternion.identity);
            }

            // Tùy ch?nh các hành ??ng khác n?u c?n thi?t (ví d?: t?t ??i t??ng IconQuestion)
            // gameObject.SetActive(false);
        }
    }
}
