using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BasesManager : MonoBehaviour
{
    public List<BaseStats> baseStats;
    public TMP_Text BaseName;
    public GameObject start;
    private void Start()
    {
        for (int i = 0; i < baseStats.Count; i++)
        {
            baseStats[i].gameObject.SetActive(false);
        }
        baseStats[PlayerPrefs.GetInt("Base", 0)].gameObject.SetActive(true);
        BaseName.text = "Base name: " + PlayerPrefs.GetString("BaseName");
        if (!FindObjectOfType<Stats>().firstInBase)
        {
            start.gameObject.SetActive(true);
            FindObjectOfType<Stats>().firstInBase = true;
        }
    }

    public void BackInSpace()
    {
        FindObjectOfType<Stats>().gameObject.AddComponent<LoadLoc>();
        Application.LoadLevel(1);
    }
}
