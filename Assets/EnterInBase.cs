using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterInBase : MonoBehaviour
{
    public int type;
    public string baseName;
    public void Go()
    {
        PlayerPrefs.SetInt("Level", FindObjectOfType<Locations>().currloc);
        PlayerPrefs.SetInt("Base", type);
        PlayerPrefs.SetString("BaseName", baseName);
        List<string> strs = new List<string>();
        var p = FindObjectsOfType<EnterInBase>();
        for (int i = 0; i < p.Length; i++)
        {
            strs.Add(p[i].baseName);
        }
        PlayerPrefs.SetString("BaseNames", string.Join("|", strs.ToArray()));
        PlayerPrefs.SetFloat("X", FindObjectOfType<PlayerMOve>().transform.position.x);
        PlayerPrefs.SetFloat("Y", FindObjectOfType<PlayerMOve>().transform.position.y);

        Application.LoadLevel(2);
    }
}
