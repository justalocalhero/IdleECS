using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class ClickAndFade : MonoBehaviour
{
    private MeshRenderer meshRenderer;
    public float yStart, yEnd;
    public Color color;
		
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnMouseDown()
    {
        color = meshRenderer.material.GetColor("_BaseColor");
    }
		
	void OnMouseDrag()
    {
        float nY = Mathf.Clamp(transform.position.y, yStart, yEnd);
        float a = (yEnd - nY) / (yEnd - yStart);

        meshRenderer.material.SetColor("_BaseColor", new Color(color.r, color.g, color.b, a));
	}

    void OnMouseUp()
    {
        meshRenderer.material.SetColor("_BaseColor", color);
    }
}
