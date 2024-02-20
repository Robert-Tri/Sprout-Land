using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    private bool playerOnBridge = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerOnBridge)
        {
            ToggleTrigger(true);
            playerOnBridge = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerOnBridge)
        {
            ToggleTrigger(false);
            playerOnBridge = false;
        }
    }

    void ToggleTrigger(bool enable)
    {
        GameObject[] platformUnderBridges = GameObject.FindGameObjectsWithTag("Platform Under Bridge");
        foreach (GameObject platform in platformUnderBridges)
        {
            Collider2D[] colliders = platform.GetComponents<Collider2D>();

            foreach (Collider2D collider in colliders)
            {
                collider.enabled = !enable;
            }
        }
    }
}
