using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    private bool _GameMenuDisplayed = false;
    private UIHandler mainUiHandler;

    private void Awake()
    {
        mainUiHandler = GetComponentInParent<UIHandler>();
    }

    public void Resume()
    {
        mainUiHandler.CloseGameMenu();
    }

    public void Items()
    {
        mainUiHandler.WakeInventory();
    }

    public void Skills()
    {
        mainUiHandler.WakeSkillTree();
    }

    public void MainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
