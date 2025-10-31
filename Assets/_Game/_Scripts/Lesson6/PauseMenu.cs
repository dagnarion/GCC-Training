using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : Singleton<PauseMenu>
{
    public GameObject PausePanel;
    public bool IsGamePause { get; private set; }
    void OnEnable()
    {
        InputManager.Pause += Pause;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        IsGamePause = true;
        Time.timeScale = 0f;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        IsGamePause = false;
        Time.timeScale = 1f;
    }
    
    public void Exit()
    {
        Application.Quit();
    }
}