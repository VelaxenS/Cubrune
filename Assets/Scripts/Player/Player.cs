using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    public int Money
    {
        get
        {
            return _money;
        }
        set
        {
            _money = value;
            UiManager.Instance.money = value;
            onPlayerStatChanged?.Invoke();
        }
    }
    public override float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            UiManager.Instance.health = (int)value;
            onPlayerStatChanged?.Invoke();
        }
    }
    public Upgrade HealthUpgradeLevel
    {
        get
        {
            return _healthUpgradeLevel;
        }
        set
        {
            _healthUpgradeLevel = value;
        }
    }
    public Upgrade AttackUpgradeLevel
    {
        get
        {
            return _attackUpgradeLevel;
        }
        set
        {
            _attackUpgradeLevel = value;
        }
    }
    public event Action onPlayerStatChanged;

    [SerializeField] private int _money;
    [SerializeField] private Upgrade _healthUpgradeLevel;
    [SerializeField] private Upgrade _attackUpgradeLevel;

    private void Start()
    {
        UiManager.Instance.health = (int)Health;
        UiManager.Instance.money = (int)Money;
    }
    public override void Attack(Character target)
    {
        target.TakeHit(AttackPower);
    }
    public override void TakeHit(float damage)
    {
        Health -= damage;
        if (Health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        //TODO: Add logic
        UiManager.Instance.GameOverPanel();
        GameManager.Instance.isPaused = true;
        Destroy(gameObject);
    }
    public void ApplyUpgrade(Upgrade upgrade)
    {
        switch (upgrade.type)
        {
            case UpgradeType.HEALTH:
                Health += upgrade.value;
                break;
            case UpgradeType.ATTACK:
                AttackPower += upgrade.value;
                break;
        }
    }
}
