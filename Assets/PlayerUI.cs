using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Ship ship;
    public RectTransform energy;
    public RectTransform hp;
    public Transform cargoError;
    public Transform radiationError;

    [HideInInspector]
    public float t = 0;
    void Update()
    {
        if (cargoError.gameObject.active)
        {
            t += Time.deltaTime;
            if (t > 5)
            {
                cargoError.gameObject.active = false;
                t = 0;
            }
        }
        if (ship == null)
        {
            ship = FindObjectOfType<Ship>();
        }
        energy.sizeDelta = new Vector2(228, (ship.energy / ship.maxEnergy) * 228);
        hp.sizeDelta = new Vector2(228, (ship.hp / ship.maxHp) * 228);
        var g = FindObjectOfType<MeteorsGen>();
        if (transform.position.x > g.range || transform.position.y > g.range || transform.position.y < -g.range || transform.position.x < -g.range)
        {
            radiationError.gameObject.active = true;
            ship.hp -= ship.hpAdd * 8 * Time.deltaTime;
        }
        else
        {
            radiationError.gameObject.active = false;
        }
    }
}
