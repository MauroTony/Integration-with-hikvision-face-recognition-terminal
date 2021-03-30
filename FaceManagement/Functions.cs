using System;
using MySqlConnector;
using System.Threading; 
using System.Web.Script.Serialization;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Globalization;

namespace FaceManagement
{
    class Functions
    {
        private static int lUserID = -1, m_iUserID = -1, m_UserID = -1, m_lCapFaceCfgHandle = 0, m_lSetCardCfgHandle = 0, m_lDelFingerPrintCfHandle = -1, m_lDelCardCfgHandle = -1;
        private static string FilePath = "", PATH_LOG = @"C:\Integracao\Log";

        public static void Main(string function, string nome, string codigo, string filename, string cd_dispositivo, string Employee, string user, string cd_camera)
        {
            try
            {
                CHCNetSDKCard.NET_DVR_Logout_V30(0);
                CHCNetSDKCard.NET_DVR_Cleanup();
                //Thread.CurrentThread.CurrentCulture = new CultureInfo("pt-BR", false);

                int verif = 0;
                string login = "", passwd = "";
                string sql_busca_dispositivos = "SELECT IP FROM DEVICES where DEVICE_TYPE = '2'";
                string sql_busca_camera = $"SELECT IP FROM DEVICES WHERE CD_DEVICES = '{cd_camera}'";
                DateTime data = DateTime.Now;

                MySqlConnection conn = new MySqlConnection("server=172.0.0.1;port=3306;User Id=USER;password=PASSWORD;database=SCHEMA");

                if (function == "camera")// inicio da chamada da camera
                {
                    conn.Open();
                    MySqlCommand dispositivos_cam = new MySqlCommand(sql_busca_camera, conn);
                    MySqlDataReader ip_dispositivo_cam_bd = dispositivos_cam.ExecuteReader();

                    if (ip_dispositivo_cam_bd.Read())
                    {

                        string ip_dispositivo = ip_dispositivo_cam_bd.GetString(0);
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";
                        //Console.WriteLine(ip_dispositivo);

                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        conn.Close();
                        conn.Open();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();


                        string json = json_bd.GetString(0);
                        //Console.WriteLine($"json = {json}");
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;
                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;
                                verif++;
                            }
                        }
                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }

                        StreamWriter log_camera = new StreamWriter($@"{PATH_LOG}\funcao_camera_{user}_.txt", true);
                        log_camera.WriteLine(data);
                        log_camera.WriteLine();
                        CapturaFace(log_camera, codigo);
                        log_camera.Close();
                        //Console.WriteLine($"m_iUserID = {m_iUserID}");
                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        //Console.ReadLine();
                    }
                }// fim da chamada da camera

                else if (function == "register")// inicio do cadastramento no dispositivo
                {

                    conn.Open();
                    MySqlCommand dispositivos = new MySqlCommand(sql_busca_dispositivos, conn);
                    MySqlDataReader ip_dispositivo_bd = dispositivos.ExecuteReader();
                    List<String> ips = new List<String>();
                    while (ip_dispositivo_bd.Read())
                    {
                        ips.Add(ip_dispositivo_bd.GetString(0));
                    }
                    conn.Close();
                    int count = 0;
                    foreach (string ips_hik in ips)
                    {
                        verif = 0;
                        count++;
                        string ip_dispositivo = ips_hik;
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";
                        conn.Open(); 
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();

                        string json = json_bd.GetString(0);
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;

                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;

                                verif++;
                            }
                        }

                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }
                        Employee = codigo;


                        StreamWriter log_registrar = new StreamWriter($@"{PATH_LOG}\funcao_registrar_{user}.txt", true);
                        log_registrar.WriteLine(data);
                        log_registrar.WriteLine();
                        log_registrar.WriteLine(login);
                        log_registrar.WriteLine(passwd);
                        CriaRegistro(nome, codigo, Employee, log_registrar);
                        Console.Write($"no Dispositivo {count}");
                        Console.Write($"*");
                        deleta_face(codigo, log_registrar);
                        Console.Write($"*");
                        EnviaFoto(filename, codigo, log_registrar);

                        log_registrar.Close();
                        //Console.WriteLine($"m_iUserID = {m_iUserID}");
                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        //Console.ReadLine();
                        Console.Write("(next)");
                    }


                }// fim do cadastramento no dispositivo

                else if (function == "qrcode")// inicio do cadastramento de qrcode no dispositivo
                {
                    verif = 0;
                    conn.Open();
                    MySqlCommand dispositivos = new MySqlCommand(sql_busca_dispositivos, conn);
                    MySqlDataReader ip_dispositivo_bd = dispositivos.ExecuteReader();
                    List<String> ips = new List<String>();
                    while (ip_dispositivo_bd.Read())
                    {
                        ips.Add(ip_dispositivo_bd.GetString(0));
                    }
                    conn.Close();
                    foreach (string ips_hik in ips)
                    {
                        string ip_dispositivo = ips_hik;
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";
                        verif = 0;
                        conn.Open();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();

                        string json = json_bd.GetString(0);
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;
                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;
                                verif++;
                            }
                        }
                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }

                        StreamWriter log_qrcode = new StreamWriter($@"{PATH_LOG}\funcao_qrcode_{user}.txt", true);
                        log_qrcode.WriteLine(data);
                        log_qrcode.WriteLine(ip_dispositivo);
                        CriaRegistro(nome, codigo, Employee, log_qrcode);
                        log_qrcode.Close();
                        //Console.WriteLine($"m_iUserID = {m_iUserID}");
                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        //Console.ReadLine();
                    }

                }// fim do cadastramento de qrcode no dispositivo

                else if (function == "delete_face")// inicio do deletamento da face
                {
                    verif = 0;
                    conn.Open();
                    MySqlCommand dispositivos = new MySqlCommand(sql_busca_dispositivos, conn);
                    MySqlDataReader ip_dispositivo_bd = dispositivos.ExecuteReader();
                    List<String> ips = new List<String>();
                    while (ip_dispositivo_bd.Read())
                    {
                        ips.Add(ip_dispositivo_bd.GetString(0));
                    }
                    conn.Close();
                    foreach (string ips_hik in ips)
                    {
                        string ip_dispositivo = ips_hik;
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";
                        conn.Open();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();

                        string json = json_bd.GetString(0);
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;
                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;
                                verif++;
                            }
                        }
                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }
                        StreamWriter log_deleta_face = new StreamWriter($@"{PATH_LOG}\funcao_deleta_face_{user}.txt", true);
                        log_deleta_face.WriteLine(data);
                        log_deleta_face.WriteLine();
                        deleta_face(codigo, log_deleta_face);
                        log_deleta_face.Close();

                        //Console.WriteLine($"m_iUserID = {m_iUserID}");
                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        //Console.ReadLine();
                    }

                }// fim do deletamento da face

                else if (function == "delete_register")// inicio do deletamento do registro
                {
                    verif = 0;
                    conn.Open();
                    MySqlCommand dispositivos = new MySqlCommand(sql_busca_dispositivos, conn);
                    MySqlDataReader ip_dispositivo_bd = dispositivos.ExecuteReader();
                    List<String> ips = new List<String>();
                    while (ip_dispositivo_bd.Read())
                    {
                        ips.Add(ip_dispositivo_bd.GetString(0));
                    }
                    conn.Close();
                    foreach (string ips_hik in ips)
                    {
                        string ip_dispositivo = ips_hik;
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";

                        conn.Open();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();

                        string json = json_bd.GetString(0);
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;
                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;
                                verif++;
                            }
                        }
                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }
                        StreamWriter log_deleta_registro = new StreamWriter($@"{PATH_LOG}\funcao_deleta_registro_{user}.txt", true);
                        log_deleta_registro.WriteLine(data);
                        log_deleta_registro.WriteLine();
                        deleta_registro(codigo, log_deleta_registro);
                        log_deleta_registro.Close();

                        //Console.WriteLine($"m_iUserID = {m_iUserID}");

                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        //Console.ReadLine();
                    }

                }// fim do deletamento do registro

                else if (function == "activate_relay")// inicio libera porta do dispositivo
                {
                    verif = 0;
                    conn.Open();
                    MySqlCommand dispositivos = new MySqlCommand(sql_busca_dispositivos, conn);
                    MySqlDataReader ip_dispositivo_bd = dispositivos.ExecuteReader();
                    List<String> ips = new List<String>();
                    while (ip_dispositivo_bd.Read())
                    {
                        ips.Add(ip_dispositivo_bd.GetString(0));
                    }
                    conn.Close();
                    foreach (string ips_hik in ips)
                    {
                        string ip_dispositivo = ips_hik;
                        string sql_busca_dados_login = $"SELECT JSON_PASSWORD_LOGIN FROM DEVICES WHERE IP = '{ip_dispositivo}';";

                        conn.Open();
                        JavaScriptSerializer serializer = new JavaScriptSerializer();
                        MySqlCommand inicializacao = new MySqlCommand(sql_busca_dados_login, conn);
                        MySqlDataReader json_bd = inicializacao.ExecuteReader();
                        json_bd.Read();

                        string json = json_bd.GetString(0);
                        conn.Close();

                        dynamic resultado = serializer.DeserializeObject(json);
                        foreach (KeyValuePair<string, object> entry in resultado)
                        {
                            var key = entry.Key;
                            var value = entry.Value as string;
                            //Console.WriteLine(String.Format("{0} : {1}", key, value));
                            if (key == "login")
                            {
                                login = value;
                                verif++;
                            }
                            else if (key == "password")
                            {
                                passwd = value;
                                verif++;
                            }
                        }
                        if (verif == 2)
                        {
                            Login(login, passwd, ip_dispositivo, user);
                        }
                        StreamWriter log_libera = new StreamWriter($@"{PATH_LOG}\funcao_libera_porta_{user}.txt", true);
                        log_libera.WriteLine(data);
                        log_libera.WriteLine();
                        libera(log_libera);
                        log_libera.Close();

                        //Console.WriteLine($"m_iUserID = {m_iUserID}");
                        CHCNetSDKCard.NET_DVR_Logout_V30(m_iUserID);
                        CHCNetSDKCard.NET_DVR_Cleanup();
                        m_UserID = m_iUserID;
                        //Console.ReadLine();
                    }

                }// fim libera porta do dispositivo
            }
            catch (Exception error)
            {
                DateTime data = DateTime.Now;
                StreamWriter log_error = new StreamWriter($@"{PATH_LOG}\erro{user}.txt");
                log_error.WriteLine(data);
                log_error.WriteLine();
                log_error.WriteLine(error);
                log_error.Close();
            }
        }
        // inicio do login
        private static void Login(string login, string passwd, string ip_dispositivo, string user)
        {
            StreamWriter log_login = new StreamWriter($@"{PATH_LOG}\Login_{user}.txt", true);
            DateTime data = DateTime.Now;
            log_login.WriteLine(data);
            log_login.WriteLine(ip_dispositivo);
            log_login.WriteLine();
            /*
            if (m_iUserID >= 0)
            {
                return;
            }
            */
            CHCNetSDKCard.NET_DVR_Init();
            if (CHCNetSDK.NET_DVR_Init() == false)
            {
                // Console.WriteLine("NET_DVR_Init error!");
                log_login.WriteLine("NET_DVR_Init error!");
                log_login.WriteLine();
                log_login.Close();

                return;
            }
            //Console.WriteLine("SDK iniciado");
            
            CHCNetSDK.NET_DVR_USER_LOGIN_INFO struLoginInfo = new CHCNetSDK.NET_DVR_USER_LOGIN_INFO();
            CHCNetSDK.NET_DVR_DEVICEINFO_V40 struDeviceInfoV40 = new CHCNetSDK.NET_DVR_DEVICEINFO_V40();

            struDeviceInfoV40.struDeviceV30.sSerialNumber = new byte[CHCNetSDK.SERIALNO_LEN];
            struLoginInfo.sDeviceAddress = ip_dispositivo;
            struLoginInfo.sUserName = login;
            struLoginInfo.sPassword = passwd;
            log_login.WriteLine(struLoginInfo.sUserName);
            log_login.WriteLine(struLoginInfo.sPassword);
            log_login.WriteLine();
            struLoginInfo.wPort = 8000;
            lUserID = CHCNetSDK.NET_DVR_Login_V40(ref struLoginInfo, ref struDeviceInfoV40);

            if (lUserID >= 0)
            {
                m_iUserID = lUserID;
                m_UserID = lUserID;
                // Console.WriteLine("Conectado");
                log_login.WriteLine("Conectado");
                log_login.WriteLine();
            }
            else
            {
                uint nErr = CHCNetSDK.NET_DVR_GetLastError();
                if (nErr == CHCNetSDK.NET_DVR_PASSWORD_ERROR)
                {
                    //Console.WriteLine("Usuario ou senha errada!");
                    log_login.WriteLine("Usuario ou senha errada!");
                    log_login.WriteLine();
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        string strTemp1 = string.Format("Left {0} try opportunity", struDeviceInfoV40.byRetryLoginTime);
                        //Console.WriteLine(strTemp1);
                        log_login.WriteLine(strTemp1);
                        log_login.WriteLine();
                    }
                }
                else if (nErr == CHCNetSDK.NET_DVR_USER_LOCKED)
                {
                    if (1 == struDeviceInfoV40.bySupportLock)
                    {
                        string strTemp1 = string.Format("user is locked, the remaining lock time is {0}", struDeviceInfoV40.dwSurplusLockTime);
                        //Console.WriteLine(strTemp1);
                        log_login.WriteLine(strTemp1);
                        log_login.WriteLine();
                    }
                }
                else
                {
                    //Console.WriteLine("erro de rede ou dispositivo está ocupado! {0}", CHCNetSDK.NET_DVR_GetLastError());
                    log_login.WriteLine("erro de rede ou dispositivo está ocupado! {0}", CHCNetSDK.NET_DVR_GetLastError());
                    log_login.WriteLine();
                }
                

            }
            log_login.Close();
        }
        // fim do login

        // inicio libera porta
        public static void libera(StreamWriter log_libera)
        {
            if (CHCNetSDKCard.NET_DVR_ControlGateway(m_UserID, 1, 1))
            {
                Console.WriteLine("NET_DVR_ControlGateway: open door succeed");
                log_libera.WriteLine("NET_DVR_ControlGateway: open door succeed");
                log_libera.WriteLine();
            }
            else
            {
                Console.WriteLine("NET_DVR_ControlGateway: open door failed error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                log_libera.WriteLine("NET_DVR_ControlGateway: open door failed error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                log_libera.WriteLine();
            }
        }
        // fim libera porta

        // inicio da inicialização da camera no dispositivo
        private static void CapturaFace(StreamWriter log_camera, string codigo)
        {
            
            if (m_lCapFaceCfgHandle != -1)
            {
                CHCNetSDK.NET_DVR_StopRemoteConfig(m_lCapFaceCfgHandle);
                m_lCapFaceCfgHandle = -1;
            }

            CHCNetSDK.NET_DVR_CAPTURE_FACE_COND struCond = new CHCNetSDK.NET_DVR_CAPTURE_FACE_COND();
            struCond.init();
            struCond.dwSize = Marshal.SizeOf(struCond);
            int dwInBufferSize = struCond.dwSize;
            IntPtr ptrStruCond = Marshal.AllocHGlobal(dwInBufferSize);
            Marshal.StructureToPtr(struCond, ptrStruCond, false);
            m_lCapFaceCfgHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(lUserID   , CHCNetSDK.NET_DVR_CAPTURE_FACE_INFO, ptrStruCond, dwInBufferSize, null, IntPtr.Zero);
            if (-1 == m_lCapFaceCfgHandle)
            {
                Marshal.FreeHGlobal(ptrStruCond);
                log_camera.WriteLine("NET_DVR_CAP_FACE_FAIL, ERROR CODE " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                log_camera.WriteLine();
                Console.WriteLine("NET_DVR_CAP_FACE_FAIL, ERROR CODE " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                return;
            }

            CHCNetSDK.NET_DVR_CAPTURE_FACE_CFG struFaceCfg = new CHCNetSDK.NET_DVR_CAPTURE_FACE_CFG();
            struFaceCfg.init();
            int dwStatus = 0;
            int dwOutBuffSize = Marshal.SizeOf(struFaceCfg);
            bool Flag = true;
            while (Flag)
            {
                dwStatus = CHCNetSDK.NET_DVR_GetNextRemoteConfig(m_lCapFaceCfgHandle, ref struFaceCfg, dwOutBuffSize);
                switch (dwStatus)
                {
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_SUCCESS:
                        ProcessCapFaceData(ref struFaceCfg, ref Flag, log_camera, codigo);
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_NEED_WAIT:
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_FAILED:
                        CHCNetSDK.NET_DVR_StopRemoteConfig(m_lCapFaceCfgHandle);
                        log_camera.WriteLine("NET_SDK_GET_NEXT_STATUS_FAILED " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                        log_camera.WriteLine();
                        Console.WriteLine("NET_SDK_GET_NEXT_STATUS_FAILED " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                        Flag = false;
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_FINISH:
                        CHCNetSDK.NET_DVR_StopRemoteConfig(m_lCapFaceCfgHandle);
                        Flag = false;
                        break;
                    default:
                        log_camera.WriteLine("NENHUM ROSTO DETECTADO OU ROSTO MAL POSICIONADO, ERRO CODE: " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                        log_camera.WriteLine();
                        Console.WriteLine("NENHUM ROSTO DETECTADO OU ROSTO MAL POSICIONADO, ERRO CODE: " + CHCNetSDK.NET_DVR_GetLastError().ToString());
                        Flag = false;
                        CHCNetSDK.NET_DVR_StopRemoteConfig(m_lCapFaceCfgHandle);
                        break;
                }
            }
            Marshal.FreeHGlobal(ptrStruCond);

        }
        private static void ProcessCapFaceData(ref CHCNetSDK.NET_DVR_CAPTURE_FACE_CFG struFaceCfg, ref bool flag, StreamWriter log_camera, string codigo)
        {
            if (0 == struFaceCfg.dwFacePicSize)
            {
                return;
            }
            string strpath = null;// FilePath = null;
            DateTime dt = DateTime.Now;
            strpath = string.Format($"{codigo}.jpg", Environment.CurrentDirectory);
            try
            {
                using (FileStream fs = new FileStream(strpath, FileMode.OpenOrCreate))
                {
                    int FaceLen = struFaceCfg.dwFacePicSize;
                    byte[] by = new byte[FaceLen];
                    Marshal.Copy(struFaceCfg.pFacePicBuffer, by, 0, FaceLen);
                    fs.Write(by, 0, FaceLen);
                    fs.Close();
                }

                //pictureFace.Image = Image.FromFile(strpath);
                FilePath = string.Format("{0}\\{1}", Environment.CurrentDirectory, strpath);
                Console.WriteLine("Capture_succeed/");
                log_camera.WriteLine("Capture succeed");
                log_camera.WriteLine(FilePath);
                log_camera.WriteLine();
                Console.WriteLine(FilePath);
            }
            catch
            {
                flag = false;
                log_camera.WriteLine("capture data wrong");
                log_camera.WriteLine();
                Console.WriteLine("capture data wrong");
            }
        }
        // fim do inicialização da camera no dispositivo

        // inicio da criação de um registro
        private static void CriaRegistro(string nome, string codigo, string Employee, StreamWriter log_registrar)
        {
            
            CHCNetSDKCard.NET_DVR_CARD_COND struCond = new CHCNetSDKCard.NET_DVR_CARD_COND();
            struCond.Init();
            struCond.dwSize = (uint)Marshal.SizeOf(struCond);
            struCond.dwCardNum = 1;
            IntPtr ptrStruCond = Marshal.AllocHGlobal((int)struCond.dwSize);
            Marshal.StructureToPtr(struCond, ptrStruCond, false);
            //m_UserID = m_iUserID;
            m_lSetCardCfgHandle = CHCNetSDKCard.NET_DVR_StartRemoteConfig(m_UserID, CHCNetSDKCard.NET_DVR_SET_CARD, ptrStruCond, (int)struCond.dwSize, null, IntPtr.Zero);
            if (m_lSetCardCfgHandle < 0)
            {
                log_registrar.WriteLine("NET_DVR_SET_CARD error:" + CHCNetSDKCard.NET_DVR_GetLastError());
                log_registrar.WriteLine();
                Console.WriteLine("NET_DVR_SET_CARD error:" + CHCNetSDKCard.NET_DVR_GetLastError());
                Marshal.FreeHGlobal(ptrStruCond);
            }
            else
            {
            SendCardData(nome, codigo, Employee, log_registrar);
            Marshal.FreeHGlobal(ptrStruCond);
            }
        }
        private static void SendCardData(string nome, string codigo, string Employee, StreamWriter log_registrar)
        {
            
            CHCNetSDKCard.NET_DVR_CARD_RECORD struData = new CHCNetSDKCard.NET_DVR_CARD_RECORD();
            struData.Init();
            struData.dwSize = (uint)Marshal.SizeOf(struData);
            struData.byCardType = 1;
            byte[] byTempCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
            byTempCardNo = System.Text.Encoding.UTF8.GetBytes(codigo); // Numero do Registro
            for (int i = 0; i < byTempCardNo.Length; i++)
            {
                struData.byCardNo[i] = byTempCardNo[i];
            }
            ushort.TryParse("1", out struData.wCardRightPlan[0]);
            uint.TryParse(Employee, out struData.dwEmployeeNo);
            byte[] byTempName = new byte[CHCNetSDKCard.NAME_LEN];
            byTempName = System.Text.Encoding.Default.GetBytes(nome);
            for (int i = 0; i < byTempName.Length; i++)
            {
                struData.byName[i] = byTempName[i];
            }
            struData.struValid.byEnable = 1;
            struData.struValid.struBeginTime.wYear = 2000;
            struData.struValid.struBeginTime.byMonth = 1;
            struData.struValid.struBeginTime.byDay = 1;
            struData.struValid.struBeginTime.byHour = 11;
            struData.struValid.struBeginTime.byMinute = 11;
            struData.struValid.struBeginTime.bySecond = 11;
            struData.struValid.struEndTime.wYear = 2030;
            struData.struValid.struEndTime.byMonth = 1;
            struData.struValid.struEndTime.byDay = 1;
            struData.struValid.struEndTime.byHour = 11;
            struData.struValid.struEndTime.byMinute = 11;
            struData.struValid.struEndTime.bySecond = 11;
            struData.byDoorRight[0] = 1;
            struData.wCardRightPlan[0] = 1;
            IntPtr ptrStruData = Marshal.AllocHGlobal((int)struData.dwSize);
            Marshal.StructureToPtr(struData, ptrStruData, false);

            CHCNetSDKCard.NET_DVR_CARD_STATUS struStatus = new CHCNetSDKCard.NET_DVR_CARD_STATUS();
            struStatus.Init();
            struStatus.dwSize = (uint)Marshal.SizeOf(struStatus);
            IntPtr ptrdwState = Marshal.AllocHGlobal((int)struStatus.dwSize);
            Marshal.StructureToPtr(struStatus, ptrdwState, false);

            int dwState = (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS;
            uint dwReturned = 0;
            while (true)
            {
                dwState = CHCNetSDKCard.NET_DVR_SendWithRecvRemoteConfig(m_lSetCardCfgHandle, ptrStruData, struData.dwSize, ptrdwState, struStatus.dwSize, ref dwReturned);
                struStatus = (CHCNetSDKCard.NET_DVR_CARD_STATUS)Marshal.PtrToStructure(ptrdwState, typeof(CHCNetSDKCard.NET_DVR_CARD_STATUS));
                if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_NEEDWAIT)
                {
                    Thread.Sleep(10);
                    continue;
                }
                else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FAILED)
                {
                    Console.WriteLine("NET_DVR_SET_CARD fail error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine("NET_DVR_SET_CARD fail error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine();
                }
                else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS)
                {
                    if (struStatus.dwErrorCode != 0)
                    {
                        //Console.WriteLine("NET_DVR_SET_CARD success but errorCode: " + struStatus.dwErrorCode);
                        log_registrar.WriteLine("NET_DVR_SET_CARD success but errorCode: " + struStatus.dwErrorCode);
                        log_registrar.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Cadastro atualizado com sucesso ");
                        log_registrar.WriteLine("Cadastro Finalizado");
                        log_registrar.WriteLine();
                    }
                }
                else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FINISH)
                {
                    //Console.WriteLine("Cadastro Finalizado");
                    log_registrar.WriteLine("Cadastro Finalizado");
                    log_registrar.WriteLine();
                    break;
                }
                else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_EXCEPTION)
                {
                    Console.WriteLine("NET_DVR_SET_CARD exception error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine("NET_DVR_SET_CARD exception error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine();
                    break;
                }
                else
                {
                    Console.WriteLine("unknown status error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine("unknown status error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                    log_registrar.WriteLine();
                    break;
                }
            }
            CHCNetSDKCard.NET_DVR_StopRemoteConfig(m_lSetCardCfgHandle);
            m_lSetCardCfgHandle = -1;
            Marshal.FreeHGlobal(ptrStruData);
            Marshal.FreeHGlobal(ptrdwState);
            return;
        }
        // fim da criação de um registro

        // inicio do enviamento da foto para o registro
        private static void EnviaFoto(string filename, string codigo, StreamWriter log_registrar)
        {
            Image pictureFace;
            string textBoxCardNo;
            int textBoxCardReaderNo, m_lSetFaceCfgHandle;
            
            pictureFace = Image.FromFile(filename); // Transforma o caminho da imagem na imagem em si
            if (filename == "")
            {
                //Console.WriteLine("Please choose human Face path");
                log_registrar.WriteLine("Please choose human Face path");
                log_registrar.WriteLine();
                return;
            }
            if (pictureFace != null)
            {
                pictureFace.Dispose();
                pictureFace = null;
            }
            CHCNetSDK.NET_DVR_FACE_COND struCond = new CHCNetSDK.NET_DVR_FACE_COND();
            struCond.init();
            struCond.dwSize = Marshal.SizeOf(struCond);
            struCond.dwFaceNum = 1;
            //int.TryParse(textBoxCardReaderNo.Text.ToString(), out struCond.dwEnableReaderNo);
            textBoxCardReaderNo = 1; // 1 por padrão, ainda não entendi muito bem o que é.
            struCond.dwEnableReaderNo = textBoxCardReaderNo;
            textBoxCardNo = codigo; // numero do registro
            byte[] byTemp = System.Text.Encoding.UTF8.GetBytes(textBoxCardNo);
            for (int i = 0; i < byTemp.Length; i++)
            {
                struCond.byCardNo[i] = byTemp[i];
            }
            int dwInBufferSize = struCond.dwSize;
            IntPtr ptrstruCond = Marshal.AllocHGlobal(dwInBufferSize);
            Marshal.StructureToPtr(struCond, ptrstruCond, false);
            m_UserID = m_iUserID;
            m_lSetFaceCfgHandle = CHCNetSDK.NET_DVR_StartRemoteConfig(m_UserID, CHCNetSDK.NET_DVR_SET_FACE, ptrstruCond, dwInBufferSize, null, IntPtr.Zero);
            if (-1 == m_lSetFaceCfgHandle)
            {
                Marshal.FreeHGlobal(ptrstruCond);
                //Console.WriteLine("NET_DVR_SET_FACE_FAIL, ERROR CODE" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                log_registrar.WriteLine("NET_DVR_SET_FACE_FAIL, ERROR CODE" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                log_registrar.WriteLine();
                return;
            }
            CHCNetSDK.NET_DVR_FACE_RECORD struRecord = new CHCNetSDK.NET_DVR_FACE_RECORD();
            struRecord.init();
            struRecord.dwSize = Marshal.SizeOf(struRecord);
            byte[] byRecordNo = System.Text.Encoding.UTF8.GetBytes(textBoxCardNo);
            for (int i = 0; i < byRecordNo.Length; i++)
            {
                struRecord.byCardNo[i] = byRecordNo[i];
            }
            Functions.ReadFaceData(ref struRecord, filename);
            int dwInBuffSize = Marshal.SizeOf(struRecord);
            int dwStatus = 0;
            CHCNetSDK.NET_DVR_FACE_STATUS struStatus = new CHCNetSDK.NET_DVR_FACE_STATUS();
            struStatus.init();
            struStatus.dwSize = Marshal.SizeOf(struStatus);
            int dwOutBuffSize = struStatus.dwSize;
            IntPtr ptrOutDataLen = Marshal.AllocHGlobal(sizeof(int));
            bool Flag = true;
            while (Flag)
            {
                dwStatus = CHCNetSDK.NET_DVR_SendWithRecvRemoteConfig(m_lSetFaceCfgHandle, ref struRecord, dwInBuffSize, ref struStatus, dwOutBuffSize, ptrOutDataLen);
                switch (dwStatus)
                {
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_SUCCESS://成功读取到数据，处理完本次数据后需调用next
                        ProcessSetFaceData(ref struStatus, ref Flag, log_registrar);
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_NEED_WAIT:
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_FAILED:
                        _ = CHCNetSDK.NET_DVR_StopRemoteConfig(m_lSetFaceCfgHandle);
                        //Console.WriteLine("NET_SDK_GET_NEXT_STATUS_FAILED" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                        log_registrar.WriteLine("NET_SDK_GET_NEXT_STATUS_FAILED" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                        log_registrar.WriteLine();
                        Flag = false;
                        break;
                    case CHCNetSDK.NET_SDK_GET_NEXT_STATUS_FINISH:
                        _ = CHCNetSDK.NET_DVR_StopRemoteConfig(m_lSetFaceCfgHandle);
                        Flag = false;
                        break;
                    default:
                        //Console.WriteLine("NET_SDK_GET_NEXT_STATUS_UNKOWN" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                        log_registrar.WriteLine("NET_SDK_GET_NEXT_STATUS_UNKOWN" + CHCNetSDK.NET_DVR_GetLastError().ToString(), "Error");
                        log_registrar.WriteLine();
                        Flag = false;

                        CHCNetSDK.NET_DVR_StopRemoteConfig(m_lSetFaceCfgHandle);
                        break;
                }
            }


            Marshal.FreeHGlobal(ptrstruCond);
            Marshal.FreeHGlobal(ptrOutDataLen);
        }
        private static void ReadFaceData(ref CHCNetSDK.NET_DVR_FACE_RECORD struRecord, string filename)
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine("The face picture does not exist!");
                return;
            }
            FileStream fs = new FileStream(filename, FileMode.OpenOrCreate);
            if (0 == fs.Length)
            {
                Console.WriteLine("The face picture is 0k,please input another picture!");
                return;
            }
            if (200 * 1024 < fs.Length)
            {
                Console.WriteLine("The face picture is larger than 200k,please input another picture!");
                return;
            }
            try
            {
                int.TryParse(fs.Length.ToString(), out struRecord.dwFaceLen);
                int iLen = struRecord.dwFaceLen;
                byte[] by = new byte[iLen];
                struRecord.pFaceBuffer = Marshal.AllocHGlobal(iLen);
                fs.Read(by, 0, iLen);
                Marshal.Copy(by, 0, struRecord.pFaceBuffer, iLen);
                fs.Close();
                filename = "";
            }
            catch
            {
                Console.WriteLine("Read Face Data failed");
                fs.Close();
                return;
            }
        }
        private static void ProcessSetFaceData(ref CHCNetSDK.NET_DVR_FACE_STATUS struStatus, ref bool flag, StreamWriter log_registrar)
        {
            switch (struStatus.byRecvStatus)
            {
                case 1:
                    Console.WriteLine("Imagem enviada com sucesso");
                    log_registrar.WriteLine("Imagem enviada com sucesso");
                    log_registrar.WriteLine();
                    break;
                default:
                    flag = false;
                    Console.WriteLine("Falha ao enviar a Imagem, erro = " + struStatus.byRecvStatus.ToString(), "ERROR");
                    log_registrar.WriteLine("Falha ao enviar a Imagem, erro = " + struStatus.byRecvStatus.ToString(), "ERROR");
                    log_registrar.WriteLine();
                    break;
            }

        }
        // fim do enviamento da foto para o registro

        // inicio do deletamento da foto de um registro
        private static void deleta_face(string codigo, StreamWriter log_deleta_face)
        {
            if (m_lDelFingerPrintCfHandle != -1)
            {
                CHCNetSDKDel.NET_DVR_StopRemoteConfig(m_lDelFingerPrintCfHandle);
            }
            //按卡号方式删除
            CHCNetSDKDel.NET_DVR_FACE_PARAM_CTRL_ByCard m_struDelByCard = new CHCNetSDKDel.NET_DVR_FACE_PARAM_CTRL_ByCard();
            m_struDelByCard.Init();
            m_struDelByCard.dwSize = Marshal.SizeOf(m_struDelByCard);
            //m_struDelByCard.byMode = (byte)comboBoxdDel.SelectedIndex;

            byte[] byCardNo = System.Text.Encoding.UTF8.GetBytes(codigo);
            for (int i = 0; i < byCardNo.Length; i++)
            {
                m_struDelByCard.struProcessMode.byCardNo[i] = byCardNo[i];
            }
            for (int i = 0; i < CHCNetSDKDel.MAX_FACE_NUM; ++i)
            {
                m_struDelByCard.struProcessMode.byFaceID[i] = 1;
                //之前的算法需要两张人脸（一张带眼镜，一张不带眼镜）所以有了这个数组(现在只需要一张)，删除时把这个数组都赋值为1。
            }

            m_struDelByCard.struProcessMode.byEnableCardReader[0] = 1;

            IntPtr ptrstruDel = Marshal.AllocHGlobal(m_struDelByCard.dwSize);
            Marshal.StructureToPtr(m_struDelByCard, ptrstruDel, false);
            if (CHCNetSDKDel.NET_DVR_RemoteControl(m_UserID, CHCNetSDKDel.NET_DVR_DEL_FACE_PARAM_CFG, ptrstruDel, (uint)m_struDelByCard.dwSize))
            {
                Console.WriteLine("foto_deletada");
                log_deleta_face.WriteLine("NET_SDK_DEL_FACE_Success");
                log_deleta_face.WriteLine();
                //Login.erro = 0;
            }
            else
            {
                Console.WriteLine(CHCNetSDKDel.NET_DVR_GetLastError());
                log_deleta_face.WriteLine("Não foi possivel deletar a imagem, erro: " + CHCNetSDKDel.NET_DVR_GetLastError());
                log_deleta_face.WriteLine();
            }
            Marshal.FreeHGlobal(ptrstruDel);

        }
        // fim do deletamento da foto de um registro

        // inicio do deletamento de um registro completo
        private static void deleta_registro(string codigo, StreamWriter log_deleta_registro)
        {

            int m_lGetCardCfgHandle;
            if (m_lDelCardCfgHandle != -1)
            {
                if (CHCNetSDKCard.NET_DVR_StopRemoteConfig(m_lDelCardCfgHandle))
                {
                    m_lDelCardCfgHandle = -1;
                }
            }
            CHCNetSDKCard.NET_DVR_CARD_COND struCond = new CHCNetSDKCard.NET_DVR_CARD_COND();
            struCond.Init();
            struCond.dwSize = (uint)Marshal.SizeOf(struCond);
            struCond.dwCardNum = 1;
            IntPtr ptrStruCond = Marshal.AllocHGlobal((int)struCond.dwSize);
            Marshal.StructureToPtr(struCond, ptrStruCond, false);

            CHCNetSDKCard.NET_DVR_CARD_SEND_DATA struSendData = new CHCNetSDKCard.NET_DVR_CARD_SEND_DATA();
            struSendData.Init();
            struSendData.dwSize = (uint)Marshal.SizeOf(struSendData);
            byte[] byTempCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
            byTempCardNo = System.Text.Encoding.UTF8.GetBytes(codigo);
            for (int i = 0; i < byTempCardNo.Length; i++)
            {
                struSendData.byCardNo[i] = byTempCardNo[i];
            }
            IntPtr ptrStruSendData = Marshal.AllocHGlobal((int)struSendData.dwSize);
            Marshal.StructureToPtr(struSendData, ptrStruSendData, false);

            CHCNetSDKCard.NET_DVR_CARD_STATUS struStatus = new CHCNetSDKCard.NET_DVR_CARD_STATUS();
            struStatus.Init();
            struStatus.dwSize = (uint)Marshal.SizeOf(struStatus);
            IntPtr ptrdwState = Marshal.AllocHGlobal((int)struStatus.dwSize);
            Marshal.StructureToPtr(struStatus, ptrdwState, false);

            m_lGetCardCfgHandle = CHCNetSDKCard.NET_DVR_StartRemoteConfig(m_UserID, CHCNetSDKCard.NET_DVR_DEL_CARD, ptrStruCond, (int)struCond.dwSize, null, ptrStruCond);
            if (m_lGetCardCfgHandle < 0)
            {
                //Console.WriteLine("NET_DVR_DEL_CARD error:" + CHCNetSDKCard.NET_DVR_GetLastError());
                log_deleta_registro.WriteLine("NET_DVR_DEL_CARD error:" + CHCNetSDKCard.NET_DVR_GetLastError());
                log_deleta_registro.WriteLine();
                Marshal.FreeHGlobal(ptrStruCond);
                return;
            }
            else
            {
                int dwState = (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS;
                uint dwReturned = 0;
                while (true)
                {
                    dwState = CHCNetSDKCard.NET_DVR_SendWithRecvRemoteConfig(m_lGetCardCfgHandle, ptrStruSendData, struSendData.dwSize, ptrdwState, struStatus.dwSize, ref dwReturned);
                    if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_NEEDWAIT)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FAILED)
                    {
                        //Console.WriteLine("NET_DVR_DEL_CARD fail error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine("NET_DVR_DEL_CARD fail error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine();
                    }
                    else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_SUCCESS)
                    {
                        //Console.WriteLine("NET_DVR_DEL_CARD success");
                        log_deleta_registro.WriteLine("NET_DVR_DEL_CARD success");
                        log_deleta_registro.WriteLine();
                    }
                    else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_FINISH)
                    {
                        //Console.WriteLine("NET_DVR_DEL_CARD finish");
                        log_deleta_registro.WriteLine("NET_DVR_DEL_CARD finish");
                        log_deleta_registro.WriteLine();
                        break;
                    }
                    else if (dwState == (int)CHCNetSDKCard.NET_SDK_SENDWITHRECV_STATUS.NET_SDK_CONFIG_STATUS_EXCEPTION)
                    {
                        //Console.WriteLine("NET_DVR_DEL_CARD exception error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine("NET_DVR_DEL_CARD exception error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine();
                        break;
                    }
                    else
                    {
                        //Console.WriteLine("unknown status error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine("unknown status error: " + CHCNetSDKCard.NET_DVR_GetLastError());
                        log_deleta_registro.WriteLine();
                        break;
                    }
                }
            }
            CHCNetSDKCard.NET_DVR_StopRemoteConfig(m_lDelCardCfgHandle);
            m_lDelCardCfgHandle = -1;
            Marshal.FreeHGlobal(ptrStruSendData);
            Marshal.FreeHGlobal(ptrdwState);
        }
    }
}
