using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public GameObject questionDialog; // K�o v� th? prefab c?a dialog c�u h?i v�o ?�y t? Editor

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // ??m b?o ch? x? l� khi ng??i ch?i va ch?m
        {
            // Hi?n th? dialog c�u h?i khi va ch?m
            if (questionDialog != null)
            {
                Instantiate(questionDialog, transform.position, Quaternion.identity);
            }

            // T�y ch?nh c�c h�nh ??ng kh�c n?u c?n thi?t (v� d?: t?t ??i t??ng IconQuestion)
            // gameObject.SetActive(false);
        }
    }
}
