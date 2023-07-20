using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbitpaths : MonoBehaviour
{
    LineRenderer lineRenderer;

    private static int vertexCount = 50;
    public float lineWidth = 0.2f;
    public float radius;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.useWorldSpace = true;
        lineRenderer.loop = true;
        lineRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        lineRenderer.receiveShadows = false;
        SetupCircle(vertexCount,radius);
    }

    private void SetupCircle(int steps, float radiuss)
    {
        lineRenderer.positionCount = steps;

        for(int currentstep=0; currentstep<steps; currentstep++)
        {
            float circumferenceProgress = (float)currentstep / steps;

            float currentRadian = circumferenceProgress * 2 * Mathf.PI;

            float xScaled = Mathf.Cos(currentRadian);
            float yScaled = Mathf.Sin(currentRadian);

            float x = xScaled * radius;
            float y = yScaled * radius;

            Vector3 currentPosition = new Vector3(x, 0, y);
            lineRenderer.SetPosition(currentstep, currentPosition);
        }
    }
}
