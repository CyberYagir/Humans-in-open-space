using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float dmg;
    public bool dmgPlayer;
    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.isTrigger) return;
        if (collision.transform.tag == "Base")
        {
            Destroy(gameObject);
            return;
        }
        if (!dmgPlayer)
        {
            if (collision.transform.tag == "Bot" || collision.transform.tag == "Meteor")
            {
                collision.GetComponent<Hp>().hp -= dmg;
                Destroy(gameObject);
                return;
            }
        }
        else
        {
            if (collision.transform.tag == "Player")
            {
                FindObjectOfType<Ship>().hp -= dmg;
                Destroy(gameObject);
                return;
            }
        }
    }
}
