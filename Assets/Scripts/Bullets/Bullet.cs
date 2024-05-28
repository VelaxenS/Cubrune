using System.Collections;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(ReturnToPoolAfterTime());
    }
    private void OnDisable()
    {
        StopAllCoroutines(); 
    }
    public void Init(Vector2 dir,float attackSpeed)
    {
        TryGetComponent(out Rigidbody rb);
        if (rb != null)
        {
            rb.velocity = dir * attackSpeed;
        }
    }
    private IEnumerator ReturnToPoolAfterTime()
    {
        yield return new WaitForSeconds(2);
        PoolManager.Instance.ReturnObject(gameObject);
    }
}