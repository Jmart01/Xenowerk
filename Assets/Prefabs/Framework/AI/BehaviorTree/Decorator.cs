public abstract class Decorator : BTNode
{
    private BTNode _child;

    public BTNode GetChild()
    {
        return _child;
    }
    public Decorator(AIController aiController, BTNode child) : base(aiController)
    {
        _child = child;
        _child.Parent = this;
    }

    public override void Finish()
    {
        _child.Finish();
        base.Finish();
    }
}
