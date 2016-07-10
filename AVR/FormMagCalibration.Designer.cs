namespace navSAR {
    partial class FormMagCalibration {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.checkBoxCalEnable = new System.Windows.Forms.CheckBox();
            this.labelXMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.maskedTextBoxMinX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMinY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMinZ = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCentrX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCentrY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxCentrZ = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMaxX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMaxY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxMaxZ = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxGraph = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.maskedTextBoxDistX = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDistY = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBoxDistZ = new System.Windows.Forms.MaskedTextBox();
            this.buttonWrite = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBoxCalEnable
            // 
            this.checkBoxCalEnable.AutoSize = true;
            this.checkBoxCalEnable.Location = new System.Drawing.Point(12, 12);
            this.checkBoxCalEnable.Name = "checkBoxCalEnable";
            this.checkBoxCalEnable.Size = new System.Drawing.Size(87, 17);
            this.checkBoxCalEnable.TabIndex = 0;
            this.checkBoxCalEnable.Text = "Калибровка";
            this.checkBoxCalEnable.UseVisualStyleBackColor = true;
            // 
            // labelXMax
            // 
            this.labelXMax.AutoSize = true;
            this.labelXMax.Location = new System.Drawing.Point(291, 40);
            this.labelXMax.Name = "labelXMax";
            this.labelXMax.Size = new System.Drawing.Size(71, 13);
            this.labelXMax.TabIndex = 1;
            this.labelXMax.Text = "Максимум X";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(291, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Максимум Y";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(291, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Максимум Z";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Среднее X";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(153, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Среднее Y";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(153, 92);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Среднее Z";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Минимум X";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(10, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Минимум Y";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(10, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Минимум Z";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(480, 117);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // maskedTextBoxMinX
            // 
            this.maskedTextBoxMinX.Location = new System.Drawing.Point(81, 37);
            this.maskedTextBoxMinX.Mask = "#00000";
            this.maskedTextBoxMinX.Name = "maskedTextBoxMinX";
            this.maskedTextBoxMinX.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMinX.TabIndex = 4;
            this.maskedTextBoxMinX.Text = "0";
            // 
            // maskedTextBoxMinY
            // 
            this.maskedTextBoxMinY.Location = new System.Drawing.Point(81, 63);
            this.maskedTextBoxMinY.Mask = "#00000";
            this.maskedTextBoxMinY.Name = "maskedTextBoxMinY";
            this.maskedTextBoxMinY.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMinY.TabIndex = 4;
            this.maskedTextBoxMinY.Text = "0";
            this.maskedTextBoxMinY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxMinZ
            // 
            this.maskedTextBoxMinZ.Location = new System.Drawing.Point(81, 89);
            this.maskedTextBoxMinZ.Mask = "#00000";
            this.maskedTextBoxMinZ.Name = "maskedTextBoxMinZ";
            this.maskedTextBoxMinZ.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMinZ.TabIndex = 4;
            this.maskedTextBoxMinZ.Text = "0";
            this.maskedTextBoxMinZ.ValidatingType = typeof(int);
            // 
            // maskedTextBoxCentrX
            // 
            this.maskedTextBoxCentrX.Enabled = false;
            this.maskedTextBoxCentrX.Location = new System.Drawing.Point(219, 37);
            this.maskedTextBoxCentrX.Mask = "#00000";
            this.maskedTextBoxCentrX.Name = "maskedTextBoxCentrX";
            this.maskedTextBoxCentrX.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxCentrX.TabIndex = 4;
            this.maskedTextBoxCentrX.Text = "0";
            this.maskedTextBoxCentrX.ValidatingType = typeof(int);
            // 
            // maskedTextBoxCentrY
            // 
            this.maskedTextBoxCentrY.Enabled = false;
            this.maskedTextBoxCentrY.Location = new System.Drawing.Point(219, 63);
            this.maskedTextBoxCentrY.Mask = "#00000";
            this.maskedTextBoxCentrY.Name = "maskedTextBoxCentrY";
            this.maskedTextBoxCentrY.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxCentrY.TabIndex = 4;
            this.maskedTextBoxCentrY.Text = "0";
            this.maskedTextBoxCentrY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxCentrZ
            // 
            this.maskedTextBoxCentrZ.Enabled = false;
            this.maskedTextBoxCentrZ.Location = new System.Drawing.Point(219, 89);
            this.maskedTextBoxCentrZ.Mask = "#00000";
            this.maskedTextBoxCentrZ.Name = "maskedTextBoxCentrZ";
            this.maskedTextBoxCentrZ.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxCentrZ.TabIndex = 4;
            this.maskedTextBoxCentrZ.Text = "0";
            this.maskedTextBoxCentrZ.ValidatingType = typeof(int);
            // 
            // maskedTextBoxMaxX
            // 
            this.maskedTextBoxMaxX.Location = new System.Drawing.Point(368, 37);
            this.maskedTextBoxMaxX.Mask = "#00000";
            this.maskedTextBoxMaxX.Name = "maskedTextBoxMaxX";
            this.maskedTextBoxMaxX.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMaxX.TabIndex = 4;
            this.maskedTextBoxMaxX.Text = "0";
            this.maskedTextBoxMaxX.ValidatingType = typeof(int);
            // 
            // maskedTextBoxMaxY
            // 
            this.maskedTextBoxMaxY.Location = new System.Drawing.Point(368, 63);
            this.maskedTextBoxMaxY.Mask = "#00000";
            this.maskedTextBoxMaxY.Name = "maskedTextBoxMaxY";
            this.maskedTextBoxMaxY.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMaxY.TabIndex = 4;
            this.maskedTextBoxMaxY.Text = "0";
            this.maskedTextBoxMaxY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxMaxZ
            // 
            this.maskedTextBoxMaxZ.Location = new System.Drawing.Point(368, 89);
            this.maskedTextBoxMaxZ.Mask = "#00000";
            this.maskedTextBoxMaxZ.Name = "maskedTextBoxMaxZ";
            this.maskedTextBoxMaxZ.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxMaxZ.TabIndex = 4;
            this.maskedTextBoxMaxZ.Text = "0";
            this.maskedTextBoxMaxZ.ValidatingType = typeof(int);
            // 
            // checkBoxGraph
            // 
            this.checkBoxGraph.AutoSize = true;
            this.checkBoxGraph.Location = new System.Drawing.Point(105, 12);
            this.checkBoxGraph.Name = "checkBoxGraph";
            this.checkBoxGraph.Size = new System.Drawing.Size(64, 17);
            this.checkBoxGraph.TabIndex = 5;
            this.checkBoxGraph.Text = "График";
            this.checkBoxGraph.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(432, 40);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Расстояние X";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(432, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "Расстояние Y";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(432, 92);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Расстояние Z";
            // 
            // maskedTextBoxDistX
            // 
            this.maskedTextBoxDistX.Enabled = false;
            this.maskedTextBoxDistX.Location = new System.Drawing.Point(509, 37);
            this.maskedTextBoxDistX.Mask = "#00000";
            this.maskedTextBoxDistX.Name = "maskedTextBoxDistX";
            this.maskedTextBoxDistX.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxDistX.TabIndex = 4;
            this.maskedTextBoxDistX.Text = "0";
            this.maskedTextBoxDistX.ValidatingType = typeof(int);
            // 
            // maskedTextBoxDistY
            // 
            this.maskedTextBoxDistY.Enabled = false;
            this.maskedTextBoxDistY.Location = new System.Drawing.Point(509, 63);
            this.maskedTextBoxDistY.Mask = "#00000";
            this.maskedTextBoxDistY.Name = "maskedTextBoxDistY";
            this.maskedTextBoxDistY.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxDistY.TabIndex = 4;
            this.maskedTextBoxDistY.Text = "0";
            this.maskedTextBoxDistY.ValidatingType = typeof(int);
            // 
            // maskedTextBoxDistZ
            // 
            this.maskedTextBoxDistZ.Enabled = false;
            this.maskedTextBoxDistZ.Location = new System.Drawing.Point(509, 89);
            this.maskedTextBoxDistZ.Mask = "#00000";
            this.maskedTextBoxDistZ.Name = "maskedTextBoxDistZ";
            this.maskedTextBoxDistZ.Size = new System.Drawing.Size(48, 20);
            this.maskedTextBoxDistZ.TabIndex = 4;
            this.maskedTextBoxDistZ.Text = "0";
            this.maskedTextBoxDistZ.ValidatingType = typeof(int);
            // 
            // buttonWrite
            // 
            this.buttonWrite.Location = new System.Drawing.Point(13, 117);
            this.buttonWrite.Name = "buttonWrite";
            this.buttonWrite.Size = new System.Drawing.Size(156, 23);
            this.buttonWrite.TabIndex = 6;
            this.buttonWrite.Text = "Записать в устройство";
            this.buttonWrite.UseVisualStyleBackColor = true;
            this.buttonWrite.Click += new System.EventHandler(this.buttonWrite_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(175, 117);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(176, 23);
            this.buttonReset.TabIndex = 6;
            this.buttonReset.Text = "Сброс калибровок устройства";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // FormMagCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 152);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonWrite);
            this.Controls.Add(this.checkBoxGraph);
            this.Controls.Add(this.maskedTextBoxDistZ);
            this.Controls.Add(this.maskedTextBoxMaxZ);
            this.Controls.Add(this.maskedTextBoxCentrZ);
            this.Controls.Add(this.maskedTextBoxDistY);
            this.Controls.Add(this.maskedTextBoxMaxY);
            this.Controls.Add(this.maskedTextBoxMinZ);
            this.Controls.Add(this.maskedTextBoxDistX);
            this.Controls.Add(this.maskedTextBoxMaxX);
            this.Controls.Add(this.maskedTextBoxCentrY);
            this.Controls.Add(this.maskedTextBoxCentrX);
            this.Controls.Add(this.maskedTextBoxMinY);
            this.Controls.Add(this.maskedTextBoxMinX);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelXMax);
            this.Controls.Add(this.checkBoxCalEnable);
            this.Name = "FormMagCalibration";
            this.Text = "Калибровка магнитометра";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBoxCalEnable;
        private System.Windows.Forms.Label labelXMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMinX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMinY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMinZ;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCentrX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCentrY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCentrZ;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMaxX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMaxY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxMaxZ;
        private System.Windows.Forms.CheckBox checkBoxGraph;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDistX;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDistY;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxDistZ;
        private System.Windows.Forms.Button buttonWrite;
        private System.Windows.Forms.Button buttonReset;
    }
}