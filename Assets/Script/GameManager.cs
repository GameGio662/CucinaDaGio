using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   
    void Start()
    {
        Time.timeScale = 1;
    }

   
    void Update()
    {
        if (Input.GetKey(KeyCode.T))
            Time.timeScale = 3;
        else
            Time.timeScale = 1;
    }
}
