using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HowManyDaysAgoVer02
{
    public partial class Form1 : Form
    {
        DateTime myDate = new DateTime();
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            double nDaysAgo;
            string strDaysAgo;
            string strMessageHeader;
            string strMessageTail;
            string strDayOfWeek;

            myDate = dateTimePicker1.Value;
            strDayOfWeek = myDate.ToString("D");
            TimeSpan myAge = DateTime.Now.Subtract(myDate);

            strDaysAgo = string.Format("{0:N0}", myAge.TotalDays);
            nDaysAgo = Convert.ToDouble(strDaysAgo);

            if(nDaysAgo == 0)
            {
                strMessageHeader = " Is Today!";
                strDaysAgo = "";
                strMessageTail = "";
                lblDisplayDays.ForeColor = Color.Blue;
            }

            else if(nDaysAgo == 1)
            {
                strMessageHeader = " Was Yesterday!";
                strDaysAgo = "";
                strMessageTail = "";
                lblDisplayDays.ForeColor = Color.DarkGreen;
            }

            else if(nDaysAgo == -1)
            {
                strMessageHeader = " is Tomorrow!";
                strDaysAgo = "";
                strMessageTail = "";
                lblDisplayDays.ForeColor = Color.DarkRed;
            }

            else if(nDaysAgo < -1)
            {
                strMessageHeader = " Occurs ";
                strDaysAgo = Math.Abs(nDaysAgo).ToString();
                strMessageTail = " Days from Today!";
                lblDisplayDays.ForeColor = Color.DarkRed;
            }

            else
            {
                strMessageHeader = " Occured ";
                strMessageTail = " Days Ago!";
                lblDisplayDays.ForeColor = Color.DarkGreen;
            }

            lblDisplayDays.Text = strDayOfWeek + strMessageHeader + strDaysAgo + strMessageTail;
        }
    }
}
