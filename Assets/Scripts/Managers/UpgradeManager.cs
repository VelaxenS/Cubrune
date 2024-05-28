using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class UpgradeManager : Singleton<UpgradeManager>
{
    public List<Upgrade> availableUpgrades;
    public List<Upgrade> healthUpgrades;
    public List<Upgrade> attackUpgrades;
    private Player _player;
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        ClassifyUpgrades();
    }
    protected override void Awake()
    {
        base.Awake();
    }

    public void ClassifyUpgrades()
    {
        foreach (Upgrade upgrade in availableUpgrades)
        {
            if(upgrade.type == UpgradeType.HEALTH)
            {
                healthUpgrades.Add(upgrade);

            }
            else
            {
                attackUpgrades.Add(upgrade); 
            }
        }
    }

    public bool AttemptUpgrade(Upgrade upgrade)
    {
        if(_player.Money >= upgrade.cost && upgrade != null)
        {
            _player.Money -= upgrade.cost;
            _player.ApplyUpgrade(upgrade);
            Debug.Log($"Type: {upgrade.type} is applied to the player.");
            availableUpgrades.Remove(upgrade);
            return true;
        }
        else
        {
            Debug.Log($"Player does not have enough money for the upgrade, {upgrade.cost - _player.Money} more coin is needed.");
            return false;
        }
    }

    public Upgrade UpgradeHealth()
    {
        Upgrade upgrade = healthUpgrades[0];
        if (AttemptUpgrade(upgrade))
        {
            healthUpgrades.Remove(upgrade);
            _player.HealthUpgradeLevel = upgrade;
            return upgrade;
        }
        return null;
    }
    public Upgrade UpgradeAttack()
    {
        Upgrade upgrade = attackUpgrades[0];
        if (AttemptUpgrade(upgrade))
        {
            attackUpgrades.Remove(upgrade);
            _player.AttackUpgradeLevel = upgrade;
            return upgrade;
        }
        return null;
    }
}
