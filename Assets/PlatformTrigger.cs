using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTrigger : MonoBehaviour
{
    private bool playerOnPlatformUnderBridge = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !playerOnPlatformUnderBridge)
        {
            ToggleTrigger(true);
            playerOnPlatformUnderBridge = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player") && playerOnPlatformUnderBridge)
        {
            ToggleTrigger(false);
            playerOnPlatformUnderBridge = false;
        }
    }

    void ToggleTrigger(bool enable)
    {
        GameObject hillZone = GameObject.Find("HillZone");
        PolygonCollider2D hillZoneCollider = hillZone.GetComponent<PolygonCollider2D>();
        hillZoneCollider.enabled = !enable;
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Bridge In Hill");
        foreach (GameObject platform in platforms)
        {
            Collider2D[] colliders = platform.GetComponents<Collider2D>();

            foreach (Collider2D collider in colliders)
            {
                collider.enabled = !enable;
            }
        }
    }
}
