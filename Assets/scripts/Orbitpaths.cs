using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbitpaths : MonoBehaviour
{
     LineRenderer lineRenderer;

    public int vertexCount = 40;
    public float lineWidth = 0.2f;
    public float radius;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.receiveShadows = false;
        SetupCircle();
    }
    
    private void SetupCircle()
    {
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta=0f;

        lineRenderer.positionCount = vertexCount;
        for(int i=0;i<lineRenderer.positionCount;i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta),0f, radius * Mathf.Sin(theta));
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }
    public void disableLine()
    {
        lineRenderer.enabled = !lineRenderer.enabled;
    }
}
