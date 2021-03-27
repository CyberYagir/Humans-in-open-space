using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public Rigidbody2D rbPlayer;
    public Renderer renderer;
    public float speedToZero;

    private void Update()
    {
        transform.position = rbPlayer.transform.position + new Vector3(0,0,5);
        renderer.material.SetTextureOffset("_MainTex", ((Vector2)rbPlayer.transform.position/speedToZero));
    }


}
