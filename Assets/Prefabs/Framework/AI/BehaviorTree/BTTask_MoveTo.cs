using UnityEngine;
using UnityEngine.AI;

public class BTTask_MoveTo : BTNode
{
    private string _keyName;
    private NavMeshAgent _agent;
    private float _acceptableRadius;
    
    public BTTask_MoveTo(AIController aiController, string keyName, float acceptableRadius) : base(aiController)
    {
        _keyName = keyName;
        _agent = aiController.GetComponent<NavMeshAgent>();
        _acceptableRadius = acceptableRadius;
    }

    public override EBTTaskResult Execute()
    {
        if (_agent)
        {
            if (GetDestination(out Vector3 destination))
            {
                _agent.SetDestination(destination);
                _agent.isStopped = false;
                return EBTTaskResult.Running;
            }
        }
        
        return EBTTaskResult.Fail;
    }

    public override EBTTaskResult UpdateTask()
    {
        if (GetDestination(out Vector3 destination))
        {
            _agent.SetDestination(destination);
            if (Vector3.Distance(aiController.transform.position, destination) <= _acceptableRadius)
            {
                return EBTTaskResult.Success;
            }
        }
        else
        {
            return EBTTaskResult.Fail;
        }
        return EBTTaskResult.Running;
    }

    public override void FinishTask()
    {
        _agent.isStopped = true;
    }

    bool GetDestination(out Vector3 Destination)
    {
        Destination = Vector3.negativeInfinity;
        object value = aiController.GetBlackboardValue(_keyName);

        if (value == null)
        {
            return false;
        }
        if (value.GetType() == typeof(GameObject))
        {
            Destination = ((GameObject) value).transform.position;
            return true;
        }

        if (value.GetType() == typeof(Vector3))
        {
            Destination = (Vector3) value;
            return true;
        }

        return false;
    }
}
