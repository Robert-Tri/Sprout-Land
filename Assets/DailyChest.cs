using Assets._Scripts.Models;
using System.Collections.Generic;
using UnityEngine;

public class DailyChest : MonoBehaviour
{
    private Animator anim;
    private bool isClaim = false;
    private bool isOpen = false; // Trạng thái hiện tại của chest
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    [SerializeField] private List<GameObjectData> items;
    private static DailyChest instance;
    public static DailyChest Instance { get => instance; set => instance = value; }
    //[SerializeField] private GameObject dailyItem;
    [SerializeField] private List<GameObject> dailyItems;
    public float delayAfterDisappear = 5f;
    public GameObject Chest;
    private int randomIndex;

    void Start()
    {
        anim = GetComponent<Animator>();
        
        //instance = this;
        //this.items = new GameObjectData();
    }

    void Update()
    {
        if (isPlayerInRange)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleChest();
                //dailyItem.SetActive(true);
                //foreach (GameObject item in dailyItems)
                //{
                // item.SetActive(true);
                //}

                if (dailyItems.Count > 0)
                {
                    isClaim = true;
                    // Chọn một vật phẩm ngẫu nhiên từ danh sách
                    randomIndex = Random.Range(0, dailyItems.Count);
                    GameObject randomItem = dailyItems[randomIndex];

                    // Kích hoạt vật phẩm và loại bỏ khỏi danh sách để không chọn lại
                    randomItem.SetActive(true);
                    //dailyItems.RemoveAt(randomIndex);
                }
            }
        }
    }

    public void ToggleChest()
    {
        // Nếu chest đang mở, đóng nó
        if (isOpen)
        {
            isClaim = false;
            anim.SetBool("isOpen", false);
            isOpen = false;
            InventoryManager.Instance.AddItem(items[randomIndex]);
            Invoke("Appear", delayAfterDisappear);
        }
        // Nếu chest đang đóng, mở nó
        else
        {
            anim.SetBool("isOpen", true);
            isOpen = true;
        }
    }

    

    void Appear()
    {
        // Biến mất đối tượng
        Chest.SetActive(true);
    }

    // Hiển thị chữ khi main vào vùng cảm biến của chest
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isClaim)
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
