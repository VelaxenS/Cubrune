using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mainmenu : MonoBehaviour
{
    public void Play()
    {
        LevelManager.Instance.LoadScene("Game");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
