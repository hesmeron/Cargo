using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowControler : MonoBehaviour
{
    [SerializeField]
    MeshRenderer meshRenderer;
    [Range(0, 100f)]
    public float percentage = 0f;
    Material material;
    // Start is called before the first frame update
    void Start()
    {
        material = new Material(meshRenderer.material);
        meshRenderer.material = material;
    }

    // Update is called once per frame
    void Update()
    {
        material.SetFloat("_SnowPercentage", percentage);
    }
}
