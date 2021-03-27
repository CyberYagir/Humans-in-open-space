using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveBase : MonoBehaviour
{
    public float speed;
    public SpriteRenderer spriteRenderer;
    public Animator animator;
    public Rigidbody2D rigidbody2D;
    void Update()
    {
        if (rigidbody2D.velocity.magnitude > 0.1f)
        {
            animator.Play("Move");
        }
        else
        {
            animator.Play("Idle");
        }
        if (Input.GetKey(KeyCode.Mouse0))
        {

            rigidbody2D.AddForce((Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position).normalized * speed * Time.deltaTime);

            spriteRenderer.flipX = Camera.main.ScreenToWorldPoint(Input.mousePosition).x < transform.position.x;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            FindObjectOfType<QuestUI>().canvasQuest.SetActive(!FindObjectOfType<QuestUI>().canvasQuest.active);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            FindObjectOfType<QuestUI>().canvasQuest.SetActive(false);
        }
    }
}
