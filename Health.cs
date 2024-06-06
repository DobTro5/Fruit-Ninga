using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Health : MonoBehaviour
{

    public int StartHealth = 3;

    public EndScreen EndScreen;

    private TextMeshProUGUI _healthText;

    private int _currentHealth;

    private void Start()
    {
        FillComponents();

        ResetHeals();
    }

    public void ResetHeals()
    {
        SetHealth(StartHealth);
    }

    private void FillComponents()
    {
        _healthText = GetComponentInChildren<TextMeshProUGUI>();

       
    }

    private void SetHealth(int value)
    {
        _currentHealth = value;

        SetHealthText();

       if (_currentHealth <= 0)
        {
            EndScreen.GameOver();
        }
    }

    private void SetHealthText()
    {
        _healthText.text = _currentHealth.ToString();
    }

    public void ChangeHealth(int value)
    {
        SetHealth(_currentHealth +  value);
    }
}
