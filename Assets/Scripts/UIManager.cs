using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private TextMeshProUGUI percentageText;
    [SerializeField] private GameObject gameLostPanel;
    [SerializeField] private GameObject gameWonPanel;

    //Making this a singleton so we can reach it easily
    private void Awake()
    {
        Instance = this;
    }
    
    //Updating our wall percentage text according to rate
    public void UpdatePercentageText(int rate)
    {
        percentageText.text = "Wall Percentage : " + rate;
    }
    
    //Making it active/deactive depending on game phase
    public void SetPercentageTextActive(bool active)
    {
        percentageText.gameObject.SetActive(active);
    }

    public void GameWonSequence()
    {
        gameWonPanel.SetActive(true);
    }
    public void GameLostSequence()
    {
        gameLostPanel.SetActive(true);
    }

    public void RestartButton()
    {
        //Restart button?
    }
}
