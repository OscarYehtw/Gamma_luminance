using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ST7701S_NB_Gamma;



//using System.Threading;

namespace Gamma_luminance
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
                   ST7701S_NB_Gamma.Class1 F = new Class1();
                 
            F.B0_VOP_B1_VCOM(Convert.ToInt32( VCM.Value), Convert.ToInt32 (VRH.Value));
            F.Input_Gamma_Parameter(Convert.ToInt32(B0_0.Value), Convert.ToInt32(B0_1.Value), Convert.ToInt32(B0_2.Value), Convert.ToInt32(B0_3.Value), Convert.ToInt32(B0_4.Value), Convert.ToInt32(B0_5.Value), Convert.ToInt32(B0_6.Value), Convert.ToInt32(B0_7.Value), Convert.ToInt32(B0_8.Value), Convert.ToInt32(B0_9.Value), Convert.ToInt32(B0_10.Value), Convert.ToInt32(B0_11.Value), Convert.ToInt32(B0_12.Value), Convert.ToInt32(B0_13.Value), Convert.ToInt32(B0_14.Value), Convert.ToInt32(B0_15.Value));
            F.Calculate_Gamma_Voltage_();
//            F.Input_Measure_luminance(Convert.ToDouble(LU_255.Text), Convert.ToDouble(LU_251.Text), Convert.ToDouble(LU_247.Text), Convert.ToDouble(LU_239.Text), Convert.ToDouble(LU_231.Text), Convert.ToDouble(LU_203.Text), Convert.ToDouble(LU_175.Text), Convert.ToDouble(LU_147.Text), Convert.ToDouble(LU_108.Text), Convert.ToDouble(LU_80.Text), Convert.ToDouble(LU_52.Text), Convert.ToDouble(LU_24.Text), Convert.ToDouble(LU_16.Text), Convert.ToDouble(LU_8.Text), Convert.ToDouble(LU_4.Text), Convert.ToDouble(LU_0.Text));
            F.Input_Measure_luminance(Convert.ToDouble(LU_0.Text), Convert.ToDouble(LU_4.Text), Convert.ToDouble(LU_8.Text), Convert.ToDouble(LU_16.Text), Convert.ToDouble(LU_24.Text), Convert.ToDouble(LU_52.Text), Convert.ToDouble(LU_80.Text), Convert.ToDouble(LU_108.Text), Convert.ToDouble(LU_147.Text), Convert.ToDouble(LU_175.Text), Convert.ToDouble(LU_203.Text), Convert.ToDouble(LU_231.Text), Convert.ToDouble(LU_239.Text), Convert.ToDouble(LU_247.Text), Convert.ToDouble(LU_251.Text), Convert.ToDouble(LU_255.Text));
            F.Output_Gamma_Parameter();

           int[] temp = ST7701S_NB_Gamma.Class1.Read_Data;
           
            B1_0.Value = temp[0];
            B1_1.Value = temp[1];
            B1_2.Value = temp[2];
            B1_3.Value = temp[3];
            B1_4.Value = temp[4];
            B1_5.Value = temp[5];
            B1_6.Value = temp[6];
            B1_7.Value = temp[7];
            B1_8.Value = temp[8];
            B1_9.Value = temp[9];
            B1_10.Value = temp[10];
            B1_11.Value = temp[11];
            B1_12.Value = temp[12];
            B1_13.Value = temp[13];
            B1_14.Value = temp[14];
            B1_15.Value = temp[15];
       
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

       
    }
}
