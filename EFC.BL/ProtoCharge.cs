using Common.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL
{
    [Serializable]
    public abstract class ProtoCharge : INotifyPropertyChanged
    {

        public List<Adjustment> AdjustmentList { get; set; }

        public Modifier Modifier { get; set; }

        public Adjustment Adjustment { get; set; }

        private decimal copay;

        public decimal Copay
        {
            get { return copay; }
            set
            {
                if(value!=copay)
                {
                    copay = value;
                    RaisePropertyChanged("Copay");
                }

            }
        }

        private decimal chargeCost;

        public decimal ChargeCost
        {
            get { return chargeCost; }
            set { chargeCost = value; }
        }


        private decimal paymentAmount;

        public decimal PaymentAmount
        {
            get { return paymentAmount; }
            set
            {
                if (value != paymentAmount)
                {
                    paymentAmount = value;
                    RaisePropertyChanged("PaymentAmount");
                    RaisePropertyChanged("CheckAmount");
                }

            }
        }

        public string ProcedureCode { get; set; }
      
        public decimal AllowedAmount
        {
            get
            {
                decimal allowed = PaymentAmount + Copay;
                return allowed;
            }
        }

        public string CountAdjustments
        {
            get { return AdjustmentList.Count.ToString(); }
        }

        [field:NonSerialized]
    public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
