using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace impulse
{
    public partial class offdesign : Form
    {
        

  
        public offdesign()
        {
            InitializeComponent();
        }
        public static double Ptur;
        public static double ω;
        public static double P00I;
        public static double P2II;
        public static double k;
        public static double T;
        public static double R;
        public static double viscous;
        public static double Dcp;
        public static double debi;
        public static double Wad2I;
        public static double Wads;
        public static double Wad2II;
        public static double speedcoef;
        public static double installcoefangle;
        public static double outputangle;
        public static double hneavr;
        public static double speedconecoef;
        public static double openconeangle;
        public static double deltahtipI;
        public static double deltahhubI;
        public static double delzaZI;
        public static double hbarbI;
       
        public static double profileinstall;
        public static double tbarbI;
        public static double delta;
        public static double kesi;
        public static double beta2ef;
        public static double mdotbary;

        public offdesign(double PPtur, double Pω, double PP00I, double PP2II, double Pk, double PT, double PR, double Pviscous, double PDcp, double Pdebi, double PWad2I, double PWads, double PWad2II, double Pspeedcoef, double Pinstallcoefangle, double Poutputangle, double Phneavr, double Pspeedconecoef, double Popenconeangle, double PdeltahtipI, double PdeltahhubI, double PdelzaZI, double PhbarbI, double Pprofileinstall, double PtbarbI, double Pdelta, double Pkesi, double Pbeta2ef, double Pmdotbary)
        {
            InitializeComponent();                
            Ptur =                                PPtur;
            ω =                                   Pω;
            P00I =                                PP00I;
            P2II =                                PP2II;
            k =                                   Pk;
            T =                                   PT;
            R =                                   PR;
            viscous =                             Pviscous;
            Dcp =                                 PDcp;
            debi =                                Pdebi;
            Wad2I =                               PWad2I;
            Wads =                                PWads;
            Wad2II =                              PWad2II;                           
            speedcoef =                           Pspeedcoef;
            installcoefangle =                    Pinstallcoefangle;
             outputangle = Poutputangle;
           hneavr = Phneavr;
            speedconecoef = Pspeedconecoef;
            openconeangle = Popenconeangle;
            deltahtipI =                          PdeltahtipI;
            deltahhubI =                          PdeltahhubI;
            delzaZI =                             PdelzaZI;
            hbarbI =                              PhbarbI;
            //bIb =                                 PbIb;
            profileinstall =                      Pprofileinstall; 
            tbarbI =                              PtbarbI;                                     
            delta =                               Pdelta;              
            kesi =                                Pkesi;
            beta2ef =                             Pbeta2ef;
            mdotbary =                            Pmdotbary;
        }                                         

        public class point
        {
            public double xvalue
            {
                get;
                set;
            }
            public double yvalue
            {
                get;
                set;
            }
        }
        public List<point> points;
        private void button1_Click(object sender, EventArgs e)
        {
            this.progressBar1.Visible = true;
            points = new List<point>();
            //MessageBox.Show((string) comboBox1.SelectedItem);
            string a = comboBox1.SelectedItem.ToString();
            string b = comboBox2.SelectedItem.ToString();
           

            int segment;
            segment = ((Convert.ToInt32(numericUpDown2.Value) - Convert.ToInt32(numericUpDown1.Value) )/ Convert.ToInt32(numericUpDown3.Value));
            //MessageBox.Show((numericUpDown2.Value.ToString()));
            //MessageBox.Show(numericUpDown1.Value.ToString());
            //MessageBox.Show(segment.ToString());
            this.progressBar1.Value = 10;
            double outpp;
            outpp = (double)numericUpDown1.Value;
            for (int x = 0; x <= numericUpDown3.Value; x++)
            {

                outpp += segment;
                if (outpp> (double)numericUpDown2.Value)
                {
                    outpp = (double)numericUpDown2.Value;
                }
                //MessageBox.Show(outpp.ToString());
                switch (b)
                {
                    
                    case "دور":
                        firstvalue begincalc = new firstvalue(Ptur, outpp, P00I, P2II, k, T, R, viscous, Dcp, debi, Wad2I, Wads, Wad2II);
                        nozel n = new nozel(speedcoef, installcoefangle, hneavr, speedconecoef, openconeangle);
                        firstraw f = new firstraw();
                        chooseprofilefirstlevel ch = new chooseprofilefirstlevel(deltahtipI, deltahhubI, delzaZI, hbarbI, profileinstall, tbarbI);
                        mapprofile m = new mapprofile(kesi, mdotbary);
                        turbin t = new turbin(delta);
                       //MessageBox.Show( firstvalue.calcu().ToString());
                       // MessageBox.Show(turbin.calcPT().ToString()+"-"+ delta.ToString());
                        if (a == "توان")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcPT() });
                        }
                        else if (a == "بازده")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcetaT2() });
                        }
                        break;
                    case "فشار":
                        firstvalue begincalc1 = new firstvalue(Ptur, ω, outpp, P2II, k, T, R, viscous, Dcp, debi, Wad2I, Wads, Wad2II);
                        nozel n1 = new nozel(speedcoef, installcoefangle, hneavr, speedconecoef, openconeangle);
                        firstraw f1 = new firstraw();
                        chooseprofilefirstlevel ch1 = new chooseprofilefirstlevel(deltahtipI, deltahhubI, delzaZI, hbarbI, profileinstall, tbarbI);
                        mapprofile m1 = new mapprofile(kesi, mdotbary);
                        turbin t1 = new turbin(delta);

                        if (a == "توان")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcPT() });
                        }
                        else if (a == "بازده")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcetaT2() });
                        }
                        break;
                    case "دبی":
                        firstvalue begincalc2 = new firstvalue(Ptur, ω, P00I, P2II, k, T, R, viscous, Dcp, debi, Wad2I, Wads, Wad2II);
                        nozel n2 = new nozel(speedcoef, installcoefangle, hneavr, speedconecoef, openconeangle);
                        firstraw f2 = new firstraw();
                        chooseprofilefirstlevel ch2 = new chooseprofilefirstlevel(deltahtipI, deltahhubI, delzaZI, hbarbI, profileinstall, tbarbI);
                        mapprofile m2 = new mapprofile(kesi, mdotbary);
                        turbin t2 = new turbin(delta);
                        if (a == "توان")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcPT() });
                        }
                        else if (a == "بازده")
                        {
                            points.Add(new point { xvalue = outpp, yvalue = turbin.calcetaT2() });
                        }
                        break;


                }
            }
            //MessageBox.Show(points[points.Count-2].xvalue.ToString()+"-"+points[points.Count-2].yvalue.ToString());
            this.progressBar1.Value = 20;
                //System.Windows.Forms.DataVisualization.Charting.Chart();
                chart1.Series.Clear();
                this.progressBar1.Value = 30;
                var series1 = new System.Windows.Forms.DataVisualization.Charting.Series
                {
                    Name = "Series1",
                    Color = System.Drawing.Color.Green,
                    IsVisibleInLegend = false,
                    IsXValueIndexed = true,
                    ChartType = SeriesChartType.Line
                };
                this.progressBar1.Value = 40;
                this.chart1.Series.Add(series1);
                this.progressBar1.Value = 50;
                for (int i = 0; i < points.Count; i++)
                {
                    series1.Points.AddXY(points[i].xvalue, points[i].yvalue);
                //MessageBox.Show(points[i].xvalue.ToString()+"-"+ points[i].yvalue.ToString());
                }
                this.progressBar1.Value = 80;
                chart1.Invalidate();
                this.progressBar1.Value = 100;
                this.progressBar1.Visible = false;
            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Printing.PrintPreview();
        }
            private void offdesign_Load(object sender, EventArgs e)
        {
           
        }
    }
}
