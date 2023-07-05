using System.Collections;
using System.Collections.Generic;
using TMPro;
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
    [SerializeField] TextMeshProUGUI MinutiText;
    [SerializeField] TextMeshProUGUI SecText;

    public float secondi;
    public float minuti;

    private void Update()
    {
        SecText.text = Mathf.RoundToInt(secondi).ToString("00");
        MinutiText.text = Mathf.RoundToInt(minuti).ToString("00");


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
            Sun.SetActive(false);
        }
        else if (minuti >= 24)
        {
            minuti = 0;
            Sun.SetActive(true);
        }
    }
}
