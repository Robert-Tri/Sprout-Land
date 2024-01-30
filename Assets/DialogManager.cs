using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    public GameObject currentDialog;
    // Thuộc tính tham chiếu tới Prefab của Dialog Question 
    public GameObject questionDialogPrefab;
    // Start is called before the first frame update
    void Start()
    {
        if (currentDialog != null)
        {
            currentDialog.SetActive(false);
        }

        if (questionDialogPrefab != null)
        {
            questionDialogPrefab.SetActive(false);
        }
    }

    

    // Hàm hiển thị Dialog Question
    public void ShowQuestionDialog()
    {

        // Kiểm tra nếu đã có dialog được mở rồi thì đóng đi
        if (currentDialog != null)
        {
            Destroy(currentDialog);
        }

        // Khởi tạo Prefab của Dialog Question
        GameObject dialogObj = Instantiate(questionDialogPrefab);

        // Lấy tham chiếu component QuestionDialog Script
        QuestionDialog ctrl = dialogObj.GetComponent<QuestionDialog>();

        // Thiết lập câu hỏi, có thể lấy ngẫu nhiên từ mảng các câu hỏi
        ctrl.SetQuestion("Câu hỏi mẫu?");

        // Lưu lại tham chiếu dialog hiện tại
        currentDialog = dialogObj;

    }

}
