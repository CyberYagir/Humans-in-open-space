using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{

    public Transform[] points;
    public float energySub;
    public Transform bullet;
    public float cooldown;
    public float dmg;
    float t;
    private void Start()
    {
        t = cooldown;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            t += 1 * Time.deltaTime;
            if (t >= cooldown)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    if (FindObjectOfType<Ship>().energy >= energySub)
                    {
                        var gm = Instantiate(bullet, points[i].position, transform.rotation);
                        gm.eulerAngles = points[i].eulerAngles;
                        gm.gameObject.GetComponent<Bullet>().dmg = dmg;
                        FindObjectOfType<Ship>().energy -= energySub;
                    }
                }
                t = 0;
            }
        }
    }
}
