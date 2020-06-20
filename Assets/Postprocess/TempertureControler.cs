using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class TempertureControler : MonoBehaviour
{
    PostProcessVolume volume;
    ColorGrading colorGrading;
    // Start is called before the first frame update
    void Start()
    {
        volume = this.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out colorGrading);
    }

    // Update is called once per frame
    void Update()
    {
        colorGrading.temperature.value = Player.multiplier - 60;
    }
}
