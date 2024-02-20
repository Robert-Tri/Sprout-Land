using UnityEngine;

public class TurnOffLight : MonoBehaviour
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
            Debug.LogWarning("No Camera reference is set in TurnOffLight script.");
        }
    }
}
