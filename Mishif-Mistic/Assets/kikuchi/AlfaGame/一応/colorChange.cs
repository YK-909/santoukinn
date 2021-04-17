using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colorChange : MonoBehaviour
{
    public GameObject cube;
    public Color startColor;
    public Color endColor;

    [Range(0f, 1f)]
    public float t;

    MeshRenderer cubeMeshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        cubeMeshRenderer = cube.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        cubeMeshRenderer.material.SetColor("_BaseColor", Color.Lerp(startColor, endColor, t));
    }
}