public class BTTask_ClearBlackboardVal : BTNode
{
    private string _key;
    public BTTask_ClearBlackboardVal(AIController aiController, string key) : base(aiController)
    {
        _key = key;
    }

    public override EBTTaskResult Execute()
    {
        aiController.SetBlackboardKey(_key,null);
        if (aiController.GetBlackboardValue(_key) == null)
        {
            return EBTTaskResult.Success;
        }
        else
        {
            return EBTTaskResult.Fail;
        }
    }

    public override EBTTaskResult UpdateTask()
    {
        return EBTTaskResult.Running;
    }

    public override void FinishTask()
    {
        throw new System.NotImplementedException();
    }
}
