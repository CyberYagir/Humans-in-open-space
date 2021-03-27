using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public Sprite[] big;
    public Sprite[] normal;
    public Sprite[] small;
    public GameObject drop;
    public Hp hp;
    public ParticleSystem ps;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Hp>().hp = Random.Range(100, 1000);
        transform.localScale = new Vector3(GetComponent<Hp>().hp / 100, GetComponent<Hp>().hp / 100, GetComponent<Hp>().hp / 100);
        gameObject.AddComponent<PolygonCollider2D>();
        if (GetComponent<Hp>().hp <= 1)
        {
            GetComponent<SpriteRenderer>().sprite = small[Random.Range(0, small.Length)];
        }else
        if (GetComponent<Hp>().hp >= 1 && GetComponent<Hp>().hp <= 7)
        {
            GetComponent<SpriteRenderer>().sprite = normal[Random.Range(0, normal.Length)];
        }
        else
        {
            GetComponent<SpriteRenderer>().sprite = big[Random.Range(0, big.Length)];
        }

        GetComponent<Hp>().hp = GetComponent<Hp>().hp / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp.hp <= 0)
        {
            for (int i = 0; i < Random.Range(1,4); i++)
            {
                Instantiate(drop, transform.position, Quaternion.identity);
            }
            FindObjectOfType<Stats>().meteordDestroyed++;
            ps.transform.parent = null;
            ps.Play();
            Destroy(gameObject);
        }
    }
}
