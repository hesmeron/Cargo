using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    public class NoteView : MonoBehaviour
    {
        [SerializeField]
        Animator anim;
        public Note note;
        public Explosion exp;
        public float speed = -2000f;
        void Start()
        {
            forwardMovment fm = this.gameObject.AddComponent<forwardMovment>();
            fm.movementSpeed = speed;
            exp = this.gameObject.GetComponent<Explosion>();
            anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();
        }

        // Update is called once per frame
        public Note GetNote()
        {
            anim.SetBool("up", true);
            return note;
        }


    }

}
