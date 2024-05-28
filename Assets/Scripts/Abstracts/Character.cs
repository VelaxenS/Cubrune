using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.TextCore.LowLevel;

public abstract class Character : MonoBehaviour
{
    [SerializeField] protected float _health;
    [SerializeField] protected float _attackPower;
    [SerializeField] protected float _attackDelay;
    [SerializeField] protected float _moveSpeedNormal;
    public abstract float Health { get; set; }
    public float AttackPower
    {
        get
        {
            return _attackPower;
        }
        set
        {
            _attackPower = value;
        }
    }
    public float MoveSpeedNormal
    {
        get
        {
            return _moveSpeedNormal;
        }
        set
        {
            _moveSpeedNormal = value;
        }
    }
    public float AttackDelay
    {
        get
        {
            return _attackDelay;
        }
        set
        {
            _attackDelay = value;
        }
    }

    public abstract void Attack(Character target);
    public abstract void TakeHit(float damage);
    public abstract void Die();
}
