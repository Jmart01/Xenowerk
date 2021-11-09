using UnityEngine;
using UnityEngine.AI;

public class BTTask_MoveTo : BTNode
{
    private string _keyName;
    private NavMeshAgent _agent;
    private GameObject destination;
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
            destination = (GameObject) aiController.GetBlackboardValue(_keyName);
            if (destination != null)
            {
                _agent.SetDestination(destination.transform.position);
                _agent.isStopped = false;
                return EBTTaskResult.Running;
            }
            
        }

        return EBTTaskResult.Fail;
    }

    public override EBTTaskResult UpdateTask()
    {
        if (Vector3.Distance(aiController.transform.position, destination.transform.position) <= _acceptableRadius)
        {
            return EBTTaskResult.Success;
        }

        return EBTTaskResult.Running;
    }

    public override void FinishTask()
    {
        _agent.isStopped = true;
    }
}
