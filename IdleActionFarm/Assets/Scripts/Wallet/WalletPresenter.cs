using UnityEngine;

public class WalletPresenter : MonoBehaviour
{

    [SerializeField] private Wallet _wallet;
    [SerializeField] private WalletView _walletView;
    
    public void TopUpWallet(int value)
    {
        _wallet.TopUpWallet(value);
        _walletView.UpdateView(_wallet.Balance);
    }

}
