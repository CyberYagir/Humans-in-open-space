using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (FindObjectOfType<Music>() != null)
        {
            if (FindObjectOfType<Music>() != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
