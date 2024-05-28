using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private float hitRange;

    private GameObject _target;
    private Enemy _self;
    private Timer _attackTimer;

    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("player");
        _self = GetComponent<Enemy>();
        _attackTimer = new Timer(_self.AttackDelay);
        _attackTimer.onTimerElapsed += TryHit;
    }

    private void Update()
    {
        if (!GameManager.Instance.isPaused)
        {
            FollowTarget();
            _attackTimer.Update(); 
        }
    }
    private void FollowTarget()
    {
        if (_target != null)
        {
            float moveSpeed;
            Vector3 moveDirection = (_target.transform.position - transform.position).normalized;
            float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
            if (distanceToTarget >= SpawnManager.Instance.halfWidth)
            {
                moveSpeed = _target.GetComponent<PlayerMovement>().MoveSpeed;
            }
            else
            {
                moveSpeed = _self.MoveSpeedNormal;
            }
            GetComponent<CharacterController>().Move(moveSpeed * Time.deltaTime * moveDirection); 
        }
    }
    private void TryHit()
    {
        if (_target != null)
        {
            float distanceToTarget = Vector3.Distance(transform.position, _target.transform.position);
            if (distanceToTarget <= hitRange)
            {
                _self.Attack(_target.GetComponent<Player>());
            } 
        }
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag("player") && !collider.CompareTag("enemy"))
        {
            PoolManager.Instance.ReturnObject(collider.gameObject);
            _target.GetComponent<Player>().Attack(_self);
        }
    }
}
