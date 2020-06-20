using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControler : MonoBehaviour
{
    public Transform target;
    public float smooth;
    public bool transitionHappened = false;
    public bool isRunning = false;
    public bool isMain = true;

    void Start()
    {
        Player.camera = this;
    }

    public void StartTransition(Transform newVector)
    {
        Debug.Log("Start Transition");
        target = newVector;
    }
    public void Update()
    {
        if (isMain){
            if (IsCloseEnoug())
            {
                Player.isActive = true;
            }
            else
            {
                Player.isActive = false;
            }
        }
       
        ChangePosition();
        ChangeRotation();
    }
    public bool IsCloseEnoug()
    {

        bool isClose = Vector3.Distance(this.transform.position, target.position) < 1;
        bool isRotated = Quaternion.Angle(this.transform.rotation, target.rotation) < 3f;
        return isClose && isRotated;
    }

    public void ResetPosition()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }
    public void ChangePosition()
    {
        Vector3 from = this.gameObject.transform.position;
        Vector3 to = target.position;

        Vector3 newPos = Vector3.Lerp(from, to, Time.deltaTime * smooth);
        this.gameObject.transform.position = newPos;
    }

    public void ChangeRotation()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, smooth * Time.deltaTime);
    }


    IEnumerator Backup()
    {
        isRunning = true;
        Debug.Log("Backup");
        yield return new WaitForSeconds(3f);
        if (!Player.isActive)
        {
            Player.isActive = true;
            target.position = this.transform.position;
            target.rotation = this.transform.rotation;
            this.transform.position = target.position;
            this.transform.rotation = target.rotation;
          
        }
        isRunning = false;
    }
}
