using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowing : MonoBehaviour
{
    protected Animator animator;
    public float growTime = 5f;
    public int maxStage = 4;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(CountdownAndSwitchAnimation());
    }
    private IEnumerator CountdownAndSwitchAnimation()
    {
        for (int i = 2; i <= maxStage; i++) 
        {
            yield return new WaitForSeconds(growTime);
            animator.SetInteger("Stage", i);
        }
    }
}
