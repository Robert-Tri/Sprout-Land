using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CowMilk : MonoBehaviour
{
    private Animator anim;
    private bool isEat = false; // Trạng thái hiện tại của cow
    private bool isMilk = false;
    private bool isClaim = false;
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    [SerializeField] private GameObject Milk;
    private int count = 0 ;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerInRange)
        {

            if (Input.GetKeyDown(KeyCode.E))
            {
                ToggleCow();
                if (isMilk && textInteraction == "[E] Claim")
                {
                    Milk.SetActive(true);
                    isClaim = true;
                }
                if (isMilk)
                {
                    textInteraction = "[E] Claim";
                }
            }
        }
    }

    public void ToggleCow()
    {

        count++;
        // Nếu cow da an
        if (isEat)
        {
            
            if (count == 3)
            {
                count = 0;
                anim.SetBool("isEat", false);
                isEat = false;
                isClaim = false;
                textInteraction = "[E] Feed";
            }

        }
        // Nếu cow chua an
        else
        {
            anim.SetBool("isEat", true);
            isEat = true;
            isMilk = true;

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !isClaim)
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
