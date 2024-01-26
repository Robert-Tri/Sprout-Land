using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel; // Kéo và thả Panel từ Canvas vào đây trong Inspector
    private bool isSettingsVisible = false;

    // Sử dụng Awake thay vì Start để đảm bảo chắc chắn rằng Awake được gọi trước Start
    void Awake()
    {
        // Ẩn SettingsManager khi khởi đầu
        settingsPanel.SetActive(false);
    }

    void Update()
    {
        // Kiểm tra nút Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Hiển thị/ẩn Panel khi nhấn Esc
            isSettingsVisible = !isSettingsVisible;
            settingsPanel.SetActive(isSettingsVisible);
        }
    }
}
