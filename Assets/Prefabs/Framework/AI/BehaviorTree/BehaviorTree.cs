using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BehaviorTree : MonoBehaviour
{
    private AIController _aiController;
    private BTNode _Root;

    public void SetRoot(BTNode root)
    {
        _Root = root;
    }

    public virtual void Init(AIController aiController)
    {
        _aiController = aiController;
    }

    public void Run()
    {
        EBTTaskResult result = EBTTaskResult.Fail;
        
        if (!_Root.HasStarted())
        {
            result = _Root.Start();
            if (result != EBTTaskResult.Running)
            {
                _Root.Finish();
                return;
            }
        }

        result = _Root.UpdateTask();
        if (result != EBTTaskResult.Running)
        {
            _Root.Finish();
        }
    }
}
