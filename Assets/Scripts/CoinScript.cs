using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class CoinScript : MonoBehaviour
{

    public static CoinScript instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        // Grabs the coins and store it so it doesnt get destroyed
        GameManager.coinStore = PlayerPrefs.GetInt("StoringCoins", 0);
    }

    public TMP_Text coinText1;
    public TMP_Text coinText2;

    void Start()
    {
        PlayerPrefs.GetInt("StoringCoins", GameManager.coinStore);
        UpdateCoinUI();
    }

    public void AddCoins(int amount)
    {
        PlayerPrefs.SetInt("StoringCoins", GameManager.coinStore += amount);
        UpdateCoinUI();
        Debug.Log("Coins added: " + amount + " | Total coins: " + GameManager.coinStore);
    }

    public bool SpendCoins(int amount)
    {
        if (GameManager.coinStore >= amount)
        {
            PlayerPrefs.SetInt("StoringCoins", GameManager.coinStore -= amount);
            UpdateCoinUI();
            Debug.Log("Coins spent: " + amount + " | Remaining coins: " + GameManager.coinStore);
            return true;
        }
        else
        {
            Debug.Log("Not enough coins to spend: " + amount);
            return false; // Not enough coins
        }
    }

    public void Load()
    {
        PlayerPrefs.GetInt("StoringCoins", GameManager.coinStore);
    }

    // Method to update the UI display
    public void UpdateCoinUI()
    {
        if (coinText1 != null)
        {
            coinText1.text = " " + PlayerPrefs.GetInt("StoringCoins", GameManager.coinStore);
        }

        if (coinText2 != null)
        {
            coinText2.text = " " + PlayerPrefs.GetInt("StoringCoins", GameManager.coinStore);
        }
        else
        {
            Debug.LogError("CoinText is not assigned!");
        }
    }

}
