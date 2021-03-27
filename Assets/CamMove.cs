using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMove : MonoBehaviour
{
    public Transform targ;
    public float z;
    private void Update()
    {
        transform.position = targ.position + new Vector3(0,0,z);
    }
}
