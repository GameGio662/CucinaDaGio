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

    public int salsaPesce;
    public int peperoncino;
    public int sale;
    public int nduja;
    public int vitello;
    public int pitta;
    public int fruttaSecca;
    public int miele;
    public int cannella;
}
