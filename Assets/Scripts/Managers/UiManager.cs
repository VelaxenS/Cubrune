using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UiManager : Singleton<UiManager>
{
    public int money;
    public int health;
    public int bodyCount = 0;
    public List<GameObject> panels;
    [SerializeField] private GameObject _inGamePanel;
    [SerializeField] private GameObject _inGameMenuPanel;
    [SerializeField] private GameObject _gameOverPanel;
    private Player _player;

    protected override void Awake()
    {
        base.Awake();
    }
    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("player").GetComponent<Player>();
        _player.onPlayerStatChanged += UpdateUi;
        UpdateHealth();
        UpdateMoney();
    }
    public void UpdateUi()
    {
        UpdateMoney();
        UpdateHealth();
    }
    private void UpdateMoney()
    {
        _inGamePanel.transform.GetChild(0).GetComponentInChildren<TextMeshProUGUI>().text = money.ToString();
    }
    private void UpdateHealth()
    {
        _inGamePanel.transform.GetChild(1).GetComponentInChildren<TextMeshProUGUI>().text = health.ToString();
    }
    public void GameOverPanel()
    {
        setActivePanel(_gameOverPanel);
    }
    private void setActivePanel(GameObject panel)
    {
        foreach(GameObject _panel in panels)
        {
            if(panel.name == _panel.name)
            {
                _panel.SetActive(true);
            }
            else
            {
                _panel.SetActive(false);
            }
        }
    }
}
