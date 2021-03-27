using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuyShip : MonoBehaviour
{
    public Transform holder;
    public Transform item;

    public BaseStats baseStats;

    public Image currShip;
    public TMP_Text stats;
    Ship ship;
    private void Start()
    {
        ship = FindObjectOfType<Ship>();
        baseStats = GetComponentInParent<BaseStats>();
        for (int i = 0; i < baseStats.availableShips.Length; i++)
        {
            var g = Instantiate(item, holder);
            print(g.GetChild(0).name);
            g.GetComponentInChildren<BuyShipButton>().cost = (baseStats.availableShipsCost[i] * (1 + baseStats.cost));
            g.GetComponentInChildren<BuyShipButton>().ship = baseStats.availableShips[i];

            g.GetChild(0).GetComponent<Image>().sprite = ship.pShips[baseStats.availableShips[i]].sprite;
            var p = ship.pShips[baseStats.availableShips[i]];
            g.GetChild(1).GetComponent<TMP_Text>().text = "" +
                $"Name: {p.shipName}       " + "\n" +
                $"Turrets count: {p.cannons.Count}  " + "\n" +
                $"Max HP: {p.maxHp}        " + "\n" +
                $"Cargo: {p.maxCargo}         " + "\n" +
                $"Speed: {p.speed}         " + "\n" +
                $"Fire Rate: {p.fireRate}     " + "\n" +
                $"Damage: {p.fireRate}          " + "\n" +
                $"Power con.: {p.energySub}      " + "\n"+
                $"Modules.: {p.maxModules}      " + "\n";
            g.GetChild(2).GetComponentInChildren<TMP_Text>().text = "Buy " + (baseStats.availableShipsCost[i] * (1 + baseStats.cost)) .ToString("F6");
        }
    }
    private void Update()
    {
        currShip.sprite = ship.pShips[ship.ship].sprite;
        stats.text = "Money: " + ship.money.ToString("F6") + "\nModules in ship: " + ship.modules.Count + "/" + ship.maxModules;
    }

}
