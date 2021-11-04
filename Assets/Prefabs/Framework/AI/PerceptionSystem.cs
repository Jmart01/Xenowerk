using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionSystem : MonoBehaviour
{
    private List<PerceptionComp> Listeners = new List<PerceptionComp>();

    private List<PerceptionStimuli> Stimulis = new List<PerceptionStimuli>();
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Stimulis.Count; i++)
        {
            for (int j = 0; j < Listeners.Count; j++)
            {
                PerceptionComp listener = Listeners[j];
                if (listener)
                {
                    listener.EvaluatPerception(Stimulis[i]);
                }
            }
        }
    }

    public void AddListener(PerceptionComp perceptionComp)
    {
        Listeners.Add(perceptionComp);
    }

    public void RemoveListener(PerceptionComp perceptionComp)
    {
        Listeners.Remove(perceptionComp);
    }

    public void RegisterStimuli(PerceptionStimuli stimuli)
    {
        Stimulis.Add(stimuli);
    }

    public void UnRegisterStimuli(PerceptionStimuli stimuli)
    {
        Stimulis.Remove(stimuli);
    }
}
