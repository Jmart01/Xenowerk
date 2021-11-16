using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class BehaviorTree : MonoBehaviour
{
    private AIController _aiController;
    private BTNode _Root;
    public BTNode CurrentRunningNode { get; set; }

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

        result = _Root.Update();
        if (result != EBTTaskResult.Running)
        {
            _Root.Finish();
        }
    }

    public void Restart()
    {
        _Root.Finish();
    }

    public bool IsRunning(BTNode Node)
    {
        if (GetHeirarchy(CurrentRunningNode).Contains(Node))
        {
            return true;
        }

        return false;
    }

    List<BTNode> GetHeirarchy(BTNode node)
    {
        List<BTNode> Heirarchy = new List<BTNode>();
        BTNode NextInHierarchy = node;
        Heirarchy.Add(NextInHierarchy);
        while (NextInHierarchy.Parent != null)
        {
            Heirarchy.Add(NextInHierarchy.Parent);
            NextInHierarchy = NextInHierarchy.Parent;
        }
        Heirarchy.Reverse();
        return Heirarchy;
    }
    
    public bool IsCurrentLowerThan(BTNode Node)
    {
        List<BTNode> CurrentRunningHeirarchy = GetHeirarchy(CurrentRunningNode);
        List<BTNode> NodeHeirarchy = GetHeirarchy(Node);
        for (int i = 0; i < CurrentRunningHeirarchy.Count && i < NodeHeirarchy.Count; i++)
        {
            BTNode CurrentParent = CurrentRunningHeirarchy[i];
            BTNode NodeParent = NodeHeirarchy[i];
            if (CurrentParent == _Root || NodeParent == _Root)
            {
                continue;
            }

            if (CurrentParent != NodeParent)
            {
                return CurrentParent.GetNodeIndexInParent() > NodeParent.GetNodeIndexInParent();
            }
        }

        return false;
    }
}
