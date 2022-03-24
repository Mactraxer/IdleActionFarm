using UnityEngine;
using System;

public class ShopTrigger : MonoBehaviour
{

    public Action<PlayerPresenter> OnDetectInventory;

    private void OnTriggerEnter(Collider other)
    {
        PlayerPresenter playerComponent;

        if (other.TryGetComponent(out playerComponent))
        {
            OnDetectInventory?.Invoke(playerComponent);
        }
    }

}
