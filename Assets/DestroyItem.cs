using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestroyItem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    public UpgradesShop upgradesShop;

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void OnPointerUp(PointerEventData eventData)
    {
        upgradesShop = GetComponentInParent<UpgradesShop>();
        var sprites = GetComponent<Image>().sprite;
        if (sprites == upgradesShop.sprites[0])
        {
            FindObjectOfType<Ship>().modules.Remove("Armor Plate");
            FindObjectOfType<Ship>().dopMaxHp -= 5;
        }
        if (sprites == upgradesShop.sprites[1])
        {
            FindObjectOfType<Ship>().modules.Remove("Cargo");
            FindObjectOfType<Ship>().dopMaxCargo -= 10;
        }
        if (sprites == upgradesShop.sprites[2])
        {
            FindObjectOfType<Ship>().modules.Remove("FireRate");
            FindObjectOfType<Ship>().dopfireRate -= 0.02f;
        }
        if (sprites == upgradesShop.sprites[3])
        {
            FindObjectOfType<Ship>().modules.Remove("Speed");
            FindObjectOfType<Ship>().dopSpeed -= 20f;
        }
        Destroy(gameObject);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(1, 1, 1, 1f);
    }

}
