namespace navSAR {
    partial class FormMain {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripDropDownButtonSerialNames = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.textBoxNAVINS1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxNAVINS2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.glControl3d = new OpenTK.GLControl();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonMahoney = new System.Windows.Forms.RadioButton();
            this.radioButtonComplementary = new System.Windows.Forms.RadioButton();
            this.radioButtonGyro = new System.Windows.Forms.RadioButton();
            this.radioButtonMagnetometer = new System.Windows.Forms.RadioButton();
            this.radioButtonAccel = new System.Windows.Forms.RadioButton();
            this.buttoNullGyro = new System.Windows.Forms.Button();
            this.maskedTextBoxComplK = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonMagCalibration = new System.Windows.Forms.Button();
            this.buttonAccCalibration = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttoNullAcc = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripDropDownButtonSerialNames,
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 522);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(878, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripDropDownButtonSerialNames
            // 
            this.toolStripDropDownButtonSerialNames.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDropDownButtonSerialNames.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonSerialNames.Image")));
            this.toolStripDropDownButtonSerialNames.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonSerialNames.Name = "toolStripDropDownButtonSerialNames";
            this.toolStripDropDownButtonSerialNames.Size = new System.Drawing.Size(70, 20);
            this.toolStripDropDownButtonSerialNames.Text = "SerialPort";
            this.toolStripDropDownButtonSerialNames.ToolTipText = "toolStripDropDownButtonSerialNames";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // textBoxNAVINS1
            // 
            this.textBoxNAVINS1.Location = new System.Drawing.Point(13, 64);
            this.textBoxNAVINS1.Multiline = true;
            this.textBoxNAVINS1.Name = "textBoxNAVINS1";
            this.textBoxNAVINS1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNAVINS1.Size = new System.Drawing.Size(215, 132);
            this.textBoxNAVINS1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Сообщение NAVINS1";
            // 
            // textBoxNAVINS2
            // 
            this.textBoxNAVINS2.Location = new System.Drawing.Point(234, 64);
            this.textBoxNAVINS2.Multiline = true;
            this.textBoxNAVINS2.Name = "textBoxNAVINS2";
            this.textBoxNAVINS2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxNAVINS2.Size = new System.Drawing.Size(234, 309);
            this.textBoxNAVINS2.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Сообщение NAVINS2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(169, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Датчики  MPL3115A2, HMC5883";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(240, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(149, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Датчики MPU6K, MPL115A1";
            // 
            // glControl3d
            // 
            this.glControl3d.BackColor = System.Drawing.Color.Black;
            this.glControl3d.Location = new System.Drawing.Point(474, 64);
            this.glControl3d.Name = "glControl3d";
            this.glControl3d.Size = new System.Drawing.Size(392, 384);
            this.glControl3d.TabIndex = 9;
            this.glControl3d.VSync = false;
            this.glControl3d.Load += new System.EventHandler(this.glControl3d_Load);
            this.glControl3d.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl3d_Paint);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(13, 202);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(215, 171);
            this.textBox1.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonMahoney);
            this.groupBox1.Controls.Add(this.radioButtonComplementary);
            this.groupBox1.Controls.Add(this.radioButtonGyro);
            this.groupBox1.Controls.Add(this.radioButtonMagnetometer);
            this.groupBox1.Controls.Add(this.radioButtonAccel);
            this.groupBox1.Location = new System.Drawing.Point(12, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 140);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Источник";
            // 
            // radioButtonMahoney
            // 
            this.radioButtonMahoney.AutoSize = true;
            this.radioButtonMahoney.Location = new System.Drawing.Point(6, 111);
            this.radioButtonMahoney.Name = "radioButtonMahoney";
            this.radioButtonMahoney.Size = new System.Drawing.Size(63, 17);
            this.radioButtonMahoney.TabIndex = 0;
            this.radioButtonMahoney.Text = "Махони";
            this.radioButtonMahoney.UseVisualStyleBackColor = true;
            this.radioButtonMahoney.CheckedChanged += new System.EventHandler(this.radioButtonComplementary_CheckedChanged);
            // 
            // radioButtonComplementary
            // 
            this.radioButtonComplementary.AutoSize = true;
            this.radioButtonComplementary.Location = new System.Drawing.Point(6, 88);
            this.radioButtonComplementary.Name = "radioButtonComplementary";
            this.radioButtonComplementary.Size = new System.Drawing.Size(121, 17);
            this.radioButtonComplementary.TabIndex = 0;
            this.radioButtonComplementary.Text = "Комплементарный";
            this.radioButtonComplementary.UseVisualStyleBackColor = true;
            this.radioButtonComplementary.CheckedChanged += new System.EventHandler(this.radioButtonComplementary_CheckedChanged);
            // 
            // radioButtonGyro
            // 
            this.radioButtonGyro.AutoSize = true;
            this.radioButtonGyro.Location = new System.Drawing.Point(6, 42);
            this.radioButtonGyro.Name = "radioButtonGyro";
            this.radioButtonGyro.Size = new System.Drawing.Size(73, 17);
            this.radioButtonGyro.TabIndex = 0;
            this.radioButtonGyro.Text = "Гироскоп";
            this.radioButtonGyro.UseVisualStyleBackColor = true;
            // 
            // radioButtonMagnetometer
            // 
            this.radioButtonMagnetometer.AutoSize = true;
            this.radioButtonMagnetometer.Location = new System.Drawing.Point(6, 65);
            this.radioButtonMagnetometer.Name = "radioButtonMagnetometer";
            this.radioButtonMagnetometer.Size = new System.Drawing.Size(93, 17);
            this.radioButtonMagnetometer.TabIndex = 0;
            this.radioButtonMagnetometer.Text = "Магнитометр";
            this.radioButtonMagnetometer.UseVisualStyleBackColor = true;
            // 
            // radioButtonAccel
            // 
            this.radioButtonAccel.AutoSize = true;
            this.radioButtonAccel.Checked = true;
            this.radioButtonAccel.Location = new System.Drawing.Point(6, 19);
            this.radioButtonAccel.Name = "radioButtonAccel";
            this.radioButtonAccel.Size = new System.Drawing.Size(99, 17);
            this.radioButtonAccel.TabIndex = 0;
            this.radioButtonAccel.TabStop = true;
            this.radioButtonAccel.Text = "Акселерометр";
            this.radioButtonAccel.UseVisualStyleBackColor = true;
            // 
            // buttoNullGyro
            // 
            this.buttoNullGyro.Location = new System.Drawing.Point(233, 392);
            this.buttoNullGyro.Name = "buttoNullGyro";
            this.buttoNullGyro.Size = new System.Drawing.Size(75, 23);
            this.buttoNullGyro.TabIndex = 12;
            this.buttoNullGyro.Text = "Ноль гиро";
            this.buttoNullGyro.UseVisualStyleBackColor = true;
            this.buttoNullGyro.Click += new System.EventHandler(this.buttoNullGyro_Click);
            // 
            // maskedTextBoxComplK
            // 
            this.maskedTextBoxComplK.Enabled = false;
            this.maskedTextBoxComplK.Location = new System.Drawing.Point(330, 477);
            this.maskedTextBoxComplK.Mask = "0.00";
            this.maskedTextBoxComplK.Name = "maskedTextBoxComplK";
            this.maskedTextBoxComplK.Size = new System.Drawing.Size(46, 20);
            this.maskedTextBoxComplK.TabIndex = 13;
            this.maskedTextBoxComplK.Text = "005";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(236, 480);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "(1-K)*gyro+K*acc";
            // 
            // buttonMagCalibration
            // 
            this.buttonMagCalibration.Location = new System.Drawing.Point(233, 450);
            this.buttonMagCalibration.Name = "buttonMagCalibration";
            this.buttonMagCalibration.Size = new System.Drawing.Size(165, 23);
            this.buttonMagCalibration.TabIndex = 16;
            this.buttonMagCalibration.Text = "Калибровка магнитометра";
            this.buttonMagCalibration.UseVisualStyleBackColor = true;
            this.buttonMagCalibration.Click += new System.EventHandler(this.buttonMagCalibration_Click);
            // 
            // buttonAccCalibration
            // 
            this.buttonAccCalibration.Location = new System.Drawing.Point(233, 421);
            this.buttonAccCalibration.Name = "buttonAccCalibration";
            this.buttonAccCalibration.Size = new System.Drawing.Size(165, 23);
            this.buttonAccCalibration.TabIndex = 16;
            this.buttonAccCalibration.Text = "Калибровка акселерометра";
            this.buttonAccCalibration.UseVisualStyleBackColor = true;
            this.buttonAccCalibration.Click += new System.EventHandler(this.buttonAccCalibration_Click);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(404, 450);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(53, 23);
            this.buttonReset.TabIndex = 17;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttoNullAcc
            // 
            this.buttoNullAcc.Location = new System.Drawing.Point(314, 392);
            this.buttoNullAcc.Name = "buttoNullAcc";
            this.buttoNullAcc.Size = new System.Drawing.Size(75, 23);
            this.buttoNullAcc.TabIndex = 18;
            this.buttoNullAcc.Text = "Ноль акс";
            this.buttoNullAcc.UseVisualStyleBackColor = true;
            this.buttoNullAcc.Click += new System.EventHandler(this.buttoNullAcc_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 544);
            this.Controls.Add(this.buttoNullAcc);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonAccCalibration);
            this.Controls.Add(this.buttonMagCalibration);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBoxComplK);
            this.Controls.Add(this.buttoNullGyro);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.glControl3d);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNAVINS2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxNAVINS1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonSerialNames;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.TextBox textBoxNAVINS1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxNAVINS2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private OpenTK.GLControl glControl3d;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonGyro;
        private System.Windows.Forms.RadioButton radioButtonAccel;
        private System.Windows.Forms.Button buttoNullGyro;
        private System.Windows.Forms.RadioButton radioButtonComplementary;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxComplK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton radioButtonMahoney;
        private System.Windows.Forms.RadioButton radioButtonMagnetometer;
        private System.Windows.Forms.Button buttonMagCalibration;
        private System.Windows.Forms.Button buttonAccCalibration;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttoNullAcc;
    }
}

