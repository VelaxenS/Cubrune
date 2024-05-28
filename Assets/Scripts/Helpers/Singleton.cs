using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T _instance;

    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("An instance of " + typeof(T) + " is needed in the scene, but there is none.");
            }

            return _instance;
        }
    }

    // if additional initialization logic in the T class wanted, override the Awake with 
    // new keyword hides the base implementation of the method. we shouldn't use it.
    protected virtual void Awake()
    {
        if (_instance == null)
        {
            _instance = (T)this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
