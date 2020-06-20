using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectKeeper : MonoBehaviour {
    [SerializeField]
    Camera camera;
 
    public float minX, maxX, minY, maxY;

    Vector3 targetPosition;
    public bool beforeStart = false;
    float smooth = 5;
    Vector3 pos;
    // Use this for initialization
    void Start () {
        if(camera == null)
        {
            camera = Camera.main;
        }
        
        pos = camera.WorldToViewportPoint(this.transform.position);
    }

    // Update is called once per frame

    void Update()
    {
        if ((Player.isActive && Player.started)||(beforeStart))
        {
            pos.x = Mathf.Clamp(pos.x, minX, maxX);
            pos.y = Mathf.Clamp(pos.y, minY, maxY);
            targetPosition = camera.ViewportToWorldPoint(pos);
            ChangePosition();

        }
     
       
    }

    public void ChangePosition()
    {
        Vector3 from = this.gameObject.transform.position;
        Vector3 to = targetPosition;

        Vector3 newPos = Vector3.Lerp(from, to, Time.deltaTime * smooth);
        this.gameObject.transform.position = newPos;
    }
}



