using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LinearAlgebra.Matricies;

namespace navSAR{
    class CIns{
        // Коэффициенты коррекции нуля гироскопа
        public int g_x_null = 0;
        public int g_y_null = 0;
        public int g_z_null = 0;

        // Коэффициенты коррекции нуля акселерометра
        public double acc_x_null = 0;
        public double acc_y_null = 0;
        public double acc_z_null = 0;

        // Матрицы коррекции показаний магнитометра
        DoubleMatrix S_MAG;
        DoubleMatrix T_MAG;

        // Матрицы коррекции показаний акселерометра
        DoubleMatrix S_ACC;
        DoubleMatrix T_ACC;

        // Коэффициенты коррекции показаний магнитометра
/*        public int mag_x_min = 0;
        public int mag_y_min = 0;
        public int mag_z_min = 0;
        public int mag_x_max = 0;
        public int mag_y_max = 0;
        public int mag_z_max = 0;
*/
        // Константы ИНС
        const double ACC_LIM = 2;                   // Предел измерения акселерометра
        const double GYR_LIM = 500 * Math.PI / 180; // Предел измерения акселерометра
        const double MAG_LIM = 1.3;                 // Предел измерения магнетометра
        const double G_CONST = 9.8;                 // Гравитационная постоянная
        const double ACC_BITS = 16;                 // Разрядность акселерометра
        const double GYR_BITS = 16;                 // Разрядность гироскопа
        const double MAG_BITS = 16;                 // Разрядность магнетометра
        const double dT       = 0.1;                // Период выдачи информации от ИНС

        // Разрешение измерителей на один бит
        double ACC_RES = (2 * ACC_LIM) * G_CONST / (Math.Pow(2, ACC_BITS)); // Разрешение акселерометра в м/с^2
        double GYR_RES = (2 * GYR_LIM) / (Math.Pow(2, GYR_BITS));           // Разрешение гироскопа в град/с
        double MAG_RES = (2 * MAG_LIM) / (Math.Pow(2, ACC_BITS));           // Разрешение магнитометра

        public bool ShowGraph = false;              // Отображение графика

        public CIns() {
            ResetCalibrationMatrix();
        }

        // Возвращает значения показаний акселерометра
        public void GetAccel(CNavSAR navsar, ref double accx, ref double accy, ref double accz) {
            accx = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_x;
            accy = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_y;
            accz = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_z;
            
            DoubleMatrix acc = new Double[,] { { accx }, { accy }, { accz }, { 1 } };
            DoubleMatrix ACC = S_ACC * T_ACC * acc;// Коррекция измерений

            accx = ACC[0, 0];
            accy = ACC[0, 1];
            accz = ACC[0, 2];
        }

        // Возвращает значения углов крена, курса и тангажа из показаний акселерометра
        public void GetAnglesFromAccel(CNavSAR navsar, ref double kurs, ref double kren, ref double tang) {
            double accx = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_x;
            double accy = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_y;
            double accz = ACC_RES * navsar.NmeaParser.NavIns2Data.acc_z;

            kren = -Math.Atan2(accx, (Math.Sqrt(accy * accy + accz * accz)));
            tang =  Math.Atan2(-accy, accz);
            kurs = 0;
        }

        // Возвращает значения углов крена, курса и тангажа из показаний гироскопа
        public void GetAnglesFromGyro(CNavSAR navsar, ref double kurs, ref double kren, ref double tang) {      
/*
            double phi = kren;
            double theta = tang;

            DoubleMatrix A = new Double[,] { { kren }, { kurs }, { tang } };

            DoubleMatrix T = new Double[,] { { 1, Math.Sin(phi) * Math.Tan(theta), Math.Cos(phi) * Math.Tan(theta)},
                                             { 0, Math.Cos(phi)                  , -Math.Sin(phi)},
                                             { 0, Math.Sin(phi) / Math.Cos(theta), Math.Cos(phi) / Math.Cos(theta)}};
*/
            double wx = GYR_RES * (navsar.NmeaParser.NavIns2Data.g_x - g_x_null);
            double wy = GYR_RES * (navsar.NmeaParser.NavIns2Data.g_y - g_y_null);
            double wz = GYR_RES * (navsar.NmeaParser.NavIns2Data.g_z - g_z_null);
/*
            DoubleMatrix W = new Double[,] { { wx }, { wy }, { wz } };

            DoubleMatrix f = T * W;

            DoubleMatrix Ak = A + (f * dT);
            
            kurs = Ak[0, 0];
            kren = Ak[0, 1];
            tang = Ak[0, 2];
*/
            kurs = kurs + wz * dT;
            kren = kren + wy * dT;
            tang = tang - wx * dT;
        }

        // Возвращает значения углов крена, курса и тангажа из показаний магнетометра
        public void GetAnglesFromMag(CNavSAR navsar, ref double kurs, ref double kren, ref double tang) {
            double magx = navsar.NmeaParser.NavIns1Data.Hmc5883_xraw;
            double magy = navsar.NmeaParser.NavIns1Data.Hmc5883_yraw;
            double magz = navsar.NmeaParser.NavIns1Data.Hmc5883_zraw;

           
            DoubleMatrix mag = new Double[,] { { magx }, { magy }, { magz }, { 1 } };
            DoubleMatrix MAG = S_MAG * T_MAG * mag;// Коррекция измерений

            kurs = 0;// Math.Atan2(MAG[0, 0], MAG[0, 1]); ;
            kren = Math.Atan2(MAG[0, 0], (Math.Sqrt(MAG[0, 1] * MAG[0, 1] + MAG[0, 2] * MAG[0, 2])));
            tang = Math.Atan2(-MAG[0, 1], MAG[0, 2]);

           // kurs = MAG[0, 0];
           // kren = MAG[0, 1];
           // tang = MAG[0, 2];
        }

        public void SetCalibrationMatrix(int mag_x_min, int mag_y_min, int mag_z_min, int mag_x_max, int mag_y_max, int mag_z_max) {
            double S_MAG_X = (2 * 10000.0f) / (mag_x_max - mag_x_min);   // Коэффициент масштабирования магнитометра по оси x
            double S_MAG_Y = (2 * 10000.0f) / (mag_y_max - mag_y_min);   // Коэффициент масштабирования магнитометра по оси y
            double S_MAG_Z = (2 * 10000.0f) / (mag_z_max - mag_z_min);   // Коэффициент масштабирования магнитометра по оси z

            double T_MAG_X = -(mag_x_max + mag_x_min) / 2; // Коэффициент смещения акселерометра по оси x
            double T_MAG_Y = -(mag_y_max + mag_y_min) / 2; // Коэффициент смещения акселерометра по оси y
            double T_MAG_Z = -(mag_z_max + mag_z_min) / 2; // Коэффициент смещения акселерометра по оси z

            S_MAG = new Double[,] { { S_MAG_X, 0, 0, 0 }, { 0, S_MAG_Y, 0, 0 }, { 0, 0, S_MAG_Z, 0 }, { 0, 0, 0, 1 } }; // Матрица масштабирования
            T_MAG = new Double[,] { { 1, 0, 0, T_MAG_X }, { 0, 1, 0, T_MAG_Y }, { 0, 0, 1, T_MAG_Z }, { 0, 0, 0, 1 } }; // Матрица смещения
        }

        public void ResetCalibrationMatrix() {
            S_MAG = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица масштабирования
            T_MAG = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица смещения

            S_ACC = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица масштабирования
            T_ACC = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица смещения

        }

        public string GetStringCalibrationMatrix() {
            DoubleMatrix MAG = S_MAG * T_MAG;

            string str = "";

            for (int c = 0; c < MAG.ColumnCount; c++) {
                for (int r = 0; r < MAG.RowCount; r++) {
                    str += ',';
                    str += ((float)MAG[r, c]).ToString();                   
                }
            }
            
            return str;
        }

        public void SetCalibrationMatrixAcc(int acc_x_min, int acc_y_min, int acc_z_min, int acc_x_max, int acc_y_max, int acc_z_max) {
            double S_ACC_X = (2 * 10000.0f) / (acc_x_max - acc_x_min);   // Коэффициент масштабирования акселерометра по оси x
            double S_ACC_Y = (2 * 10000.0f) / (acc_y_max - acc_y_min);   // Коэффициент масштабирования акселерометра по оси y
            double S_ACC_Z = (2 * 10000.0f) / (acc_z_max - acc_z_min);   // Коэффициент масштабирования акселерометра по оси z

            double T_ACC_X = -(acc_x_max + acc_x_min) / 2; // Коэффициент смещения акселерометра по оси x
            double T_ACC_Y = -(acc_y_max + acc_y_min) / 2; // Коэффициент смещения акселерометра по оси y
            double T_ACC_Z = -(acc_z_max + acc_z_min) / 2; // Коэффициент смещения акселерометра по оси z

            S_ACC = new Double[,] { { S_ACC_X, 0, 0, 0 }, { 0, S_ACC_Y, 0, 0 }, { 0, 0, S_ACC_Z, 0 }, { 0, 0, 0, 1 } }; // Матрица масштабирования
            T_ACC = new Double[,] { { 1, 0, 0, T_ACC_X }, { 0, 1, 0, T_ACC_Y }, { 0, 0, 1, T_ACC_Z }, { 0, 0, 0, 1 } }; // Матрица смещения
        }

        public void ResetCalibrationMatrixAcc() {
            S_ACC = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица масштабирования
            T_ACC = new Double[,] { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } }; // Матрица смещения
        }
        
        public string GetStringCalibrationMatrixAcc() {
            DoubleMatrix ACC = S_ACC * T_ACC;

            string str = "";

            for (int c = 0; c < ACC.ColumnCount; c++) {
                for (int r = 0; r < ACC.RowCount; r++) {
                    str += ',';
                    str += ((float)ACC[r, c]).ToString();
                }
            }

            return str;
        }
    }
}
