using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Bank : MonoBehaviour
{
    [SerializeField] private int startingBalance = 250;
    
    [SerializeField] private int currentBalance = 250;
    public int CurrentBalance { get { return currentBalance; } }

    [SerializeField] private TextMeshProUGUI displayBalance;
    
    private void Awake()
    {
        currentBalance = startingBalance;
        UpdateDisplayBalance();
    }

    public void Deposit(int amount)
    {
        currentBalance += Mathf.Abs(amount);
        UpdateDisplayBalance();
    }
    
    public void Withdraw(int amount)
    {
        currentBalance -= Mathf.Abs(amount);
        UpdateDisplayBalance();
        
        if (currentBalance < 0)
        {
            ReloadScene();
        }
    }

    private void ReloadScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }

    private void UpdateDisplayBalance()
    {
        displayBalance.text = $"Gold: {currentBalance}";
    }
    
}
