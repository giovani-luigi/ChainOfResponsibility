namespace ChainOfResponsibility.Base {
    public abstract class HandlerBase<TRequest, TResponse> : IHandler<TRequest, TResponse> {

        public IHandler<TRequest, TResponse> NextHandler { protected get; set; }

        protected HandlerBase() { /* default constructor */ }

        public abstract bool TryHandle(TRequest request, ref TResponse response);
        
    }
}
