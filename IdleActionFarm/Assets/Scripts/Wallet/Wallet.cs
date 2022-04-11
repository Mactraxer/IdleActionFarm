using UnityEngine;
using System;

public class Wallet : MonoBehaviour
{
    private int _balance;

    void Start()
    {
        _balance = 0;    
    }

    /// API
    public void TopUpWallet(int value)
    {
        if (value < 1)
        {
            throw new InvalidOperationException("Value is not negative or zero for pay balance");
        }
        else
        {
            _balance += value;
        }
    }

    public int Balance => _balance;

    public int WithDrawFromWallet(int value)
    {
        if (value > _balance)
        {
            throw new InvalidOperationException("There are not enough funds for the withdraw");
        }
        else
        {
            _balance -= value;
            return value;
        }
    }

}
