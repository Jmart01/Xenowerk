public enum EBTTaskResult
{
    Success,
    Fail,
    Running
}

public abstract class BTNode
{
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

    public EBTTaskResult Start()
    {
        if (!_Started)
        {
            _Started = true;
            _Finished = false;
            return Execute();
        }
        return EBTTaskResult.Running;
    }

    public void Finish()
    {
        if (!_Finished)
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