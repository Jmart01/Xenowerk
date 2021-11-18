using UnityEngine;
using UnityEngine.Rendering;

public delegate void AttackTarget();
public class BTTask_Attack : BTNode
{
    private float _attackRange;
    private string _key;
    public BTTask_Attack(AIController aiController, string key,float attackRange) : base(aiController)
    {
        _key = key;
        _attackRange = attackRange;
    }

    public override EBTTaskResult Execute()
    {
        if (aiController.GetBlackboardValue("Target") != null)
        {
            if (GetDestination(out Vector3 destination))
            {
                if (Vector3.Distance(aiController.transform.position, destination) <= _attackRange)
                {
                    aiController._attackTarget.Invoke();
                    return EBTTaskResult.Success;
                }
            }
        }
        else
        {
            return EBTTaskResult.Fail;
        }

        return EBTTaskResult.Fail;
    }

    public override EBTTaskResult UpdateTask()
    {
        return EBTTaskResult.Running;
    }

    public override void FinishTask()
    {
    }
    
    bool GetDestination(out Vector3 Destination)
    {
        Destination = Vector3.negativeInfinity;
        object value = aiController.GetBlackboardValue(_key);

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