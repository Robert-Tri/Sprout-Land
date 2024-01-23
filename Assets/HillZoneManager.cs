using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HillZoneManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetSortingLayer(other.gameObject, "Player (In Higher Platform)");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SetSortingLayer(other.gameObject, "Player (In Platform)");
        }
    }

    private void SetSortingLayer(GameObject obj, string sortingLayerName)
    {
        Renderer objRenderer = obj.GetComponent<Renderer>();

        if (objRenderer != null)
        {
            objRenderer.sortingLayerName = sortingLayerName;
        }
    }
}
