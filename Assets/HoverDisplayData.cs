using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverDisplayData : MonoBehaviour, IPointerEnterHandler,IPointerExitHandler
{
    [TextArea]
    public string displayText;
    public GameObject menu;
    public TMP_Text text;
    public Transform part;

    private void Start()
    {
        part = transform.parent;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        text.text = displayText;
        menu.SetActive(true);
        menu.transform.parent = part.parent;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        menu.SetActive(false);
        if (part == null)
        {
            Destroy(menu);
        }
    }
    private void OnDestroy()
    {
        Destroy(menu);
    }
}
