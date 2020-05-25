using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameMenu : MonoBehaviour
{
    public Button btn_Resume;
    public Button btn_MainMenu;
    public Button btn_Quit;

    void Start()
    {
        btn_Resume.onClick.AddListener(Resume);
        btn_MainMenu.onClick.AddListener(() => { Time.timeScale = 1; SceneManager.LoadScene("MainMenu", LoadSceneMode.Single); });
        btn_Quit.onClick.AddListener(() => { Application.Quit(); });
        this.gameObject.SetActive(false);
    }

    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            Resume();
        }
    }

    private void Resume()
    {
        Time.timeScale = 1;
        this.gameObject.SetActive(false);
    }
}
