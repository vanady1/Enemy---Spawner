using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaypointMovement : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;

    private void Start()
    {
        Vector3[] pathPoints = new Vector3[_waypoints.Length];

        for (int i = 0; i < _waypoints.Length; i++)
        {
            pathPoints[i] = _waypoints[i].position;
        }

        Tween tween = transform.DOPath(pathPoints, 5, PathType.CatmullRom).SetOptions(true);

        tween.SetEase(Ease.Linear).SetLoops(-1);
    }
}
