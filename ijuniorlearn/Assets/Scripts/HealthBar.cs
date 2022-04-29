using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    [SerializeField] private float _valueChangingTime;

    private Slider _slider;

    public void SetValues(int maxValue, int currentValue)
    {
        _slider = GetComponent<Slider>();
        _slider.maxValue = maxValue;
        _slider.value = currentValue;
    }

    public void ChangeValue(int targetValue)
    {
        _slider.DOValue(targetValue, _valueChangingTime).SetEase(Ease.Linear);
    }
}
