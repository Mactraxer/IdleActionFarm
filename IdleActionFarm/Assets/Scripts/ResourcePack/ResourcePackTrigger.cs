using UnityEngine;
using System;

[RequireComponent(typeof(Collider))]
public class ResourcePackTrigger : MonoBehaviour
{
    public Action<IResourceable> OnDetectResource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IResourceable resource) == false) return;

        OnDetectResource?.Invoke(resource);
    }

}
