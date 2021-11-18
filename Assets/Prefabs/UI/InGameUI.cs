using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InGameUI : MonoBehaviour
{
    [SerializeField] private GameObject InGamePanel;
    [SerializeField] private GameObject PausePanel;
    [SerializeField] private Image PlayerHealthBar;

    public void SwitchToPausePanel()
    {
        InGamePanel.SetActive(false);
        PausePanel.SetActive(true);
    }

    public void SwitchToInGamePanel()
    {
        InGamePanel.SetActive(true);
        PausePanel.SetActive(false);
    }

    public void SetPlayerHealth(int newValue, int oldValue, int MaxValue)
    {
        PlayerHealthBar.material.SetFloat("_Progress",(float)newValue/(float)MaxValue);
    }
}
