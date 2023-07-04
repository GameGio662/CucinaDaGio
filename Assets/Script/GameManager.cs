using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 2;
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            Time.timeScale = 7;
        else
            Time.timeScale = 2;
    }
}
