using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Composite
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

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
