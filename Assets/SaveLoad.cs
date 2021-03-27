using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public string path;

    public bool loadonnewscenne;
    public SaveData data;
    float t = 0;
    int loc = 0;
    private void Start()
    {
        path = Path.GetFullPath(Path.Combine(Application.dataPath, @"..\"));
    }
    public void Save()
    {
        Debug.Log(Application.dataPath);
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(path + "save.yag");
        SaveData d = new SaveData();
        //data.map = PlayerPrefs.GetInt("Map");
        //data.pPos = new EmmiVector(manager.localPlayer.transform.position);
        //data.pRot = new EmmiVector(manager.localPlayer.transform.localEulerAngles);

        var s = FindObjectOfType<Ship>();
        var st = FindObjectOfType<Stats>();
        var q = FindObjectOfType<Quest>();

        d.mKilled = st.mobsKilled;
        d.mDestroyed = st.meteordDestroyed;

        d.energy = s.energy;
        d.menergy = s.maxEnergy;
        d.energyadd = s.energyAdd;
        d.hp = s.hp;
        d.maxhp = s.maxHp;
        d.hpadd = s.hpAdd;

        d.copper = s.copper;
        d.iron = s.iron;
        d.diamond = s.diamond;
        d.rock = s.rock;
        d.maxcargo = s.maxCargo;

        d.money = s.money;
        d.userName = s.userName;
        d.ship = s.ship;

        d.dopMaxHp = s.dopMaxHp;
        d.dopMaxCargo = s.dopMaxCargo;
        d.maxModules = s.maxModules;
        d.dopFireRate = s.dopfireRate;
        d.dopSpeed = s.dopSpeed;

        d.modules = s.modules;

        d.firstInBase = st.firstInBase;

        d.quests = q.quests;
        


        if (Application.loadedLevel == 1)
        {
            d.inbase = false;
            d.x = FindObjectOfType<PlayerMOve>().transform.position.x;
            d.y = FindObjectOfType<PlayerMOve>().transform.position.y;
            d.loc = FindObjectOfType<Locations>().currloc;
            print("Save: " + FindObjectOfType<Locations>().currloc);
        }
        if (Application.loadedLevel == 2)
        {
            d.inbase = true;
            d.x = PlayerPrefs.GetFloat("X");
            d.y = PlayerPrefs.GetFloat("Y");
            d.loc = PlayerPrefs.GetInt("Level");



            d.level = PlayerPrefs.GetInt("Level");
            d.basetype = PlayerPrefs.GetInt("Base");
            d.baseName = PlayerPrefs.GetString("BaseName");

        }
        if (FindObjectOfType<PlayerMOve>() != null)
        {
            d.z = FindObjectOfType<PlayerMOve>().transform.localEulerAngles.z;
        }
        bf.Serialize(file, d);
        file.Close();

    }
    public void Load()
    {
        if (!loadonnewscenne)
        {
            if (File.Exists(path + "save.yag"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file = File.Open(path + "save.yag", FileMode.Open);
                SaveData d = (SaveData)bf.Deserialize(file);
                file.Close();
                data = d;
                if (data.inbase == false)
                {
                    Application.LoadLevel(1);
                }
                else
                {

                    PlayerPrefs.SetInt("Level", d.loc);
                    PlayerPrefs.SetFloat("X", d.x);
                    PlayerPrefs.SetFloat("Y", d.y);
                    Application.LoadLevel(2);
                }
                loadonnewscenne = true;
            }
        }
    }
    public void LoadNewSave(SaveData d)
    {
        var s = FindObjectOfType<Ship>();
        var st = FindObjectOfType<Stats>();
        var q = FindObjectOfType<Quest>();

        st.mobsKilled = d.mKilled;
        st.meteordDestroyed = d.mDestroyed;
        st.firstInBase = d.firstInBase;

        s.energy = d.energy;
        s.maxEnergy = d.menergy;
        s.energyAdd = d.energyadd;
        s.hp = d.hp +0.05f;
        s.maxHp = d.maxhp;
        s.hpAdd = d.hpadd;

        s.copper = d.copper;
        s.iron = d.iron;
        s.diamond = d.diamond;
        s.rock = d.rock;
        s.maxCargo = d.maxcargo;

        s.money = d.money;

        s.userName = d.userName;
        s.ship = d.ship;

        s.dopfireRate = d.dopFireRate;
        s.dopSpeed = d.dopSpeed;
        s.dopMaxHp = d.dopMaxHp;
        s.dopMaxCargo = d.dopMaxCargo;
        s.maxModules = d.maxModules;

        s.modules = d.modules;

        q.quests = d.quests;
        if (Application.loadedLevel == 1)
        {
            FindObjectOfType<PlayerMOve>().transform.localEulerAngles = new Vector3(0, 0, d.z);
            FindObjectOfType<PlayerMOve>().transform.position = new Vector2(d.x, d.y);
            FindObjectOfType<ShipManager>().Active();
            FindObjectOfType<Locations>().Activate(d.loc);
            PlayerPrefs.SetInt("Level", d.loc);
        }
        if (Application.loadedLevel == 2)
        {
        }

    }

    private void Update()
    {
        if (loadonnewscenne)
        {
            if (data.inbase == false)
            {
                LoadNewSave(data);
                t += Time.unscaledDeltaTime;
                if (t > 0.2f)
                {
                    loadonnewscenne = false;
                    t = 0;
                }
            }
            else
            {
                PlayerPrefs.SetInt("Level", data.level);
                PlayerPrefs.SetInt("Base", data.basetype);
                PlayerPrefs.SetString("BaseName", data.baseName);

                LoadNewSave(data);
                t += Time.unscaledDeltaTime;
                if (t > 0.2f)
                {
                    loadonnewscenne = false;
                    t = 0;
                }
            }
        }
    }
    [System.Serializable]
    public class SaveData
    {
        public int mKilled, mDestroyed;
        public float energy, menergy, energyadd, hp, maxhp, hpadd;
        public int copper, iron, diamond, rock, maxcargo;
        public float money;

        public string userName;
        public int ship;

        public float dopFireRate, dopSpeed;
        public int dopMaxHp, dopMaxCargo, maxModules;

        public List<string> modules = new List<string>();

        public bool firstInBase;

        public List<Quest.QuestType> quests = new List<Quest.QuestType>();

        public float x, y, z;
        public int loc;

        public bool inbase;
        public int level;
        public int basetype;
        public string baseName;
    }

}
