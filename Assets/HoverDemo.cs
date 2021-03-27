using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverDemo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<TMP_Text>().color = new Color(GetComponent<TMP_Text>().color.r, GetComponent<TMP_Text>().color.g, GetComponent<TMP_Text>().color.b, 0.4f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<TMP_Text>().color = new Color(GetComponent<TMP_Text>().color.r, GetComponent<TMP_Text>().color.g, GetComponent<TMP_Text>().color.b, 0.6745098f);
    }

    public void Click()
    {
        Application.LoadLevel(1);
    }
}
