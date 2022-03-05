using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;


public class ThiefAlarm : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private Color _defaultColor;
    [SerializeField] private AudioSource _alarmEffect;
    [SerializeField] private float _soundChangingDuration;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;

    private void Start()
    {
        _tilemap = gameObject.GetComponent<Tilemap>();
        _defaultColor = _tilemap.color;
        _alarmEffect = gameObject.GetComponent<AudioSource>();
        _alarmEffect.Stop();
        _alarmEffect.volume = _minVolume;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = Color.red;
            _alarmEffect.Play();
            StopAllCoroutines();
            StartCoroutine(IncreaseVolume());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = _defaultColor;
            StopAllCoroutines();
            StartCoroutine(DecreaseVolume());
        }
    }
    private IEnumerator IncreaseVolume()
    {
        while (_alarmEffect.volume < 1)
        {
            _alarmEffect.volume += Time.deltaTime / _soundChangingDuration;

            yield return new WaitForSeconds(0.01f);
        }
    }
    private IEnumerator DecreaseVolume()
    {
        while (_alarmEffect.volume > 0)
        {
            
            _alarmEffect.volume -= Time.deltaTime / _soundChangingDuration;

            yield return new WaitForSeconds(0.01f);
        }
        _alarmEffect.Stop();
    }
}
