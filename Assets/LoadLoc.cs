using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLoc : MonoBehaviour
{

    private void Update()
    {
        if (Application.loadedLevel == 1)
        {
            print("Level: " + PlayerPrefs.GetInt("Level"));
            FindObjectOfType<Locations>().Activate(PlayerPrefs.GetInt("Level", 0));
            FindObjectOfType<PlayerMOve>().transform.position =
                new Vector2(PlayerPrefs.GetFloat("X"), PlayerPrefs.GetFloat("Y"));


            PlayerPrefs.DeleteAll();

            Destroy(this);
        }
    }

}
