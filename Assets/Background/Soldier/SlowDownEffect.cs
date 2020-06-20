using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowDownEffect : MonoBehaviour
{
    public GameObject prefab;
    public Transform from, to;
    public int minNumber, maxNumber;
    public bool fast = false;
    // Start is called before the first frame update
    void Start()
    {
        if (fast)
        {
            Player.fast = this;
        }
        else
        {
            Player.slow = this;
        }
        //CreateEffect();
    }

    // Update is called once per frame
    void Update()
    {


    }

    public void CreateEffect()
    {
        int numberOfSoldiers = Random.Range(minNumber, maxNumber);
        for (int i=0; i<numberOfSoldiers; i++)
        {
            Debug.Log("Create soldier" + i);
            float x = Random.Range(from.position.x, to.transform.position.x);
            float y = this.transform.position.y;
            float z = Random.Range(from.position.z, to.transform.position.z);
            GameObject target = Instantiate(prefab, this.transform);
            target.transform.localPosition = new Vector3(x, y, z);
        }

    }
}
