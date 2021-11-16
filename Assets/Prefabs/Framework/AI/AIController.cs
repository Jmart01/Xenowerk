using System;using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public delegate void OnBlackboardKeyUpdated(string key, object value);
public class AIController : MonoBehaviour
{
    [SerializeField] BehaviorTree _behaviorTree;
    PerceptionComp _perceptionComp;

    private Dictionary<string, object> _Blackboard = new Dictionary<string, object>();
    public OnBlackboardKeyUpdated onBlackboardKeyUpdated;
    public void AddBlackboardKey(string key, object defaultValue = null)
    {
        if (!_Blackboard.ContainsKey(key))
        {
            _Blackboard.Add(key, defaultValue);
        }
    }

    public void SetBlackboardKey(string key, object value)
    {
        if (_Blackboard.ContainsKey(key))
        {
            _Blackboard[key] = value;
            if (onBlackboardKeyUpdated != null)
            {
                onBlackboardKeyUpdated.Invoke(key, value);
            }
        }
    }

    public object GetBlackboardValue(string key)
    {
        return _Blackboard[key];
    }

    public BehaviorTree GetBehaviorTree()
    {
        return _behaviorTree;
    }
    // Start is called before the first frame update
    void Start()
    {
        if (_behaviorTree != null)
        {
            _behaviorTree.Init(this);
        }

        _perceptionComp = GetComponent<PerceptionComp>();
        if (_perceptionComp != null)
        {
            _perceptionComp.onPerceptionUpdated += PerceptionUpdated;
        }
    }

    private void PerceptionUpdated(PerceptionStimuli stimuli, bool succesfullysensed)
    {
        if (succesfullysensed)
        {
            SetBlackboardKey("Target", stimuli.gameObject);
        }
        else
        {
            SetBlackboardKey("LastSeenLocation", stimuli.transform.position);
            SetBlackboardKey("Target", null);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (_behaviorTree)
        {
            _behaviorTree.Run();
        }
    }

    
}
