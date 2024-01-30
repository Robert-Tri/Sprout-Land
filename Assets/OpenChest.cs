using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    protected Animator animator;
    // Biến để xác định trạng thái của rương
    // Hàm được gọi khi người chơi va chạm vào rương
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            // Kiểm tra xem rương đã mở chưa       
                // Gọi hàm để mở rương
                OpenChestFunction();      
        }
    }

    // Hàm mở rương
    private void OpenChestFunction()
    {
        // Thực hiện các thao tác mở rương ở đây
        Debug.Log("Rương đã mở!");

        // Đặt trạng thái rương thành đã mở
        animator.SetBool("isOpenChest", true);
        // Bạn có thể thêm các hiệu ứng âm thanh, hình ảnh, hoặc thay đổi trạng thái đồ họa ở đây
    }

    // Start is called before the first frame update
    void Start()
    {
        this.animator = GetComponent<Animator>();
    }
}
