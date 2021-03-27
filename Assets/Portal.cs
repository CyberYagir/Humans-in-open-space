using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Portal : MonoBehaviour
{
    public int locID, portalInLoc, portalID;
    public Transform point;
    public bool triggered;
    PlayerMOve ship;
    public SpriteRenderer green;
    public float alpha;
    private void Start()
    {
        ship = FindObjectOfType<PlayerMOve>();
    }
    private void Update()
    {
        if (triggered)
        {
            if (!ship.enabled)
            {
                alpha += 0.02f;

                green.color = new Color(green.color.r, green.color.g, green.color.b, alpha);
                if (alpha >= 1)
                {
                    FindObjectOfType<Locations>().Activate(locID);
                    FindObjectOfType<Locations>().locations[locID].GetComponentInChildren<MeteorsGen>().Respawn();

                    var gen = FindObjectOfType<Locations>().locations[locID].GetComponentInChildren<MeteorsGen>();
                   
                    var portals = gen.objects.FindAll(x => x.transform.tag == "Portal");
                    var eq = portals.Find(x => x.GetComponent<Portal>().portalID == portalInLoc);
                    FindObjectOfType<PlayerMOve>().transform.position = eq.GetComponent<Portal>().point.position;
                    triggered = false;
                    alpha = 0;
                    green.color = new Color(green.color.r, green.color.g, green.color.b, alpha);
                }
            }
            else
            {
                alpha -= 0.02f;
                if (alpha <= 0)
                {
                    alpha = 0;
                }
                green.color = new Color(green.color.r, green.color.g, green.color.b, alpha);

            }
        }
        else
        {
            alpha -= 0.02f;
            if (alpha <= 0)
            {
                alpha = 0;
            }
            green.color = new Color(green.color.r, green.color.g, green.color.b, alpha);

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggered = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        triggered = false;
    }
}
