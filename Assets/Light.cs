using UnityEngine;

public class Light : MonoBehaviour
{
    public Camera mainCamera; // Tham chiếu đến đối tượng Camera

    public float brightnessDecreaseAmount = 0.1f; // Số lượng giảm độ sáng

    // Phương thức được gọi khi button được nhấn
    public void DecreaseBrightness()
    {
        // Kiểm tra xem Camera có tồn tại không
        if (mainCamera != null)
        {
            // Giảm độ sáng của Camera
            mainCamera.backgroundColor -= new Color(brightnessDecreaseAmount, brightnessDecreaseAmount, brightnessDecreaseAmount, 0f);
        }
        else
        {
            Debug.LogWarning("Camera reference is not set in Light script.");
        }
    }
}
