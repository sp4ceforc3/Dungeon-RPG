using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animation_functions : MonoBehaviour
{
    ParticleSystem ps;

    // Start is called before the first frame update
    void Awake()
    {
        ps = (ParticleSystem) FindObjectOfType(typeof(ParticleSystem));
    }

    public void PlayParticle()
    {
        Debug.Log("Test");
        ps.Play();
    }
}
