using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] BehaviorTree _behaviorTree;

    private Dictionary<string, object> _Blackboard = new Dictionary<string, object>();
    
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
