using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastWindows : MonoBehaviour
{
    public List<GameObject> windows;
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Escape").transform.GetChild(0).gameObject.active)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
        if (GameObject.FindGameObjectWithTag("Escape").transform.GetChild(0).gameObject.active == false)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                windows[0].SetActive(!windows[0].active);
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                windows[1].SetActive(!windows[1].active);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                FindObjectOfType<QuestUI>().canvasQuest.SetActive(!FindObjectOfType<QuestUI>().canvasQuest.active);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bool allclose = true;
                for (int i = 0; i < windows.Count; i++)
                {
                    if (windows[i].active)
                    {
                        allclose = false;
                        break;
                    }
                }
                if (FindObjectOfType<QuestUI>().canvasQuest.active)
                {
                    allclose = false;
                }
                if (allclose == false)
                {
                    for (int i = 0; i < windows.Count; i++)
                    {
                        windows[i].SetActive(false);
                    }
                    FindObjectOfType<QuestUI>().canvasQuest.SetActive(false);
                }
                else
                {
                    GameObject.FindGameObjectWithTag("Escape").transform.GetChild(0).gameObject.SetActive(true);
                }
                print(allclose);
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                GameObject.FindGameObjectWithTag("Escape").transform.GetChild(0).gameObject.SetActive(false);
            }
        }
    }
    public void OpenQuests()
    {
        FindObjectOfType<QuestUI>().canvasQuest.SetActive(true);
    }
}
