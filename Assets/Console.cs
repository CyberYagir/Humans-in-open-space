using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public Transform[] cargo;
    public Ship s;
    public RectTransform shipPreview;
    public Transform content, item;

    private void Update()
    {
        shipPreview.Rotate(Vector3.forward, -5 * Time.deltaTime);
        s = FindObjectOfType<Ship>();
    }
    private void FixedUpdate()
    {
        if (s == null)
        {
            s = FindObjectOfType<Ship>();
        }
        cargo[0].GetComponentInChildren<TMP_Text>().text =""+ s.iron;
        cargo[1].GetComponentInChildren<TMP_Text>().text =""+ s.diamond;
        cargo[2].GetComponentInChildren<TMP_Text>().text =""+ s.copper;
        cargo[3].GetComponentInChildren<TMP_Text>().text =""+ s.rock;
        cargo[4].GetComponentInChildren<TMP_Text>().text =""+ s.money.ToString("F2");
    }

    public void ItemsRefresh()
    {
        s = FindObjectOfType<Ship>();
        foreach (Transform item in content)
        {
            Destroy(item.gameObject);
        }
        for (int i = 0; i < s.items.Count; i++)
        {
            var g = Instantiate(item, content);
            g.GetComponent<Image>().sprite = s.items[i].sprite;
            g.GetComponentInChildren<TMP_Text>().text = "" + s.items[i].count;
            g.gameObject.SetActive(true);
        }
    }
}
