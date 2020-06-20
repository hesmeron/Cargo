using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ScaleObjectKeeper : MonoBehaviour
{
    [SerializeField]
    Camera camera;

    public float scaleX, scaleY;
    public bool ySensitive =  false;
    Vector3 targetPosition;
    public bool beforeStart = false;
    float smooth = 5;
    Vector3 scale, startScale;
    // Use this for initialization
    void Start()
    {
        if (camera == null)
        {
            camera = Camera.main;
        }
        startScale = transform.localScale;
    }

    // Update is called once per frame

    void Update()
    {
        if ((Player.isActive && Player.started) || (beforeStart))
        {
            float distance = Vector3.Distance(camera.transform.position, this.transform.position);
            Debug.Log("Distance:" + distance);
            float newScale = 2.0f * Mathf.Tan((0.5f * camera.fieldOfView * Mathf.Deg2Rad)/2) * distance;
            if (!ySensitive)
            {
                scaleY = camera.aspect * scaleX;
            }
            scale.x = newScale * camera.aspect * scaleX;
            scale.y = newScale *  scaleY;
            scale.z = startScale.z * (scale.x / startScale.x); 
            this.transform.localScale = scale;

        }


    }

    public void ChangePosition()
    {
        Vector3 from = this.gameObject.transform.localScale;
        Vector3 to = scale;

        Vector3 newPos = Vector3.Lerp(from, to, Time.deltaTime * smooth);
        this.gameObject.transform.localScale = newPos;
    }
}
