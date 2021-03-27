using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class LineAnim : MonoBehaviour
{
    public Transform target;
    public LineRenderer lineRenderer;
    private void Update()
    {
        lineRenderer.SetPosition(1, target.position);
    }
}
