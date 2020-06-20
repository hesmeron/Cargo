using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject prefab;
    public GameObject target;
    bool exploding = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (exploding)
        {
            Explode();
        }
    }
    void Explode()
    {
        ParticleSystem particleSystem = target.GetComponent<ParticleSystem>();
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleSystem.main.maxParticles];
        int numberParticlesAlive = particleSystem.GetParticles(particles);

        for (int i = 0; i < numberParticlesAlive; i++)
        {
            particles[i].startColor = Color.red;
        }
        exploding = false;
        particleSystem.SetParticles(particles);
        Destroy(this.gameObject);
    }

    public void Detonate()
    {
        target = Instantiate(prefab, this.transform);
        target.transform.parent = null;
        exploding = true;       
    }
}
