using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShotLineRenderer : MonoBehaviour
{
    private static LineRenderer lineRenderer;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    public static void OnShot(Vector3 startPoint, Vector3 endPoint)
    {
        lineRenderer.positionCount = 2;
        var defaultColor = new Color2(lineRenderer.startColor, lineRenderer.endColor);
        lineRenderer.SetPositions(new[] {startPoint, endPoint});
        DOVirtual.DelayedCall(0.25f,
            () =>
            {
                lineRenderer.DOColor(defaultColor, new Color2(Color.clear, Color.clear), 0.25f)
                    .OnComplete(() => OnFadeLineRenderer(defaultColor));
            });
    }

    private static void OnFadeLineRenderer(Color2 defaultColor)
    {
        lineRenderer.endColor = defaultColor.cb;
        lineRenderer.startColor = defaultColor.ca;
        lineRenderer.positionCount = 0;
    }
}