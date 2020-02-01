using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class LineCollider : MonoBehaviour {
    [SerializeField] private bool DebugMod = false;
    [SerializeField] private float colliderSize;
    private LineRenderer _lineRenderer;

    private void Start() {
        _lineRenderer = GetComponent<LineRenderer>();
        if (!DebugMod) _lineRenderer.startWidth = 0f;
        Vector3[] positions = new Vector3[_lineRenderer.positionCount];
        var pointsCount = _lineRenderer.GetPositions(positions);
        // var pointsCount = 
        for (int i = 0; i < pointsCount; i++) {
            _lineRenderer.SetPosition(i, new Vector3(positions[i].x, positions[i].y, 0));
        }

        pointsCount = _lineRenderer.GetPositions(positions);
        for (int i = 0; i < pointsCount; i++) {
            var go = new GameObject();
            go.transform.position = positions[i];
            go.transform.SetParent(transform);
            go.AddComponent<CircleCollider2D>();
            go.GetComponent<CircleCollider2D>().radius = colliderSize;
        }
    }
}
