using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconQuestion : MonoBehaviour
{
    [SerializeField] private AudioClip openQuestionSoundEffect;
    [SerializeField] private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        OpenSound();
        // Gọi hàm hiển thị dialog câu hỏi
        GameObject.Find("DialogManager").GetComponent<DialogManager>().ShowQuestionDialog();
        // Ẩn icon câu hỏi khi đã chạm vào
        gameObject.SetActive(false);
    }
    private void OpenSound()
    {
        audioSrc.clip = openQuestionSoundEffect;
        audioSrc.Play();
    }
}
