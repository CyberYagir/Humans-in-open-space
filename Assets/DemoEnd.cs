using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoEnd : MonoBehaviour
{
    public float t = 0;
    public int lvl = 1;
    private void Start()
    {
        PlayerPrefs.DeleteAll();
        if (FindObjectOfType<Ship>() != null)
        {
            Destroy(FindObjectOfType<Ship>().gameObject);
        }
    }
    void Update()
    {
        t += 1 * Time.deltaTime;

        if (t > 4)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
            {
                Application.LoadLevel(lvl);
            }
        }
    }
}
