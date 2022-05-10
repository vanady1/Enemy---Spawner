using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _currentHealth;
    [SerializeField] private int _healthChangeValue;

    public event UnityAction HealthChanged;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _minHealth;
    public int CurrentHealth => _currentHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            ChangeHealthValue(-_healthChangeValue);
        }
        else if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            ChangeHealthValue(_healthChangeValue);
        }
    }

    private void ChangeHealthValue(int amount)
    {
        int healthChange = _currentHealth;
        _currentHealth = Mathf.Clamp(_currentHealth += amount, _minHealth, _maxHealth);

        if (_currentHealth != healthChange)
        {
            HealthChanged?.Invoke();
        }
    }
}
