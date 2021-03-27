using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    public float perlin ;
    public float cost;
    public float coppercoststd, ironcoststd, diamondscoststd, rockcoststd;
    public float coppercost, ironcost, diamondscost, rockcost;

    public int[] availableShips;
    public int[] availableShipsCost;
    private void Start()
    {
        cost = Mathf.PerlinNoise((float)perlin / 1.235324f, (float)DateTime.Now.Day / 10.14242f);

        coppercost = coppercoststd * (1 + cost);
        ironcost = ironcoststd * (1 + cost);
        diamondscost = diamondscoststd * (1 + cost);
        rockcost = rockcoststd * (1 + cost);
    }
}
