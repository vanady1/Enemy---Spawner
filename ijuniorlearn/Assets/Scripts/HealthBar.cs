using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _valueChangingTime;
    [SerializeField] private PlayerHealth _playerHealth;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = _playerHealth.MaxHealth;
        _slider.value = _playerHealth.CurrentHealth;
    }

    public void ChangeValue()
    {
        _slider.DOValue(_playerHealth.CurrentHealth, _valueChangingTime).SetEase(Ease.Linear);
    }
}
