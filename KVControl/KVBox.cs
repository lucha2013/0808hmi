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
        bool KVReadOnly { get; }
        string KVMemAddr { get; set; }
        ITag[] KVTags { get; set; }
        short KVTagCount { get; }
        void ValueChange(object sender, ValueChangeEventArgs e);


    }
}
