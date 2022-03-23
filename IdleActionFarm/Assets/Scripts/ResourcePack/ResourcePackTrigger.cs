using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class ResourcePackTrigger : MonoBehaviour
{
    public Action<ResourcePackData> OnDetectResource;

    private void OnTriggerEnter(Collider other)
    {
        ResourcePackData resourceComponent;
                
        if (other.TryGetComponent(out resourceComponent))
        {
            OnDetectResource?.Invoke(resourceComponent);
        }
    }

}
