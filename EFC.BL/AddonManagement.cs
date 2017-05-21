using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFC.BL
{
    public class AddonManagement
    {

        private static bool CheckIfAddonExists(AddonCharge addon)
        {
            if (addon == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void AddAddonToSelectedCharge(Charge charge, AddonCharge addon)
        {
            charge.AddonChargeList.Add(addon);
        }

        public static void ValidateAddonBeforeAddingToList(Charge charge, AddonCharge addon)
        {
            if (CheckIfAddonExists(addon) == true)

            {
                AddAddonToSelectedCharge(charge, addon);
            }
        }
    }
}
