using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemyTemplate;
    [SerializeField] private float _timeBetweenSpawns;
    private Transform _spawner;
    private Transform[] _spawningPoints;
    private int _currentPoint;

    private void Start()
    {
        _spawner = GetComponent<Transform>();
        _spawningPoints = new Transform[_spawner.childCount];

        for (int i = 0; i < _spawner.childCount; i++)
        {
            _spawningPoints[i] = _spawner.GetChild(i);
        }

        StartCoroutine(SpawnPeriodically(_timeBetweenSpawns));
    }

    private IEnumerator SpawnPeriodically(float timeAmount)
    {
        for (int i = 0; i < _spawningPoints.Length; i++)
        {
            Instantiate(_enemyTemplate, _spawningPoints[i]);
            yield return new WaitForSeconds(timeAmount);
        }
    }
}
