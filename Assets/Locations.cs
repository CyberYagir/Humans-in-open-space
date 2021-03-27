using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locations : MonoBehaviour
{
    public List<GameObject> locations;

    public int currloc;
    public void Activate(int id)
    {
        print("Curr:" + currloc + " id:" + id); 
        for (int i = 0; i < locations.Count; i++)
        {
            locations[i].SetActive(i == id);
        }
        currloc = id;
    }

}
