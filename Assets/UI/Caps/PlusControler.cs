using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlusControler : MonoBehaviour
{
    [SerializeField]
    float lifetime = 1f;
    float currentTime = 0;

    Vector3 startScale;
    // Start is called before the first frame update
    void Start()
    {
  
        //startScale = this.transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= lifetime)
        {
            Destroy(this.gameObject);
        }

       // this.transform.localScale = this
    }
}
