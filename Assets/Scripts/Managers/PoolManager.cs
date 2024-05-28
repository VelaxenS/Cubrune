using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : Singleton<PoolManager>
{
    [System.Serializable]
    public class ObjectPoolItem
    {
        public GameObject prefab;
        public int poolSize;
    }

    public List<ObjectPoolItem> objectPoolItems;
    private Dictionary<GameObject, List<GameObject>> objectPools = new Dictionary<GameObject, List<GameObject>>();
    protected override void Awake()
    {
        base.Awake();
        InitializePools();
    }

    private void InitializePools()
    {
        foreach (ObjectPoolItem item in objectPoolItems)
        {
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i < item.poolSize; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                objectPool.Add(obj);
            }
            objectPools.Add(item.prefab, objectPool);
        }
    }

    public GameObject GetObject(GameObject prefab)
    {
        if(objectPools.ContainsKey(prefab))
        {
            foreach(GameObject obj in objectPools[prefab])
            {
                if(!obj.activeInHierarchy)
                {
                    obj.SetActive(true);
                    return obj;
                }
            }
        }
        return null;
    }
    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
    }
}
