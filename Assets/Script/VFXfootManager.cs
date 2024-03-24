using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXfootManager : MonoBehaviour
{
   public static VFXfootManager instance;
    public ParticleSystem footStep;
    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    public void FootStep()
    {
        footStep.Play();
    }
}
