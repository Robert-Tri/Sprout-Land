using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconQuestion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Gọi hàm hiển thị dialog câu hỏi
        GameObject.Find("DialogManager").GetComponent<DialogManager>().ShowQuestionDialog();
    }
}
