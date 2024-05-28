using System;
using UnityEngine;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform shootPoint;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private float _attackSpeed;
    private Camera mainCamera;
    private Vector3 mousePos;
    private void Start()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            Vector3 rotation = mousePos - transform.position;
            float rotZ = MathF.Atan2(rotation.y, rotation.x) * 57.3f;
            transform.rotation = Quaternion.Euler(0, 0, rotZ);
            if (Input.GetMouseButtonDown(0))
            {
                Fire();
            } 
        }
    }
    private void Fire()
    {
        GameObject bulletFromPool = PoolManager.Instance.GetObject(bulletPrefab);
        if (bulletFromPool != null)
        {
            bulletFromPool.transform.position = transform.position;
            bulletFromPool.transform.rotation = transform.rotation;
            bulletFromPool.GetComponent<Bullet>().Init(transform.right, _attackSpeed);
        }
    }
}
