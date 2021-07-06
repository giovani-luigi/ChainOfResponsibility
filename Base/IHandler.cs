namespace ChainOfResponsibility.Base {
    public interface IHandler<TRequest, TResponse> {

        IHandler<TRequest, TResponse> NextHandler { set; }

        bool TryHandle(TRequest request, ref TResponse response);
        
    }
}
