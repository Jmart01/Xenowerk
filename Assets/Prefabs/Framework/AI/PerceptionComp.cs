using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPerceptionUpdated(PerceptionStimuli stimuli, bool succesfullySensed);
public abstract class PerceptionComp : MonoBehaviour
{
    public OnPerceptionUpdated onPerceptionUpdated;
    private void Start()
    {
        FindObjectOfType<PerceptionSystem>().AddListener(this);
    }

    private void OnDestroy()
    {
        PerceptionSystem system = FindObjectOfType<PerceptionSystem>();
        if (system != null)
        {
            system.RemoveListener(this);
        }
    }

    //abstract key word means it is not used right away, look into it more later
    public abstract bool EvaluatPerception(PerceptionStimuli _stimuli);
}
