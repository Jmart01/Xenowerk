using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BTTask_AlwaysFail : BTNode
{
    public override EBTTaskResult Execute()
    {
        return EBTTaskResult.Fail;
    }

    public override EBTTaskResult UpdateTask()
    {
        return EBTTaskResult.Fail;
    }

    public override void FinishTask()
    {
        
    }

    public BTTask_AlwaysFail(AIController aiController) : base(aiController)
    {
    }
}
