using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace EFC.BL
{
    [Serializable]
    public class AddonCharge:ProtoCharge, ICloneable
    {
        public AddonCharge()
        {
            AdjustmentList = new List<Adjustment>();
            Modifier = new Modifier();
            new Adjustment();
        }

        public object Clone()
        {
            MemoryStream m = new MemoryStream();
            BinaryFormatter b = new BinaryFormatter();
            b.Serialize(m, this);
            m.Position = 0;

            return (AddonCharge)b.Deserialize(m);
        }
    }
}
