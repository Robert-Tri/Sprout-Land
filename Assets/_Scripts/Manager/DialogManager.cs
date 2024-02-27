using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using static DialogManager;
using System;
using static Dialogue;
using TMPro;
using System.Linq;

public class DialogManager : MonoBehaviour
{
    public GameObject currentDialog;
    // Thuộc tính tham chiếu tới Prefab của Dialog Question 
    public GameObject questionDialogPrefab;
    public GameObject contentQuestion;
    public GameObject iconQuestion1;
    public GameObject iconQuestion2;
    public GameObject iconQuestion3;
    public GameObject iconQuestion4;

    public GameObject iconChest;
    public Button buttonA;
    public GameObject contentButtonA;
    public Button buttonB;
    public GameObject contentButtonB;
    public float delayBeforeDestroy = 1f; // Độ trễ trước khi hủy đối tượng

    public Image uiImage; // Tham chiếu đến component Image trong Inspector
    public Sprite correctSprite;
    public Sprite wrongSprite;
    public Sprite questionSprite;
    public List<Question> questions;
    public List<Question> randomQuestions;
    public Question currentQuestion;
    int countQuestion = 0;
    //lưu số câu hỏi trả lời đúng
    public static int countAnswer = 0;

    [System.Serializable]
    public class Question
    {
        public string question;
        public List<Answer> answers;
    }

    [System.Serializable]
    public class Answer
    {
        public string text;
        public bool isCorrect;
    }
    [System.Serializable]
    public class QuestionData
    {
        public List<Question> questionTree;
    }

    // Start is called before the first frame update
    void Start()
    {
        iconChest.SetActive(false);

        TextAsset jsonFile = JsonLoader.GetJsonFile("bocauhoiMap2");
        string jsonText = jsonFile.text;
        QuestionData data = JsonUtility.FromJson<QuestionData>(jsonText);
        questions = data.questionTree;

        if (currentDialog != null)
        {
            currentDialog.SetActive(false);
        }

        if (questionDialogPrefab != null)
        {
            questionDialogPrefab.SetActive(false);
        }

        uiImage.sprite = questionSprite;
        uiImage.gameObject.SetActive(true);

        // lấy ramdom 4 question
        randomQuestions = GetRandomQuestions();
    }
 
    // Hàm hiển thị Dialog Question
    public void ShowQuestionDialog()
    {
        FillContentQuestion(randomQuestions, countQuestion);

        currentDialog.SetActive(true);
        countQuestion++;
    }
    public void OnButtonAClick()
    {
        // Kiểm tra đáp án và xử lý kết quả
        if (CheckAnswer(buttonA.GetComponentInChildren<TextMeshProUGUI>().text))
        {
            // Đáp án đúng
            uiImage.sprite = correctSprite;
            uiImage.gameObject.SetActive(true);
            countAnswer++;
        }
        else
        {
            // Đáp án sai
            uiImage.sprite = wrongSprite;
            uiImage.gameObject.SetActive(true);
        }

        // Bắt đầu coroutine để hủy đối tượng sau một khoảng thời gian
        StartCoroutine(DelayedDestroy());
    }
    public void OnButtonBClick()
    {
        // Kiểm tra đáp án và xử lý kết quả
        if (CheckAnswer(buttonB.GetComponentInChildren<TextMeshProUGUI>().text))
        {
            // Đáp án đúng
            uiImage.sprite = correctSprite;
            uiImage.gameObject.SetActive(true);
            countAnswer++;
        }
        else
        {
            // Đáp án sai
            uiImage.sprite = wrongSprite;
            uiImage.gameObject.SetActive(true);
        }

        // Bắt đầu coroutine để hủy đối tượng sau một khoảng thời gian
        StartCoroutine(DelayedDestroy());
    }

    private IEnumerator DelayedDestroy()
    {
        // Chờ trong khoảng thời gian đã đặt
        yield return new WaitForSeconds(delayBeforeDestroy);

        // Hủy đối tượng
        //Destroy(currentDialog);
        currentDialog.SetActive(false);

        uiImage.sprite = questionSprite;
        uiImage.gameObject.SetActive(true);
        if (countQuestion == 4 && countAnswer >= 2)
        {
            //lưu số câu trả lời đúng qua QpenChest để dùng
            ManageChest.SetCountAnswer(countAnswer);
            iconChest.SetActive(true);
        }
    }
    
    // Hàm ngẫu nhiên lấy 4 câu hỏi từ danh sách và trả về danh sách mới
    public List<Question> GetRandomQuestions()
    {
        System.Random rnd = new System.Random();

        // Lấy một danh sách sao chép từ danh sách gốc để tránh ảnh hưởng đến danh sách gốc
        List<Question> copyOfQuestions = new List<Question>(questions);

        // Ngẫu nhiên xáo trộn danh sách câu hỏi
        copyOfQuestions = copyOfQuestions.OrderBy(q => rnd.Next()).ToList();

        // Lấy 4 câu hỏi đầu tiên sau khi xáo trộn
        List<Question> randomQuestions = copyOfQuestions.Take(4).ToList();

        return randomQuestions;
    }

    public void FillContentQuestion(List<Question> list, int n)
    {
        if (contentQuestion != null && !contentQuestion.Equals(null))  // Kiểm tra nếu contentQuestion không null và chưa bị hủy
        {
            TextMeshProUGUI questionText = contentQuestion.GetComponent<TextMeshProUGUI>();

            if (questionText != null)  // Kiểm tra nếu thành phần TextMeshProUGUI không null
            {
                // Kiểm tra nếu danh sách câu hỏi không rỗng và có ít nhất 1 câu hỏi
                if (list != null && list.Count > 0)
                {
                    // Lấy câu hỏi n từ danh sách
                    Question nQuestion = list[n];
                    currentQuestion = nQuestion;

                    // Hiển thị nội dung câu hỏi lên UI
                    questionText.text = nQuestion.question;

                    // ... (Các thao tác khác)

                    // Nếu câu hỏi có ít nhất 2 đáp án
                    if (nQuestion.answers != null && nQuestion.answers.Count >= 2)
                    {
                        // Lấy đáp án A và B từ câu hỏi
                        Answer answerA = nQuestion.answers[0];
                        Answer answerB = nQuestion.answers[1];

                        // Hiển thị đáp án lên Button
                        TextMeshProUGUI buttonAText = contentButtonA.GetComponent<TextMeshProUGUI>();
                        buttonAText.text = answerA.text;

                        TextMeshProUGUI buttonBText = contentButtonB.GetComponent<TextMeshProUGUI>();
                        buttonBText.text = answerB.text;
                    }
                }
            }
        }
    }
    // Hàm kiểm tra đáp án
    public bool CheckAnswer(string selectedAnswer)
    {
        if (currentQuestion != null && currentQuestion.answers != null)
        {
            // Duyệt qua tất cả các đáp án để kiểm tra đáp án được chọn
            foreach (Answer answer in currentQuestion.answers)
            {
                if (answer.text == selectedAnswer)
                {
                    // Kiểm tra xem đáp án có đúng không
                    return answer.isCorrect;
                }
            }
        }

        return false; // Trả về false nếu không tìm thấy đáp án
    }

}
