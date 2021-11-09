using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void OnPerceptionUpdated(bool successfullySensed, PerceptionStimuli stimuli);


public class SightPerceptionComp : PerceptionComp
{
    public OnPerceptionUpdated onPerceptionUpdated;
    private List<PerceptionStimuli> CurrentlySeeingStimulis = new List<PerceptionStimuli>();
    [SerializeField] private float SightRadius = 5f;
    [SerializeField] private float LoseSightRadius = 6f;
    [SerializeField] private float PeriferalAngleDegrees = 80f;
    [SerializeField] private float eyeHeight = 1.6f;
    
    public override bool EvaluatPerception(PerceptionStimuli _stimuli)
    {
        bool InSightRange = this.InSightRange(_stimuli);
        bool IsNotBlocked = this.IsNotBlocked(_stimuli);
        bool IsInPeripheralAngleDegrees = this.IsInPeripherals(_stimuli);

        bool Percepted = InSightRange && IsNotBlocked && IsInPeripheralAngleDegrees;
        if (Percepted && !CurrentlySeeingStimulis.Contains(_stimuli))
        {
            CurrentlySeeingStimulis.Add(_stimuli);
            if (onPerceptionUpdated != null)
            {
                Debug.Log($"I have seen: {_stimuli.gameObject}");
                
                onPerceptionUpdated.Invoke(true, _stimuli);
            }
        }
        if(!Percepted && CurrentlySeeingStimulis.Contains(_stimuli))
        {
            CurrentlySeeingStimulis.Remove(_stimuli);
            if (onPerceptionUpdated != null)
            {
                Debug.Log($"I have lost track of: {_stimuli.gameObject}");
                onPerceptionUpdated.Invoke(false, _stimuli);
            }
        }

        return Percepted;
    }

    bool InSightRange(PerceptionStimuli stimuli)
    {
        Vector3 ownerPos = transform.position;
        Vector3 stimuliPos = stimuli.transform.position;
        float checkRadius = SightRadius;
        if (CurrentlySeeingStimulis.Contains(stimuli))
        {
            checkRadius = LoseSightRadius;
        }
        return Vector3.Distance(ownerPos, stimuliPos) < checkRadius;
    }

    bool IsNotBlocked(PerceptionStimuli stimuli)
    {
        Vector3 StimuliCheckPos = stimuli.GetComponent<Collider>().bounds.center;
        Vector3 EyePos = transform.position + Vector3.up * eyeHeight;
        Ray ray = new Ray(EyePos, (StimuliCheckPos - EyePos).normalized);
        if(Physics.Raycast(ray, out RaycastHit raycastHit, LoseSightRadius))
        {
            if (raycastHit.collider.gameObject == stimuli.gameObject)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;
    }

    bool IsInPeripherals(PerceptionStimuli stimuli)
    {
       /* Quaternion LeftRotation = Quaternion.AngleAxis(PeriferalAngleDegrees / 2, Vector3.up);
        Quaternion RightRotation = Quaternion.AngleAxis(-PeriferalAngleDegrees / 2, Vector3.up);
        Vector3 LeftPeripheralEdge = LeftRotation * transform.forward;
        Vector3 RightPeripheralEdge = RightRotation * transform.forward;*/

        float AngleToStimuli = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(transform.forward, (stimuli.transform.position - transform.position).normalized));
        return AngleToStimuli < PeriferalAngleDegrees / 2;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SightRadius);
        Gizmos.DrawWireSphere(transform.position, LoseSightRadius);
        Vector3 forward = transform.forward;
        Quaternion RotateLeft = Quaternion.AngleAxis(PeriferalAngleDegrees/2, Vector3.up);
        Quaternion RotateRight = Quaternion.AngleAxis(-PeriferalAngleDegrees / 2,Vector3.up);
        Gizmos.DrawLine(transform.position, transform.position + RotateLeft * forward *LoseSightRadius);
        Gizmos.DrawLine(transform.position, transform.position + RotateRight * forward *LoseSightRadius);
        foreach (var Stimuli in CurrentlySeeingStimulis)
        {
            Gizmos.DrawLine(transform.position, Stimuli.transform.position);
        }
    }
}
