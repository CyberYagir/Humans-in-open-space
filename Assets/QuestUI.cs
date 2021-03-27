using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public Quest quest;
    public TMP_Text text, text2;
    public Stats stats;
    public Ship ship;

    public GameObject canvasQuest;
    public TMP_Text canvasQuestText;
    private void Start()
    {
        ship = FindObjectOfType<Ship>();
    }
    public void FixedUpdate()
    {
        if (!canvasQuest.active)
        {
            if (quest.quests.Count != 0)
            {
                text.text = "Quests: ";
                string str = "";
                int q = 0;
                for (int i = 0; i < quest.quests.Count; i++)
                {
                    if (q > 2)
                    {
                        str += "...";
                        break;
                    }
                    if (!quest.quests[i].ended)
                    {
                        q++;
                           str += "" + quest.quests[i].questid + ":\n";
                        if (quest.quests[i].collect)
                        {
                            if (quest.quests[i].meteors != -1)
                            {
                                str += "  Meteors: " + (stats.meteordDestroyed - quest.quests[i].oldmeteors) + "/" + quest.quests[i].meteors + "\n";
                            }
                            if (quest.quests[i].kills != -1)
                            {
                                str += "  Kills: " + (stats.mobsKilled - quest.quests[i].oldkills) + "/" + quest.quests[i].kills + "\n";
                            }
                            if (quest.quests[i].iron != -1)
                            {
                                str += "  Iron: " + ship.iron + "/" + quest.quests[i].iron + "\n";
                            }
                            if (quest.quests[i].copper != -1)
                            {
                                str += "  Copper: " + ship.copper + "/" + quest.quests[i].copper + "\n";
                            }
                            if (quest.quests[i].diamonds != -1)
                            {
                                str += "  Diamonds: " + ship.diamond + "/" + quest.quests[i].diamonds + "\n";
                            }
                            if (quest.quests[i].rocks != -1)
                            {
                                str += "  Rocks: " + ship.rock + "/" + quest.quests[i].rocks + "\n";
                            }
                        }
                        if (quest.quests[i].transport)
                        {
                            if (quest.quests[i].itemname.name != "")
                            {
                                str += "  Item: " + quest.quests[i].itemname.name + "\n";
                                str += "  Transport to base: " + quest.quests[i].basename + "\n";
                            }
                            else
                            {
                                str += "  Ended.\n";
                            }
                        }
                    }
                }
                text.text += "\n" + str;


            }
            else text.text = "";
            text2.text = text.text;
        }
        else
        {
            if (quest.quests.Count != 0)
            {
                canvasQuestText.text = "Quests: ";
                string str = "";
                for (int i = 0; i < quest.quests.Count; i++)
                {
                    if (!quest.quests[i].ended)
                    {
                        str += "" + quest.quests[i].questid + ":\n";
                        if (quest.quests[i].collect)
                        {
                            if (quest.quests[i].meteors != -1)
                            {
                                str += "  Meteors: " + (stats.meteordDestroyed - quest.quests[i].oldmeteors) + "/" + quest.quests[i].meteors + "\n";
                            }
                            if (quest.quests[i].kills != -1)
                            {
                                str += "  Kills: " + (stats.mobsKilled - quest.quests[i].oldkills) + "/" + quest.quests[i].kills + "\n";
                            }
                            if (quest.quests[i].iron != -1)
                            {
                                str += "  Iron: " + ship.iron + "/" + quest.quests[i].iron + "\n";
                            }
                            if (quest.quests[i].copper != -1)
                            {
                                str += "  Copper: " + ship.copper + "/" + quest.quests[i].copper + "\n";
                            }
                            if (quest.quests[i].diamonds != -1)
                            {
                                str += "  Diamonds: " + ship.diamond + "/" + quest.quests[i].diamonds + "\n";
                            }
                            if (quest.quests[i].rocks != -1)
                            {
                                str += "  Rocks: " + ship.rock + "/" + quest.quests[i].rocks + "\n";
                            }
                        }
                        if (quest.quests[i].transport)
                        {
                            if (quest.quests[i].itemname.name != "")
                            {
                                str += "  Item: " + quest.quests[i].itemname.name + "\n";
                                str += "  Transport to base: " + quest.quests[i].basename + "\n";
                            }
                            else
                            {
                                str += "  Ended.\n";
                            }
                        }
                    }
                }
                canvasQuestText.text += "\n" + str;


            }
            else canvasQuestText.text = "";
        }
    }
}
