using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Giorno : MonoBehaviour
{
    #region instaza
    public static Giorno current;
    public void Awake()
    {
        if (current == null)
            current = this;
        else
            Destroy(this);
    }
    #endregion

    [SerializeField] GameObject Sun;
    public float secondi;
    public float minuti;

    private void Update()
    {
        if (minuti < 20)
        {
            secondi += Time.deltaTime;
        }
        if (secondi >= 60)
        {
            secondi = 0;
            minuti++;
        }
        if (minuti >= 10 && minuti < 24)
        {
            secondi = 0;
            minuti += Time.deltaTime;
            Sun.SetActive(false);
        }
        else if (minuti >= 24)
        {
            minuti = 0;
            Sun.SetActive(true);
        }
    }
}
