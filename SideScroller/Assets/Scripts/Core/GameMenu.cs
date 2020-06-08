using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    //public Button btn_Resume;
    //public Button btn_MainMenu;
    //public Button btn_Quit;
    private bool _GameMenuDisplayed = false;
    [SerializeField]
    private GameObject _SkillsGameObject;

    private void Start()
    {
        this.gameObject.SetActive(false);
    }

    public void ProcessGameMenu()
    {
        if (_GameMenuDisplayed)
        {
            Resume();
        } else
        {
            Time.timeScale = 0;
            _GameMenuDisplayed = true;
            this.gameObject.SetActive(_GameMenuDisplayed);
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        _GameMenuDisplayed = false;
        this.gameObject.SetActive(_GameMenuDisplayed);
    }

    public void Skills()
    {
        _SkillsGameObject.SetActive(true);
        _GameMenuDisplayed = false;
        this.gameObject.SetActive(_GameMenuDisplayed);
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
