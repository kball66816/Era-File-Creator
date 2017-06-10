﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace EFC.BL
{
    [Serializable]
    public class Charge : ProtoCharge
    {
        public Charge()
        {
            Id = Guid.NewGuid();
            AddonChargeList = new List<AddonCharge>();
            AdjustmentList = new List<Adjustment>();
            Modifier = new Modifier();
            DateOfService = DateTime.Today;
            PlaceOfService = new PlaceOfService();
        }

        public PlaceOfService PlaceOfService { get; set; }

        public DateTime DateOfService { get; set; }

        public List<AddonCharge> AddonChargeList { get; set; }

        private decimal TotalCostofAddonCharge
        {
            get
            {
                decimal totalCostOfAddon = AddonChargeList.Sum(addon => addon.ChargeCost);
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

        
        public decimal SumOfChargePaid
        {
            get
            {
                decimal total = ChargeCost+ TotalAddonChargesPaid;
                return total;
            }
        }

        public decimal SumOfChargeCost
        {
            get
            {
                decimal totalCost = ChargeCost+TotalCostofAddonCharge;
                return totalCost;
            }
        }

        public Guid Id { get; private set; }
    }
}
