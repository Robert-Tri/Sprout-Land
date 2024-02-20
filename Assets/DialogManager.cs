using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject currentDialog;
    // Thuộc tính tham chiếu tới Prefab của Dialog Question 
    public GameObject questionDialogPrefab;
    public GameObject content;
    public GameObject iconQuestion;
    public GameObject iconChest;
    public Button buttonA;
    public Button buttonB;
    public Sprite checkSprite;
    public float delayBeforeDestroy = 2f; // Độ trễ trước khi hủy đối tượng

    public Image uiImage; // Tham chiếu đến component Image trong Inspector
    public Sprite correctSprite;
    public Sprite wrongSprite;
    
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
        uiImage.gameObject.SetActive(false);
    }
 
    // Hàm hiển thị Dialog Question
    public void ShowQuestionDialog()
    {

        currentDialog = Instantiate(questionDialogPrefab);
        currentDialog.SetActive(true);

    }
    public void OnButtonAClick()
    {
        iconQuestion.SetActive(false);

        uiImage.sprite = correctSprite;
        uiImage.gameObject.SetActive(true);

   
        // Bắt đầu coroutine để hủy đối tượng sau một khoảng thời gian
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        // Chờ trong khoảng thời gian đã đặt
        yield return new WaitForSeconds(delayBeforeDestroy);

        // Hủy đối tượng
        Destroy(currentDialog);
        iconChest.SetActive(true);
    }
    public void OnButtonBClick()
    {
        return;
    }
}
