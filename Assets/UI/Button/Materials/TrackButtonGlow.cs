using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackButtonGlow : MonoBehaviour
{
    public List<GlowControler> controlers = new List<GlowControler>();
    [SerializeField]
    float maxBrightness = 0.5f;
    float brightness = 0;
    [SerializeField]
    float smooth = 5;
    // Update is called once per frame
    void Update()
    {
        brightness = Mathf.Lerp(brightness, 0, smooth * Time.deltaTime);
        foreach(var c in controlers)
        {
            c.brightness = brightness;
        }
    }

    public void SetAlight()
    {
        brightness = maxBrightness;
    }
}
