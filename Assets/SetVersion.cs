using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class SetVersion:MonoBehaviour {
    public TMP_Text text;
    

    public void Start()
    {
        text.text = "V:" + Application.version;
        PlayerPrefs.DeleteAll();
        if (FindObjectOfType<Ship>() != null)
        {
            Destroy(FindObjectOfType<Ship>().gameObject);
        }
    }

    public void SetMusic(Slider slider)
    {
        AudioListener.volume = slider.value;
    }
}
