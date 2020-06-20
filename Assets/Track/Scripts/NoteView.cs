using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    public class NoteView : MonoBehaviour
    {
        [SerializeField]
        public bool inEditing = false;
        Animator anim;
        public List<SnowControler> snowControlers = new List<SnowControler>();
        public Note note;
        public Explosion exp;
        public SoundsLibrary sounds;
        public NoteUiView noteUiView;
        public TrackEditor editor;
        public AudioSource audio;
        void Start()
        {
            forwardMovment fm = this.gameObject.AddComponent<forwardMovment>();
            exp = this.gameObject.GetComponent<Explosion>();
            anim = this.gameObject.transform.GetChild(0).GetComponent<Animator>();

            if (inEditing)
            {
                noteUiView = this.gameObject.transform.GetChild(1).GetComponent<NoteUiView>();
                noteUiView.Activate(note);
                sounds = FindObjectOfType<SoundsLibrary>();
                audio = this.gameObject.AddComponent<AudioSource>();
                OnMouseDown();
            }

        }

        public void SetupProgression()
        {
            foreach(var s in snowControlers)
            {
                s.enabled = true;
            }
        }
        // Update is called once per frame
        public Note GetNote()
        {
            anim.SetBool("up", true);
            return note;
        }
        public float GetEndZPosition()
        {
            return this.gameObject.transform.localPosition.z + (13 * note.length -1);
        }
        private void OnMouseDown()
        {
            if (inEditing)
            {
                audio.pitch = Mathf.Pow(2f, (float)(note.semitone()) / 12);
                AudioClip shot = sounds.shots[note.octave - 1];
                Debug.Log("Short");
                audio.PlayOneShot(shot, 1);

            }

        }
        public float GetStartZPosition()
        {

            return this.gameObject.transform.position.z;
        }

        void OnMouseOver()
        {
            if (Input.GetMouseButtonDown(1) && inEditing)
            {
                editor.notes.Remove(this);
                Destroy(this.gameObject);
            }
        }

        public void UpdateCompletionLevel(float completion)
        {
            float snowCars = completion * note.length;
            for(int i=0; i<snowControlers.Count; i++)
            {
                if(i +1 <= snowCars)
                {
                    snowControlers[i].percentage = 100f;
                }
                else if (i  <= snowCars)
                {
                    snowControlers[i].percentage = (snowCars - i) * 100;
                }
                else
                {
                    snowControlers[i].percentage = 0;
                }
            }
        }

    }

}
