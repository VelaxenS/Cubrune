using System;
using System.Collections;
using UnityEngine;

public class Enemy : Character
{
    private Player _target;
    public override float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
        }
    }
    private void Start()
    {
        _target = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        _health = EnemyManager.Instance.baseHealth;
        _attackPower = EnemyManager.Instance.baseAttackPower;
    }
    public override void Attack(Character target)
    {
        target.TakeHit(AttackPower);
    }

    public override void TakeHit(float damage)
    {
        Health -= damage;
        StartCoroutine(TakeHitColorChange(0.1f));
        if(Health <= 0)
        {
            Die();
        }
    }
    public override void Die()
    {
        //TODO: Add logic
        _target.Money += 1;
        UiManager.Instance.bodyCount += 1;
        if(UiManager.Instance.bodyCount % 10 == 0)
        {
            Evolve();
        }
        Destroy(gameObject);
    }

    private void Evolve()
    {
        EnemyManager.Instance.baseHealth = EnemyManager.Instance.baseHealth + ((EnemyManager.Instance.baseHealth * 20) / 100);
        EnemyManager.Instance.baseAttackPower = EnemyManager.Instance.baseAttackPower + ((EnemyManager.Instance.baseAttackPower * 20) / 100);
    }

    private IEnumerator TakeHitColorChange(float duration)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.white, Color.red, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            GetComponentInChildren<SpriteRenderer>().color = Color.Lerp(Color.red, Color.white, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
