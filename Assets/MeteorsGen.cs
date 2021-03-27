using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorsGen : MonoBehaviour
{
    public GameObject meteor;
    public GameObject[] mobs;
    public int count, mobscount;
    public int range;
    public List<GameObject> objects;

    private void Start()
    {
        Respawn();
        
    }

    public void Respawn()
    {
        var g = FindObjectsOfType<Meteor>();
        for (int i = 0; i < g.Length; i++)
        {
            Destroy(g[i].gameObject);
        }
        var f = FindObjectsOfType<Bot>();
        for (int i = 0; i < f.Length; i++)
        {
            Destroy(f[i].gameObject);
        }
        for (int i = 0; i < count; i++)
        {
            var pos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), -2);
            if (objects.FindAll(x=>Vector2.Distance(x.transform.position, pos) <= 10).Count == 0)
                Instantiate(meteor, pos, Quaternion.identity);
        }
        for (int i = 0; i < mobscount; i++)
        {
            var pos = new Vector3(Random.Range(-range, range), Random.Range(-range, range), -2);
            if (objects.FindAll(x => Vector2.Distance(x.transform.position, pos) <= 15).Count == 0)
                Instantiate(mobs[Random.Range(0,mobs.Length)], pos, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(Vector3.zero, new Vector3(range * 2, range * 2, 1));
    }
}
