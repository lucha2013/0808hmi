using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using KVDrive;

namespace KVControl
{
    public interface KVBox
    {
        bool KVReadOnly { get; set; }
        string KVMemAddr { get; set; }
        ITag this[int i] { get; set; }
        KVType Type { get; }
     
    }


    public enum KVType
    {
        Button = 1,
        Light = 2,
        ButtonAndLight = 3,
        NumberInput=4,
        Label=5,
    }

}
