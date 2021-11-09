public class Sequence : Composite
{
    public Sequence(AIController aiController) : base(aiController)
    {
        
    }
    
    public override EBTTaskResult DetermineResult(EBTTaskResult result)
    {
        if (result == EBTTaskResult.Fail)
        {
            return EBTTaskResult.Fail;
        }

        if (result == EBTTaskResult.Success)
        {
            if (RunNext())
            {
                return EBTTaskResult.Running;
            }
            else
            {
                return EBTTaskResult.Success;
            }
        }
        
        return EBTTaskResult.Running;
    }
}
