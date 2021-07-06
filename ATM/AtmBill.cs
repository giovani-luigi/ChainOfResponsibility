namespace ChainOfResponsibility.ATM {
    public class AtmBill {

        public decimal Value { get; }

        public AtmBill(decimal value) {
            Value = value;
        }

        public override string ToString() {
            return $"$ {Value:C}";
        }

    }
}
