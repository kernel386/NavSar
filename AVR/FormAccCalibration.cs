using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace navSAR
{
    public partial class FormAccCalibration : Form
    {
        public FormAccCalibration() {
            InitializeComponent();
        }
        
        public int minX = 0;
        public int minY = 0;
        public int minZ = 0;
        public int maxX = 0;
        public int maxY = 0;
        public int maxZ = 0;

        public void SetValues(int accx, int accy, int accz) {
            if (checkBoxCalEnable.Checked == false) {
                return;
            }

            // Минимумы
            if (accx < minX) {
                minX = accx;
            }

            if (accy < minY) {
                minY = accy;
            }

            if (accz < minZ) {
                minZ = accz;
            }

            // Максимумы
            if (accx > maxX) {
                maxX = accx;
            }

            if (accy > maxY) {
                maxY = accy;
            }

            if (accz > maxZ) {
                maxZ = accz;
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
        }

        private void buttonOK_Click_1(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void buttonReset_Click_1(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            Close();
        }

        private void buttonWrite_Click_1(object sender, EventArgs e) {
            this.DialogResult = System.Windows.Forms.DialogResult.Retry;
            Close();
        }
    }
}
