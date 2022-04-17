using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] _spawningPoints;
    [SerializeField] private Coin _coin;

    private void Awake()
    {
        _spawningPoints = new Transform[gameObject.transform.childCount];

        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _spawningPoints[i] = gameObject.transform.GetChild(i);
        }
    }
    private void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for (int i = 0; i < _spawningPoints.Length; i++)
        {
            Instantiate(_coin, _spawningPoints[i]);
        }
    }
}
