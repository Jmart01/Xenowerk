public enum EBTTaskResult
{
    Success,
    Fail,
    Running
}

public abstract class BTNode
{
    private bool ShouldAbortTask;

    public int GetNodeIndexInParent()
    {
        if (Parent.GetType() == typeof(Selector) || Parent.GetType() == typeof(Sequence))
        {
            return ((Composite) Parent).GetChildIndex(this);
        }

        return 0;
    }
    public BTNode Parent { set; get; }
    public void AbortTask()
    {
        ShouldAbortTask = true;
    }
    public AIController aiController
    {
        get { return AIC; }
    }
    
    private AIController AIC;

    public BTNode(AIController aiController)
    {
        AIC = aiController;
    }

    public bool HasStarted()
    {
        return _Started;
    }

    private bool _Started;
    private bool _Finished;

    public EBTTaskResult Update()
    {
        if (!ShouldAbortTask)
        {
            return UpdateTask();
        }

        return EBTTaskResult.Fail;
    }

    public EBTTaskResult Start()
    {
        if (!_Started)
        {
            ShouldAbortTask = false;
            _Started = true;
            _Finished = false;
            aiController.GetBehaviorTree().CurrentRunningNode = this;
            return Execute();
        }
        return EBTTaskResult.Running;
    }

    public virtual void Finish()
    {
        if (!_Finished && HasStarted())
        {
            _Finished = true;
            _Started = false;
            FinishTask();
        }
    }

    public abstract EBTTaskResult Execute();
    public abstract EBTTaskResult UpdateTask();
    public abstract void FinishTask();
}