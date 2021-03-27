using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyShipButton : MonoBehaviour
{
    public float cost;
    public int ship;

    public void Buy()
    {
        if (cost <= FindObjectOfType<Ship>().money)
        {
            FindObjectOfType<Ship>().ship = ship;
            FindObjectOfType<Ship>().modules = new List<string>();
            FindObjectOfType<Ship>().dopfireRate = 0;
            FindObjectOfType<Ship>().dopMaxCargo = 0;
            FindObjectOfType<Ship>().dopMaxHp = 0;
            FindObjectOfType<Ship>().dopSpeed = 0;
            FindObjectOfType<Ship>().money -= cost;
        }
    }
}
