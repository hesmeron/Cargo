using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovment : MonoBehaviour { 

    public float speed = 5f;
    Rigidbody rgb;
    // Start is called before the first frame update
    void Start()
    {
        rgb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = this.transform.localPosition.x + speed * Time.deltaTime;
        float y = this.transform.localPosition.y;
        float z = this.transform.localPosition.z;
        Vector3 delta = transform.forward * speed * Time.deltaTime;
        rgb.velocity = delta;
       // this.transform.Translate(delta);
        
    }
}
