using UnityEngine;
using UnityEngine.UI;

public class PlayerWalletView : MonoBehaviour
{
    [SerializeField] private Text _goldValue;

    public void UpdateGold(int value)
    {
        _goldValue.text = $"{value}";
    }

}
