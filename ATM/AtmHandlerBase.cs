using System;
using ChainOfResponsibility.Base;

namespace ChainOfResponsibility.ATM {

    public abstract class AtmHandlerBase : HandlerBase<AtmRequest, AtmResponse> {
        
        public decimal BillValue { get; }

        protected AtmHandlerBase(decimal billValue) {
            BillValue = billValue;
        }

        public override bool TryHandle(AtmRequest request, ref AtmResponse response) {

            // calculate amount to handle
            decimal diff = request.TotalAmount - response.HandledAmount;

            // calculate how many bills we need
            int billsToHandle = (int)Math.Truncate(diff / BillValue);
            
            // update request and response
            response.AddBill(new AtmBill(BillValue), billsToHandle);

            // forward if not handled completely
            if (response.HandledAmount < request.TotalAmount) {
                if (NextHandler is null) {
                    return false; // could not handle request
                } else {
                    return NextHandler.TryHandle(request, ref response);
                }
            } else {
                return true;
            }
        }

    }
}
