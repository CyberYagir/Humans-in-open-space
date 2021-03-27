using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerMOve>() == null)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                transform.GetChild(0).gameObject.active = !transform.GetChild(0).gameObject.active;
                if (transform.GetChild(0).gameObject.active)
                {
                    Time.timeScale = 0;
                }
                else
                {
                    Time.timeScale = 1;
                }
            }
        }
    }

    public void Go(int scene)
    {
        Application.LoadLevel(scene);
    }
    public void Exit()
    {
        Application.Quit();
    }

    public void Save()
    {
        FindObjectOfType<SaveLoad>().Save();
    }
    public void Load()
    {
        FindObjectOfType<SaveLoad>().Load();
    }
}
