﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Localize_WinFormsResourceShift
{
    public partial class Form2 : Form
    {
        public Form2(string sCulture)
        {
            Thread.CurrentThread.CurrentCulture
                = new System.Globalization.CultureInfo(sCulture);
            Thread.CurrentThread.CurrentUICulture
                = new System.Globalization.CultureInfo(sCulture);

            InitializeComponent();
        }
    }
}
