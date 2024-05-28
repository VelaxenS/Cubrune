using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private float _smoothing;
    private Vector3 _offset;



    private void Start()
    {
        _offset = transform.position - _player.transform.position;
    }
    private void LateUpdate()
    {
        if (_player != null)
        {
            Vector3 targetCamPos = _player.transform.position + _offset;
            transform.position = Vector3.Lerp(transform.position, targetCamPos, _smoothing * Time.deltaTime); 
        }
    }
}
