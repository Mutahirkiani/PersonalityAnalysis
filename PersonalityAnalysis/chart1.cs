﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;

namespace PersonalityAnalysis
{
    public partial class chart1 : Form
    {

        public chart1(List<string> x, List<int> y)
        {
            InitializeComponent();
            try
            {
                for (int i = 0; i <= x.Count; i++)
                {
                    this.chart2.Series["Series1"].Points.AddXY(x[i], y[i]);
                }
            }
            catch (Exception e) { }
        }
        private void chart1_Load(object sender, EventArgs e)
        {

        }
    }
}
