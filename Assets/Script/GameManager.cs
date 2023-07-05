using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 1;
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            Time.timeScale = 4;
        else
            Time.timeScale = 1;
    }

    public void StartGame()
    {
        SceneManager.LoadSceneAsync(1, LoadSceneMode.Single);
    }

    public void Return()
    {
        SceneManager.LoadSceneAsync(0, LoadSceneMode.Single);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
