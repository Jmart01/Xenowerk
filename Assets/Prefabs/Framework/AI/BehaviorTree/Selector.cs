using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    public Selector(AIController aiController) : base(aiController)
    {
    }

    public override EBTTaskResult DetermineResult(EBTTaskResult result)
    {
        if (result == EBTTaskResult.Fail)
        {
            if (RunNext())
            {
                return EBTTaskResult.Running;
            }
            else
            {
                return EBTTaskResult.Fail;
            }
        }

        if (result == EBTTaskResult.Success)
        {
            return EBTTaskResult.Success;
        }
        
        
        return EBTTaskResult.Running;
    }
}
