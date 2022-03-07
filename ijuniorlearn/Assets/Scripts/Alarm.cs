using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[RequireComponent(typeof(Tilemap))]
public class Alarm : MonoBehaviour
{
    [SerializeField] private Color _defaultColor;
    [SerializeField] private AudioSource _alarmEffect;
    [SerializeField] private float _soundChangingDuration;
    [SerializeField] private float _minVolume;
    [SerializeField] private float _maxVolume;
    
    private bool _isChangingVolume;
    private Tilemap _tilemap;
    
    private void Start()
    {
        _tilemap = gameObject.GetComponent<Tilemap>();
        _defaultColor = _tilemap.color;
        _alarmEffect = gameObject.GetComponent<AudioSource>();
        _alarmEffect.Stop();
        _alarmEffect.volume = _minVolume;
        _isChangingVolume = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = Color.red;
            _alarmEffect.Play();
            StopCoroutine(ChangeVolume(false));
            _isChangingVolume = false;
            StartCoroutine(ChangeVolume(true));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PhysicsMovement>(out PhysicsMovement thief))
        {
            _tilemap.color = _defaultColor;
            StopCoroutine(ChangeVolume(true));
            _isChangingVolume = false;
            StartCoroutine(ChangeVolume(false));
        }
    }

    private IEnumerator ChangeVolume(bool isIncrease)
    {
        if (_isChangingVolume == false)
        {
            _isChangingVolume = true;

            if (isIncrease)
            {
                while (_alarmEffect.volume < 1)
                {
                    _alarmEffect.volume += Time.deltaTime / _soundChangingDuration;

                    yield return new WaitForSeconds(0.01f);
                }
            }
            else
            {
                while (_alarmEffect.volume > 0)
                {

                    _alarmEffect.volume -= Time.deltaTime / _soundChangingDuration;

                    yield return new WaitForSeconds(0.01f);
                }                
            }
        }
    }
}
