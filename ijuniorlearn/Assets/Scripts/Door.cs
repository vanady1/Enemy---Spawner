using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Alarm))]
public class Door : MonoBehaviour
{
    [SerializeField] private Alarm _alarm;

    void Start()
    {
        _alarm = GetComponent<Alarm>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _alarm.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _alarm.Stop();
        }
    }
}
