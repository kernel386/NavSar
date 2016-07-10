using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MathWorks.MATLAB.NET.Arrays;
using MatlabFn;


namespace navSAR {
    public partial class FormMagCalibration : Form {

        public int minX = 0;
        public int minY = 0;
        public int minZ = 0;
        public int maxX = 0;
        public int maxY = 0;
        public int maxZ = 0;

        public FormMagCalibration() {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        public void SetValues(int magx, int magy, int magz) {
            if (checkBoxCalEnable.Checked == false) {
                return;
            }

            // Минимумы
            if (magx < minX) {
                minX = magx;
            }

            if (magy < minY) {
                minY = magy;
            }

            if (magz < minZ) {
                minZ = magz;
            }

            // Максимумы
            if (magx > maxX) {
                maxX = magx;
            }

            if (magy > maxY) {
                maxY = magy;
            }

            if (magz > maxZ) {
                maxZ = magz;
            }

            maskedTextBoxMinX.Text = minX.ToString();
            maskedTextBoxMinY.Text = minY.ToString();
            maskedTextBoxMinZ.Text = minZ.ToString();

            maskedTextBoxMaxX.Text = maxX.ToString();
            maskedTextBoxMaxY.Text = maxY.ToString();
            maskedTextBoxMaxZ.Text = maxZ.ToString();

            maskedTextBoxDistX.Text = (maxX - minX).ToString();
            maskedTextBoxDistY.Text = (maxY - minY).ToString();
            maskedTextBoxDistZ.Text = (maxZ - minZ).ToString();

            maskedTextBoxCentrX.Text = ((int)((maxX - minX) / 2 + minX)).ToString();
            maskedTextBoxCentrY.Text = ((int)((maxY - minY) / 2 + minY)).ToString();
            maskedTextBoxCentrZ.Text = ((int)((maxZ - minZ) / 2 + minZ)).ToString();

            if (checkBoxGraph.Checked) {
                MyClass matlabClass = new MyClass();

                MWArray[] res = null;                       // выходной массив метода 

                MWNumericArray arx = new MWNumericArray(magx);
                MWNumericArray ary = new MWNumericArray(magy);
                MWNumericArray arz = new MWNumericArray(magz);
                res = matlabClass.mplot3(1, arx, ary, arz); //обращение к методу mplot3, первый параметр - количество возвращаемых аргументов                  
            }
        }

        private void buttonWrite_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            Close();
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            Close();
        }
    }
}
