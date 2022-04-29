using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _healthChangeValue;
    [SerializeField] private HealthBar _healthBar;
    

    private void Start()
    {
        _currentHealth = _maxHealth;
        _healthBar.SetValues(_maxHealth, _currentHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            ChangeHealthValue(-_healthChangeValue);
            _healthBar.ChangeValue(_currentHealth);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            ChangeHealthValue(_healthChangeValue);
            _healthBar.ChangeValue(_currentHealth);
        }
    }

    private void ChangeHealthValue(int amount)
    {
        if (_currentHealth >= 0 && _currentHealth <= _maxHealth)
        {
            _currentHealth += amount;

            if (_currentHealth < 0)
            {
                _currentHealth = 0;
            }
            else if(_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
