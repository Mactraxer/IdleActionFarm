using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerTrigger : MonoBehaviour
{

    public Action OnDetectHarvestableObject;
    public Action OnLoseHarvestableObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IHarvestable>() != null)
        {
            OnDetectHarvestableObject?.Invoke();
        }    
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<IHarvestable>() != null)
        {
            OnLoseHarvestableObject?.Invoke();
        }
    }

}
