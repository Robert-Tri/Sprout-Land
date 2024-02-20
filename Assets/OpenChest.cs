using UnityEngine;

public class OpenChest : MonoBehaviour
{
    private Animator anim;
    private bool isOpen = false; // Trạng thái hiện tại của chest
    public GameObject textObject; // Tham chiếu đến GameObject chứa chữ

    void Start()
    {
        anim = GetComponent<Animator>();
        textObject.SetActive(false); // Ẩn chữ khi bắt đầu
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ToggleChest();
        }
    }

    void ToggleChest()
    {
        // Nếu chest đang mở, đóng nó
        if (isOpen)
        {
            anim.SetBool("isOpen", false);
            isOpen = false;
        }
        // Nếu chest đang đóng, mở nó
        else
        {
            anim.SetBool("isOpen", true);
            isOpen = true;
        }
    }

    // Hiển thị chữ khi main vào vùng cảm biến của chest
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(true);
        }
    }

    // Ẩn chữ khi main ra khỏi vùng cảm biến của chest
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textObject.SetActive(false);
        }
    }
}
