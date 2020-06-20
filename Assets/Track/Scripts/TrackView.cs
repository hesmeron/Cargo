using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Beats
{
    public class TrackView : MonoBehaviour
    {
        public float offsetZ = 13;
        float currentZPosition = 0;
        [SerializeField]
        Track track;
        public List<Note> notes = new List<Note>();
        public bool isInEditing = false;
        public List<GameObject> cars = new List<GameObject>();
        public Transform spawnPoint;
        public List<NoteView> noteViews = new List<NoteView>();
        public TrackEditor editor;
        public GameObject locomotive, car, only, firstCar, speedUp, slowDown;
       
        public void Start()
        {
            if(spawnPoint == null)
            {
                spawnPoint = this.transform;
            }
        }
        public void AddTrack(Track track)
        {
            this.track = track;
            foreach(var n in track.notes)
            {
                notes.Add(n);
            }
        }
        public bool hasEnded()
        {
            for(int i = 0; i < cars.Count; i++){
                if (cars[i] == null)
                {
                    cars.RemoveAt(i);
                }
            }
            return cars.Count == 0;
        }
        public void Init()
        {
            foreach(var n in notes)
            {     
                if(n.note == "0"){
                    currentZPosition += offsetZ * n.length;
                    continue;
                }
                for(int i = 0; i < n.length; i++)
                { 
                    Debug.Log("Add Car" + " " + n.note + " " + n.semitone().ToString());
                    if (n.note != "0")
                    {
                        GameObject target = CreateNewCar(i, n);
                    }
                    currentZPosition += offsetZ;
                }
            }
        }
        GameObject CreateNewCar(int i, Note n)
        {

            GameObject target;
            if (i == 0 )
            {
                target = AddFirstCar(n);
            }
            else
            {
                target = Instantiate(car, this.transform);
            }
            SetCarsTag(n, i, target);

            target.transform.localPosition = new Vector3(0f, 0f, currentZPosition);
            if (firstCar != null)
            {
                target.transform.parent = firstCar.transform;
                SnowControler snow = target.GetComponent<SnowControler>();
                if(snow != null)
                {
                    firstCar.GetComponent<NoteView>().snowControlers.Add(snow);
                }
            }
            cars.Add(target);
            return target;
        }


        GameObject AddFirstCar(Note n)
        {
            GameObject target;
            if (n.length > 1 || isInEditing)
            {
                target = Instantiate(locomotive, spawnPoint);

            }
            else
            {
                if(n.note == "speed")
                {
                    target = Instantiate(speedUp, spawnPoint);
                }
                else if (n.note == "slow")
                {
                    target = Instantiate(slowDown, spawnPoint);
                }
                else
                {
                    target = Instantiate(only, spawnPoint);
                }

            }
            firstCar = target;
            NoteView view = target.AddComponent<NoteView>();
            noteViews.Add(view);
            view.note = n;
            view.inEditing = isInEditing;
            if (editor)
            {
                view.editor = editor;
            }
            return target;
        }
        void SetCarsTag(Note n, int i,  GameObject target)
        {
            if (i == n.length - 1)
            {
                target.tag = "Last";
            }
            if (n.length == 1)
            {
                target.tag = "Only";
            }
        }
        public void Reset()
        {
            notes = new List<Note>();
            currentZPosition = 0;

        }
    }

}
