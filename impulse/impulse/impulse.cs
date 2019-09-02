using Newtonsoft.Json;
using System;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;

namespace impulse
{
    public partial class Impulse : Form
    {
        public Impulse()
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
        //public static double bIb;
        public static double profileinstall;
        public static double tbarbI;
        public static double delta;
        public static double kesi;
        public static double beta2ef;
        public static double mdotbary;


        private void calculate_Click(object sender, EventArgs e)
        {
            progressBar1.Visible = true;
            tabControl1.Visible = true;
           
            

            //firstvalue
            Ptur               = Convert.ToDouble(numturpow.Value);
            ω                  = Convert.ToDouble(numfreqrot.Value); ;
            P00I               = Convert.ToDouble(numinitalturpressure.Value);
            P2II               = Convert.ToDouble(numturoutputpressure.Value);
            k                  = Convert.ToDouble(numadiabaticoef.Value);
            T                  = Convert.ToDouble(numinitaltemp.Value);
            R                  = Convert.ToDouble(gascoef.Value);
            viscous            = Convert.ToDouble(numgasdynamicviscous.Value);
            Dcp                = Convert.ToDouble(numaveragediameter.Value);
            debi               = Convert.ToDouble(numdebi.Value);
            Wad2I              = Convert.ToDouble(numWad2I.Value);
            Wads               = Convert.ToDouble(numWads.Value);
            Wad2II             = Convert.ToDouble(numWad2II.Value);
            //nozle
            speedcoef          = Convert.ToDouble(numՓ.Value);
            installcoefangle   = (Convert.ToDouble(numisnstalldeg.Value) * Math.PI) / 180;
            hneavr             = Convert.ToDouble(numhne.Value);
            speedconecoef      = Convert.ToDouble(numspeedconecoef.Value);
            openconeangle      = (Convert.ToDouble(numopencone.Value) * Math.PI) / 180;
            //chooseprofilefirstlevel
            deltahtipI         = Convert.ToDouble(numdeltahtipI.Value)  * Math.Pow(10, -3);
            deltahhubI         = Convert.ToDouble(numdeltahhubI.Value)  * Math.Pow(10, -3);
            delzaZI            = Convert.ToDouble(numdelzaZI.Value);
            hbarbI             = Convert.ToDouble(numhbarbI.Value);
            //bIb                = Convert.ToDouble(numbIb.Value);
            profileinstall     = Convert.ToDouble(numprofileinstall.Value);
            tbarbI             = Convert.ToDouble(numtbarbI.Value);
            //turbin
            delta              = Convert.ToDouble(numdelta.Value);
            //mapprofile
            kesi               = Convert.ToDouble(numkesi.Value);
            //beta2ef            = Convert.ToDouble(numbeta2ef.Value);
            mdotbary           = Convert.ToDouble(nummdotbary.Value);
            progressBar1.Value = 10;
            
            firstvalue begincalc = new firstvalue(Ptur, ω, P00I, P2II, k, T, R, viscous, Dcp, debi,Wad2I,Wads,Wad2II);
            progressBar1.Value = 20;
            //MessageBox.Show(speedconecoef.ToString());
            nozel n = new nozel(speedcoef, installcoefangle, hneavr, speedconecoef, openconeangle);
            progressBar1.Value = 30;
            firstraw f = new firstraw();
            progressBar1.Value = 40;
            chooseprofilefirstlevel ch = new chooseprofilefirstlevel(deltahtipI, deltahhubI, delzaZI, hbarbI, profileinstall, tbarbI);
            progressBar1.Value = 50;
            mapprofile m = new mapprofile(kesi, mdotbary);
            progressBar1.Value = 60;
            turbin t = new turbin(delta);
            progressBar1.Value = 70;
            setlable();
            progressBar1.Value = 80;
            saveres();
            progressBar1.Value = 100;
            progressBar1.Visible = false;
        }

        public void setlable()
        {
            round r = new round();
            // firstvalue
            lblcalcu.Text               = r.rond(firstvalue.calcu());
            lblcalcδ.Text               = r.rond(firstvalue.calcδ());
            lblcalcWoad.Text            = r.rond(firstvalue.calcWoad());
            lblcalcCad.Text             = r.rond(firstvalue.calcCad());
            lblcalcspeedratio.Text      = r.rond(firstvalue.calcspeedratio());
            lblcalcworkcoef.Text        = r.rond(firstvalue.calcworkcoef());
            lblcalcMdotT.Text           = r.rond(firstvalue.calcMdotT());
            lblcalcȠt.Text              = r.rond(firstvalue.calcȠt());
            lblcalcρTI.Text             = r.rond(firstvalue.calcρTI());
            lblcalcρTS.Text             = r.rond(firstvalue.calcρTS());
            lblcalcρTII.Text            = r.rond(firstvalue.calcρTII());

            // nozle
            lblcalcwad1I.Text           = r.rond(nozel.calcwad1I());
            lblcalcc1adI.Text           = r.rond(nozel.calcc1adI());
            lblspeedcoef.Text           = r.rond(nozel.speedcoef);
            lblcalcC1I.Text             = r.rond(nozel.calcC1I());
            lblcalcaCI.Text             = r.rond(nozel.calcastarCI());
            lblcalcMc1I.Text            = r.rond(nozel.calcMstarc1I());
            lblinstallcoefangle.Text    = r.rond(nozel.installcoefangle);
            lbloutputangle.Text         = r.rond(nozel.outputangle);
            lblcalcσ1I.Text             = r.rond(nozel.calcσ1I());
            lblcalcP01I.Text            = r.rond(nozel.calcP01I());
            lblcalcP1I.Text             = r.rond(nozel.calcP1I());
            lblcalcT1I.Text             = r.rond(nozel.calcT1I());
            lblcalcρ1I.Text             = r.rond(nozel.calcρ1I());
            lbla1I.Text                 = r.rond(nozel.calca1I());
            lblM1I.Text                 = r.rond(nozel.calcM1I());
            lblhne.Text                 = r.rond(nozel.calchne());
            lblFmin.Text                = r.rond(nozel.calcFmin());
            lblpressconeratio.Text      = Convert.ToDouble(numspeedconecoef.Value).ToString();
            σStar1.Text                 = r.rond(nozel.calcpressconeratio());
            Pstarlbl.Text               = r.rond(nozel.calcPstar());
            Tstarlbl.Text               = r.rond(nozel.calcTstar());
            densitystarlbl.Text         = r.rond(nozel.calcdensitystar());
            Fprm1lbl.Text               = r.rond(nozel.calcFprm1());
            FNelbl.Text                 = r.rond(nozel.calcFNe());
            lblε1.Text                  = r.rond(nozel.calcε1());
            lblNN.Text                  = r.rond(nozel.calcNN());
            hne2lbl.Text                = r.rond(nozel.calchne2());
            aNelbl.Text                 = r.rond(nozel.calcaNe());
            tNlbl.Text                  = r.rond(nozel.calctN());
            lbldmin.Text                = r.rond(nozel.calcdmin());
            spdconecoeflbl.Text         = r.rond(nozel.speedconecoef);
            lstarlbl.Text               = r.rond(nozel.calclstar());
                                        
            // firstraw                 
            w1Ilbl.Text                 = r.rond(firstraw.calcw1I());
            MstaruIlbl.Text             = r.rond(firstraw.calcMstaruI());
            T0WIlbl.Text                = r.rond(firstraw.calcT0WI());
            astarwIlbl.Text             = r.rond(firstraw.calcastarwI());
            Mstarw1Ilbl.Text            = r.rond(firstraw.calcMstarw1I());
            Mw1Ilbl.Text                = r.rond(firstraw.calcMw1I());
            P0w1Ilbl.Text               = r.rond(firstraw.calcP0w1I());
            beta1Ilbl.Text              = r.rond(firstraw.calcbeta1I());
            w2adIlbl.Text               = r.rond(firstraw.calcw2adI());
            T02wadIlbl.Text             = r.rond(firstraw.calcT02wadI());
            T2adI.Text                  = r.rond(firstraw.calcT2adI());
            a2adIlbl.Text               = r.rond(firstraw.calca2adI());
            M2TIlbl.Text                = r.rond(firstraw.calcM2TI());

            // chooseprofilefirstlevel  
            deltahtipIlbl.Text          = r.rond(chooseprofilefirstlevel.deltahtipI      );
            deltahhubIlbl.Text          = r.rond(chooseprofilefirstlevel. deltahhubI      );
            hinIlbl.Text                = r.rond(chooseprofilefirstlevel. calchinI()       );
            delzaZIlbl.Text             = r.rond(chooseprofilefirstlevel. delzaZI         );
            hbarbIlbl.Text              = r.rond(chooseprofilefirstlevel. hbarbI          );
            bIblbl.Text                 = r.rond(chooseprofilefirstlevel. calcBIB()             );
            profileinstalllbl.Text      = r.rond(chooseprofilefirstlevel. profileinstall  );
            tbarbIlbl.Text              = r.rond(chooseprofilefirstlevel. tbarbI);                         
            lblcalctprimebI.Text        = r.rond(chooseprofilefirstlevel.calctprimebI());
            lblcalcNbI.Text             = r.rond(chooseprofilefirstlevel.calcNbI());
            lblcalctbI.Text             = r.rond(chooseprofilefirstlevel.calctbI());

            // mapprofile               
            kesilbl.Text                = r.rond(mapprofile.kesi);
            si1lbl.Text                 = r.rond(mapprofile.calcsi1());
            beta2eflbl.Text             = r.rond(mapprofile.calcbeta2ef());
            w2Ilbl.Text                 = r.rond(mapprofile.calcw2I());
            calcMsarw2Ilbl.Text         = r.rond(mapprofile.calcMsarw2I());
            calcsigma2Ilbl.Text         = r.rond(mapprofile.calcsigma2I());
            calcqMstarw2Ilbl.Text       = r.rond(mapprofile.calcqMstarw2I());
            mdotbarylbl.Text            = r.rond(mapprofile.mdotbary);
            calcmdotprimeT.Text         = r.rond(mapprofile.calcmdotprimeT());
            calch2bI.Text               = r.rond(mapprofile.calch2bI());
            calcT2I.Text                = r.rond(mapprofile.calcT2I());
            calcC2I.Text                = r.rond(mapprofile.calcC2I());
            calcalpha2Ilbl.Text         = r.rond(mapprofile.calcalpha2I());
            calcT02I.Text               = r.rond(mapprofile.calcT02I());
            calcastarC2Ilbl.Text        = r.rond(mapprofile.calcastarC2I());
            calcMstarC2Ilbl.Text        = r.rond(mapprofile.calcMstarC2I());
            calcP02ilbl.Text            = r.rond(mapprofile.calcP02i());

            // turbin                   
            calcWuIlbl.Text              = r.rond(turbin.calcWuI());
            calcWu.Text                  = r.rond(turbin.calcWu());
            calcetaulbl.Text             = r.rond(turbin.calcetau());
            calcetakIlbl.Text            = r.rond(turbin.calcetakI());
            calcReglbl.Text              = r.rond(turbin.calcReg());
            calcffric_diskll.Text        = r.rond(turbin.calcffric_disk());
            calcffric_diskTur.Text       = r.rond(turbin.calcPfric_diskTur());
            calcDbandlbl.Text            = r.rond(turbin.calcDband());
            calcDeltar1lbl.Text          = r.rond(turbin.calcDeltar1());
            calcReband.Text              = r.rond(turbin.calcReband());
            calcffric_bandlbl.Text       = r.rond(turbin.calcffric_band());
            calcbbandlbl.Text            = r.rond(turbin.calcbband());
            calcPfric_bandlbl.Text       = r.rond(turbin.calcPfric_band());
            calcPepsilonI.Text           = r.rond(turbin.calcPepsilonI());
            calcPTadlbl.Text             = r.rond(turbin.calcPTad());
            calcPTbl.Text                = r.rond(turbin.calcPT());
            calcWTlbl.Text               = r.rond(turbin.calcWT());
            lblcalcetaT.Text             = r.rond(turbin.calcetaT());
            calcWbarTlbl.Text            = r.rond(turbin.calcWbarT());
            calcetau2lbl.Text            = r.rond(turbin.calcetau2());
            calcepsilonfric_disklbl.Text = r.rond(turbin.calcepsilonfric_disk());
            calcepsilonfric_bandlbl.Text = r.rond(turbin.calcepsilonfric_band());
            calcepsilonepsilonIlbl.Text  = r.rond(turbin.calcepsilonepsilonI());
            calcetaT2.Text               = r.rond(turbin.calcetaT2());
            deltalbl.Text                = r.rond(turbin.delta);
            calcetaTmaxlbl.Text          = r.rond(turbin.calcetaTmax());
                                                                                     
        }                              

        public static void saveres()
        {
            round r = new round();
            result re = new result();
  re.calcu                                               = r.rondd(firstvalue.calcu());
  re.calcδ                                               = r.rondd(firstvalue.calcδ());
  re.calcWoad                                            = r.rondd(firstvalue.calcWoad());
  re.calcCad                                             = r.rondd(firstvalue.calcCad());
  re.calcspeedratio                                      = r.rondd(firstvalue.calcspeedratio());
  re.calcworkcoef                                        = r.rondd(firstvalue.calcworkcoef());
  re.calcMdotT                                           = r.rondd(firstvalue.calcMdotT());
  re.calcȠt                                              = r.rondd(firstvalue.calcȠt());
  re.calcρTI                                             = r.rondd(firstvalue.calcρTI());
  re.calcρTS                                             = r.rondd(firstvalue.calcρTS());
  re.calcρTII                                            = r.rondd(firstvalue.calcρTII());


            re.calcwad1I                                           = r.rondd(nozel.calcwad1I());
  re.calcc1adI                                           = r.rondd(nozel.calcc1adI());
  re.speedcoef                                           = r.rondd(nozel.speedcoef);
  re.calcC1I                                             = r.rondd(nozel.calcC1I());
  re.calcastarCI                                         = r.rondd(nozel.calcastarCI());
  re.calcMstarc1I                                        = r.rondd(nozel.calcMstarc1I());
  re.installcoefangle                                    = r.rondd(nozel.installcoefangle);
  re.outputangle                                         = r.rondd(nozel.outputangle);
  re.calcσ1I                                             = r.rondd(nozel.calcσ1I());
  re.calcP01I                                            = r.rondd(nozel.calcP01I());
  re.calcP1I                                             = r.rondd(nozel.calcP1I());
            re.calcT1I                                             = r.rondd(nozel.calcT1I());
  re.calca1I                                             = r.rondd(nozel.calca1I());
  re.calcM1I                                             = r.rondd(nozel.calcM1I());
  re.calchne                                             = r.rondd(nozel.calchne());
  re.calcFmin                                            = r.rondd(nozel.calcFmin());
  re.calcpressconeratio                                  = r.rondd(nozel.calcpressconeratio());
  re.calcσStar1                                          = r.rondd(nozel.calcσStar1());
  re.calcPstar                                           = r.rondd(nozel.calcPstar());
  re.calcTstar                                           = r.rondd(nozel.calcTstar());
  re.calcdensitystar                                     = r.rondd(nozel.calcdensitystar());
  re.calcFprm1                                           = r.rondd(nozel.calcFprm1());
            re.calcFNe                                             = r.rondd(nozel.calcFNe());
  re.calcε1                                              = r.rondd(nozel.calcε1());
  re.calcNN                                              = r.rondd(nozel.calcNN());
  re.calchne2                                            = r.rondd(nozel.calchne2());
  re.calcaNe                                             = r.rondd(nozel.calcaNe());
  re.calctN                                              = r.rondd(nozel.calctN());
  re.calcdmin                                            = r.rondd(nozel.calcdmin());
  re.speedconecoef                                       = r.rondd(nozel.speedconecoef);
  re.calclstar                                           = r.rondd(nozel.calclstar());
                                                   
                                                     
            re.calcw1I                              = r.rondd(firstraw.calcw1I());
            re.calcMstaruI                                          = r.rondd(firstraw.calcMstaruI());
  re.calcT0WI                                             = r.rondd(firstraw.calcT0WI());
  re.calcastarwI                                          = r.rondd(firstraw.calcastarwI());
  re.calcMstarw1I                                         = r.rondd(firstraw.calcMstarw1I());
  re.calcMw1I                                             = r.rondd(firstraw.calcMw1I());
  re.calcP0w1I                                            = r.rondd(firstraw.calcP0w1I());
  re.calcbeta1I                                           = r.rondd(firstraw.calcbeta1I());
  re.calcw2adI                                            = r.rondd(firstraw.calcw2adI());
  re.calcT02wadI                                          = r.rondd(firstraw.calcT02wadI());
  re.calcT2adI                                            = r.rondd(firstraw.calcT2adI());
  re.calca2adI                                            = r.rondd(firstraw.calca2adI());
  re.calcM2TI                                             = r.rondd(firstraw.calcM2TI());
                                                     
                                                       
            re.deltahtipI                              = r.rondd(chooseprofilefirstlevel.deltahtipI      );
  re. deltahhubI                                                    = r.rondd(chooseprofilefirstlevel. deltahhubI      );
  re. calchinI                                            = r.rondd(chooseprofilefirstlevel. calchinI()       );
  re. delzaZI                                             = r.rondd(chooseprofilefirstlevel. delzaZI         );
  re. hbarbI                                              = r.rondd(chooseprofilefirstlevel. hbarbI          );
  re. bIb                                                 = r.rondd(chooseprofilefirstlevel.calcBIB());
  re. profileinstall                                      = r.rondd(chooseprofilefirstlevel. profileinstall  );
  re. tbarbI                                              = r.rondd(chooseprofilefirstlevel. tbarbI);                         
  re.calctprimebI                                         = r.rondd(chooseprofilefirstlevel.calctprimebI());
  re.calcNbI                                              = r.rondd(chooseprofilefirstlevel.calcNbI());
  re.calctbI                                              = r.rondd(chooseprofilefirstlevel.calctbI());
                                                     
                                                       
                                                     
            re.kesi                             = r.rondd(mapprofile.kesi);
            re.calcsi1                                           = r.rondd(mapprofile.calcsi1());
  re.beta2ef                                                        = r.rondd(mapprofile.calcbeta2ef());
  re.calcw2I                                              = r.rondd(mapprofile.calcw2I());
  re.calcMsarw2I                                          = r.rondd(mapprofile.calcMsarw2I());
  re.calcsigma2I                                          = r.rondd(mapprofile.calcsigma2I());
  re.calcqMstarw2I                                        = r.rondd(mapprofile.calcqMstarw2I());
  re.mdotbary                                             = r.rondd(mapprofile.mdotbary);
  re.calcmdotprimeT                                       = r.rondd(mapprofile.calcmdotprimeT());
  re.calch2bI                                             = r.rondd(mapprofile.calch2bI());
  re.calcT2I                                              = r.rondd(mapprofile.calcT2I());
  re.calcC2I                                              = r.rondd(mapprofile.calcC2I());
  re.calcalpha2I                                          = r.rondd(mapprofile.calcalpha2I());
  re.calcT02I                                             = r.rondd(mapprofile.calcT02I());
  re.calcastarC2I                                         = r.rondd(mapprofile.calcastarC2I());
  re.calcMstarC2I                                         = r.rondd(mapprofile.calcMstarC2I());
   re.calcP02i                                            = r.rondd(mapprofile.calcP02i());
                                                     
                                                     
    re.calcetakI                                = r.rondd(turbin.calcetakI());
   re.calcReg                                           = r.rondd(turbin.calcReg());
   re.calcffric_disk                                                = r.rondd(turbin.calcffric_disk());
   re.calcffric_diskTur                                    = r.rondd(turbin.calcffric_diskTur());
   re.calcDband                                            = r.rondd(turbin.calcDband());
   re.calcDeltar1                                          = r.rondd(turbin.calcDeltar1());
   re.calcReband                                           = r.rondd(turbin.calcReband());
   re.calcffric_band                                       = r.rondd(turbin.calcffric_band());
   re.calcbband                                            = r.rondd(turbin.calcbband());
   re.calcPfric_band                                       = r.rondd(turbin.calcPfric_band());
   re.calcPepsilonI                                        = r.rondd(turbin.calcPepsilonI());
            re.calcPTad                                    = r.rondd(turbin.calcPTad());
   re.calcPT                                               = r.rondd(turbin.calcPT());
   re.calcWT                                                        = r.rondd(turbin.calcWT());
   re.calcetaT                                             = r.rondd(turbin.calcetaT());
   re.calcWbarT                                            = r.rondd(turbin.calcWbarT());
   re.calcetau2                                            = r.rondd(turbin.calcetau2());
   re.calcepsilonfric_disk                               = r.rondd(turbin.calcepsilonfric_disk());
   re.calcepsilonfric_band                               = r.rondd(turbin.calcepsilonfric_band());
   re.calcepsilonepsilonI                                 = r.rondd(turbin.calcepsilonepsilonI());
   re.calcetaT2                                            = r.rondd(turbin.calcetaT2());
   re.delta                                                = r.rondd(turbin.delta);
   re.calcetaTmax                                             = r.rondd(turbin.calcetaTmax());
            int a = 0;
            string json = JsonConvert.SerializeObject(re);
            for (int x =0;x<int.MaxValue;x++)
            {
                if (File.Exists(Application.StartupPath + @"\output\output"+a+".txt"))
                {
                    a++;
                }
                else
                {
                    File.WriteAllText(Application.StartupPath + @"\output\output" + a + ".txt", json);
                    break;
                }
                

            }
            
        }                                                                                              


        public static void error (string message)
        {
            MessageBox.Show(message.ToString(),"خطا",MessageBoxButtons.OK,MessageBoxIcon.Error);
        }
      
        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label84_Click(object sender, EventArgs e)
        {

        }

        private void label97_Click(object sender, EventArgs e)
        {

        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            setting formseting = new setting();
            formseting.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string path2 = Application.StartupPath + @"\output";
            if(!Directory.Exists(path2))
            {
                DirectoryInfo di = Directory.CreateDirectory( path2);
            }

            toolTip1.SetToolTip(this.calculate, "شروع محاسبات");
            toolTip1.SetToolTip(this.printfirstvalue, "پرینت اخرین محاسبات");
            string path = Application.StartupPath + @"\input.json";


            using (StreamWriter sw = (File.Exists(path)) ? File.AppendText(path) : File.CreateText(path))
            {
                
            }
            string path1 = Application.StartupPath + @"\setting.json";


            using (StreamWriter sw = (File.Exists(path1)) ? File.AppendText(path1) : File.CreateText(path1))
            {

            }

            StreamReader reader = new StreamReader(Application.StartupPath + @"\input.json");
            string jsonValue = reader.ReadToEnd();
            reader.Close();
            input.inp a = JsonConvert.DeserializeObject<input.inp>(jsonValue);

            numfreqrot.Value = a.numfreqrot;
            numinitalturpressure.Value = a.numinitalturpressure;
            numturoutputpressure.Value = a.numturoutputpressure;
            numadiabaticoef.Value = a.numadiabaticoef;
            numinitaltemp.Value = a.numinitaltemp;
            gascoef.Value = a.gascoef;
            numgasdynamicviscous.Value = a.numgasdynamicviscous;
            numaveragediameter.Value = a.numaveragediameter;
            numdebi.Value = a.numdebi;
            numWad2I.Value = a.numWad2I;
            numWads.Value = a.numWads;
            numWad2II.Value = a.numWad2II;
            numՓ.Value = a.numՓ;
            numisnstalldeg.Value = a.numisnstalldeg;
            numhne.Value = a.numhne;
            numspeedconecoef.Value = a.numspeedconecoef;
            numopencone.Value = a.numopencone;
            numdelta.Value = a.numdelta;
            numdeltahtipI.Value = a.numdeltahtipI;
            numdeltahhubI.Value = a.numdeltahhubI;
            numdelzaZI.Value = a.numdelzaZI;
            numhbarbI.Value = a.numhbarbI;
            //numbIb.Value = a.numbIb;
            numprofileinstall.Value = a.numprofileinstall;
            numtbarbI.Value = a.numtbarbI;
            numkesi.Value = a.numkesi;
            //numbeta2ef.Value = a.numbeta2ef;
            nummdotbary.Value = a.nummdotbary;
          
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            DialogResult a = 
            MessageBox.Show("آیا می خواهید اخرین ورودی ذخیره شود؟", "ذخیره ورودی", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
            if (a== DialogResult.Yes)
            {
                input.inp b = new input.inp();
                b.numfreqrot =                                 numfreqrot.Value;
                b.numinitalturpressure =                      numinitalturpressure.Value    ; 
                b.numturoutputpressure =                      numturoutputpressure.Value    ; 
                b.numadiabaticoef=                             numadiabaticoef.Value        ;  
                b.numinitaltemp=                              numinitaltemp.Value           ; 
                b.gascoef=                                     gascoef.Value                ;  
                b.numgasdynamicviscous=                        numgasdynamicviscous.Value   ;  
                b.numaveragediameter=                          numaveragediameter.Value     ;  
                b.numdebi=                                     numdebi.Value                ;  
                b.numWad2I=                                    numWad2I.Value               ;  
                b.numWads=                                     numWads.Value                ;  
                b.numWad2II=                                   numWad2II.Value              ;  
                b.numՓ=                                        numՓ.Value                   ;  
                b.numisnstalldeg=                              numisnstalldeg.Value         ;  
                b.numhne=                                      numhne.Value                 ;  
                b.numspeedconecoef=                            numspeedconecoef.Value       ;  
                b.numopencone=                                 numopencone.Value            ;  
                b.numdelta=                                    numdelta.Value               ;  
                b.numdeltahtipI=                               numdeltahtipI.Value          ;  
                b.numdeltahhubI=                               numdeltahhubI.Value;
                b.numdelzaZI=                                  numdelzaZI.Value             ;    
                b.numhbarbI=                                   numhbarbI.Value              ;    
                //b.numbIb=                                      numbIb.Value                 ;    
                b.numprofileinstall=                           numprofileinstall.Value      ;    
                b.numtbarbI=                                   numtbarbI.Value              ;    
                b.numkesi=                                     numkesi.Value                ;    
                //b.numbeta2ef=                                  numbeta2ef.Value             ;    
                b.nummdotbary=                                 nummdotbary.Value            ;    
                                                                                            

                string json = JsonConvert.SerializeObject(b);

                File.WriteAllText(Application.StartupPath + @"\input.json", json);
            }
        }

        private void printToolStripMenuItem_RightToLeftChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }
       

        Bitmap memoryImage;

        private void CaptureScreen()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = this.tabPage1.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            //Size ss = new Size(1500, 1500);
            
            memoryGraphics.CopyFromScreen(this.Location.X, this.Location.Y, this.tabPage1.Height, this.tabPage1.Width, s);
        }
        private string documentContents;

        // Declare a variable to hold the portion of the document that
        // is not printed.
        private string stringToPrint;
        private void ReadDocument()
        {
            var directory = new DirectoryInfo(Application.StartupPath + @"\output\");
            var myFile = directory.GetFiles()
             .OrderByDescending(f => f.LastWriteTime)
             .First();

            printDocument1.DocumentName = myFile.ToString();
            using (FileStream stream = new FileStream(Application.StartupPath + @"\output\"+myFile.ToString(), FileMode.Open))
            using (StreamReader reader = new StreamReader(stream))
            {
                documentContents = reader.ReadToEnd();
            }
            stringToPrint = documentContents;
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            int charactersOnPage = 0;
            int linesPerPage = 0;

            // Sets the value of charactersOnPage to the number of characters 
            // of stringToPrint that will fit within the bounds of the page.
            e.Graphics.MeasureString(stringToPrint, this.Font,
                e.MarginBounds.Size, StringFormat.GenericTypographic,
                out charactersOnPage, out linesPerPage);

            // Draws the string within the bounds of the page.
            e.Graphics.DrawString(stringToPrint, this.Font, Brushes.Black,
            e.MarginBounds, StringFormat.GenericTypographic);

            // Remove the portion of the string that has been printed.
            stringToPrint = stringToPrint.Substring(charactersOnPage);

            // Check to see if more pages are to be printed.
            e.HasMorePages = (stringToPrint.Length > 0);

            // If there are no more pages, reset the string to be printed.
            if (!e.HasMorePages)
                stringToPrint = documentContents;
        }

        private void printfirstvalue_Click(object sender, EventArgs e)
        {
            ReadDocument();
            printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show(speedconecoef.ToString());
            //MessageBox.Show(speedconecoef.ToString());
            offdesign a = new offdesign(Ptur, ω, P00I, P2II, k, T, R, viscous, Dcp, debi, Wad2I, Wads, Wad2II, speedcoef, installcoefangle, outputangle, hneavr, speedconecoef, openconeangle, deltahtipI, deltahhubI, delzaZI, hbarbI, profileinstall, tbarbI, delta, kesi, beta2ef, mdotbary);
            a.ShowDialog();
        }

        private void مستنداتToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pdfview a = new pdfview();
            a.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://srbiau.ac.ir/fa");
        }

        private void label54_Click_1(object sender, EventArgs e)
        {
            info a = new info(1);
            a.ShowDialog();
        }

        private void label100_Click(object sender, EventArgs e)
        {
            info a = new info(2);
            a.ShowDialog();
        }
    }
}
