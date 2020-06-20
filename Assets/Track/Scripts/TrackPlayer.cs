using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    public class TrackPlayer : MonoBehaviour
    {
        public bool isDown = false;
        public AudioSource audioSource;
        public SoundsLibrary sounds;
        public TrackButtonGlow buttonGlow;
        bool hasExited = true;

        [SerializeField]
        Press currentPress, previousPress, playedPress;

        void Start()
        {
            audioSource = this.gameObject.GetComponent<AudioSource>();
            currentPress = null;
            sounds = FindObjectOfType<SoundsLibrary>();
        }
        public void StartPlaying()
        {
            playedPress = currentPress;
     
            PlayCurrentNote();
            

        }

        public bool compareNote(Note note)
        {
            if(currentPress == null)
            {
                if(note == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return currentPress.note == note;
        }

        public bool IsNotePlayed(Note note)
        {
            return playedPress.note == note;
        }
        void Update()
        {
            if (audioSource.isPlaying)
            {
                if (playedPress != null)
                {
                    playedPress.Update(Time.deltaTime);
                }

            }
        }

        public void UpdatePress(GameObject car, NoteView view)
        {
   
            if (currentPress != null)
            {
                previousPress = currentPress;
            }
            view.SetupProgression();
            currentPress = new Press(view , car, buttonGlow);
            hasExited = false;
        }
        public void StopPlaying()
        {
            if (playedPress != null)
            {
                if (!hasExited)
                {
                    playedPress.GetResult();
                    hasExited = true;
                }
                if (playedPress.note.length != 1)
                {
                    audioSource.Stop();
                }
                playedPress = null;
            }
        }
        public void RemoveNote(Note note)
        {
          

            CheckIfMissed(note);
        }

        public void PlayCurrentNote()
        {
            Note currentNote = null;
            if (currentPress != null)
            {
                currentNote = currentPress.note;
            }
            if (currentNote != null)
            {

                audioSource.pitch = Mathf.Pow(2f, (float)(currentNote.semitone()) / 12);
                if (currentNote.length == 1)
                {
                    PlayShort();
                    return;
                }
                else
                {
                    PlayLongNote();
                }

            }
        }

        void PlayShort()
        {
            if (currentPress.note.note == "speed")
            {
                Player.SpeedUp();
            }
            else if (currentPress.note.note == "slow")
            {
                Player.SlowDown();
            }
            else
            {
                PlayOneShot();
            }
            currentPress.SetAsCompleted();
            currentPress.target.GetComponent<Explosion>().Detonate();
            RemoveNote(currentPress.note);
        }
        void PlayOneShot()
        {
            AudioClip shot = sounds.shots[currentPress.note.octave - 1];
            Debug.Log("Short");
            audioSource.PlayOneShot(shot, 1);



        }

        void PlayLongNote()
        {
            audioSource.clip = sounds.ac[currentPress.note.octave - 1];
            audioSource.loop = true;
            Debug.Log("Long");
            audioSource.Play();
        }

        void CheckIfMissed(Note note)
        {
            Press press;
            if (currentPress == null)
            {
                return;
            }
            if (currentPress.note == note)
            {
                press = currentPress;
                currentPress = null;
            }
            else if(previousPress != null)
            {
                press = previousPress;
                previousPress = null;
            }
            else
            {
                return;
            }
            if (press.Missed())
            {
                Player.multiplier = Player.multiplier / 2;
                Player.songSpeed =Player.basicSpeed;
            }
        }
    }

}
