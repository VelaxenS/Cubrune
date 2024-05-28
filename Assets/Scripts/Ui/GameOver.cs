using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI killCount;

    private void OnEnable()
    {
        SetEndGameKillCount();
    }

    public void SetEndGameKillCount()
    {
        killCount.text = UiManager.Instance.bodyCount.ToString();
    }

    public void PlayAgain()
    {
        GameManager.Instance.isPaused = false;
        LevelManager.Instance.LoadScene("Game");
    }
}
