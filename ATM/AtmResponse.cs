using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ChainOfResponsibility.ATM {

    public class AtmResponse {

        private readonly List<AtmBill> _bills;

        public AtmResponse() {
            _bills = new List<AtmBill>();
        }

        public decimal HandledAmount {
            get {
                return _bills.Sum(bill => bill.Value);
            }
        }

        public void AddBill(AtmBill bill, int count) {
            for (int i = 0; i < count; i++) {
                _bills.Add(bill);
            }
        }

        public IReadOnlyList<AtmBill> GetBills() {
            return new ReadOnlyCollection<AtmBill>(_bills);
        }

    }
}
