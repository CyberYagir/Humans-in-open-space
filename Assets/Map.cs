using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{

    public Transform player;
    public Image playerImage, meteorImage, botImage, baseImage, portalImage;

    public Meteor[] meteors;
    public GameObject[] bots;
    public List<GameObject> meteorsImage = new List<GameObject>();
    public List<GameObject> botsImage = new List<GameObject>();
    public List<GameObject> othersImages = new List<GameObject>();
    public Transform center;
    float t = 6;
    public void Start()
    {
        
    }
    public void Refresh()
    {
        meteors = FindObjectsOfType<Meteor>();
        bots = GameObject.FindGameObjectsWithTag("Bot");
        for (int i = 0; i < meteorsImage.Count; i++)
        {
            Destroy(meteorsImage[i].gameObject);
        }
        for (int i = 0; i < othersImages.Count; i++)
        {
            Destroy(othersImages[i].gameObject);
        }
        for (int i = 0; i < botsImage.Count; i++)
        {
            Destroy(botsImage[i].gameObject);
        }
        meteorsImage = new List<GameObject>();
        botsImage = new List<GameObject>();
        othersImages = new List<GameObject>();

        for (int i = 0; i < meteors.Length; i++)
        {
            var p = Instantiate(meteorImage.gameObject, center);
            p.transform.localPosition = meteors[i].transform.position * 2.6f;
            meteorsImage.Add(p);
        }
        for (int i = 0; i < bots.Length; i++)
        {
            var p = Instantiate(botImage.gameObject, center);
            p.transform.localPosition = bots[i].transform.position * 2.6f;
            meteorsImage.Add(p);
        }
        var bases = GameObject.FindGameObjectsWithTag("Base");
        var portal = GameObject.FindGameObjectsWithTag("Portal");
        for (int i = 0; i < bases.Length; i++)
        {
            var p = Instantiate(baseImage.gameObject, center);
            p.transform.localPosition = bases[i].transform.position * 2.6f;
            p.GetComponent<HoverDisplayData>().displayText = "Base:  " + bases[i].GetComponent<OpenMenuByClick>().other.GetComponent<EnterInBase>().baseName;
            othersImages.Add(p);
        }
        for (int i = 0; i < portal.Length; i++)
        {
            var p = Instantiate(portalImage.gameObject, center);
            p.transform.localPosition = portal[i].transform.position * 2.6f;
            p.GetComponent<HoverDisplayData>().displayText = "Portal to location " + portal[i].GetComponent<Portal>().locID;
            othersImages.Add(p);
        }
    }
    void Update()
    {
        
        playerImage.rectTransform.localPosition = player.transform.position * 2.6f;
        t += 1 * Time.deltaTime;

        if (t > 5)
        {
            Refresh();
            t = 0;
        }

    }
}
