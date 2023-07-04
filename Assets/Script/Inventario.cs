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

    public int salsaPesce = 0;
    public int peperoncino = 5;
    public int sale = 5;
    public int nduja = 5;
    public int vitello = 5;
    public int pitta = 5;
}
