using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    [System.Serializable]
    public class Press
    {
        public Note note;
        public NoteView noteView;
        public GameObject target;
        TrackButtonGlow buttonGlow;
        float offset = 0.2f;
        float timePressed = 0;
        float targetTime;



        public void Update(float time)
        {
            timePressed += time;
            float completionLevel = Mathf.Clamp01(timePressed / targetTime);
            noteView.UpdateCompletionLevel(completionLevel);
        }

        public Press(NoteView view, GameObject target, TrackButtonGlow buttonGlow)
        {
            this.note = view.GetNote();
            this.noteView = view;
            this.target = target;
            this.buttonGlow = buttonGlow;
            targetTime = note.length / Player.songSpeed;
        }

        public bool Missed()
        {
            
          if(note.note != "speed" && note.note != "slow")
            {
                return timePressed < 0.1 / Player.songSpeed;
            }
            else
            {
                return false;
            }
        }

        public void SetAsCompleted()
        {
            timePressed = (float) 1 / Player.songSpeed;
            
        }
        
        public void GetResult()
        {
            float error = Mathf.Abs(timePressed - targetTime);
            if (error < offset * targetTime)
            {
                int reward = 5 * Player.multiplier;
                UI.Points.points += reward;
                Player.multiplier++;
                buttonGlow.SetAlight();
            }        
        }
    }

}
