using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace navSAR
{
    class CNmeaParser
    {
        const int NP_MAX_CMD_LEN = 128;
        const int NP_MAX_DATA_LEN = 256;
        const int MAXFIELD = 15;

        public struct NAVINS1_STRUCT {
            public float Mpl3115a2_Altitude;
            public float Mpl3115a2_fPressure;
            public float Mpl3115a2_fTemp;
            public Int16 Hmc5883_xraw;
            public Int16 Hmc5883_yraw;
            public Int16 Hmc5883_zraw;
            public float Hmc5883_heading;
        };

        public struct NAVINS2_STRUCT {
            public Int16 acc_x;
            public Int16 acc_y;
            public Int16 acc_z;
            public Int16 g_x;
            public Int16 g_y;
            public Int16 g_z;
            public float Mpu_Temp;
            public float Mpl115a1_altitude;
            public float Mpl115a1_pressure;
            public float Mpl115a1_Temp;
        };

        public NAVINS1_STRUCT NavIns1Data;
        public NAVINS2_STRUCT NavIns2Data;

        public enum NMEA_TERMS
        {
            NP_TERM_NONE,
            NP_TERM_NAVINS1,
            NP_TERM_NAVINS2,
            NP_TERM_NAVGPS
        };

        public enum NP_STATE
        {
            NP_STATE_SOM,
            NP_STATE_CMD,
            NP_STATE_DATA,
            NP_STATE_CHECKSUM1,
            NP_STATE_CHECKSUM2
        };

        NP_STATE    m_nState = NP_STATE.NP_STATE_SOM;
        int m_btChecksum = 0;
        int m_wIndex = 0;
        int[] m_pCommand = new int[NP_MAX_CMD_LEN];
        int[] m_pData = new int[NP_MAX_DATA_LEN];
        int m_btReceivedChecksum;

        // ParseBuffer()
        public NMEA_TERMS ParseBuffer(string str) {
            NMEA_TERMS cmd = NMEA_TERMS.NP_TERM_NONE;

            foreach (char ch in str) {
                cmd = ProcessNMEA(ch);
                if (cmd != NMEA_TERMS.NP_TERM_NONE)
                    break;
            }
            return cmd;
        }

        // ProcessNMEA()
        public NMEA_TERMS ProcessNMEA(char btData) {
            NMEA_TERMS command = NMEA_TERMS.NP_TERM_NONE;
            
            switch (m_nState) {
                ///////////////////////////////////////////////////////////////////////
                // Search for start of message '$'
                case NP_STATE.NP_STATE_SOM:
                    if (btData == '$') {
                        m_btChecksum = 0;			// reset checksum
                        m_wIndex = 0;				// reset index
                        m_nState = NP_STATE.NP_STATE_CMD;
                    }
                    break;
                ///////////////////////////////////////////////////////////////////////
                // Retrieve command (NMEA Address)
                case NP_STATE.NP_STATE_CMD:
                    if (btData != ',' && btData != '*') {
                        m_pCommand[m_wIndex++] = btData;
                        m_btChecksum ^= btData;

                        // Check for command overflow
                        if (m_wIndex >= NP_MAX_CMD_LEN) {
                            m_nState = NP_STATE.NP_STATE_SOM;
                        }
                    } else {
                        m_pCommand[m_wIndex] = '\0';	// terminate command
                        m_btChecksum ^= btData;
                        m_wIndex = 0;
                        m_nState = NP_STATE.NP_STATE_DATA;		// goto get data state
                    }
                    break;
                ///////////////////////////////////////////////////////////////////////
                // Store data and check for end of sentence or checksum flag
                case NP_STATE.NP_STATE_DATA:
                    if (btData == '*') { // checksum flag?
                        m_pData[m_wIndex] = '\0';
                        m_nState = NP_STATE.NP_STATE_CHECKSUM1;
                    } else { // no checksum flag, store data
                        // Check for end of sentence with no checksum
                        if (btData == '\r') {
                            m_pData[m_wIndex] = '\0';
                            command = ProcessCommand(m_pCommand, m_pData);
                            m_nState = NP_STATE.NP_STATE_SOM;
                            return command;
                        }

                        // Store data and calculate checksum
                        m_btChecksum ^= btData;
                        m_pData[m_wIndex] = btData;
                        if (++m_wIndex >= NP_MAX_DATA_LEN) { // Check for buffer overflow
                            m_nState = NP_STATE.NP_STATE_SOM;
                        }
                    }
                    break;

                ///////////////////////////////////////////////////////////////////////
                case NP_STATE.NP_STATE_CHECKSUM1:
                    if ((btData - '0') <= 9) {
                        m_btReceivedChecksum = (btData - '0') << 4;
                    } else {
                        m_btReceivedChecksum = (btData - 'A' + 10) << 4;
                    }

                    m_nState = NP_STATE.NP_STATE_CHECKSUM2;

                    break;

                ///////////////////////////////////////////////////////////////////////
                case NP_STATE.NP_STATE_CHECKSUM2:
                    if ((btData - '0') <= 9) {
                        m_btReceivedChecksum |= (btData - '0');
                    } else {
                        m_btReceivedChecksum |= (btData - 'A' + 10);
                    }

                    if (m_btChecksum == m_btReceivedChecksum) {
                        command = ProcessCommand(m_pCommand, m_pData);
                    }

                    m_nState = NP_STATE.NP_STATE_SOM;
                    break;

                ///////////////////////////////////////////////////////////////////////
                default:
                    m_nState = NP_STATE.NP_STATE_SOM;

                    return command;
            }
            return command;
        }

        string IntArrayToString(int[] array) {
            string str = "";

            foreach (int ch in array) {
                if (ch == 0)
                    break;
                str += (char)ch;
            }
            return str;
        }

        // ProcessCommand()
        NMEA_TERMS ProcessCommand(int[] pCommand, int[] pData) {
            NMEA_TERMS command = NMEA_TERMS.NP_TERM_NONE;

            string Command = IntArrayToString(pCommand);
            string Data = IntArrayToString(pData);

            string Field = "";
            //NAVINS1
            if (Command == "NAVINS1") {
                if (GetField(Data, ref Field, 0, MAXFIELD)) {
                    NavIns1Data.Mpl3115a2_Altitude  = Convert.ToSingle(Field);
                }
                if (GetField(Data, ref Field, 1, MAXFIELD)) {
                    NavIns1Data.Mpl3115a2_fPressure = Convert.ToSingle(Field);
                }
                if (GetField(Data, ref Field, 2, MAXFIELD)) {
                    NavIns1Data.Mpl3115a2_fTemp = Convert.ToSingle(Field);
                }
                if (GetField(Data, ref Field, 3, MAXFIELD)) {
                    NavIns1Data.Hmc5883_xraw = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 4, MAXFIELD)) {
                    NavIns1Data.Hmc5883_yraw = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 5, MAXFIELD)) {
                    NavIns1Data.Hmc5883_zraw = Convert.ToInt16(Field);
                }

                command = NMEA_TERMS.NP_TERM_NAVINS1;
            }

            //NAVINS2
            if (Command == "NAVINS2") {
                if (GetField(Data, ref Field, 0, MAXFIELD)) {
                    NavIns2Data.acc_x = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 1, MAXFIELD)) {
                    NavIns2Data.acc_y = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 2, MAXFIELD)) {
                    NavIns2Data.acc_z = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 3, MAXFIELD)) {
                    NavIns2Data.g_x = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 4, MAXFIELD)) {
                    NavIns2Data.g_y = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 5, MAXFIELD)) {
                    NavIns2Data.g_z = Convert.ToInt16(Field);
                }
                if (GetField(Data, ref Field, 6, MAXFIELD)) {
                    NavIns2Data.Mpu_Temp = Convert.ToSingle(Field);
                }
                if (GetField(Data, ref Field, 7, MAXFIELD)) {
                    NavIns2Data.Mpl115a1_altitude = Convert.ToSingle(Field);
                }
                if (GetField(Data, ref Field, 8, MAXFIELD)) {
                    NavIns2Data.Mpl115a1_pressure = Convert.ToSingle(Field);
                }
//                if (GetField(Data, ref Field, 9, MAXFIELD)) {
//                    NavIns2Data.Mpl115a1_Temp = Convert.ToSingle(Field);
//                }
                command = NMEA_TERMS.NP_TERM_NAVINS2;
            }

            //NAVGPS
            if (Command == "NAVGPS") {
                command = NMEA_TERMS.NP_TERM_NAVGPS;
            }

            return command;
        }

        // GetField()
        bool GetField(string Data, ref string Field, int nFieldNum, int nMaxFieldLen) {
            Field = "";

            // Validate params
            if (Data.Length == 0 || nMaxFieldLen <= 0) {
                return false;
            }

            // Go to the beginning of the selected field
            int i = 0;
            int nField = 0;
            while (nField != nFieldNum /*&& Data[i]*/) {
                if (Data[i] == ',') {
                    nField++;
                }

                i++;
                            
                if (i >= Data.Length) {
                    Field = "0";
                    return false;
                }
            }

            if (Data[i] == ',' || Data[i] == '*') {
                Field = "0";
                return false;
            }
            
            // copy field from pData to Field
            int i2 = 0;
            while (Data[i] != ',' && Data[i] != '*') {
                Field += Data[i];
                //i2++;
                i++;

                // check if field is too big to fit on passed parameter. If it is,
                // crop returned field to its max length.
                if (i2 >= nMaxFieldLen) {
                    i2 = nMaxFieldLen - 1;
                    break;
                }
            }

            Field = Field.Replace('.', ',');
//            pField[i2] = '\0';

            return true;
        }
    }
}
