using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL
{
    public class Charge : ProtoCharge
    {
        public Charge()
        {
            AddonChargeList = new List<AddonCharge>();
            AdjustmentList = new List<Adjustment>();
            Modifier = new Modifier();
            Adjustment = new Adjustment();
            DateOfService = DateTime.Today;
        }

        public DateTime DateOfService { get; set; }

        public List<AddonCharge> AddonChargeList { get; set; }

        private decimal TotalCostofAddonCharge
        {
            get
            {
                decimal totalCostOfAddon = this.AddonChargeList.Sum(addon => addon.ChargeCost);
                return totalCostOfAddon;
            }
        }

        private decimal TotalAddonChargesPaid
        {
            get
            {
                decimal totalChargesPaid = AddonChargeList.Sum(addon => addon.PaymentAmount);
                return totalChargesPaid;
            }
        }

        //TODO determine if needed for a loop or segment, interpretations differ depending on 5010 companion
        //public decimal SumOfChargePaid
        //{
        //    get
        //    {
        //        decimal total = TotalPaidforCharge+ TotalAddonChargesPaid;
        //        return total;
        //    }
        //}

        public decimal SumOfChargeCost
        {
            get
            {
                decimal totalCost = ChargeCost+TotalCostofAddonCharge;
                return totalCost;
            }
        }
    }
}
