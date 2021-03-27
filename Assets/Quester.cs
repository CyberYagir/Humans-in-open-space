using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Quester : MonoBehaviour
{
    public List<Quest.QuestType> questList = new List<Quest.QuestType>();

    public Transform item, holder;


    public void Start()
    {
        for (int i = 0; i < questList.Count; i++)
        {
            var pq = FindObjectOfType<Quest>().quests.Find(x => x.questid == questList[i].questid);
            if (pq != null)
            if (pq.ended) continue;

            if (questList[i].ended == false)
            {
                var p = Instantiate(item, holder);
                p.GetComponent<GetQuesterQuest>().questid = i;
                p.GetChild(1).GetComponent<TMP_Text>().text = "Quest id: " + questList[i].questid;
                p.GetChild(2).GetComponent<TMP_Text>().text = questList[i].replic;

                string str = "";
                if (questList[i].collect)
                {
                    if (questList[i].meteors != -1)
                    {
                        str += "Meteors: " + questList[i].meteors + "\n";
                    }
                    if (questList[i].kills != -1)
                    {
                        str += "Kills: " + questList[i].kills + "\n";
                    }
                    if (questList[i].iron != -1)
                    {
                        str += "Iron: " + questList[i].iron + "\n";
                    }
                    if (questList[i].copper != -1)
                    {
                        str += "Copper: " + questList[i].copper + "\n";
                    }
                    if (questList[i].diamonds != -1)
                    {
                        str += "Diamonds: " + questList[i].diamonds + "\n";
                    }
                    if (questList[i].rocks != -1)
                    {
                        str += "Rocks: " + questList[i].rocks + "\n";
                    }
                }
                if (questList[i].transport)
                {
                    str += "Item: " + questList[i].itemname.name + "\n";
                    str += "Transport to base: " + questList[i].basename + "\n";
                }
                str += "Reward: " + questList[i].reward + "\n";

                p.GetChild(3).GetComponent<TMP_Text>().text = str;
            }
        }
    }

}
