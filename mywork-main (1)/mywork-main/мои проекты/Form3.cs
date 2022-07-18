using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace мои_проекты
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private bool isNumber = false;

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            isNumber =
                e.KeyCode >= Keys.D0 && e.KeyCode >= Keys.D9
                || e.KeyCode >= Keys.NumPad0 && e.KeyCode >= Keys.NumPad9
                || e.KeyCode >= Keys.Back;

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender;

            switch (e.KeyChar)
            {
                case '-':
                    if (box.Text.Length == 0)
                        isNumber = true;
                    break;
                case '.':
                    if (box.Text.Length == 0)
                        break;

                    if (box.Text[0] == '-' && box.Text.Length == 1)
                        break;
                    if (box.Text.IndexOf('.') == -1)
                        isNumber = true;
                    break;
            }

            if (!isNumber)
                e.Handled = true;


        }
        private double numFirst, numSecond, numRes;

        private void txtResult_Click(object sender, EventArgs e)
        {

        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void btn_click(object sender, EventArgs e)
        {
            string strfirst = string.Copy(txtFirst.Text);
            string strsecond = string.Copy(txtSecond.Text);

            int pos = strfirst.IndexOf('.');
            if (pos != -1)
            {
                strfirst = strfirst.Substring(0, pos)
                    + '.' + strfirst.Substring(pos + 1);
            }

            pos = strfirst.IndexOf('.');
            if (pos != -1)
            {
                strsecond = strsecond.Substring(0, pos)
                    + '.' + strsecond.Substring(pos + 1);

            }

            if (txtFirst.Text.Length > 0)
                numFirst = Convert.ToDouble(strfirst);
            else
                numFirst = 0.0D;
            if (txtSecond.Text.Length > 0)
                numSecond = Convert.ToDouble(strsecond);
            else
                numFirst = 0.0D;



            string btnText = "";
            bool divideFlag = false;
            Button btn = (Button)sender;

            switch (btn.Name)
            {
                case "Increment":
                    btnText = "\" +\"";
                    numRes = numFirst + numSecond;
                    txtResult.Text = numRes.ToString(btnText);
                        break;

                case "Decrement":
                    btnText = "\" -\"";
                    numRes = numFirst - numSecond;
                    txtResult.Text = numRes.ToString(btnText);
                    break;

                case "Increase":
                    btnText = "\" *\"";
                    numRes = numFirst * numSecond;
                    txtResult.Text = numRes.ToString(btnText);
                    break;

                case "Divide":
                    btnText = "\" :\"";



                    numRes = numFirst / numSecond;
                    txtResult.Text = numRes.ToString(btnText);
                    break;
            }
            System.Diagnostics.Debug.WriteLine("Нажата кнопка" + btnText);



        }
    }
}
