using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIPanelGame : MonoBehaviour,IMenu
{
    public Text LevelConditionView;

    [SerializeField] private Button btnPause;

    [SerializeField] private Button btnRestart;
    
    private UIMainManager m_uiMngr;
    
    private GameManager m_gameMngr;

    private void Awake()
    {
        btnPause.onClick.AddListener(OnClickPause);
        
        btnRestart.onClick.AddListener(OnClickRestart);
    }

    private void OnClickPause()
    {
        m_uiMngr.ShowPauseMenu();
    }
    private void OnClickRestart()
    {
        m_gameMngr.RestartLevel();
    }
    

    public void Setup(UIMainManager uiMngr, GameManager gameMngr)
    {
        m_uiMngr   = uiMngr;
        m_gameMngr = gameMngr;
    }

    public void Show()
    {
        this.gameObject.SetActive(true);
    }

    public void Hide()
    {
        this.gameObject.SetActive(false);
    }
}
