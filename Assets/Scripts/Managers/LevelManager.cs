using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : Singleton<LevelManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
