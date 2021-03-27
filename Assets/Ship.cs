using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public float energy, maxEnergy, energyAdd;
    public float hp, maxHp, hpAdd;

    public int copper, iron, diamond, rock;
    public int maxCargo;

    public float money;
    public List<Item> items;

    public string userName = "";
    public int ship = 0;


    public int dopMaxHp, dopMaxCargo, maxModules;
    public float dopfireRate, dopSpeed;

    public List<string> modules;
    public List<ShipManager.PShip> pShips;

    private void Start()
    {
        pShips = FindObjectOfType<ShipManager>().pShips;
        Cursor.visible = true;
        DontDestroyOnLoad(gameObject);   
    }
    private void Update()
    {
        if (hp <= 0)
        {
            Application.LoadLevel("Death");
        }
        var p = FindObjectsOfType<Ship>();
        for (int i = 0; i < p.Length; i++)
        {
            if (p[i] != this)
            {
                Destroy(p[i].gameObject);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if (FindObjectOfType<PlayerMOve>() != null)
            {
                FindObjectOfType<PlayerMOve>().enabled = !FindObjectOfType<PlayerMOve>().enabled;
                GameObject.FindGameObjectWithTag("OnOff").GetComponent<AudioSource>().Play();
            }
        }
        energy += energyAdd * Time.deltaTime;
        if (energy > maxEnergy)
        {
            energy = maxEnergy;
        }
        if (energy < 0)
        {
            energy = 0;
        }

        hp += hpAdd * Time.deltaTime;
        if (hp > maxHp)
        {
            hp = maxHp;
        }
        if (hp < 0)
        {
            hp = 0;
        }
    }
    [System.Serializable]
    public class Item {
        public string name;
        [System.NonSerialized]
        public Sprite sprite;
        public int count;
    }

}
