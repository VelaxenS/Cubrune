using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _panel;
    [SerializeField] private GameObject _attackButton;
    [SerializeField] private GameObject _healthButton;
    [SerializeField] private TextMeshProUGUI _healthCostText;
    [SerializeField] private TextMeshProUGUI _attackCostText;
    public void Pause()
    {
        _panel.SetActive(true);
        Time.timeScale = 0f;
        GameManager.Instance.isPaused = true;
    }
    public void Continue()
    {
        _panel.SetActive(false);
        Time.timeScale = 1f;
        GameManager.Instance.isPaused = false;
    }

    public void UpgradeAttackUi()
    {
        Upgrade upgrade = UpgradeManager.Instance.UpgradeAttack();
        if (upgrade != null)
        {
            _attackButton.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = upgrade.name;
            if (UpgradeManager.Instance.attackUpgrades.Count != 0)
            {
                _attackCostText.text = UpgradeManager.Instance.attackUpgrades[0].cost.ToString(); 
            }
            else
            {
                _attackCostText.text = "-";
            }
        }
    }
    public void UpgradeHealthUi()
    {
        Upgrade upgrade = UpgradeManager.Instance.UpgradeHealth();
        if (upgrade != null)
        {
            _healthButton.GetComponent<Button>().GetComponentInChildren<TextMeshProUGUI>().text = upgrade.name;
            if (UpgradeManager.Instance.healthUpgrades.Count != 0)
            {
                _healthCostText.text = UpgradeManager.Instance.healthUpgrades[0].cost.ToString(); 
            }
            else
            {
                _healthCostText.text = "-";
            }
        }
    }

    public void CheckUpgrades()
    {
        if(UpgradeManager.Instance.attackUpgrades.Count == 0)
        {
            _attackButton.GetComponent<Button>().interactable = false;
        }
        if (UpgradeManager.Instance.healthUpgrades.Count == 0)
        {
            _healthButton.GetComponent<Button>().interactable = false;
        }
    }
}
