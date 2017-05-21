using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace EFC.BL
{
    public class AdjustmentManagement
    {

        private static void AddAdjustmentToSelectedCharge(ProtoCharge charge, Adjustment adjustment)
        {
            charge.AdjustmentList.Add(adjustment);
        }

        private static bool CheckifAdjustmentExists(Adjustment adjustment)
        {
            if (adjustment == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static void ValidateAdjustmentBeforeAddingToList(ProtoCharge protoCharge, Adjustment adjustment)
        {
            if(CheckifAdjustmentExists(adjustment)==true)
            {
                AddAdjustmentToSelectedCharge(protoCharge, adjustment);
            }
        }

        public static void CountAdjustmentList(TextBlock adjustmentCounterTextBox, List<Adjustment> adjustmentlist)
        {
            if (adjustmentlist == null)
            {
                adjustmentCounterTextBox.Text = "0";
            }
            else
            {
                adjustmentCounterTextBox.Text = adjustmentlist.Count().ToString();
            }
        }
    }
}
