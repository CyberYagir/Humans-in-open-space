using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    [System.Serializable]
    public class QuestType{

        public string questid = "001";
        public int meteors = -1;
        public int oldmeteors = -1;
        public int kills = -1;
        public int oldkills = -1;
        public int iron = -1, copper = -1, diamonds = -1, rocks = -1;
        [Space]
        public string basename;
        public Ship.Item itemname;
        [TextArea]
        public string replic;

        public float reward;

        public bool collect, transport;

        public bool ended;
    }

    public List<QuestType> quests = new List<QuestType>();





}
