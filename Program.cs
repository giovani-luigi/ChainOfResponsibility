using System;
using System.Globalization;
using System.Linq;
using ChainOfResponsibility.ATM;

namespace ChainOfResponsibility {
    class Program {
        
        static void Main(string[] args) {
            
            var atm = new Atm();

            decimal value = 0;
            do {
                Console.WriteLine("Enter value to withdraw: (integer only)");
                if (decimal.TryParse(Console.ReadLine(), NumberStyles.Integer, CultureInfo.InvariantCulture, out value)) {
                    break;
                } 
            } while (true);
            
            var bills = atm.Withdraw(value);

            Console.WriteLine("Here is your cash:\n");

            foreach (var billGroup in bills.GroupBy(bill => bill.Value)) {
                Console.WriteLine($"Bill: ${billGroup.Key}, count = {billGroup.Count()}");
            }

            Console.WriteLine("Enter to exit.");
            Console.ReadLine();

        }
    }
}
