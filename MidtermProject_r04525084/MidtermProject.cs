using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RandomVariateGeneratorLibrary;

namespace MidtermProject_r04525084
{
    public partial class MidtermProject : Form
    {

        // Single Server Three Queue

    //    EventList_start Server3Queue1 = new EventList_start();



        public MidtermProject()
        {
          InitializeComponent();
            txtbx_Average.Text = ("1.0");
            txtbx_GenerateCaseTime.Text = ("430");
            txt_S3Q3_average.Text = ("1.0");
            txt_S3Q3_caseTime.Text = ("430");
        }
        

        private void MidtermProject_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 3 Server 1 Queue
            EventList_start Server3Queue1 = new EventList_start();
            //clear chart
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
            chart1.Series[3].Points.Clear();
            chart1.Series[4].Points.Clear();
            chart1.Series[5].Points.Clear();


            //set values
            Server3Queue1.client.setmu(Convert.ToDouble(txtbx_Average.Text));
            Server3Queue1.setStopClientTime(Convert.ToDouble(txtbx_GenerateCaseTime.Text));

            //start
            Server3Queue1.Start();

            //show the value 
            txtbx_showData.Clear();
            txtbx_showData.AppendText($"Total Jobs: {Server3Queue1.client.NumberOfClient}\n");
            txtbx_showData.AppendText($"Average Interarrival Time: {Math.Round(Server3Queue1.client.InterSum / Server3Queue1.client.NumberOfClient , 2)}");
            txtbx_showData.AppendText($" , Arrival Rate: {Math.Round(Server3Queue1.thao / Server3Queue1.client.InterSum, 2)}\n");
            txtbx_showData.AppendText($"Average Service (0) Time: {Math.Round(Server3Queue1.node.serverList[0].mx / (Server3Queue1.node.serverList[0].NumOfJob.Count() / 2) , 2)}\n");
            txtbx_showData.AppendText($"Average Service (1) Time: {Math.Round(Server3Queue1.node.serverList[1].mx / (Server3Queue1.node.serverList[1].NumOfJob.Count() / 2), 2)}\n");
            txtbx_showData.AppendText($"Average Service (2) Time: {Math.Round(Server3Queue1.node.serverList[2].mx / (Server3Queue1.node.serverList[2].NumOfJob.Count() / 2), 2)}\n");
            txtbx_showData.AppendText($"Time-Averaged Job in Service (0): {Math.Round(Server3Queue1.node.serverList[0].mx / (Server3Queue1.thao), 2)}\n");
            txtbx_showData.AppendText($"Time-Averaged Job in Service (1): {Math.Round(Server3Queue1.node.serverList[1].mx / (Server3Queue1.thao), 2)}\n");
            txtbx_showData.AppendText($"Time-Averaged Job in Service (2): {Math.Round(Server3Queue1.node.serverList[2].mx / (Server3Queue1.thao), 2)}\n");
            txtbx_showData.AppendText($"Average Delay Time: {Math.Round(Server3Queue1.node.DESqueueList[0].md / (Server3Queue1.node.NumOfJob.Count() / 2), 2)}\n");
            txtbx_showData.AppendText($"Average Lenth of Queue: {Math.Round(Server3Queue1.node.DESqueueList[0].NumOfJob.Sum() / Server3Queue1.thao, 2)}\n");

            if (Server3Queue1.node.DESqueueList[0].NumOfJob.Count() != 0)
            {
                txtbx_showData.AppendText($"Maximal Lenth of Queue: {Server3Queue1.node.DESqueueList[0].NumOfJob.Max()}\n");
            }
            else { txtbx_showData.AppendText($"Maximal Lenth of Queue: 0\n"); }

            txtbx_showData.AppendText($"Total jobs of Queue: {Server3Queue1.node.DESqueueList[0].NumOfJob.Count() / 2}\n");

            //chart

            //add zero
            chart1.Series[5].Points.AddXY(Convert.ToDouble(txtbx_GenerateCaseTime.Text), 0);
            chart1.Series[5].Points.AddXY(Convert.ToDouble(txtbx_GenerateCaseTime.Text), Server3Queue1.node.NumOfJob.Max()+0.5);
            chart1.Series[0].Points.AddXY(0, 0);
            chart1.Series[1].Points.AddXY(0, 0);
            chart1.Series[2].Points.AddXY(0, 0);
            chart1.Series[3].Points.AddXY(0, 0);
            chart1.Series[4].Points.AddXY(0, 0);


            for (int i = 0; i< Server3Queue1.node.timePoint.Count(); i++) { chart1.Series[0].Points.AddXY(Server3Queue1.node.timePoint[i], Server3Queue1.node.NumOfJob[i]); }
            for (int i = 0; i < Server3Queue1.node.DESqueueList[0].timePoint.Count(); i++) { chart1.Series[1].Points.AddXY(Server3Queue1.node.DESqueueList[0].timePoint[i], Server3Queue1.node.DESqueueList[0].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue1.node.serverList[0].timePoint.Count(); i++) { chart1.Series[2].Points.AddXY(Server3Queue1.node.serverList[0].timePoint[i], Server3Queue1.node.serverList[0].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue1.node.serverList[1].timePoint.Count(); i++) { chart1.Series[3].Points.AddXY(Server3Queue1.node.serverList[1].timePoint[i], Server3Queue1.node.serverList[1].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue1.node.serverList[2].timePoint.Count(); i++) { chart1.Series[4].Points.AddXY(Server3Queue1.node.serverList[2].timePoint[i], Server3Queue1.node.serverList[2].NumOfJob[i]); }
            chart1.ChartAreas[0].AxisX.IsMarginVisible = false;
        }

        private void comboBox_Seed_Click(object sender, EventArgs e)
        {

        }
        int click = 1;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            click++;
            if (click % 2 == 0) { chart1.Series[0].Enabled = false; }
            else chart1.Series[0].Enabled = true;
        }
        int click1 = 1;
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            click1++;
            if (click1 % 2 == 0) { chart1.Series[1].Enabled = false; }
            else chart1.Series[1].Enabled = true;
        }
        int click2 = 1;
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            click2++;
            if (click2 % 2 == 0) { chart1.Series[2].Enabled = false; }
            else chart1.Series[2].Enabled = true;
        }
        
        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
        int click4 = 1;
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            click4++;
            if (click4 % 2 == 0) { chart1.Series[4].Enabled = false; }
            else chart1.Series[4].Enabled = true;
        }
        int click3 = 1;
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            click3++;
            if (click3 % 2 == 0) { chart1.Series[3].Enabled = false; }
            else chart1.Series[3].Enabled = true;
        }

        private void S3Q3_buttom_Click(object sender, EventArgs e)
        {
            // 3 Server 3 Queue
            EventList_Start_3Q3S Server3Queue3 = new EventList_Start_3Q3S();

            //clear chart
            chart2.Series[0].Points.Clear();
            chart2.Series[1].Points.Clear();
            chart2.Series[2].Points.Clear();
            chart2.Series[3].Points.Clear();
            chart2.Series[4].Points.Clear();
            chart2.Series[5].Points.Clear();
            chart2.Series[6].Points.Clear();
            chart2.Series[7].Points.Clear();

            //set values
            Server3Queue3.client.setmu(Convert.ToDouble(txt_S3Q3_average.Text));
            Server3Queue3.setStopClientTime(Convert.ToDouble(txt_S3Q3_caseTime.Text));

            //start
            Server3Queue3.Start();

            //show the value 
            txtbx_S3Q3_showData.Clear();
            txtbx_S3Q3_showData.AppendText($"Total Jobs: {Server3Queue3.client.NumberOfClient}\n");
            txtbx_S3Q3_showData.AppendText($"Average Interarrival Time: {Math.Round(Server3Queue3.client.InterSum / Server3Queue3.client.NumberOfClient, 2)}");
            txtbx_S3Q3_showData.AppendText($" , Arrival Rate: {Math.Round(Server3Queue3.thao / Server3Queue3.client.InterSum, 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Average Service (0) Time: {Math.Round(Server3Queue3.node.serverList[0].mx / (Server3Queue3.node.serverList[0].NumOfJob.Count() / 2), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Average Service (1) Time: {Math.Round(Server3Queue3.node.serverList[1].mx / (Server3Queue3.node.serverList[1].NumOfJob.Count() / 2), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Average Service (2) Time: {Math.Round(Server3Queue3.node.serverList[2].mx / (Server3Queue3.node.serverList[2].NumOfJob.Count() / 2), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Time-Averaged Job in Service (0): {Math.Round(Server3Queue3.node.serverList[0].mx / (Server3Queue3.thao), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Time-Averaged Job in Service (1): {Math.Round(Server3Queue3.node.serverList[1].mx / (Server3Queue3.thao), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Time-Averaged Job in Service (2): {Math.Round(Server3Queue3.node.serverList[2].mx / (Server3Queue3.thao), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Average Delay Time: {Math.Round((Server3Queue3.node.DESqueueList[0].md+Server3Queue3.node.DESqueueList[1].md+ Server3Queue3.node.DESqueueList[2].md) / (Server3Queue3.node.NumOfJob.Count() / 2), 2)}\n");
            txtbx_S3Q3_showData.AppendText($"Average Lenth of Queue(0): {Math.Round(Server3Queue3.node.DESqueueList[0].NumOfJob.Sum() / Server3Queue3.thao, 2)}\n");
            if (Server3Queue3.node.DESqueueList[0].NumOfJob.Count() != 0)
            {
                txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(0): {Server3Queue3.node.DESqueueList[0].NumOfJob.Max()}\n");
            }
            else { txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(0): 0\n"); }

            txtbx_S3Q3_showData.AppendText($"Average Lenth of Queue(1): {Math.Round(Server3Queue3.node.DESqueueList[1].NumOfJob.Sum() / Server3Queue3.thao, 2)}\n");

            if (Server3Queue3.node.DESqueueList[1].NumOfJob.Count() != 0)
            {
                txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(1): {Server3Queue3.node.DESqueueList[1].NumOfJob.Max()}\n");
            }
            else { txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(1): 0\n"); }

            txtbx_S3Q3_showData.AppendText($"Average Lenth of Queue(2): {Math.Round(Server3Queue3.node.DESqueueList[2].NumOfJob.Sum() / Server3Queue3.thao, 2)}\n");

            if (Server3Queue3.node.DESqueueList[2].NumOfJob.Count() != 0)
            {
                txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(2): {Server3Queue3.node.DESqueueList[2].NumOfJob.Max()}\n");
            }
            else { txtbx_S3Q3_showData.AppendText($"Maximal Lenth of Queue(2): 0\n"); }

            txtbx_S3Q3_showData.AppendText($"Total jobs of Queue(0): {Server3Queue3.node.DESqueueList[0].NumOfJob.Count() / 2}\n");
            txtbx_S3Q3_showData.AppendText($"Total jobs of Queue(1): {Server3Queue3.node.DESqueueList[1].NumOfJob.Count() / 2}\n");
            txtbx_S3Q3_showData.AppendText($"Total jobs of Queue(2): {Server3Queue3.node.DESqueueList[2].NumOfJob.Count() / 2}\n");

            //add zero
            chart2.Series[7].Points.AddXY(Convert.ToDouble(txt_S3Q3_caseTime.Text), 0);
            chart2.Series[7].Points.AddXY(Convert.ToDouble(txt_S3Q3_caseTime.Text), Server3Queue3.node.NumOfJob.Max() + 0.5);

            chart2.Series[0].Points.AddXY(0, 0);
            chart2.Series[1].Points.AddXY(0, 0);
            chart2.Series[2].Points.AddXY(0, 0);
            chart2.Series[3].Points.AddXY(0, 0);
            chart2.Series[4].Points.AddXY(0, 0);
            chart2.Series[5].Points.AddXY(0, 0);
            chart2.Series[6].Points.AddXY(0, 0);

            for (int i = 0; i < Server3Queue3.node.timePoint.Count(); i++) { chart2.Series[0].Points.AddXY(Server3Queue3.node.timePoint[i], Server3Queue3.node.NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.DESqueueList[0].timePoint.Count(); i++) { chart2.Series[1].Points.AddXY(Server3Queue3.node.DESqueueList[0].timePoint[i], Server3Queue3.node.DESqueueList[0].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.DESqueueList[1].timePoint.Count(); i++) { chart2.Series[2].Points.AddXY(Server3Queue3.node.DESqueueList[1].timePoint[i], Server3Queue3.node.DESqueueList[1].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.DESqueueList[2].timePoint.Count(); i++) { chart2.Series[3].Points.AddXY(Server3Queue3.node.DESqueueList[2].timePoint[i], Server3Queue3.node.DESqueueList[2].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.serverList[0].timePoint.Count(); i++) { chart2.Series[4].Points.AddXY(Server3Queue3.node.serverList[0].timePoint[i], Server3Queue3.node.serverList[0].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.serverList[1].timePoint.Count(); i++) { chart2.Series[5].Points.AddXY(Server3Queue3.node.serverList[1].timePoint[i], Server3Queue3.node.serverList[1].NumOfJob[i]); }
            for (int i = 0; i < Server3Queue3.node.serverList[2].timePoint.Count(); i++) { chart2.Series[6].Points.AddXY(Server3Queue3.node.serverList[2].timePoint[i], Server3Queue3.node.serverList[2].NumOfJob[i]); }
            chart2.ChartAreas[0].AxisX.IsMarginVisible = false;


        }
        int click5 = 1;
        private void checkBox6_CheckedChanged(object sender, EventArgs e)
        {
            click5++;
            if (click5 % 2 == 0) { chart2.Series[0].Enabled = false; }
            else chart2.Series[0].Enabled = true;
        }
        int click6 = 1;
        private void checkBox7_CheckedChanged(object sender, EventArgs e)
        {
            click6++;
            if (click6 % 2 == 0) { chart2.Series[1].Enabled = false; chart2.Series[4].Enabled = false; }
            else { chart2.Series[1].Enabled = true; chart2.Series[4].Enabled = true; }
            }
        int click7 = 1;
        private void checkBox8_CheckedChanged(object sender, EventArgs e)
        {
            click7++;
            if (click7 % 2 == 0) { chart2.Series[2].Enabled = false; chart2.Series[5].Enabled = false; }
            else { chart2.Series[2].Enabled = true; chart2.Series[5].Enabled = true; }
        }
        int click8 = 1;
        private void checkBox9_CheckedChanged(object sender, EventArgs e)
        {
            click8++;
            if (click8 % 2 == 0) { chart2.Series[3].Enabled = false; chart2.Series[6].Enabled = false; }
            else { chart2.Series[3].Enabled = true; chart2.Series[6].Enabled = true; }
        }
    }
}
