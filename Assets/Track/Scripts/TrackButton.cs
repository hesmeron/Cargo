using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    public class TrackButton : MonoBehaviour
    {
        TrackPlayer trackPlayer;
        public KeyCode key;
        [SerializeField]
        Animator anim;
        [SerializeField]
        Animator uiAnimator;
        float cooldown = 3f;
        [SerializeField]
        bool isActive = true;


        GameObject onlyCar;

        void Start()
        {

            trackPlayer = this.gameObject.GetComponent<TrackPlayer>();
            Player.uiAnimator = uiAnimator;
        }

        public void Update()
        {

            
            if (isActive)
            {
                if (Input.GetKeyDown(key))
                {
                    Debug.Log("Remove button " + trackPlayer.compareNote(null));
                    if (trackPlayer.compareNote(null))
                    {
                        Player.TakePunishment();
                    }
                    anim.SetBool("isPressed", true);
                    trackPlayer.StartPlaying();
                }
                else if (Input.GetKeyUp(key))
                {
                    anim.SetBool("isPressed", false);
                    trackPlayer.StopPlaying();
                }
            }
        }




        IEnumerator Cooldown()
        {
            Debug.Log("Start Courtine");
            Player.multiplier = Player.multiplier /2;
            isActive = false;
            anim.SetBool("isActive", false);
            anim.Play("MoveAway");
            yield return new WaitForSeconds(cooldown);
            anim.SetBool("isPressed", false);
            anim.SetBool("isActive", true);
            isActive = true;
        }


        void OnTriggerEnter(Collider col)
        {

            Debug.Log("Entered");
            Note note = null;
            NoteView view = col.gameObject.GetComponent<NoteView>();
            if (view != null)
            {
                note = col.gameObject.GetComponent<NoteView>().GetNote();
            }
            else if(col.gameObject.GetComponent<MoveCarUp>() != null)
            {
                
                col.gameObject.GetComponent<MoveCarUp>().LiftCar();
            }
           
            if (view!= null && (col.tag == "First" ||col.tag == "Only"))
            {
                Debug.Log("Change Press");
                trackPlayer.UpdatePress(col.gameObject, view);
            }
            
   
        }

        void OnTriggerExit(Collider col)
        {
            //may result in keeping some unvalid scores
            if (trackPlayer.audioSource.isPlaying && (true))
            {
                UI.Points.points += Player.multiplier;
            }
            if((col.tag == "Last"|| col.tag == "Only"))
            {
                RemoveNote(col);
            }

            
        }
        void RemoveNote(Collider col)
        {
            Note noteToRemove;
            GameObject objectToRemove;
            if (col.tag == "Last")
            {
                noteToRemove = col.gameObject.transform.parent.gameObject.GetComponent<NoteView>().GetNote();
                objectToRemove = col.gameObject.transform.parent.gameObject;
            }
            else
            {
                noteToRemove = col.gameObject.GetComponent<NoteView>().GetNote();
                objectToRemove = col.gameObject;
            }
            trackPlayer.RemoveNote(noteToRemove);
            StartCoroutine("DelayedDestruction", objectToRemove);
        }


        IEnumerator DelayedDestruction(GameObject target)
        {
            yield return new WaitForSeconds(3f);
            Destroy(target);
            
        }
    }

}
