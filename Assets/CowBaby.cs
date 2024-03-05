using Assets._Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using UnityEngine;

public class CowBaby : MonoBehaviour
{
    private Animator anim;
    private int isEat = 0; // Trạng thái hiện tại của cow
    private bool isMilk = false;
    //private bool isDone = false;
    private bool isClaim = false;
    private GameObject textObject; // Tham chiếu đến GameObject chứa chữ
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    [SerializeField] private GameObject Milk;
    [SerializeField] private List<GameObject> Power;
    private int count = 0;
    private int countUp = 0;
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
            if (isEat < Power.Count)
            {
                // Set active gameObject tại vị trí count trong Power list thành true
                Power[isEat].SetActive(true);
            }
            if(isEat < 3)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Power[isEat].SetActive(false);
                    ToggleCow();
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && countUp < 4)
            {
                countUp++;
            }               
            if(countUp == 4)
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    ToggleMilk();
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
    }

    public void ToggleCow()
    {
        isEat++;
        // Nếu cow da an
        if (isEat == 3)
        {
            
            anim.SetInteger("isEat", isEat);
            
            
            textInteraction = "[E] Feed";  
        }
        // Nếu cow chua an
        else
        {
                
                anim.SetInteger("isEat", isEat);
                
            if (isEat == 2)
            {
                textInteraction = "[E] Update";
            }
            
        }
    }

    public void ToggleMilk()
    {

        count++;
        // Nếu cow da an
        if (isMilk)
        {

            if (count == 3)
            {
                count = 0;
                anim.SetBool("isMilk", false);
                isMilk = false;
                isClaim = false;
                textInteraction = "[E] Feed";
            }

        }
        // Nếu cow chua an
        else
        {
            anim.SetBool("isMilk", true);
            isMilk = true;
            //isDone = true;
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
            if (isEat < Power.Count)
            {
                Power[isEat].SetActive(false);
            }
        }
    }
}
