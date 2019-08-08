﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using KVDrive;


namespace KVControl
{
    /// <summary>
    /// 指示灯开关
    /// </summary>
    public class KVText : Button, KVBox
    {
        private bool _kvReadOnly;
        private string _kvMenAddr;
        private ITag _kvtag;

        public KVText() : base()
        {
            if (_kvtag == null)
            {
                _kvtag = new BoolTag(1, Storage.Empty, _kvMenAddr);
            }
            this._kvtag.ValueChangeEvent += ValueChange;
        }
        public Color KVTrueColor
        {
            get; set;
        }

        public Color KVFalseColor
        {
            get; set;
        }
        public bool KVReadOnly { get { return _kvReadOnly; } set { _kvReadOnly = value; } }
        public string KVMemAddr { get { return _kvMenAddr; } set { _kvMenAddr = value; } }
        public ITag KVTag { get { return _kvtag; } set { _kvtag = value; } }


        public void ValueChange(object sender, ValueChangeEventArgs e)
        {
            if (e.Value.Boolean)
            {
                this.BackColor = KVTrueColor;
            }
            else
            {
                this.BackColor = KVFalseColor;
            }
        }
    }
}