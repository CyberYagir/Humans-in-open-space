using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesShop : MonoBehaviour
{

    public TMP_Text armor, cargo, firerate, speed;
    public TMP_Text barmor, bcargo, bfirerate, bspeed;
    public TMP_Text stats;
    public Ship ship;
    public float armorcost, cargocost, firecost, speedcost;

    public Transform holderModule, itemModule;
    public Image shipimg;
    public Sprite[] sprites;
    private void Start()
    {
        ship = FindObjectOfType<Ship>();

        shipimg.sprite = ship.pShips[ship.ship].sprite;
        barmor.text = "Buy " + armorcost;
        bcargo.text = "Buy " + cargocost;
        bfirerate.text = "Buy " + firecost;
        bspeed.text = "Buy " + speedcost;
        var p = ship.pShips[ship.ship];
        stats.text = $"Name: {p.shipName}       " + "\n" +
                $"Turrets count: {p.cannons.Count}  " + "\n" +
                $"Max HP: {p.maxHp}        " + "\n" +
                $"Cargo: {p.maxCargo}         " + "\n" +
                $"Speed: {p.speed}         " + "\n" +
                $"Fire Rate: {p.fireRate}     " + "\n" +
                $"Damage: {p.fireRate}          " + "\n" +
                $"Power con.: {p.energySub}      " + "\n"+
                $"Modules: {ship.modules.Count}/{ship.maxModules}      " + "\n"+
                $"Money: {ship.money.ToString("F3")}     " + "\n";
        Refresh();
    }

    public void Refresh()
    {
        foreach (Transform item in holderModule)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < ship.modules.Count; i++)
        {
            Instantiate(itemModule.gameObject, holderModule).GetComponent<Image>().sprite = (ship.modules[i] == "Armor Plate" ? sprites[0] : (ship.modules[i] == "Cargo" ? sprites[1] : (ship.modules[i] == "FireRate" ? sprites[2] : sprites[3])));
        }
    }
    private void Update()
    {
        armor.text = "+" + ship.dopMaxHp;
        cargo.text = "+" + ship.dopMaxCargo;
        firerate.text = "-" + ship.dopfireRate;
        speed.text = "+" + ship.dopSpeed;
        var p = ship.pShips[ship.ship];
        stats.text = $"Name: {p.shipName}       " + "\n" +
                $"Turrets count: {p.cannons.Count}  " + "\n" +
                $"Max HP: {p.maxHp}        " + "\n" +
                $"Cargo: {p.maxCargo}         " + "\n" +
                $"Speed: {p.speed}         " + "\n" +
                $"Fire Rate: {p.fireRate}     " + "\n" +
                $"Damage: {p.fireRate}          " + "\n" +
                $"Power con.: {p.energySub}      " + "\n" +
                $"Modules: {ship.modules.Count}/{ship.maxModules}      " + "\n" +
                $"Money: {ship.money.ToString("F3")}     " + "\n";
    }

    public void AddArmor()
    {
        if (ship.modules.Count < ship.maxModules)
        {
            if (ship.money >= armorcost)
            {
                ship.dopMaxHp += 5;
                ship.money -= armorcost;
                ship.modules.Add("Armor Plate");
            }
        }
        Refresh();
    }

    public void AddCargo()
    {
        if (ship.modules.Count < ship.maxModules)
        {
            if (ship.money >= cargocost)
            {
                ship.dopMaxCargo += 10;
                ship.money -= cargocost;
                ship.modules.Add("Cargo");
            }
        }
        Refresh();
    }

    public void AddFireRate()
    {
        if (ship.modules.Count < ship.maxModules)
        {
            if (ship.money >= firecost)
            {
                ship.dopfireRate += 0.02f;
                ship.money -= firecost;
                ship.modules.Add("FireRate");
            }
        }
        Refresh();
    }

    public void AddSpeed()
    {
        if (ship.modules.Count < ship.maxModules)
        {
            if (ship.money >= speedcost)
            {
                ship.dopSpeed += 20f;
                ship.money -= speedcost;
                ship.modules.Add("Speed");
            }
        }
        Refresh();
    }
}
