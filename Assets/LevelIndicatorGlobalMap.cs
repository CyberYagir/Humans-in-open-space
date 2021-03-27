using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelIndicatorGlobalMap : MonoBehaviour
{
    public int level;
    public RectTransform arrow;


    private void Start()
    {
        int currLevel = PlayerPrefs.GetInt("Level", 0);

        if (level == currLevel)
        {
            arrow.position = transform.position + new Vector3(0, 70);
        }
    }


}
