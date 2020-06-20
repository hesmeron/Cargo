using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsStar : MonoBehaviour
{
    [SerializeField]
    float treshold = 1/3;
    bool wasTurned = false;
    float speed = 10;
    float targetRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.started && UI.Points.completion() > treshold && Player.isActive && !wasTurned)
        {
            wasTurned = true;
            targetRotation += 180;

        }
        if(wasTurned && UI.Points.completion() < treshold)
        {
            targetRotation += 180;
            wasTurned = false;
        }
        Turn();
    }
    void Turn()
    {
        if (targetRotation > 0)
        {
            float delta = (Time.deltaTime * speed * targetRotation / 10) + 1;
            this.transform.Rotate(0, delta, 0);
            targetRotation -= delta;
        }
    }
    void Reverse()
    {
        if (wasTurned)
        {
            targetRotation += 180;
        }
    }
}
