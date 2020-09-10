using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartParticle : MonoBehaviour
{

    public ParticleSystem effect;
    // Start is called before the first frame update
    void Start()
    {
        effect.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
