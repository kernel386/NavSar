using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace navSAR {
    public partial class FormMain : Form {
        // Сообщения строки состояния
        const string STRING_CONNECTED       = "Подключено";
        const string STRING_DISCONNECTED    = "Отключено";
        const string STRING_NOPORTS         = "Нет портов";

        //Переменые
        CNavSAR             NavSAR              = new CNavSAR();
        Thread              thread;
        AutoResetEvent      Event               = new AutoResetEvent(false);
        CIns                Ins                 = new CIns();
        FormMagCalibration  formMagCalibration;
        FormAccCalibration  formAccCalibration;

        private double kurs = 0;
        private double kren = 0;
        private double tang = 0;

        private double vx = 0;
        private double vy = 0;
        private double vz = 0;

        private double sx = 0;
        private double sy = 0;
        private double sz = 0;

        public FormMain() {
            InitializeComponent();

            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;

            Text = Application.ProductName + " " + version.Major + "." + version.Minor;

            toolStripDropDownButtonSerialNames.Text = STRING_NOPORTS;
            toolStripStatusLabel.Text = STRING_DISCONNECTED;
            // Енумерация последовательных портов
            string[] theSerialPortNames = System.IO.Ports.SerialPort.GetPortNames();
            foreach (string portName in theSerialPortNames) {
                toolStripDropDownButtonSerialNames.DropDownItems.Add(portName);
            }

            toolStripDropDownButtonSerialNames.Text = toolStripDropDownButtonSerialNames.DropDownItems[0].Text;
            toolStripDropDownButtonSerialNames.DropDown.ItemClicked += new ToolStripItemClickedEventHandler(toolStripDropDownButtonSerialNames_ItemClicked);

            // Запуск потока приема сообщений от модуля навигации
           thread = new Thread(new ThreadStart(ThreadProc));
            thread.Start();
        }

        /// <summary>
        /// Поток приема данных с модуля навигации
        /// </summary>
        public void ThreadProc() {
            int a = 1;
            Action action = () => {
                string str = "MPL3115A2\r\n" +
                             "Высота:    " + "\t" + NavSAR.NmeaParser.NavIns1Data.Mpl3115a2_Altitude + "\r\n" +
                             "Давление: " + "\t" + NavSAR.NmeaParser.NavIns1Data.Mpl3115a2_fPressure + "\r\n" +
                             "Температура: " + "\t" + NavSAR.NmeaParser.NavIns1Data.Mpl3115a2_fTemp + "\r\n" +
                             "\r\n" +
                             "HMC5883\r\n" +
                             "xraw:   :    " + "\t" + NavSAR.NmeaParser.NavIns1Data.Hmc5883_xraw + "\r\n" +
                             "yraw:   :    " + "\t" + NavSAR.NmeaParser.NavIns1Data.Hmc5883_yraw + "\r\n" +
                             "zraw:   :    " + "\t" + NavSAR.NmeaParser.NavIns1Data.Hmc5883_zraw + "\r\n";
                textBoxNAVINS1.Text = str;

                str = "MPU6K\r\n" +
                      "acc_x: " + "\t" + NavSAR.NmeaParser.NavIns2Data.acc_x + "\r\n" +
                      "acc_y: " + "\t" + NavSAR.NmeaParser.NavIns2Data.acc_y + "\r\n" +
                      "acc_z: " + "\t" + NavSAR.NmeaParser.NavIns2Data.acc_z + "\r\n" +
                      "g_x: " + "\t" + NavSAR.NmeaParser.NavIns2Data.g_x + "\r\n" +
                      "g_y : " + "\t" + NavSAR.NmeaParser.NavIns2Data.g_y + "\r\n" +
                      "g_z : " + "\t" + NavSAR.NmeaParser.NavIns2Data.g_z + "\r\n" +
                      "Темп: " + "\t" + NavSAR.NmeaParser.NavIns2Data.Mpu_Temp + "\r\n" +
                      "\r\n" +
                      "MPL115A1\r\n" +
                      "Давление:   " + "\t" + NavSAR.NmeaParser.NavIns2Data.Mpl115a1_pressure + "\r\n" +
                      "Температура: " + "\t" + NavSAR.NmeaParser.NavIns2Data.Mpl115a1_Temp + "\r\n";
                textBoxNAVINS2.Text = str;

                glControl3d.Invalidate();

                if (formMagCalibration != null) {
                    formMagCalibration.SetValues(NavSAR.NmeaParser.NavIns1Data.Hmc5883_xraw, NavSAR.NmeaParser.NavIns1Data.Hmc5883_yraw, NavSAR.NmeaParser.NavIns1Data.Hmc5883_zraw);
                    //Ins.SetCalibrationMatrix(formMagCalibration.minX, formMagCalibration.minY, formMagCalibration.minZ, formMagCalibration.maxX, formMagCalibration.maxY, formMagCalibration.maxZ);
//                    Ins.mag_x_min = formMagCalibration.minX; Ins.mag_y_min = formMagCalibration.minY; Ins.mag_z_min = formMagCalibration.minZ;
 //                   Ins.mag_x_max = formMagCalibration.maxX; Ins.mag_y_max = formMagCalibration.maxY; Ins.mag_z_max = formMagCalibration.maxZ;
                }

                if (formAccCalibration != null) {
                    formAccCalibration.SetValues(NavSAR.NmeaParser.NavIns2Data.acc_x, NavSAR.NmeaParser.NavIns2Data.acc_y, NavSAR.NmeaParser.NavIns2Data.acc_z);
                    //Ins.SetCalibrationMatrix(formMagCalibration.minX, formMagCalibration.minY, formMagCalibration.minZ, formMagCalibration.maxX, formMagCalibration.maxY, formMagCalibration.maxZ);
                    //                    Ins.mag_x_min = formMagCalibration.minX; Ins.mag_y_min = formMagCalibration.minY; Ins.mag_z_min = formMagCalibration.minZ;
                    //                   Ins.mag_x_max = formMagCalibration.maxX; Ins.mag_y_max = formMagCalibration.maxY; Ins.mag_z_max = formMagCalibration.maxZ;
                }

            };

            while (true) {
                Event.WaitOne();
                a++;
                if (InvokeRequired) {
                    Invoke(action);
                } else {
                    action();
                }
                Thread.Sleep(0);
            }
        }

        /// <summary>
        /// Обработчик нажатия на пункт меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void toolStripDropDownButtonSerialNames_ItemClicked(object sender, ToolStripItemClickedEventArgs e) {
            toolStripDropDownButtonSerialNames.Text = e.ClickedItem.Text;

            if (NavSAR.PortIsOpen()){
                NavSAR.Close();
            }

            if (!NavSAR.Open(e.ClickedItem.Text)) {
                return;
            }

            NavSAR.Initialize(ref Event);
            toolStripStatusLabel.Text = STRING_CONNECTED;
        }

        /// <summary>
        /// Обработчик закрытия формы
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e) {
            Event.Close();
            NavSAR.Release();
            thread.Abort();
        }

        /// <summary>
        /// Инициализация OpenGL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl3d_Load(object sender, EventArgs e) {
            GL.ClearColor(Color.SkyBlue);

            Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 300);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref p);

            Matrix4 modelview = Matrix4.LookAt(0, 0, 100, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            //Свет
            float[] light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
            float[] light_ambient  = { 1.0f, 0.5f, 0.5f, 1.0f };
            float[] mat_specular   = { 1.0f, 1.0f, 1.0f, 1.0f };
            float[] mat_shinines   = { 50.0f};

            GL.ShadeModel(ShadingModel.Smooth);
            GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
            GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shinines);
            GL.Light(LightName.Light0, LightParameter.Position, light_position);
            GL.Light(LightName.Light0, LightParameter.Ambient, light_ambient);
            GL.Light(LightName.Light0, LightParameter.Diffuse, mat_specular);

            GL.LightModel(LightModelParameter.LightModelTwoSide, 1);
            GL.Enable(EnableCap.Normalize);
            GL.Enable(EnableCap.Lighting);
            GL.Enable(EnableCap.Light0);
            GL.Enable(EnableCap.DepthTest);

        }

        float angle = 0;

        /// <summary>
        /// Отрисовка OpenGL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void glControl3d_Paint(object sender, PaintEventArgs e) {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            float hwidth = 20;
            float hlength = 40;
            float hheight = 10;

            GL.Color3(Color.Green);
            
            //Задняя
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(0, 0, 1);
            GL.Vertex3(-hwidth, -hheight, -hlength);
            GL.Vertex3(hwidth, -hheight, -hlength);
            GL.Vertex3(hwidth, hheight, -hlength);
            GL.Vertex3(-hwidth, hheight, -hlength);
            GL.End();

            //Передняя
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(0, 0, 1);
            GL.Vertex3(-hwidth, -hheight, hlength);
            GL.Vertex3(hwidth, -hheight, hlength);
            GL.Vertex3(hwidth, hheight, hlength);
            GL.Vertex3(-hwidth, hheight, hlength);
            GL.End();

            //Левая
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(-1, 0, 0);
            GL.Vertex3(-hwidth, -hheight, hlength);
            GL.Vertex3(-hwidth, -hheight, -hlength);
            GL.Vertex3(-hwidth, hheight, -hlength);
            GL.Vertex3(-hwidth, hheight, hlength);
            GL.End();

            //Правая
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(1, 0, 0);
            GL.Vertex3(hwidth, -hheight, hlength);
            GL.Vertex3(hwidth, -hheight, -hlength);
            GL.Vertex3(hwidth, hheight, -hlength);
            GL.Vertex3(hwidth, hheight, hlength);
            GL.End();

            //Низ
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(0, -1, 0);
            GL.Vertex3(hwidth, -hheight, hlength);
            GL.Vertex3(hwidth, -hheight, -hlength);
            GL.Vertex3(-hwidth, -hheight, -hlength);
            GL.Vertex3(-hwidth, -hheight, hlength);
            GL.End();

            //Верх
            GL.Color3(Color.Yellow);
            GL.Begin(BeginMode.Polygon);
            GL.Normal3(0, 1, 0);
            GL.Vertex3(hwidth, hheight, hlength);
            GL.Vertex3(hwidth, hheight, -hlength);
            GL.Vertex3(-hwidth, hheight, -hlength);
            GL.Vertex3(-hwidth, hheight, hlength);
            GL.End();

            //GL.MatrixMode(MatrixMode.Modelview);

            // Вращение
            Matrix4 modelview = Matrix4.LookAt(0, 0, 100, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            if (radioButtonAccel.Checked) { 
                // Акселерометр
                Ins.GetAnglesFromAccel(NavSAR, ref kurs, ref kren, ref tang);
            } else if (radioButtonGyro.Checked) {
                // Гироскоп
                Ins.GetAnglesFromGyro(NavSAR, ref kurs, ref kren, ref tang);
            }else if (radioButtonMagnetometer.Checked) {
                // Магнетометр
                Ins.GetAnglesFromMag(NavSAR, ref kurs, ref kren, ref tang);
            } else if (radioButtonComplementary.Checked) {
                // Комплементарный фильтр
                Ins.GetAnglesFromGyro(NavSAR, ref kurs, ref kren, ref tang);
                double kren_a = 0;
                double kurs_a = 0;
                double tang_a = 0;
                Ins.GetAnglesFromAccel(NavSAR, ref kurs_a, ref kren_a, ref tang_a);
                
                double K = Convert.ToDouble(maskedTextBoxComplK.Text);

                kren = (1 - K) * kren + K * kren_a;
                kurs = (1 - K) * kurs + K * kurs_a;
                tang = (1 - K) * tang + K * tang_a;
            }

            GL.Rotate(180.0f / Math.PI * kurs, 0, 1, 0);
            GL.Rotate(180.0f / Math.PI * kren, 0, 0, 1);
            GL.Rotate(180.0f / Math.PI * tang, 1, 0, 0);

            string str = "kren: " + "\t" + kren + "\r\n" +
                         "tang: " + "\t" + tang + "\r\n" +
                         "kurs: " + "\t" + kurs + "\r\n";
            
            // Показания акселерометра
            double acc_x =0, acc_y = 0, acc_z = 0;
            Ins.GetAccel(NavSAR, ref acc_x, ref acc_y, ref acc_z);

            acc_x -= Ins.acc_x_null;
            acc_y -= Ins.acc_y_null;
            acc_z -= Ins.acc_z_null;

            vx += acc_x * 0.1;
            vy += acc_y * 0.1;
            vz += acc_z * 0.1;

            sx += vx * 0.1;
            sy += vy * 0.1;
            sz += vz * 0.1;


            str += "акс_x: " + "\t" + acc_x + "\r\n" +
                   "акс_y: " + "\t" + acc_y + "\r\n" +
                   "акс_z: " + "\t" + acc_z + "\r\n" +
                   "\r\n" +
                   "s_x: " + "\t" + sx + "\r\n" +
                   "s_y: " + "\t" + sy + "\r\n" +
                   "s_z: " + "\t" + sz + "\r\n";

                        
            textBox1.Text = str;
            
            glControl3d.SwapBuffers();
        }

        /// <summary>
        /// Нуль гироскопа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttoNullGyro_Click(object sender, EventArgs e) {
            Ins.g_x_null = NavSAR.NmeaParser.NavIns2Data.g_x;
            Ins.g_y_null = NavSAR.NmeaParser.NavIns2Data.g_y;
            Ins.g_z_null = NavSAR.NmeaParser.NavIns2Data.g_z;
        }

        /// <summary>
        /// Нуль акселерометра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttoNullAcc_Click(object sender, EventArgs e) {
            double acc_x = 0, acc_y = 0, acc_z = 0;
            Ins.GetAccel(NavSAR, ref acc_x, ref acc_y, ref acc_z);
            Ins.acc_x_null = acc_x;
            Ins.acc_y_null = acc_y;
            Ins.acc_z_null = acc_z;

            vx = 0; vy = 0; vz = 0;
            sx = 0; sy = 0; sz = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButtonComplementary_CheckedChanged(object sender, EventArgs e) {
            if (radioButtonComplementary.Checked) {
                maskedTextBoxComplK.Enabled = true;
            } else {
                maskedTextBoxComplK.Enabled = false;
            }
        }

        /// <summary>
        /// Калибровка магнитометра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonMagCalibration_Click(object sender, EventArgs e) {
            formMagCalibration = new FormMagCalibration();
            //formMagCalibration.Initialize(this);
            System.Windows.Forms.DialogResult res = formMagCalibration.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK) {
                Ins.SetCalibrationMatrix(formMagCalibration.minX, formMagCalibration.minY, formMagCalibration.minZ, formMagCalibration.maxX, formMagCalibration.maxY, formMagCalibration.maxZ);
            }
            if (res == System.Windows.Forms.DialogResult.Retry) {
                Ins.SetCalibrationMatrix(formMagCalibration.minX, formMagCalibration.minY, formMagCalibration.minZ, formMagCalibration.maxX, formMagCalibration.maxY, formMagCalibration.maxZ);
                string str = Ins.GetStringCalibrationMatrix();
                NavSAR.WriteCal1String(str);
            }
            if (res == System.Windows.Forms.DialogResult.Ignore) {
                NavSAR.WriteIdentityCal1String();
            }

        }

        /// <summary>
        /// Калибровка акселерометра
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAccCalibration_Click(object sender, EventArgs e) {
            formAccCalibration = new FormAccCalibration();
            //formMagCalibration.Initialize(this);
            System.Windows.Forms.DialogResult res = formAccCalibration.ShowDialog();
            if (res == System.Windows.Forms.DialogResult.OK) {
                Ins.SetCalibrationMatrixAcc(formAccCalibration.minX, formAccCalibration.minY, formAccCalibration.minZ, formAccCalibration.maxX, formAccCalibration.maxY, formAccCalibration.maxZ);
            }
            if (res == System.Windows.Forms.DialogResult.Retry) {
                Ins.SetCalibrationMatrixAcc(formAccCalibration.minX, formAccCalibration.minY, formAccCalibration.minZ, formAccCalibration.maxX, formAccCalibration.maxY, formAccCalibration.maxZ);
                string str = Ins.GetStringCalibrationMatrixAcc();
              //  NavSAR.WriteCal1String(str);
            }
            if (res == System.Windows.Forms.DialogResult.Ignore) {
                NavSAR.WriteIdentityCal1String();
            }
        }

        private void buttonReset_Click(object sender, EventArgs e) {
            Ins.ResetCalibrationMatrix();
        }
    }
}
