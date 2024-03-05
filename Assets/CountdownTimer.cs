using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f; // 60 giây (1 phút)
    private float currentTime;
    public GameObject telePort;
    public Text countdownText;

    private bool isTeleportedBack = false;

    void Start()
    {
        currentTime = countdownTime;
        UpdateCountdownText();

        // Kiểm tra nếu người chơi đã teleport về từ Map 2, bắt đầu đếm ngược
        if (currentTime != 0)
        {
            StartCountdown();
        }
        else
        {
            countdownText.text = "Dungeon Ready";
        }
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateCountdownText();
        }
        else
        {
            telePort.SetActive(true);
            countdownText.text = "Dungeon Ready";
            // Ví dụ: Hiển thị "Start Challenge"
            Debug.Log("Start Challenge");
        }
    }

    void UpdateCountdownText()
    {
        // Kiểm tra countdownText để tránh lỗi NullReferenceException
        if (countdownText != null)
        {
            int minutes = Mathf.FloorToInt(currentTime / 60);
            int seconds = Mathf.FloorToInt(currentTime % 60);

            countdownText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }


    public void StartCountdown()
    {
        telePort.SetActive(false);

        currentTime = countdownTime;
        UpdateCountdownText();
    }
}
