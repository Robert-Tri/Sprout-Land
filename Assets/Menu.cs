using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Th�m d?ng n�y �? s? d?ng SceneManager

public class Menu : MonoBehaviour
{
    // ��y l� ph��ng th?c ��?c g?i khi n�t ��?c nh?n
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // T?i l?i scene "Main Menu"
    }
}
