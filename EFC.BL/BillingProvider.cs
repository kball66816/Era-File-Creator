﻿namespace EFC.BL
{
    public class BillingProvider : Provider

    {
        public BillingProvider()
        {
            Address = new Address();
        }

        private string name;

        public string Name
        {
            get {
                if (IsAlsoRendering)
                {
                    return FirstName + " " + LastName;
                }

                else
                {
                    return name;
                }
            }

            set
            {
                if (value != name)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }
        private bool isAlsoRendering;

        public bool IsAlsoRendering
        {
            get { return isAlsoRendering; }
            set
            {
                if (value != isAlsoRendering)
                {
                    isAlsoRendering = value;
                    RaisePropertyChanged("IsAlsoRendering");
                }

            }
        }
        public Address Address { get; set; }

    }
}
