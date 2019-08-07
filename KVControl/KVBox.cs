using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KVControl
{
    public interface KVBox
    {
        bool KVReadOnly { get; set; }
        string KVMemAddr { get; set; }
        ITag KVTag { get; set; }
    }


    public enum KVButtonType
    {
        Button = 1,
        Light = 2,
        ButtonAndLight = 3
    }

}
