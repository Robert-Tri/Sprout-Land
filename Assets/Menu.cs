using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Thêm d?ng này ð? s? d?ng SceneManager

public class Menu : MonoBehaviour
{
    // Ðây là phýõng th?c ðý?c g?i khi nút ðý?c nh?n
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); // T?i l?i scene "Main Menu"
    }
}
