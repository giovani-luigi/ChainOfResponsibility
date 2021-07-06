using System.Collections.Generic;

namespace ChainOfResponsibility.ATM {
    public class Atm {

        private readonly AtmHandlerBase _root;

        public Atm() {
            _root = new AtmHandler100() {
                NextHandler = new AtmHandler10() {
                    NextHandler = new AtmHandler1()
                }
            };
        }

        public IEnumerable<AtmBill> Withdraw(decimal amount) {
            var response = new AtmResponse();
            _root.TryHandle(new AtmRequest(amount), ref response);
            return response.GetBills();
        }

    }
}
