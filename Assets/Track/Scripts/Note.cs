using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    [System.Serializable]
    public class Note 
    {
        public string note = "0";
        [Range(1,8)]
        public int octave = 5;
        [Range(1, 20)]
        public int length;
        public int semitoneNumber = -1;


        public int semitone()
        {
            
            //semitoneNumber += (octave -1) * 12;
            return semitoneNumber;
        }
        public void SetNote(string note)
        {
            this.note = note;
            semitoneNumber = TurnNoteIntoNumber();
        }

        public void AddSemitone()
        {
            if(semitoneNumber < 11)
            {
                semitoneNumber++;
            }
            else
            {
                if(octave < 8)
                {
                    octave++;
                    semitoneNumber = 0;
                }
            }

            TurnNumberIntoNote();
        }

        public void SubstractSemitone()
        {
            if (semitoneNumber > 0)
            {
                semitoneNumber--;
            }
            else
            {
                if (octave > 1)
                {
                    octave--;
                    semitoneNumber = 11;
                }
            }

            TurnNumberIntoNote();
        }
        int TurnNoteIntoNumber()
        {
            int semitoneNumber = -1;
            switch (note)
            {
                case "C":
                    semitoneNumber = 0;
                    break;
                case "C#":
                    semitoneNumber = 1;
                    break;
                case "D":
                    semitoneNumber = 2;
                    break;
                case "D#":
                    semitoneNumber = 3;
                    break;
                case "E":
                    semitoneNumber = 4;
                    break;
                case "F":
                    semitoneNumber = 5;
                    break;
                case "F#":
                    semitoneNumber = 6;
                    break;
                case "G":
                    semitoneNumber = 7;
                    break;
                case "G#":
                    semitoneNumber = 8;
                    break;
                case "A":
                    semitoneNumber = 9;
                    break;

                case "A#":
                    semitoneNumber = 10;
                    break;
                case "B":
                    semitoneNumber = 11;
                    break;
                
            }
            return semitoneNumber;
        }

        public void TurnNumberIntoNote()
        {
            string note = "";
            switch (semitoneNumber)
            {
                case 0:
                    note = "C";
                    break;
                case 1:
                    note = "C#";
                    break;
                case 2:
                    note = "D";
                    break;
                case 3:
                    note = "D#";
                    break;
                case 4:
                    note = "E";
                    break;
                case 5:
                    note = "F";
                    break;
                case 6:
                    note = "F#";
                    break;
                case 7:
                    note = "G";
                    break;
                case 8:
                    note = "G#";
                    break;
                case 9:
                    note = "A";
                    break;
                case 10:
                    note = "A#";
                    break;
                case 11:
                    note = "B";
                    break;
                default:
                    note = "0";
                    break;
            }
            this.note = note;
        }

        public Note (int x)
        {
           
            this.length = 1;
            this.octave = (x / 13) + 1;
            Debug.Log(x + " " + this.octave);
            this.semitoneNumber = ((x) % 13) - 1;
            this.TurnNumberIntoNote();
            
        }

        public Note(Note note)
        {
            this.octave = note.octave;
            this.SetNote(note.note);
            this.length = note.length;
        }

        public Note()
        {

        }

    }
}


