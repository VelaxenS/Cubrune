using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Timer 
{
    private float _elapsedTime;
    private float _interval;
    private bool _isRunning;
    public bool IsRunning => _isRunning;

    public Timer(float interval)
    {
        _interval = interval;
        _elapsedTime = 0f;
        _isRunning = true;
    }

    public void Update()
    {
        if (!_isRunning) return;

        _elapsedTime += Time.deltaTime;
        if(_elapsedTime >= _interval)
        {
            _elapsedTime = 0f;
            onTimerElapsed?.Invoke();
        }
    }
    public void Start()
    {
        _isRunning = true;
    }
    public void Stop()
    {
        _isRunning = false;
    }
    public void Reset()
    {
        _elapsedTime = 0f;
    }
    public event System.Action onTimerElapsed;
}
