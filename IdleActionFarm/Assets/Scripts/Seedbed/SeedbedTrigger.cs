using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class SeedbedTrigger : MonoBehaviour
{

    public Action OnDetectTool;

    private void OnTriggerEnter(Collider collider)
    {
        HarvestTool toolComponent;
        
        if (collider.TryGetComponent<HarvestTool>(out toolComponent))
        {
            OnDetectTool?.Invoke();
        }
    }

}
