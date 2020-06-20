using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChanger : MonoBehaviour
{
    public float time;
    public float speedChange;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(time > 0 && Player.isActive && Player.started)
        {
            time -= Time.deltaTime;
            if(time < 0)
            {
                Change();
            }
        }
    }

    void Change()
    {
        Player.songSpeed += speedChange;
        if(speedChange < 0)
        {
            //Player.slow.CreateEffect();
        }
        else
        {
            //Player.fast.CreateEffect();
        }
    }
}
