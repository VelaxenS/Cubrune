using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : Singleton<SpawnManager>
{
    public Camera MainCamera;
    public GameObject enemyObject;
    public float Offset = 1f;
    public float SpawnDelay = 1.5f;
    public float halfHeight;
    public float halfWidth;
    private Timer _timer;
    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        if(MainCamera == null)
        {
            MainCamera = Camera.main;
        }

        halfHeight = MainCamera.orthographicSize;
        halfWidth = halfHeight * MainCamera.aspect;
        _timer = new Timer(SpawnDelay);
        _timer.onTimerElapsed += SpawnEnemy;
    }
    private void Update()
    {
        if (GameManager.Instance.isPaused == false)
        {
            _timer.Update(); 
        }
    }

    private void SpawnEnemy()
    {
        Vector3 spawnPoint = GetSpawnPoint(GetRandomEdge());
        Instantiate(enemyObject, spawnPoint, Quaternion.identity);
    }
    private Vector3 GetSpawnPoint(CameraEdge edge)
    {
        Vector3 point = Vector3.zero;
        Vector3 cameraPosition = MainCamera.transform.position;
        switch(edge)
        {
            case CameraEdge.LEFT:
                point = new Vector3(cameraPosition.x - halfWidth - Offset, cameraPosition.y, 0);
                break;
            case CameraEdge.RIGHT:
                point = new Vector3(cameraPosition.x + halfWidth + Offset, cameraPosition.y, 0);
                break;
            case CameraEdge.TOP:
                point = new Vector3(cameraPosition.x, cameraPosition.y + halfHeight + Offset, 0);
                break;
            case CameraEdge.BOTTOM:
                point = new Vector3(cameraPosition.x, cameraPosition.y - halfHeight - Offset, 0);
                break;
        }
        return point;
    }

    public enum CameraEdge
    {
        LEFT,
        RIGHT,
        TOP,
        BOTTOM
    }
    public CameraEdge GetRandomEdge()
    {
        CameraEdge edge = (CameraEdge)UnityEngine.Random.Range(0, Enum.GetValues(typeof(CameraEdge)).Length);
        return edge;
    }

}
