using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenMenuByClick : MonoBehaviour
{
    public Texture2D pointer, std;
    public GameObject canvas;
    [Header("Чтобы для карты данные получить")]
    public GameObject other;

    bool over;

    bool triggered;
    private void Start()
    {
        Cursor.SetCursor(std, new Vector2(16, 16), CursorMode.Auto);
    }
    private void Update()
    {

        if (triggered)
        {
            if (FindObjectOfType<PlayerMoveBase>() != null)
            {
                if (canvas.active)
                {
                    FindObjectOfType<PlayerMoveBase>().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                }
                else
                {
                    FindObjectOfType<PlayerMoveBase>().enabled = true;
                }
            }
        }
        if (over)
        {
            if (triggered)
            {
                Cursor.SetCursor(pointer, new Vector2(16, 16), CursorMode.Auto);
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    if (FindObjectOfType<PlayerMoveBase>() != null)
                    {
                        FindObjectOfType<PlayerMoveBase>().GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                        FindObjectOfType<PlayerMoveBase>().enabled = false;
                    }
                    canvas.SetActive(true);
                }
            }
        }
    }
    private void OnMouseEnter()
    {
        over = true;
    }

    private void OnMouseExit()
    {
        over = false;
        Cursor.SetCursor(std, new Vector2(16, 16), CursorMode.Auto);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            print("Enter Trigger");
            triggered = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Cursor.SetCursor(std, new Vector2(16, 16), CursorMode.Auto);
            canvas.SetActive(false);
            triggered = false;
        }
    }
}
