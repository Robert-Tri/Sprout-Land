using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    // Biến tĩnh để nhận giá trị countAnswer
    private static int countAnswerReceived;
    protected Animator animator;
    public GameObject award1;
    public GameObject award2;
    public GameObject award3;
    public GameObject award4;


    // Start is called before the first frame update
    void Start()
    {
        award1.SetActive(false);
        award2.SetActive(false);
        award3.SetActive(false);
        award4.SetActive(false);


        this.animator = GetComponent<Animator>();
    }
    // Hàm được gọi khi người chơi va chạm vào rương
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Kiểm tra xem đối tượng va chạm có phải là người chơi không
        if (other.CompareTag("Player"))
        {
            // Kiểm tra xem rương đã mở chưa 
            if (!animator.GetBool("isOpenChest"))
            {
                // Gọi hàm để mở rương
                OpenChestFunction();
            }
        }
    }

    // Hàm mở rương
    private void OpenChestFunction()
    {
        // Thực hiện các thao tác mở rương ở đây
        Debug.Log("Rương đã mở!");

        // Đặt trạng thái rương thành đã mở
        animator.SetBool("isOpenChest", true);
        if(countAnswerReceived > 1)
        {
            award1.SetActive(true);
            award2.SetActive(true);
        }
        if (countAnswerReceived > 2)
        {
            award3.SetActive(true);
        }
        if (countAnswerReceived > 3)
        {
            award4.SetActive(true);

        }



    }

    public static void SetCountAnswer(int value)
    {
        countAnswerReceived = value;
    }
}

