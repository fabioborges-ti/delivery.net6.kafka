namespace GroupApp.Delivery.Application.Common;

public abstract class Handler<TRequest> where TRequest : class
{
    protected Handler<TRequest>? _successor;

    public void SetSuccessor(Handler<TRequest> successor)
    {
        _successor = successor;
    }

    public abstract Task Process(TRequest request);
}
