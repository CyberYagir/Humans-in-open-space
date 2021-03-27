using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMOve : MonoBehaviour
{
    public float rotSpeed, speed;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.deltaTime != 0)
        {
            if (!Input.GetKey(KeyCode.Space))
            {
                Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                transform.up = Vector3.Lerp((mouseWorldPosition - (Vector2)transform.position).normalized, transform.up, rotSpeed * Time.deltaTime);
            }
            rb.AddRelativeForce(Vector2.up * speed * Time.deltaTime);
        }
    }
}
