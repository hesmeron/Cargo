using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forwardMovment : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        //rigidbody.velocity = transform.forward * Time.deltaTime * movementSpeed; ;
        Debug.Log(Player.isActive);
        if (Player.isActive && Player.started)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - Time.deltaTime * 13 * Player.songSpeed);
        }
       
    }
}
