using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowControler : MonoBehaviour
{
    [Range(0, 1)]
    public float brightness;
    public Material material;
    public MeshRenderer meshRenderer;
    // Start is called before the first frame update
    void Start()
    {
        material = new Material(meshRenderer.material);
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        meshRenderer.material.SetFloat("_Brightness", brightness);
    }
}
