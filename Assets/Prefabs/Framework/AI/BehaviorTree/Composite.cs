using System.Collections.Generic;

public abstract class Composite : BTNode
{
    private List<BTNode> _Children;

    public void AddChild(BTNode newChild)
    {
        if (!_Children.Contains(newChild))
        {
            _Children.Add(newChild);
        }
    }

    public bool RunNext()
    {
        _CurrentRunningChild.Finish();
        _CurrentRunningChildIndex++;
        if (_CurrentRunningChildIndex < _Children.Count)
        {
            _CurrentRunningChild = _Children[_CurrentRunningChildIndex];
            return true;
        }

        return false;
    }
    
    private BTNode _CurrentRunningChild;
    private int _CurrentRunningChildIndex;
    protected Composite(AIController aiController) : base(aiController)
    {
        _Children = new List<BTNode>();
    }

    public override EBTTaskResult Execute()
    {
        if (_Children.Count > 0)
        {
            _CurrentRunningChild = _Children[0];
            _CurrentRunningChildIndex = 0;
            return EBTTaskResult.Running;
        }
        return EBTTaskResult.Success;
    }

    public override EBTTaskResult UpdateTask()
    {
        EBTTaskResult result = EBTTaskResult.Fail;
        if (!_CurrentRunningChild.HasStarted())
        {
            result = _CurrentRunningChild.Start();
            return DetermineResult(result);
        }
        result = _CurrentRunningChild.UpdateTask();
        return DetermineResult(result);
    }
    
    public override void FinishTask()
    {
        foreach (var node in _Children)
        {
            node.Finish();
        }
    }

    public abstract EBTTaskResult DetermineResult(EBTTaskResult result);
}