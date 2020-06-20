using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCarUp : MonoBehaviour
{
    [SerializeField]
    Animator anim;
    public void LiftCar()
    {
        anim.SetBool("up", true);
    }

}
