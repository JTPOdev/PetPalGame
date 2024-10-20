using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CoinScript : MonoBehaviour
{
    public int PlayerCoins = 0;
    public TMP_Text coinText1;
    public TMP_Text coinText2;

    void Start()
    {
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        PlayerCoins += amount;
        UpdateCoinUI();
        Debug.Log("Coins added: " + amount + " | Total coins: " + PlayerCoins);
    }

    public bool SpendCoins(int amount)
    {
        if (PlayerCoins >= amount)
        {
            PlayerCoins -= amount;
            UpdateCoinUI();
            Debug.Log("Coins spent: " + amount + " | Remaining coins: " + PlayerCoins);
            return true;
        }
        else
        {
            Debug.Log("Not enough coins to spend: " + amount);
            return false; // Not enough coins
        }
    }

    // Method to update the UI display
    private void UpdateCoinUI()
    {
        if (coinText1 != null)
        {
            coinText1.text = " " + PlayerCoins;
        }

        if (coinText2 != null)
        {
            coinText2.text = " " + PlayerCoins;
        }
        else
        {
            Debug.LogError("CoinText is not assigned!");
        }
    }
}
