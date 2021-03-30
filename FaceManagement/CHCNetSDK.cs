using System;
using System.Runtime.InteropServices;

namespace FaceManagement
{
    class CHCNetSDK
    {

        #region HCNetSDK.dll macro definition
        public const int SERIALNO_LEN = 48; //serial number length
        public const int NET_DVR_DEV_ADDRESS_MAX_LEN = 129; //device address max length
        public const int NET_DVR_LOGIN_USERNAME_MAX_LEN = 64;   //login username max length
        public const int NET_DVR_LOGIN_PASSWD_MAX_LEN = 64; //login password max length


        public const int NET_DVR_PASSWORD_ERROR = 1;//Username or Password error
        public const int NET_DVR_USER_LOCKED = 153;

        public const int ACS_CARD_NO_LEN = 32;
        public const int MAX_CARD_READER_NUM_512 = 512;
        public const int NET_DVR_GET_FACE = 2566;//获取人脸
        public const int NET_DVR_SET_FACE = 2567;
        public const int ERROR_MSG_LEN=32;
        public const int NET_DVR_DEL_FACE_PARAM_CFG = 2509;
        public const int NET_DVR_CAPTURE_FACE_INFO = 2510;//采集人脸


        public const int NET_SDK_GET_NEXT_STATUS_SUCCESS = 1000;
        public const int NET_SDK_GET_NEXT_STATUS_NEED_WAIT = 1001;
        public const int NET_SDK_GET_NEXT_STATUS_FINISH = 1002;
        public const int NET_SDK_GET_NEXT_STATUS_FAILED = 1003;

        public const int MAX_FACE_NUM=2;
        
        #endregion


        #region HCNetSDK.dll structure definition

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V30
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber;    //serial number
            public byte byAlarmInPortNum;   //Number of Alarm input
            public byte byAlarmOutPortNum;  //Number of Alarm Output
            public byte byDiskNum;  //Number of Hard Disk
            public byte byDVRType;  //DVR Type, 1: DVR 2: ATM DVR 3: DVS ......
            public byte byChanNum;  //Number of Analog Channel
            public byte byStartChan;    //The first Channel No. E.g. DVS- 1, DVR- 1
            public byte byAudioChanNum; //Number of Audio Channel
            public byte byIPChanNum;    //Maximum number of IP Channel  low
            public byte byZeroChanNum;  //Zero channel encoding number//2010- 01- 16
            public byte byMainProto;    //Main stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySubProto; //Sub stream transmission protocol 0- private,  1- rtsp,2-both private and rtsp
            public byte bySupport;  //Ability, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1,  smart search
            //bySupport & 0x2,  backup
            //bySupport & 0x4,  get compression configuration ability
            //bySupport & 0x8,  multi network adapter
            //bySupport & 0x10, support remote SADP
            //bySupport & 0x20  support Raid card
            //bySupport & 0x40 support IPSAN directory search
            public byte bySupport1; //Ability expand, the 'AND' result by bit: 0- not support;  1- support
            //bySupport1 & 0x1, support snmp v30
            //bySupport1& 0x2,support distinguish download and playback
            //bySupport1 & 0x4, support deployment level
            //bySupport1 & 0x8, support vca alarm time extension 
            //bySupport1 & 0x10, support muti disks(more than 33)
            //bySupport1 & 0x20, support rtsp over http
            //bySupport1 & 0x40, support delay preview
            //bySuppory1 & 0x80 support NET_DVR_IPPARACFG_V40, in addition  support  License plate of the new alarm information
            public byte bySupport2; //Ability expand, the 'AND' result by bit: 0- not support;  1- support
            //bySupport & 0x1, decoder support get stream by URL
            //bySupport2 & 0x2,  support FTPV40
            //bySupport2 & 0x4,  support ANR
            //bySupport2 & 0x20, support get single item of device status
            //bySupport2 & 0x40,  support stream encryt
            public ushort wDevType; //device type
            public byte bySupport3; //Support  epresent by bit, 0 - not support 1 - support 
            //bySupport3 & 0x1-muti stream support 
            //bySupport3 & 0x8  support use delay preview parameter when delay preview
            //bySupport3 & 0x10 support the interface of getting alarmhost main status V40
            public byte byMultiStreamProto; //support multi stream, represent by bit, 0-not support ;1- support; bit1-stream 3 ;bit2-stream 4, bit7-main stream, bit8-sub stream
            public byte byStartDChan;   //Start digital channel
            public byte byStartDTalkChan;   //Start digital talk channel
            public byte byHighDChanNum; //Digital channel number high
            public byte bySupport4; //Support  epresent by bit, 0 - not support 1 - support
            //bySupport4 & 0x4 whether support video wall unified interface
            // bySupport4 & 0x80 Support device upload center alarm enable
            public byte byLanguageType; //support language type by bit,0-support,1-not support  
            //byLanguageType 0 -old device
            //byLanguageType & 0x1 support chinese
            //byLanguageType & 0x2 support english
            public byte byVoiceInChanNum;   //voice in chan num
            public byte byStartVoiceInChanNo;   //start voice in chan num
            public byte bySupport5;  //0-no support,1-support,bit0-muti stream
            //bySupport5 &0x01support wEventTypeEx 
            //bySupport5 &0x04support sence expend
            public byte bySupport6;
            public byte byMirrorChanNum;    //mirror channel num,<it represents direct channel in the recording host
            public ushort wStartMirrorChanNo;   //start mirror chan
            public byte bySupport7;        //Support  epresent by bit, 0 - not support 1 - support 
            //bySupport7 & 0x1- supports INTER_VCA_RULECFG_V42 extension    
            // bySupport7 & 0x2  Supports HVT IPC mode expansion
            // bySupport7 & 0x04  Back lock time
            // bySupport7 & 0x08  Set the pan PTZ position, whether to support the band channel
            // bySupport7 & 0x10  Support for dual system upgrade backup
            // bySupport7 & 0x20  Support OSD character overlay V50
            // bySupport7 & 0x40  Support master slave tracking (slave camera)
            // bySupport7 & 0x80  Support message encryption 
            public byte byRes2;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_COND
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;//人脸关联的卡号（设置时该参数可不设置）
            public int dwFaceNum;// 设置或获取人脸数量，获取时置为0xffffffff表示获取所有人脸信息
            public int dwEnableReaderNo;// 人脸读卡器编号
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124)]
            public byte[] byRes;
            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byRes = new byte[124];
            }
        }


        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_RECORD
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CHCNetSDK.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            public int dwFaceLen;
            public IntPtr pFaceBuffer;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128)]
            public byte[] byRes;

            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byRes = new byte[128];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICEINFO_V40
        {
            public NET_DVR_DEVICEINFO_V30 struDeviceV30;
            public byte bySupportLock;        //设备支持锁定功能，该字段由SDK根据设备返回值来赋值的。bySupportLock为1时，dwSurplusLockTime和byRetryLoginTime有效
            public byte byRetryLoginTime;        //剩余可尝试登陆的次数，用户名，密码错误时，此参数有效
            public byte byPasswordLevel;      //admin密码安全等级0-无效，1-默认密码，2-有效密码,3-风险较高的密码。当用户的密码为出厂默认密码（12345）或者风险较高的密码时，上层客户端需要提示用户更改密码。      
            public byte byProxyType;  //代理类型，0-不使用代理, 1-使用socks5代理, 2-使用EHome代理
            public uint dwSurplusLockTime;    //剩余时间，单位秒，用户锁定时，此参数有效
            public byte byCharEncodeType;     //字符编码类型
            public byte bySupportDev5;//支持v50版本的设备参数获取，设备名称和设备类型名称长度扩展为64字节
            public byte bySupport;  //能力集扩展，位与结果：0- 不支持，1- 支持
            // bySupport & 0x1:  保留
            // bySupport & 0x2:  0-不支持变化上报 1-支持变化上报
            public byte byLoginMode; //登录模式 0-Private登录 1-ISAPI登录
            public uint dwOEMCode;
            public int iResidualValidity;   //该用户密码剩余有效天数，单位：天，返回负值，表示密码已经超期使用，例如“-3表示密码已经超期使用3天”
            public byte byResidualValidity; // iResidualValidity字段是否有效，0-无效，1-有效
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 243)]
            public byte[] byRes2;
        }

        public delegate void LoginResultCallBack(int lUserID, uint dwResult, ref NET_DVR_DEVICEINFO_V30 lpDeviceInfo, IntPtr pUser);
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_USER_LOGIN_INFO
        {
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_DEV_ADDRESS_MAX_LEN)]
            public string sDeviceAddress;
            public byte byUseTransport;
            public ushort wPort;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_LOGIN_USERNAME_MAX_LEN)]
            public string sUserName;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NET_DVR_LOGIN_PASSWD_MAX_LEN)]
            public string sPassword;
            public LoginResultCallBack cbLoginResult;
            public IntPtr pUser;
            public bool bUseAsynLogin;
            public byte byProxyType;
            public byte byUseUTCTime;
            public byte byLoginMode; //登录模式 0-Private 1-ISAPI 2-自适应（默认不采用自适应是因为自适应登录时，会对性能有较大影响，自适应时要同时发起ISAPI和Private登录）
            public byte byHttps;    //ISAPI登录时，是否使用HTTPS，0-不使用HTTPS，1-使用HTTPS 2-自适应（默认不采用自适应是因为自适应登录时，会对性能有较大影响，自适应时要同时发起HTTP和HTTPS）
            public int iProxyID;
            public byte byVerifyMode;  //认证方式，0-不认证，1-双向认证，2-单向认证；认证仅在使用TLS的时候生效;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 119, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_STATUS
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg;//下发错误信息，当byCardReaderRecvStatus为4时，表示已存在人脸对应的卡号
            public int dwReaderNo; //人脸读卡器编号，可用于下发错误返回
            public byte byRecvStatus;  //人脸读卡器状态，按字节表示，0-失败，1-成功，2-重试或人脸质量差，3-内存已满(人脸数据满)，4-已存在该人脸，5-非法人脸ID
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =131, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void init()
            {
                byCardNo=new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byErrorMsg=new byte[CHCNetSDK.ERROR_MSG_LEN];
                byRes=new byte[131];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FACE_COND
        {
            public int dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void init()
            {
                byRes = new byte[128];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FACE_CFG
        {
            public int dwSize;
            public int dwFaceTemplate1Size;//人脸模板1数据大小，等于0时，代表无人脸模板1数据
            public IntPtr pFaceTemplate1Buffer;//人脸模板1数据缓存（不大于2.5k）
            public int dwFaceTemplate2Size;//人脸模板2数据大小，等于0时，代表无人脸模板2数据
            public IntPtr pFaceTemplate2Buffer; //人脸模板2数据缓存（不大于2.5K）
            public int dwFacePicSize;//人脸图片数据大小，等于0时，代表无人脸图片数据;
            public IntPtr pFacePicBuffer;//人脸图片数据缓存;
            public byte byFaceQuality1;//人脸质量，范围1-100
            public byte byFaceQuality2;//人脸质量，范围1-100
            public byte  byCaptureProgress;    //采集进度，目前只有两种进度值：0-未采集到人脸，100-采集到人脸（只有在进度为100时，才解析人脸信息）
            public byte  byRes1;
            public int dwInfraredFacePicSize;   //红外人脸图片数据大小，等于0时，代表无人脸图片数据
            public IntPtr  pInfraredFacePicBuffer;      //红外人脸图片数据缓存
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 116, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void init()
            {
                byRes = new byte[116];
            }
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_CTRL_CARDNO
        {
            public int dwSize;
            public byte byMode;//删除方式，0-按卡号方式删除，1-按读卡器删除
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public CHCNetSDK.NET_DVR_FACE_PARAM_BYCARD struByCard;//按卡号的方式删除,读卡器暂时不写
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void init()
            {
                byRes1 = new byte[3];
                byRes = new byte[64];
                struByCard.init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_BYCARD
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //人脸关联的卡号
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;//人脸的读卡器信息，按数组表示
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =CHCNetSDK.MAX_FACE_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byFaceID; //需要删除的人脸编号，按数组下标，值表示0-不删除，1-删除该人脸
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst =42, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;

            public void init()
            {
                byCardNo = new byte[CHCNetSDK.ACS_CARD_NO_LEN];
                byEnableCardReader=new byte[CHCNetSDK.MAX_CARD_READER_NUM_512];
                byFaceID = new byte[CHCNetSDK.MAX_FACE_NUM];
                byRes1 = new byte[42];
            }
        }



        #endregion


        #region  HCNetSDK.dll function definition
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern uint NET_DVR_GetLastError();

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        public delegate void RemoteConfigCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, int dwCommand, IntPtr lpInBuffer, int dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_FACE_RECORD lpOutBuff, int dwOutBuffSize);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StopRemoteConfig(int lHandle);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_FACE_RECORD lpInBuff, int dwInBuffSize, ref CHCNetSDK.NET_DVR_FACE_STATUS lpOutBuff, int dwOutBuffSize, IntPtr dwOutDataLen);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_RemoteControl(int lUserID, int dwCommand, ref CHCNetSDK.NET_DVR_FACE_PARAM_CTRL_CARDNO lpInBuffer, int dwInBufferSize);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, ref CHCNetSDK.NET_DVR_CAPTURE_FACE_CFG lpOutBuff, int dwOutBuffSize);
        #endregion
    }
}
