using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventario : MonoBehaviour
{
    #region Instanza
    public static Inventario current;

    public void Awake()
    {
        if (current == null)
        {
            current = this;
        }
        else
        {
            Destroy(this);
        }
    }
    #endregion

    [Header("Caviale Dei Poveri")]
    public int salsaPesce;
    public int peperoncino;
    public int sale;
    [Header("Morzeddhu")]
    public int nduja;
    public int vitello;
    public int pitta;
    [Header("Pitta 'nchiusa")]
    public int fruttaSecca;
    public int miele;
    public int cannella;
}
