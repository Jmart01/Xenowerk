using UnityEngine;

public class BTTask_GetNextPatrolPoint : BTNode
{
    public BTTask_GetNextPatrolPoint(AIController aiController) : base(aiController)
    {
            
    }

    public override EBTTaskResult Execute()
    {
        GameObject nextPatrolPoint = aiController.GetComponent<PatrollingComponent>().GetNextPatrolPoint();
        if (nextPatrolPoint != null)
        {
            aiController.SetBlackboardKey("patrolPoint", nextPatrolPoint);
            return EBTTaskResult.Success;
        }

        return EBTTaskResult.Fail;
    }

    public override EBTTaskResult UpdateTask()
    {
        return EBTTaskResult.Fail;
    }

    public override void FinishTask()
    {
        
    }
}