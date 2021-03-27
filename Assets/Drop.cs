using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Drop : MonoBehaviour
{
    public Sprite[] sprites;
    public int id, count;

    private void Start()
    {
        count = Random.Range(6, 20);
        id = Random.Range(0, sprites.Length);
        GetComponent<SpriteRenderer>().sprite = sprites[id];
        GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-100, 100), Random.Range(-100, 100)));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            var s = FindObjectOfType<Ship>();

            if (s.iron + s.copper + s.diamond + s.rock + count <= s.maxCargo)
            {
                if (id == 0)
                {
                    FindObjectOfType<Ship>().copper += count;
                }
                if (id == 1)
                {
                    FindObjectOfType<Ship>().iron += count;
                }
                if (id == 2)
                {
                    FindObjectOfType<Ship>().diamond += count;
                }
                if (id == 3)
                {
                    FindObjectOfType<Ship>().rock += count;
                }

                Destroy(gameObject);
                GameObject.FindGameObjectWithTag("Collect").GetComponent<AudioSource>().Play();

                return;
            }
            else
            {
                FindObjectOfType<PlayerUI>().cargoError.gameObject.SetActive(true);
                FindObjectOfType<PlayerUI>().t = 0;
                FindObjectOfType<PlayerUI>().cargoError.gameObject.GetComponentInChildren<TMP_Text>().text = $"The ship cannot accommodate this amount of cargo. Buy a module. [{s.iron + s.copper + s.diamond + s.rock}+{count} > {s.maxCargo}]";
            }

            if (id == 4)
            {
                FindObjectOfType<Ship>().energy += Random.Range(10, 20);
                GameObject.FindGameObjectWithTag("Bonus").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
            if (id == 5)
            {
                FindObjectOfType<Ship>().hp += Random.Range(10, 20);
                GameObject.FindGameObjectWithTag("Bonus").GetComponent<AudioSource>().Play();
                Destroy(gameObject);
            }
        }
    }
}
