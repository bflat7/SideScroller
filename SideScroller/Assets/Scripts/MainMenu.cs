using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button btn_Start;
    public Button btn_Exit;

    // Start is called before the first frame update
    void Start()
    {
        btn_Start.onClick.AddListener(() => { SceneManager.LoadScene("SampleScene", LoadSceneMode.Single); });
        btn_Exit.onClick.AddListener(() => { Application.Quit(); });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
