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

    void Start()
    {
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Resume();
        }
    }

    public void Resume()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
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
