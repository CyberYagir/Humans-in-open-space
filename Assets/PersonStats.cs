using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonStats : MonoBehaviour
{
    public string _name;
    public string type;
    public string desc;
    Transform player;
    SpriteRenderer spriteRenderer;
    private void Start()
    {

        player = FindObjectOfType<PlayerMoveBase>().transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void Update()
    {
        spriteRenderer.flipX = player.transform.position.x < transform.position.x;
       
    }
}
