using System.Collections;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    public Enemy enemy;
    protected override void Awake()
    {
        base.Awake();
    }
    public float baseHealth;
    public float baseAttackPower;
    private void Start()
    {
        baseHealth = enemy.Health;
        baseAttackPower = enemy.AttackPower;
    }
}
