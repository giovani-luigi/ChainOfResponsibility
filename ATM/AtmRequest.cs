
namespace ChainOfResponsibility.ATM {

    public class AtmRequest {
        
        public decimal TotalAmount { get; }

        public AtmRequest(decimal totalAmount) {
            TotalAmount = totalAmount;
        }

    }

}
