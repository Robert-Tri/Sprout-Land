using Assets._Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

public class DailyItem : MonoBehaviour
{
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    private List<GameObjectData> items;
    private static DailyItem instance;
    public static DailyItem Instance { get => instance; set => instance = value; }
    public float delayBeforeDisappear = 2f;
    public GameObject Chest;
    private OpenChest chest = new OpenChest();
    
    void Update()
    {
        // Kiểm tra nếu người dùng nhấn phím "F"
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Đảo ngược trạng thái của gameObject (ẩn nếu đang hiện và hiện nếu đang ẩn)
            gameObject.SetActive(false);
            Invoke("Disappear", delayBeforeDisappear);
            chest.ToggleChest();
        }
    }

    void Disappear()
    {
        // Biến mất đối tượng
        Chest.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            textObject = InteractManager.Instance.textObject;
            interactText = InteractManager.Instance.interactText;
            interactText.text = textInteraction;
            interactText.gameObject.SetActive(true);
            textObject.transform.SetParent(transform);
            textObject.transform.localPosition = new Vector3(0f, 1f, 0f);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            interactText.gameObject.SetActive(false);
        }
    }
}
