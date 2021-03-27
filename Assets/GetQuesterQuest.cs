using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GetQuesterQuest : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int questid;
    public Transform unable, getreward;
    private void Update()
    {
        unable.gameObject.SetActive(FindObjectOfType<Quest>().quests.Find(x => x.questid == GetComponentInParent<Quester>().questList[questid].questid) != null);
        if (unable.gameObject.active)
        {
            print(CheckEnd());
            if (CheckEnd())
            {
                getreward.gameObject.SetActive(true);
            }
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (!unable.gameObject.active)
        {
            var q = GetComponentInParent<Quester>().questList[questid];
            q.oldkills = FindObjectOfType<Stats>().mobsKilled;
            q.oldmeteors = FindObjectOfType<Stats>().meteordDestroyed;
            FindObjectOfType<Quest>().quests.Add(q);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.4f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetComponent<Image>().color = new Color(GetComponent<Image>().color.r, GetComponent<Image>().color.g, GetComponent<Image>().color.b, 0.6745098f);
    }
    public void GetReward()
    {
        var ship = FindObjectOfType<Ship>();

        if (CheckEnd())
        {
            ship.money += GetComponentInParent<Quester>().questList[questid].reward;

            var q = GetComponentInParent<Quester>().questList[questid];

            if (q.iron != -1)
            {
                ship.iron -= q.iron;
            }
            if (q.copper != -1)
            {
                ship.copper -= q.copper;
            }
            if (q.diamonds != -1)
            {
                ship.diamond -= q.diamonds;
            }
            if (q.rocks != -1)
            {
                ship.rock -= q.rocks;
            }

            var qst = GetComponentInParent<Quester>();
            qst.questList[questid].ended = true;
            
            FindObjectOfType<Quest>().quests.Find(x=>x.questid == qst.questList[questid].questid).ended = true;

            Destroy(gameObject);
        }
    }
    public bool CheckEnd()
    {
        var stats = FindObjectOfType<Stats>();
        var ship = FindObjectOfType<Ship>();
        var q = GetComponentInParent<Quester>().questList[questid];
        int errors = 0;
        if (q.collect)
        {
            if (q.meteors != -1)
            {
                if (q.meteors > (stats.meteordDestroyed - q.oldmeteors))
                {
                    errors++;
                }
            }
            print(q.meteors + ">" + (stats.meteordDestroyed - q.oldmeteors));
            if (q.kills != -1)
            {
                if (q.kills > (stats.mobsKilled - q.oldkills))
                {
                    errors++;
                }
            }
            if (q.iron != -1)
            {
                if (q.iron > ship.iron)
                {
                    errors++;
                }
            }
            if (q.copper != -1)
            {
                if (q.copper > ship.copper)
                {
                    errors++;
                }
            }
            if (q.diamonds != -1)
            {
                if (q.diamonds > ship.diamond)
                {
                    errors++;
                }
            }
            if (q.rocks != -1)
            {
                if (q.rocks > ship.rock)
                {
                    errors++;
                }
            }
        }
        else if (q.transport)
        {
            var g = FindObjectOfType<Quest>().quests.Find(x => x.questid == q.questid);
            if (g != null)
            {
                if (g.itemname.name != "")
                    errors++;
            }
        }

        return (errors == 0);
    }
}
