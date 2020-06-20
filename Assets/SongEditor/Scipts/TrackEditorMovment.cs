using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackEditorMovment : MonoBehaviour
{
    float speed = 20f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Move(-speed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Move(speed);
        }
    }

    void Move(float change)
    {
        float delta = 10 * change * Time.deltaTime;
        if (delta > 0 && this.transform.localPosition.z >= 0)
        {
            return;
        }
        
        this.transform.Translate(this.transform.forward * delta);
    }
}
