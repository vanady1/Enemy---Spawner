using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ThiefAlarm : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private AudioSource _alarmEffect;
    [SerializeField] private float _timePassed;

    private void Start()
    {
        _tilemap = gameObject.GetComponent<Tilemap>();
        _defaultColor = _tilemap.color;
        _alarmEffect = gameObject.GetComponent<AudioSource>();
        _alarmEffect.Stop();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = Color.red;
            _alarmEffect.Play();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = _defaultColor;
            _alarmEffect.Stop();
        }
    }
    private void Update()
    {
        if (_alarmEffect.isPlaying)
        {
            _timePassed += Time.deltaTime;

            _alarmEffect.volume = Mathf.Sin(_timePassed) * 0.5f + 0.5f;
        }
    }
}
