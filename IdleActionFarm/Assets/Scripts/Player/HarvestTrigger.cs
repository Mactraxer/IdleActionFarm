using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class HarvestTrigger : MonoBehaviour
{

    public Action<IHarvestable> OnDetectHarvestableObject;
    public Action OnLoseHarvestableObject;

    private void OnTriggerStay(Collider other)
    {
        IHarvestable harvestableComponent;
        if (other.TryGetComponent(out harvestableComponent))
        {
            OnDetectHarvestableObject?.Invoke(harvestableComponent);
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
