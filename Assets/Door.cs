using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections; 

public class Door : MonoBehaviour
{
    private bool isPlayerInRange = false;
    private TextMesh interactText;
    public string textInteraction;
    private GameObject textObject;
    private Coroutine fadeCoroutine;
    [SerializeField] private Animator animator;
    [SerializeField] private Material originalMaterial;
    [SerializeField] private Collider2D roofCollider;
    [SerializeField] private Collider2D doorCollider;
    [SerializeField] private GameObject player;
    [SerializeField] private AudioClip openDoorSoundEffect;
    [SerializeField] private AudioClip closeDoorSoundEffect;
    [SerializeField] private AudioSource audioSrc;


    private void Update()
    {
        if (isPlayerInRange)
        {
            textObject = InteractManager.Instance.textObject;
            interactText = InteractManager.Instance.interactText;
            interactText.text = textInteraction;
            interactText.gameObject.SetActive(true);
            textObject.transform.SetParent(transform);
            textObject.transform.localPosition = new Vector3(0f, 1f, 0f);
            if (Input.GetKeyDown(KeyCode.E))
            {
                audioSrc.clip = openDoorSoundEffect;
                audioSrc.Play();
                animator.SetBool("IsOpen", true);
                fadeCoroutine = StartCoroutine(FadeTilemap());
                doorCollider.isTrigger = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            isPlayerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            audioSrc.clip = closeDoorSoundEffect;
            audioSrc.Play();
            isPlayerInRange = false;
            animator.SetBool("IsOpen", false);
            interactText.gameObject.SetActive(false);
            StopCoroutine(fadeCoroutine);
            if(!roofCollider.bounds.Contains(player.transform.position))
                roofCollider.GetComponent<TilemapRenderer>().material = originalMaterial;
            doorCollider.isTrigger = false;
        }
    }

    private IEnumerator FadeTilemap()
    {
        float fadeDuration = 1f; 
        float targetAlpha = 0.1f; 

        Material material = new Material(roofCollider.GetComponent<TilemapRenderer>().material);

        float startTime = Time.time;
        while (Time.time - startTime < fadeDuration)
        {
            float progress = (Time.time - startTime) / fadeDuration;
            float alpha = Mathf.Lerp(material.color.a, targetAlpha, progress);

            Color color = material.color;
            color.a = alpha;
            material.color = color;

            roofCollider.GetComponent<TilemapRenderer>().material = material;

            yield return null; 
        }
    }
}
