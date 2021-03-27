using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipManager : MonoBehaviour
{

    public Ship ship;
    public List<PShip> pShips = new List<PShip>();
    [System.Serializable]
    public class PShip {
        public string shipName;
        public GameObject shipTransform;
        public List<Transform> cannons;
        public int hp, maxHp, maxCargo, maxModules;
        public float speed, fireRate, dmg, energySub;

        public Sprite sprite;
    }

    private void Start()
    {
        Active();
    }
    public void Active()
    {
        ship = FindObjectOfType<Ship>();

        if (ship == null) ship = FindObjectOfType<Ship>();

        for (int i = 0; i < pShips.Count; i++)
        {
            pShips[i].shipTransform.SetActive(i == ship.ship);
            if (i == ship.ship)
            {
                ship.maxHp = pShips[i].maxHp + ship.dopMaxHp;
                ship.maxCargo = pShips[i].maxCargo + ship.dopMaxCargo;
                ship.maxModules = pShips[i].maxModules;
                GetComponent<PolygonCollider2D>().points = pShips[i].shipTransform.GetComponent<PolygonCollider2D>().points;
                FindObjectOfType<PlayerMOve>().speed = pShips[i].speed + ship.dopSpeed;
                FindObjectOfType<Attack>().cooldown = pShips[i].fireRate - ship.dopfireRate;
                FindObjectOfType<Attack>().dmg = pShips[i].dmg;
                FindObjectOfType<Attack>().energySub = pShips[i].energySub;
                FindObjectOfType<Attack>().points = pShips[i].cannons.ToArray();
                break;
            }
        }
    }
    private void Update()
    {
    }
}
