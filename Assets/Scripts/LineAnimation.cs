using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LineAnimation : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private float _time;
    private bool _isRise = true;

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (lineRenderer.positionCount > 1)
        {
            AnimateLine();
        }
        else
        {
            lineRenderer.textureScale = new Vector2(1, 1);
            _time = 0;
            _isRise = true;
        }
    }

    private void AnimateLine()
    {
        if (_isRise)
        {
            lineRenderer.textureScale = new Vector2(Mathf.Lerp(1f, 0.5f, _time), 1);
            _time += Time.deltaTime / 5;
            if (_time >=1)
            {
                _isRise = false;
            }
        }
        else
        {
            lineRenderer.textureScale = new Vector2(Mathf.Lerp(1f, 0.5f, _time), 1);
            _time -= Time.deltaTime / 4;
            if (_time <= 0)
            {
                _isRise = true;
            }
        }
    }
}