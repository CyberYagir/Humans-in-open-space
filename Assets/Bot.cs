using UnityEngine;

public class Bot : MonoBehaviour
{
    public Transform player;
    public Transform[] points;
    public Transform bullet;
    public float cooldown;
    public float dmg, speed;
    float t;
    public bool agred;
    public Rigidbody2D rb;
    public ParticleSystem explode;
    private void Start()
    {
        t = cooldown;
    }
    void Update()
    {
        if (agred)
        {
            if (GetComponent<Hp>().hp <= 0)
            {
                explode.transform.parent = null;
                explode.Play();
                FindObjectOfType<Stats>().mobsKilled++;
                Destroy(gameObject);
            }
            t += 1 * Time.deltaTime;
            if (t >= cooldown)
            {
                for (int i = 0; i < points.Length; i++)
                {
                    var gm = Instantiate(bullet, points[i].position, transform.rotation);
                    gm.localEulerAngles = transform.localEulerAngles;
                    gm.gameObject.GetComponent<Bullet>().dmg = dmg;
                    gm.gameObject.GetComponent<Bullet>().dmgPlayer = true;
                }
                t = 0;
            }

            transform.up = Vector3.Lerp(((Vector2)player.position - (Vector2)transform.position).normalized, transform.up, 1 * Time.deltaTime);
            rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        if (collision.gameObject.tag == "Player")
        {
            player = collision.transform;
            agred = true;
        }
    }
}
