using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour
{
    [TextArea]
    public string text;
    public TMP_Text textHolder;
    public float speed;
    public float t;
    public int i;
    public GameObject next;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource.Play();
    }
    private void Update()
    {
        t += 1 * Time.deltaTime;
        if (t > speed)
        {
            if (textHolder.text != text)
            {
                textHolder.text += text[i];
            }
            else
            {
                audioSource.Stop();
            }
            if (i < text.Length)
            {
                i++;
            }
            t = 0;
        }
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (textHolder.text == text)
            {
                next.SetActive(true);
                this.gameObject.SetActive(false);
            }
            if (i != text.Length)
            {
                textHolder.text = text;
                i = text.Length;
            }
        }
    }
}
