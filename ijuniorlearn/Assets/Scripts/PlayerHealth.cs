using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private int _maxHealth;
    [SerializeField] private int _minHealth;
    [SerializeField] private int _healthChangeValue;
    [SerializeField] private UnityEvent _healthChanged;

    public int _currentHealth;

    public int MaxHealth => _maxHealth;
    public int MinHealth => _maxHealth;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            ChangeHealthValue(-_healthChangeValue);
            _healthChanged?.Invoke();
        }
        else if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
            ChangeHealthValue(_healthChangeValue);
            _healthChanged?.Invoke();
        }
    }

    private void ChangeHealthValue(int amount)
    {
        if (_currentHealth >= _minHealth && _currentHealth <= _maxHealth)
        {
            _currentHealth += amount;

            if (_currentHealth < _minHealth)
            {
                _currentHealth = _minHealth;
            }
            else if(_currentHealth > _maxHealth)
            {
                _currentHealth = _maxHealth;
            }
        }
    }
}
