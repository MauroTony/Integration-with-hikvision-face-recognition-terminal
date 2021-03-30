using System;
using System.Runtime.InteropServices;

namespace FaceManagement
{
    public class CHCNetSDKCard
    {
        #region HCNetSDK.dll macro definition
        //macro definition
        #region common use

        /*******************Global Error Code**********************/
        public const int NET_DVR_NOERROR = 0; //No Error
        public const int NET_DVR_PASSWORD_ERROR = 1;//Username or Password error
        public const int NET_DVR_NOENOUGHPRI = 2;//Don't have enough authority
        public const int NET_DVR_NOINIT = 3;//have not Initialized
        public const int NET_DVR_CHANNEL_ERROR = 4;//Channel number error
        public const int NET_DVR_OVER_MAXLINK = 5;//Number of clients connecting to DVR beyonds the Maximum
        public const int NET_DVR_VERSIONNOMATCH = 6;//Version is not matched
        public const int NET_DVR_NETWORK_FAIL_CONNECT = 7;//Connect to server failed
        public const int NET_DVR_NETWORK_SEND_ERROR = 8;//Send data to server failed
        public const int NET_DVR_NETWORK_RECV_ERROR = 9;//Receive data from server failed
        public const int NET_DVR_NETWORK_RECV_TIMEOUT = 10;//Receive data from server timeout
        public const int NET_DVR_NETWORK_ERRORDATA = 11;//Transferred data has error
        public const int NET_DVR_ORDER_ERROR = 12;//Wrong Sequence of invoking API
        public const int NET_DVR_OPERNOPERMIT = 13;//No such authority.
        public const int NET_DVR_COMMANDTIMEOUT = 14;//Execute command timeout
        public const int NET_DVR_ERRORSERIALPORT = 15;//Serial port number error
        public const int NET_DVR_ERRORALARMPORT = 16;//Alarm port error
        public const int NET_DVR_PARAMETER_ERROR = 17;//Parameters error
        public const int NET_DVR_CHAN_EXCEPTION = 18;//Server channel in error status
        public const int NET_DVR_NODISK = 19;//No hard disk
        public const int NET_DVR_ERRORDISKNUM = 20;//Hard disk number error
        public const int NET_DVR_DISK_FULL = 21;//Server's hard disk is full
        public const int NET_DVR_DISK_ERROR = 22;//Server's hard disk error
        public const int NET_DVR_NOSUPPORT = 23;//Server doesn't support
        public const int NET_DVR_BUSY = 24;//Server is busy
        public const int NET_DVR_MODIFY_FAIL = 25;//Server modification failed
        public const int NET_DVR_PASSWORD_FORMAT_ERROR = 26;///Input format of Password error
        public const int NET_DVR_DISK_FORMATING = 27;//Hard disk is formating,  cannot execute. 
        public const int NET_DVR_DVRNORESOURCE = 28;//DVR don't have enough resource
        public const int NET_DVR_DVROPRATEFAILED = 29;//DVR Operation failed
        public const int NET_DVR_OPENHOSTSOUND_FAIL = 30;//Open PC audio failed
        public const int NET_DVR_DVRVOICEOPENED = 31;///Server's talk channel is occupied 
        public const int NET_DVR_TIMEINPUTERROR = 32;//Time input is not correct
        public const int NET_DVR_NOSPECFILE = 33;//Can't playback the file that does not exist in Server
        public const int NET_DVR_CREATEFILE_ERROR = 34;//Create file error
        public const int NET_DVR_FILEOPENFAIL = 35;///Open file error
        public const int NET_DVR_OPERNOTFINISH = 36; //The previous operation is not finished yet
        public const int NET_DVR_GETPLAYTIMEFAIL = 37;//Get current playing time error
        public const int NET_DVR_PLAYFAIL = 38;//Playback error
        public const int NET_DVR_FILEFORMAT_ERROR = 39;//Wrong file format
        public const int NET_DVR_DIR_ERROR = 40;//Wrong directory 
        public const int NET_DVR_ALLOC_RESOURCE_ERROR = 41;//Assign resource error
        public const int NET_DVR_AUDIO_MODE_ERROR = 42;//Audio card mode error
        public const int NET_DVR_NOENOUGH_BUF = 43;///Buffer is too small
        public const int NET_DVR_CREATESOCKET_ERROR = 44;//Create SOCKET error
        public const int NET_DVR_SETSOCKET_ERROR = 45;//Setup SOCKET error
        public const int NET_DVR_MAX_NUM = 46;//Reach the maximum number
        public const int NET_DVR_USERNOTEXIST = 47;//User does not exist
        public const int NET_DVR_WRITEFLASHERROR = 48;//Write to FLASH error
        public const int NET_DVR_UPGRADEFAIL = 49;//DVR update failed
        public const int NET_DVR_CARDHAVEINIT = 50;//Decoding Card has been initialized already
        public const int NET_DVR_PLAYERFAILED = 51;//Invoke API of player library error
        public const int NET_DVR_MAX_USERNUM = 52;//Reach the maximum number of Users
        public const int NET_DVR_GETLOCALIPANDMACFAIL = 53;//Failed to get Client software's IP or MAC address
        public const int NET_DVR_NOENCODEING = 54;//No encoding on this channel
        public const int NET_DVR_IPMISMATCH = 55;//IP address is not matched
        public const int NET_DVR_MACMISMATCH = 56;//MAC address is not matched

        public const int NET_DVR_USER_LOCKED = 153;
        /*******************END**********************/

        public const int NET_DVR_DEV_ADDRESS_MAX_LEN = 129; //device address max length
        public const int NET_DVR_LOGIN_USERNAME_MAX_LEN = 64;   //login username max length
        public const int NET_DVR_LOGIN_PASSWD_MAX_LEN = 64; //login password max length
        public const int SERIALNO_LEN = 48; //serial number length
        public const int STREAM_ID_LEN = 32;
        public const int MAX_AUDIO_V40 = 8;
        public const int LOG_INFO_LEN = 11840; // log append information 

        public const int MAX_NAMELEN = 16;        //DVR's local Username
        public const int MAX_DOMAIN_NAME = 64;  // max domain name length
        public const int MAX_ETHERNET = 2;      // device
        public const int NAME_LEN = 32;// name length
        public const int PASSWD_LEN = 16;//password length
        public const int MAX_RIGHT = 32;        //Authority permitted by Device (1- 12 for local authority,  13- 32 for remote authority) 
        public const int MACADDR_LEN = 6;//mac adress length
        public const int DEV_TYPE_NAME_LEN = 24;

        public const int MAX_ANALOG_CHANNUM = 32;      //32 analog channels in total
        public const int MAX_IP_CHANNEL = 32;      //9000 DVR can connect 32 IP channels
        public const int MAX_CHANNUM_V30 = (MAX_ANALOG_CHANNUM + MAX_IP_CHANNEL);   //64
        public const int MAX_CHANNUM_V40 = 512;
        public const int MAX_IP_DEVICE_V40 = 64;      //Maximum number of IP devices that can be added, the value is 64, including IVMS-2000
        public const int DEV_ID_LEN = 32;

        public const int MAX_IP_DEVICE = 32;//9000 DVR can connect 32 IP devices
        public const int MAX_IP_ALARMIN_V40 = 4096;//Maximum number of alarm input channels that can be added
        public const int MAX_IP_ALARMOUT_V40 = 4096;//Maximum number of alarm output channels that can be added
        public const int MAX_IP_ALARMIN = 128;//Maximum number of alarm input channels that can be added
        public const int MAX_IP_ALARMOUT = 64;//Maximum number of alarm output channels that can be added
        public const int URL_LEN = 240;   //URL length
        public const int MAX_AUDIOOUT_PRO_TYPE = 8;

        public const int ACS_ABILITY = 0x801; //acs ability

        public const int NET_DVR_CLEAR_ACS_PARAM = 2118;    //clear acs host parameters
        public const int NET_DVR_GET_ACS_EVENT = 2514;    //clear acs host parameters

        #endregion

        #region acs event upload

        public const int COMM_ALARM_ACS = 0x5002; //access card alarm

        /* Alarm */
        // Main Type
        public const int MAJOR_ALARM = 0x1;
        // Hypo- Type
        public const int MINOR_ALARMIN_SHORT_CIRCUIT = 0x400; // region short circuit 
        public const int MINOR_ALARMIN_BROKEN_CIRCUIT = 0x401; // region broken circuit
        public const int MINOR_ALARMIN_EXCEPTION = 0x402; // region exception 
        public const int MINOR_ALARMIN_RESUME = 0x403; // region resume 
        public const int MINOR_HOST_DESMANTLE_ALARM = 0x404; // host desmantle alarm
        public const int MINOR_HOST_DESMANTLE_RESUME = 0x405; //  host desmantle resume
        public const int MINOR_CARD_READER_DESMANTLE_ALARM = 0x406; // card reader desmantle alarm 
        public const int MINOR_CARD_READER_DESMANTLE_RESUME = 0x407; // card reader desmantle resume
        public const int MINOR_CASE_SENSOR_ALARM = 0x408; // case sensor alarm 
        public const int MINOR_CASE_SENSOR_RESUME = 0x409; // case sensor resume 
        public const int MINOR_STRESS_ALARM = 0x40a; // stress alarm 
        public const int MINOR_OFFLINE_ECENT_NEARLY_FULL = 0x40b; // offline ecent nearly full 
        public const int MINOR_CARD_MAX_AUTHENTICATE_FAIL = 0x40c; // card max authenticate fall 
        public const int MINOR_SD_CARD_FULL = 0x40d; // SD card is full
        public const int MINOR_LINKAGE_CAPTURE_PIC = 0x40e; // lingage capture picture
        public const int MINOR_SECURITY_MODULE_DESMANTLE_ALARM = 0x40f;  //Door control security module desmantle alarm
        public const int MINOR_SECURITY_MODULE_DESMANTLE_RESUME = 0x410;  //Door control security module desmantle resume
        public const int MINOR_POS_START_ALARM = 0x411; // POS Start
        public const int MINOR_POS_END_ALARM = 0x412; // POS end
        public const int MINOR_FACE_IMAGE_QUALITY_LOW = 0x413; // face image quality low
        public const int MINOR_FINGE_RPRINT_QUALITY_LOW = 0x414; // finger print quality low
        public const int MINOR_FIRE_IMPORT_SHORT_CIRCUIT = 0x415; // Fire import short circuit
        public const int MINOR_FIRE_IMPORT_BROKEN_CIRCUIT = 0x416; // Fire import broken circuit
        public const int MINOR_FIRE_IMPORT_RESUME = 0x417; // Fire import resume
        public const int MINOR_FIRE_BUTTON_TRIGGER = 0x418; // fire button trigger
        public const int MINOR_FIRE_BUTTON_RESUME = 0x419; // fire button resume
        public const int MINOR_MAINTENANCE_BUTTON_TRIGGER = 0x41a; // maintenance button trigger
        public const int MINOR_MAINTENANCE_BUTTON_RESUME = 0x41b; // maintenance button resume
        public const int MINOR_EMERGENCY_BUTTON_TRIGGER = 0x41c; // emergency button trigger
        public const int MINOR_EMERGENCY_BUTTON_RESUME = 0x41d; // emergency button resume
        public const int MINOR_DISTRACT_CONTROLLER_ALARM = 0x41e; // distract controller alarm
        public const int MINOR_DISTRACT_CONTROLLER_RESUME = 0x41f; // distract controller resume
        public const int MINOR_CHANNEL_CONTROLLER_DESMANTLE_ALARM = 0x422; //channel controller desmantle alarm
        public const int MINOR_CHANNEL_CONTROLLER_DESMANTLE_RESUME = 0x423; //channel controller desmantle resume
        public const int MINOR_CHANNEL_CONTROLLER_FIRE_IMPORT_ALARM = 0x424; //channel controller fire import alarm
        public const int MINOR_CHANNEL_CONTROLLER_FIRE_IMPORT_RESUME = 0x425;  //channel controller fire import resume
        public const int MINOR_PRINTER_OUT_OF_PAPER = 0x440;  //printer no paper
        public const int MINOR_LEGAL_EVENT_NEARLY_FULL = 0x442;  //Legal event nearly full

        /* Exception*/
        // Main Type
        public const int MAJOR_EXCEPTION = 0x2;
        // Hypo- Type

        public const int MINOR_NET_BROKEN = 0x27; // Network disconnected 
        public const int MINOR_RS485_DEVICE_ABNORMAL = 0x3a; // RS485 connect status exception
        public const int MINOR_RS485_DEVICE_REVERT = 0x3b; // RS485 connect status exception recovery

        public const int MINOR_DEV_POWER_ON = 0x400; // device power on
        public const int MINOR_DEV_POWER_OFF = 0x401; // device power off
        public const int MINOR_WATCH_DOG_RESET = 0x402; // watch dog reset 
        public const int MINOR_LOW_BATTERY = 0x403; // low battery 
        public const int MINOR_BATTERY_RESUME = 0x404; // battery resume
        public const int MINOR_AC_OFF = 0x405; // AC off
        public const int MINOR_AC_RESUME = 0x406; // AC resume 
        public const int MINOR_NET_RESUME = 0x407; // Net resume
        public const int MINOR_FLASH_ABNORMAL = 0x408; // FLASH abnormal 
        public const int MINOR_CARD_READER_OFFLINE = 0x409; // card reader offline 
        public const int MINOR_CARD_READER_RESUME = 0x40a; // card reader resume 
        public const int MINOR_INDICATOR_LIGHT_OFF = 0x40b; // Indicator Light Off
        public const int MINOR_INDICATOR_LIGHT_RESUME = 0x40c; // Indicator Light Resume
        public const int MINOR_CHANNEL_CONTROLLER_OFF = 0x40d; // channel controller off
        public const int MINOR_CHANNEL_CONTROLLER_RESUME = 0x40e; // channel controller resume
        public const int MINOR_SECURITY_MODULE_OFF = 0x40f; // Door control security module off
        public const int MINOR_SECURITY_MODULE_RESUME = 0x410; // Door control security module resume
        public const int MINOR_BATTERY_ELECTRIC_LOW = 0x411; // battery electric low
        public const int MINOR_BATTERY_ELECTRIC_RESUME = 0x412; // battery electric resume
        public const int MINOR_LOCAL_CONTROL_NET_BROKEN = 0x413; // Local control net broken
        public const int MINOR_LOCAL_CONTROL_NET_RSUME = 0x414; // Local control net resume
        public const int MINOR_MASTER_RS485_LOOPNODE_BROKEN = 0x415; // Master RS485 loop node broken
        public const int MINOR_MASTER_RS485_LOOPNODE_RESUME = 0x416; // Master RS485 loop node resume
        public const int MINOR_LOCAL_CONTROL_OFFLINE = 0x417; // Local control offline
        public const int MINOR_LOCAL_CONTROL_RESUME = 0x418; // Local control resume
        public const int MINOR_LOCAL_DOWNSIDE_RS485_LOOPNODE_BROKEN = 0x419; // Local downside RS485 loop node broken
        public const int MINOR_LOCAL_DOWNSIDE_RS485_LOOPNODE_RESUME = 0x41a; // Local downside RS485 loop node resume
        public const int MINOR_DISTRACT_CONTROLLER_ONLINE = 0x41b; // distract controller online
        public const int MINOR_DISTRACT_CONTROLLER_OFFLINE = 0x41c; // distract controller offline
        public const int MINOR_ID_CARD_READER_NOT_CONNECT = 0x41d; // Id card reader not connected(intelligent dedicated)
        public const int MINOR_ID_CARD_READER_RESUME = 0x41e; //Id card reader connection restored(intelligent dedicated)
        public const int MINOR_FINGER_PRINT_MODULE_NOT_CONNECT = 0x41f; // fingerprint module is not connected(intelligent dedicated)
        public const int MINOR_FINGER_PRINT_MODULE_RESUME = 0x420; // The fingerprint module connection restored(intelligent dedicated)
        public const int MINOR_CAMERA_NOT_CONNECT = 0x421; // Camera not connected
        public const int MINOR_CAMERA_RESUME = 0x422; // Camera connection restored
        public const int MINOR_COM_NOT_CONNECT = 0x423; // COM not connected
        public const int MINOR_COM_RESUME = 0x424;// COM connection restored
        public const int MINOR_DEVICE_NOT_AUTHORIZE = 0x425; // device are not authorized
        public const int MINOR_PEOPLE_AND_ID_CARD_DEVICE_ONLINE = 0x426; // people and ID card device online
        public const int MINOR_PEOPLE_AND_ID_CARD_DEVICE_OFFLINE = 0x427;// people and ID card device offline
        public const int MINOR_LOCAL_LOGIN_LOCK = 0x428; // local login lock
        public const int MINOR_LOCAL_LOGIN_UNLOCK = 0x429; //local login unlock
        public const int MINOR_SUBMARINEBACK_COMM_BREAK = 0x42a;  //submarineback communicate break
        public const int MINOR_SUBMARINEBACK_COMM_RESUME = 0x42b;  //submarineback communicate resume
        public const int MINOR_MOTOR_SENSOR_EXCEPTION = 0x42c;  //motor sensor exception
        public const int MINOR_CAN_BUS_EXCEPTION = 0x42d;  //can bus exception
        public const int MINOR_CAN_BUS_RESUME = 0x42e;  //can bus resume
        public const int MINOR_GATE_TEMPERATURE_OVERRUN = 0x42f; //gate temperature over run
        public const int MINOR_IR_EMITTER_EXCEPTION = 0x430; //IR emitter exception
        public const int MINOR_IR_EMITTER_RESUME = 0x431;  //IR emitter resume
        public const int MINOR_LAMP_BOARD_COMM_EXCEPTION = 0x432;  //lamp board communicate exception
        public const int MINOR_LAMP_BOARD_COMM_RESUME = 0x433;  //lamp board communicate resume
        public const int MINOR_IR_ADAPTOR_COMM_EXCEPTION = 0x434; //IR adaptor communicate exception
        public const int MINOR_IR_ADAPTOR_COMM_RESUME = 0x435;  //IR adaptor communicate resume
        public const int MINOR_PRINTER_ONLINE = 0x436; //printer online
        public const int MINOR_PRINTER_OFFLINE = 0x437; //printer offline
        public const int MINOR_4G_MOUDLE_ONLINE = 0x438; //4G module online
        public const int MINOR_4G_MOUDLE_OFFLINE = 0x439; //4G module offline


        /* Operation  */
        // Main Type
        public const int MAJOR_OPERATION = 0x3;

        // Hypo- Type
        public const int MINOR_LOCAL_UPGRADE = 0x5a; // Upgrade  (local)
        public const int MINOR_REMOTE_LOGIN = 0x70; // Login  (remote)
        public const int MINOR_REMOTE_LOGOUT = 0x71; // Logout   (remote)
        public const int MINOR_REMOTE_ARM = 0x79; // On guard   (remote)
        public const int MINOR_REMOTE_DISARM = 0x7a; // Disarm   (remote)
        public const int MINOR_REMOTE_REBOOT = 0x7b; // Reboot   (remote)
        public const int MINOR_REMOTE_UPGRADE = 0x7e; // upgrade  (remote)
        public const int MINOR_REMOTE_CFGFILE_OUTPUT = 0x86; // Export Configuration   (remote) 
        public const int MINOR_REMOTE_CFGFILE_INTPUT = 0x87; // Import Configuration  (remote) 
        public const int MINOR_REMOTE_ALARMOUT_OPEN_MAN = 0xd6; // remote mamual open alarmout 
        public const int MINOR_REMOTE_ALARMOUT_CLOSE_MAN = 0xd7; // remote mamual close alarmout 

        public const int MINOR_REMOTE_OPEN_DOOR = 0x400; // remote open door 
        public const int MINOR_REMOTE_CLOSE_DOOR = 0x401; // remote close door (controlled) 
        public const int MINOR_REMOTE_ALWAYS_OPEN = 0x402; // remote always open door (free) 
        public const int MINOR_REMOTE_ALWAYS_CLOSE = 0x403; // remote always close door (forbiden)
        public const int MINOR_REMOTE_CHECK_TIME = 0x404; // remote check time 
        public const int MINOR_NTP_CHECK_TIME = 0x405; // ntp check time 
        public const int MINOR_REMOTE_CLEAR_CARD = 0x406; // remote clear card 
        public const int MINOR_REMOTE_RESTORE_CFG = 0x407; // remote restore configure 
        public const int MINOR_ALARMIN_ARM = 0x408; // alarm in arm 
        public const int MINOR_ALARMIN_DISARM = 0x409; // alarm in disarm 
        public const int MINOR_LOCAL_RESTORE_CFG = 0x40a; // local configure restore 
        public const int MINOR_REMOTE_CAPTURE_PIC = 0x40b; // remote capture picture 
        public const int MINOR_MOD_NET_REPORT_CFG = 0x40c; // modify net report cfg 
        public const int MINOR_MOD_GPRS_REPORT_PARAM = 0x40d; // modify GPRS report param 
        public const int MINOR_MOD_REPORT_GROUP_PARAM = 0x40e; // modify report group param 
        public const int MINOR_UNLOCK_PASSWORD_OPEN_DOOR = 0x40f; // unlock password open door 
        public const int MINOR_AUTO_RENUMBER = 0x410; // auto renumber 
        public const int MINOR_AUTO_COMPLEMENT_NUMBER = 0x411; // auto complement number 
        public const int MINOR_NORMAL_CFGFILE_INPUT = 0x412; // normal cfg file input 
        public const int MINOR_NORMAL_CFGFILE_OUTTPUT = 0x413; // normal cfg file output 
        public const int MINOR_CARD_RIGHT_INPUT = 0x414; // card right input 
        public const int MINOR_CARD_RIGHT_OUTTPUT = 0x415; // card right output 
        public const int MINOR_LOCAL_USB_UPGRADE = 0x416; // local USB upgrade 
        public const int MINOR_REMOTE_VISITOR_CALL_LADDER = 0x417; // visitor call ladder 
        public const int MINOR_REMOTE_HOUSEHOLD_CALL_LADDER = 0x418; // household call ladder 
        public const int MINOR_REMOTE_ACTUAL_GUARD = 0x419;  //remote actual guard
        public const int MINOR_REMOTE_ACTUAL_UNGUARD = 0x41a;  //remote actual unguard
        public const int MINOR_REMOTE_CONTROL_NOT_CODE_OPER_FAILED = 0x41b; //remote control not code operate failed
        public const int MINOR_REMOTE_CONTROL_CLOSE_DOOR = 0x41c; //remote control close door
        public const int MINOR_REMOTE_CONTROL_OPEN_DOOR = 0x41d; //remote control open door
        public const int MINOR_REMOTE_CONTROL_ALWAYS_OPEN_DOOR = 0x41e; //remote control always open door

        /* Additional Log Info*/
        // Main Type
        public const int MAJOR_EVENT = 0x5;/*event*/
        // Hypo- Type
        public const int MINOR_LEGAL_CARD_PASS = 0x01; // legal card pass
        public const int MINOR_CARD_AND_PSW_PASS = 0x02; // swipe and password pass
        public const int MINOR_CARD_AND_PSW_FAIL = 0x03; // swipe and password fail
        public const int MINOR_CARD_AND_PSW_TIMEOUT = 0x04; // swipe and password timeout
        public const int MINOR_CARD_AND_PSW_OVER_TIME = 0x05; // swipe and password over time
        public const int MINOR_CARD_NO_RIGHT = 0x06; // card no right 
        public const int MINOR_CARD_INVALID_PERIOD = 0x07; // invalid period 
        public const int MINOR_CARD_OUT_OF_DATE = 0x08; // card out of date
        public const int MINOR_INVALID_CARD = 0x09; // invalid card 
        public const int MINOR_ANTI_SNEAK_FAIL = 0x0a; // anti sneak fail 
        public const int MINOR_INTERLOCK_DOOR_NOT_CLOSE = 0x0b; // interlock door doesn't close
        public const int MINOR_NOT_BELONG_MULTI_GROUP = 0x0c; // card no belong multi group 
        public const int MINOR_INVALID_MULTI_VERIFY_PERIOD = 0x0d; // invalid multi verify period 
        public const int MINOR_MULTI_VERIFY_SUPER_RIGHT_FAIL = 0x0e; // have no super right in multi verify mode 
        public const int MINOR_MULTI_VERIFY_REMOTE_RIGHT_FAIL = 0x0f; // have no remote right in multi verify mode 
        public const int MINOR_MULTI_VERIFY_SUCCESS = 0x10; // success in multi verify mode 
        public const int MINOR_LEADER_CARD_OPEN_BEGIN = 0x11; // leader card begin to open
        public const int MINOR_LEADER_CARD_OPEN_END = 0x12; // leader card end to open 
        public const int MINOR_ALWAYS_OPEN_BEGIN = 0x13; // always open begin
        public const int MINOR_ALWAYS_OPEN_END = 0x14; // always open end
        public const int MINOR_LOCK_OPEN = 0x15; // lock open
        public const int MINOR_LOCK_CLOSE = 0x16; // lock close
        public const int MINOR_DOOR_BUTTON_PRESS = 0x17; // press door open button 
        public const int MINOR_DOOR_BUTTON_RELEASE = 0x18; // release door open button 
        public const int MINOR_DOOR_OPEN_NORMAL = 0x19; // door open normal 
        public const int MINOR_DOOR_CLOSE_NORMAL = 0x1a; // door close normal 
        public const int MINOR_DOOR_OPEN_ABNORMAL = 0x1b; // open door abnormal 
        public const int MINOR_DOOR_OPEN_TIMEOUT = 0x1c; // open door timeout 
        public const int MINOR_ALARMOUT_ON = 0x1d; // alarm out turn on 
        public const int MINOR_ALARMOUT_OFF = 0x1e; // alarm out turn off 
        public const int MINOR_ALWAYS_CLOSE_BEGIN = 0x1f; // always close begin 
        public const int MINOR_ALWAYS_CLOSE_END = 0x20; // always close end 
        public const int MINOR_MULTI_VERIFY_NEED_REMOTE_OPEN = 0x21; // need remote open in multi verify mode 
        public const int MINOR_MULTI_VERIFY_SUPERPASSWD_VERIFY_SUCCESS = 0x22; // superpasswd verify success in multi verify mode 
        public const int MINOR_MULTI_VERIFY_REPEAT_VERIFY = 0x23; // repeat verify in multi verify mode 
        public const int MINOR_MULTI_VERIFY_TIMEOUT = 0x24; // timeout in multi verify mode 
        public const int MINOR_DOORBELL_RINGING = 0x25; // doorbell ringing 
        public const int MINOR_FINGERPRINT_COMPARE_PASS = 0x26; // fingerprint compare pass 
        public const int MINOR_FINGERPRINT_COMPARE_FAIL = 0x27; // fingerprint compare fail 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_PASS = 0x28; // card and fingerprint verify pass 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_FAIL = 0x29; // card and fingerprint verify fail 
        public const int MINOR_CARD_FINGERPRINT_VERIFY_TIMEOUT = 0x2a; // card and fingerprint verify timeout 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_PASS = 0x2b; // card and fingerprint and passwd verify pass 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_FAIL = 0x2c; // card and fingerprint and passwd verify fail 
        public const int MINOR_CARD_FINGERPRINT_PASSWD_VERIFY_TIMEOUT = 0x2d; // card and fingerprint and passwd verify timeout 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_PASS = 0x2e; // fingerprint and passwd verify pass 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_FAIL = 0x2f; // fingerprint and passwd verify fail 
        public const int MINOR_FINGERPRINT_PASSWD_VERIFY_TIMEOUT = 0x30; // fingerprint and passwd verify timeout 
        public const int MINOR_FINGERPRINT_INEXISTENCE = 0x31; // fingerprint inexistence 
        public const int MINOR_CARD_PLATFORM_VERIFY = 0x32; // card platform verify 
        public const int MINOR_CALL_CENTER = 0x33; // call center 
        public const int MINOR_FIRE_RELAY_TURN_ON_DOOR_ALWAYS_OPEN = 0x34; // fire relay turn on door always open 
        public const int MINOR_FIRE_RELAY_RECOVER_DOOR_RECOVER_NORMAL = 0x35; // fire relay recover door recover normal 
        public const int MINOR_FACE_AND_FP_VERIFY_PASS = 0x36; // face and finger print verify pass 
        public const int MINOR_FACE_AND_FP_VERIFY_FAIL = 0x37; // face and finger print verify fail 
        public const int MINOR_FACE_AND_FP_VERIFY_TIMEOUT = 0x38; // face and finger print verify timeout 
        public const int MINOR_FACE_AND_PW_VERIFY_PASS = 0x39; // face and password verify pass 
        public const int MINOR_FACE_AND_PW_VERIFY_FAIL = 0x3a; // face and password verify fail 
        public const int MINOR_FACE_AND_PW_VERIFY_TIMEOUT = 0x3b; // face and password verify timeout 
        public const int MINOR_FACE_AND_CARD_VERIFY_PASS = 0x3c; // face and card verify pass 
        public const int MINOR_FACE_AND_CARD_VERIFY_FAIL = 0x3d; // face and card verify fail 
        public const int MINOR_FACE_AND_CARD_VERIFY_TIMEOUT = 0x3e; // face and card verify timeout 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_PASS = 0x3f; // face and password and finger print verify pass 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_FAIL = 0x40; // face and password and finger print verify fail 
        public const int MINOR_FACE_AND_PW_AND_FP_VERIFY_TIMEOUT = 0x41; // face and password and finger print verify timeout 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_PASS = 0x42; // face and card and finger print verify pass 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_FAIL = 0x43; // face and card and finger print verify fail 
        public const int MINOR_FACE_CARD_AND_FP_VERIFY_TIMEOUT = 0x44; // face and card and finger print verify timeout 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_PASS = 0x45; // employee and finger print verify pass 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_FAIL = 0x46; // employee and finger print verify fail 
        public const int MINOR_EMPLOYEENO_AND_FP_VERIFY_TIMEOUT = 0x47; // employee and finger print verify timeout 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_PASS = 0x48; // employee and finger print and password verify pass 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_FAIL = 0x49; // employee and finger print and password verify fail 
        public const int MINOR_EMPLOYEENO_AND_FP_AND_PW_VERIFY_TIMEOUT = 0x4a; // employee and finger print and password verify timeout
        public const int MINOR_FACE_VERIFY_PASS = 0x4b; // face verify pass 
        public const int MINOR_FACE_VERIFY_FAIL = 0x4c; // face verify fail 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_PASS = 0x4d; // employee no and face verify pass 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_FAIL = 0x4e; // employee no and face verify fail 
        public const int MINOR_EMPLOYEENO_AND_FACE_VERIFY_TIMEOUT = 0x4f; // employee no and face verify time out 
        public const int MINOR_FACE_RECOGNIZE_FAIL = 0x50; // face recognize fail 
        public const int MINOR_FIRSTCARD_AUTHORIZE_BEGIN = 0x51; // first card authorize begin 
        public const int MINOR_FIRSTCARD_AUTHORIZE_END = 0x52; // first card authorize end 
        public const int MINOR_DOORLOCK_INPUT_SHORT_CIRCUIT = 0x53; // door lock input short circuit 
        public const int MINOR_DOORLOCK_INPUT_BROKEN_CIRCUIT = 0x54; // door lock input broken circuit 
        public const int MINOR_DOORLOCK_INPUT_EXCEPTION = 0x55; // door lock input exception 
        public const int MINOR_DOORCONTACT_INPUT_SHORT_CIRCUIT = 0x56; // door contact input short circuit 
        public const int MINOR_DOORCONTACT_INPUT_BROKEN_CIRCUIT = 0x57; // door contact input broken circuit 
        public const int MINOR_DOORCONTACT_INPUT_EXCEPTION = 0x58; // door contact input exception 
        public const int MINOR_OPENBUTTON_INPUT_SHORT_CIRCUIT = 0x59; // open button input short circuit 
        public const int MINOR_OPENBUTTON_INPUT_BROKEN_CIRCUIT = 0x5a; // open button input broken circuit 
        public const int MINOR_OPENBUTTON_INPUT_EXCEPTION = 0x5b; // open button input exception 
        public const int MINOR_DOORLOCK_OPEN_EXCEPTION = 0x5c; // door lock open exception 
        public const int MINOR_DOORLOCK_OPEN_TIMEOUT = 0x5d; // door lock open timeout 
        public const int MINOR_FIRSTCARD_OPEN_WITHOUT_AUTHORIZE = 0x5e; // first card open without authorize 
        public const int MINOR_CALL_LADDER_RELAY_BREAK = 0x5f; // call ladder relay break 
        public const int MINOR_CALL_LADDER_RELAY_CLOSE = 0x60; // call ladder relay close 
        public const int MINOR_AUTO_KEY_RELAY_BREAK = 0x61; // auto key relay break 
        public const int MINOR_AUTO_KEY_RELAY_CLOSE = 0x62; // auto key relay close 
        public const int MINOR_KEY_CONTROL_RELAY_BREAK = 0x63; // key control relay break 
        public const int MINOR_KEY_CONTROL_RELAY_CLOSE = 0x64; // key control relay close 
        public const int MINOR_EMPLOYEENO_AND_PW_PASS = 0x65; // minor employee no and password pass 
        public const int MINOR_EMPLOYEENO_AND_PW_FAIL = 0x66; // minor employee no and password fail 
        public const int MINOR_EMPLOYEENO_AND_PW_TIMEOUT = 0x67; // minor employee no and password timeout 
        public const int MINOR_HUMAN_DETECT_FAIL = 0x68; // human detect fail 
        public const int MINOR_PEOPLE_AND_ID_CARD_COMPARE_PASS = 0x69; // the comparison with people and id card success 
        public const int MINOR_PEOPLE_AND_ID_CARD_COMPARE_FAIL = 0x70; // the comparison with people and id card failed 
        public const int MINOR_CERTIFICATE_BLACK_LIST = 0x71; // black list 
        public const int MINOR_LEGAL_MESSAGE = 0x72; // legal message 
        public const int MINOR_ILLEGAL_MESSAGE = 0x73; // illegal messag 
        public const int MINOR_MAC_DETECT = 0x74; // mac detect 
        public const int MINOR_DOOR_OPEN_OR_DORMANT_FAIL = 0x75; //door open or dormant fail
        public const int MINOR_AUTH_PLAN_DORMANT_FAIL = 0x76;  //auth plan dormant fail
        public const int MINOR_CARD_ENCRYPT_VERIFY_FAIL = 0x77; //card encrypt verify fail
        public const int MINOR_SUBMARINEBACK_REPLY_FAIL = 0x78;  //submarineback reply fail
        public const int MINOR_DOOR_OPEN_OR_DORMANT_OPEN_FAIL = 0x82;  //door open or dormant open fail
        public const int MINOR_DOOR_OPEN_OR_DORMANT_LINKAGE_OPEN_FAIL = 0x84; //door open or dormant linkage open fail
        public const int MINOR_TRAILING = 0x85;  //trailing
        public const int MINOR_HEART_BEAT = 0x83;  //heart beat event
        public const int MINOR_REVERSE_ACCESS = 0x86; //reverse access
        public const int MINOR_FORCE_ACCESS = 0x87; //force access
        public const int MINOR_CLIMBING_OVER_GATE = 0x88; //climbing over gate
        public const int MINOR_PASSING_TIMEOUT = 0x89;  //passing timeout
        public const int MINOR_INTRUSION_ALARM = 0x8a;  //intrusion alarm
        public const int MINOR_FREE_GATE_PASS_NOT_AUTH = 0x8b; //free gate pass not auth
        public const int MINOR_DROP_ARM_BLOCK = 0x8c; //drop arm block
        public const int MINOR_DROP_ARM_BLOCK_RESUME = 0x8d;  //drop arm block resume
        public const int MINOR_LOCAL_FACE_MODELING_FAIL = 0x8e;  //device upgrade with module failed
        public const int MINOR_STAY_EVENT = 0x8f;  //stay event
        public const int MINOR_PASSWORD_MISMATCH = 0x97;  //password mismatch
        public const int MINOR_EMPLOYEE_NO_NOT_EXIST = 0x98;  //employee no not exist
        public const int MINOR_COMBINED_VERIFY_PASS = 0x99;  //combined verify pass
        public const int MINOR_COMBINED_VERIFY_TIMEOUT = 0x9a;  //combined verify timeout
        public const int MINOR_VERIFY_MODE_MISMATCH = 0x9b;  //verify mode mismatch

        #endregion

        #region card parameters configuration
        public const int CARD_PARAM_CARD_VALID = 0x00000001;  //card valid parameter 
        public const int CARD_PARAM_VALID = 0x00000002;  //valid period parameter
        public const int CARD_PARAM_CARD_TYPE = 0x00000004;  //card type parameter
        public const int CARD_PARAM_DOOR_RIGHT = 0x00000008;  //door right parameter
        public const int CARD_PARAM_LEADER_CARD = 0x00000010;  //leader card parameter
        public const int CARD_PARAM_SWIPE_NUM = 0x00000020;  //max swipe time parameter
        public const int CARD_PARAM_GROUP = 0x00000040;  //belong group parameter
        public const int CARD_PARAM_PASSWORD = 0x00000080;  //card password parameter
        public const int CARD_PARAM_RIGHT_PLAN = 0x00000100;  //card right plan parameter
        public const int CARD_PARAM_SWIPED_NUM = 0x00000200;  //has swiped card time parameter
        public const int CARD_PARAM_EMPLOYEE_NO = 0x00000400;  //employee no

        public const int ACS_CARD_NO_LEN = 32;  //access card No. len
        public const int MAX_DOOR_NUM_256 = 256; //max door num
        public const int MAX_GROUP_NUM_128 = 128; //The largest number of grou
        public const int CARD_PASSWORD_LEN = 8;   // card password len 
        public const int MAX_CARD_RIGHT_PLAN_NUM = 4;   //max card right plan number
        public const int MAX_DOOR_CODE_LEN = 8; //room code length
        public const int MAX_LOCK_CODE_LEN = 8; //lock code length

        public const int MAX_CASE_SENSOR_NUM = 8;   //max case sensor number
        public const int MAX_CARD_READER_NUM_512 = 512; //max card reader num
        public const int MAX_ALARMHOST_ALARMIN_NUM = 512; //Max number of alarm host alarm input ports
        public const int MAX_ALARMHOST_ALARMOUT_NUM = 512; //Max number of alarm host alarm output ports

        public const int NET_DVR_GET_ACS_WORK_STATUS_V50 = 2180;   //Access door host working condition (V50)
        public const int NET_DVR_GET_CARD_CFG_V50 = 2178;    //Parameters to acquire new CARDS (V50)
        public const int NET_DVR_SET_CARD_CFG_V50 = 2179;    //Setting up the new parameters (V50)

        #endregion

        public const int NET_DVR_GET_TIMECFG = 118;//get device time
        public const int NET_DVR_SET_TIMECFG = 119;//set device time
        public const int NET_DVR_GET_AUDIOIN_VOLUME_CFG = 6355;  //get audio in volume
        public const int NET_DVR_SET_AUDIOIN_VOLUME_CFG = 6356;  //set audio in volume
        public const int NET_DVR_GET_AUDIOOUT_VOLUME_CFG = 6369; //get audio out volume
        public const int NET_DVR_SET_AUDIOOUT_VOLUME_CFG = 6370; //set audio out volume



        #region door parameters configuration
        public const int DOOR_NAME_LEN = 32;//door name len 
        public const int STRESS_PASSWORD_LEN = 8;//stress password len
        public const int SUPER_PASSWORD_LEN = 8;//super password len
        public const int UNLOCK_PASSWORD_LEN = 8;
        public const int MAX_DOOR_NUM = 32;
        public const int MAX_GROUP_NUM = 32;
        public const int LOCAL_CONTROLLER_NAME_LEN = 32;

        public const int NET_DVR_GET_DOOR_CFG = 2108; //get door parameter
        public const int NET_DVR_SET_DOOR_CFG = 2109; //set door parameter

        #endregion

        #region GetAcsEvent
        public const int NET_SDK_MONITOR_ID_LEN = 64;
        public const int WM_MSG_ADD_ACS_EVENT_TOLIST = 1002;
        public const int WM_MSG_GET_ACS_EVENT_FINISH = 1003;
        #endregion

        #region group configuration

        public const int GROUP_NAME_LEN = 32;

        public const int NET_DVR_GET_GROUP_CFG = 2112;   //get group parameter
        public const int NET_DVR_SET_GROUP_CFG = 2113;    //set group parameter

        #endregion

        #region user parameters configuration

        public const int MAX_ALARMHOST_VIDEO_CHAN = 64;

        public const int NET_DVR_GET_DEVICECFG_V40 = 1100;//Get extended device parameters  
        public const int NET_DVR_SET_DEVICECFG_V40 = 1101;//Set extended device parameters 

        #endregion

        #region cardreader configuration

        public const int CARD_READER_DESCRIPTION = 32;       //card reader description

        public const int NET_DVR_GET_CARD_READER_CFG_V50 = 2505;      //get card reader configure v50
        public const int NET_DVR_SET_CARD_READER_CFG_V50 = 2506;      //set card reader configure v50

        #endregion

        #region face configuration

        public const int MAX_FACE_NUM = 2;                       //max face number

        public const int NET_DVR_GET_FACE_PARAM_CFG = 2507;      //get face param configure
        public const int NET_DVR_SET_FACE_PARAM_CFG = 2508;      //set face param configure
        public const int NET_DVR_DEL_FACE_PARAM_CFG = 2509;      //delete face param configure
        public const int NET_DVR_CAPTURE_FACE_INFO = 2510;       //capture face information

        #endregion

        #region fingerprint configuration

        public const int MAX_FINGER_PRINT_LEN = 768; //max finger print len
        public const int MAX_FINGER_PRINT_NUM = 10; //max finger print num
        public const int ERROR_MSG_LEN = 32;
        public const int NET_SDK_EMPLOYEE_NO_LEN = 32;

        public const int NET_DVR_GET_FINGERPRINT_CFG = 2150;    //get fingerprint parameter
        public const int NET_DVR_SET_FINGERPRINT_CFG = 2151;    //set fingerprint parameter
        public const int NET_DVR_DEL_FINGERPRINT_CFG = 2152;    //delete fingerprint parameter

        public const int NET_DVR_GET_FINGERPRINT_CFG_V50 = 2183;    //get fingerprint parameter V50
        public const int NET_DVR_SET_FINGERPRINT_CFG_V50 = 2184;    //set fingerprint parameter V50

        #endregion

        #region plan configuration

        public const int MAX_DAYS = 7; //The number of days in a week
        public const int MAX_TIMESEGMENT_V30 = 8; //Maximum number of time segments in 9000 DVR's guard schedule
        public const int HOLIDAY_GROUP_NAME_LEN = 32;  //holiday group name len
        public const int MAX_HOLIDAY_PLAN_NUM = 16;  //holiday max plan number
        public const int TEMPLATE_NAME_LEN = 32; //plan template name len 
        public const int MAX_HOLIDAY_GROUP_NUM = 16;   //plan template max group number

        public const int NET_DVR_GET_WEEK_PLAN_CFG = 2100; //get door status week plan config 
        public const int NET_DVR_SET_WEEK_PLAN_CFG = 2101; //set door status week plan config 
        public const int NET_DVR_GET_DOOR_STATUS_HOLIDAY_PLAN = 2102; //get door status holiday week plan config 
        public const int NET_DVR_SET_DOOR_STATUS_HOLIDAY_PLAN = 2103; //set door status holiday week plan config
        public const int NET_DVR_GET_DOOR_STATUS_HOLIDAY_GROUP = 2104; //get door holiday group parameter
        public const int NET_DVR_SET_DOOR_STATUS_HOLIDAY_GROUP = 2105; //set door holiday group parameter
        public const int NET_DVR_GET_DOOR_STATUS_PLAN_TEMPLATE = 2106; //get door status plan template parameter
        public const int NET_DVR_SET_DOOR_STATUS_PLAN_TEMPLATE = 2107; //set door status plan template parameter
        public const int NET_DVR_GET_VERIFY_WEEK_PLAN = 2124; //get reader card verfy week plan
        public const int NET_DVR_SET_VERIFY_WEEK_PLAN = 2125; //set reader card verfy week plan
        public const int NET_DVR_GET_CARD_RIGHT_WEEK_PLAN = 2126;  //get card right week plan 
        public const int NET_DVR_SET_CARD_RIGHT_WEEK_PLAN = 2127; //set card right week plan 
        public const int NET_DVR_GET_VERIFY_HOLIDAY_PLAN = 2128; //get card reader verify holiday plan 
        public const int NET_DVR_SET_VERIFY_HOLIDAY_PLAN = 2129; //set card reader verify holiday plan 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_PLAN = 2130; //get card right holiday plan 
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_PLAN = 2131; //set card right holiday plan 
        public const int NET_DVR_GET_VERIFY_HOLIDAY_GROUP = 2132; //get card reader verify holiday group 
        public const int NET_DVR_SET_VERIFY_HOLIDAY_GROUP = 2133; //set card reader verify holiday group 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_GROUP = 2134; //get card right holiday group 
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_GROUP = 2135; //set card right holiday group 
        public const int NET_DVR_GET_VERIFY_PLAN_TEMPLATE = 2136; //get card reader verify plan template 
        public const int NET_DVR_SET_VERIFY_PLAN_TEMPLATE = 2137; //set card reader verify plan template 
        public const int NET_DVR_GET_CARD_RIGHT_PLAN_TEMPLATE = 2138; //get card right plan template
        public const int NET_DVR_SET_CARD_RIGHT_PLAN_TEMPLATE = 2139; //set card right plan template
        // V50
        public const int NET_DVR_GET_CARD_RIGHT_WEEK_PLAN_V50 = 2304;  //Access card right V50 weeks plan parameters
        public const int NET_DVR_SET_CARD_RIGHT_WEEK_PLAN_V50 = 2305;  //Set card right V50 weeks plan parameters 
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_PLAN_V50 = 2310;  //Access card right parameters V50 holiday plan  
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_PLAN_V50 = 2311;  //Set card right parameters V50 holiday plan
        public const int NET_DVR_GET_CARD_RIGHT_HOLIDAY_GROUP_V50 = 2316; //Access card right parameters V50 holiday group
        public const int NET_DVR_SET_CARD_RIGHT_HOLIDAY_GROUP_V50 = 2317; //Set card right parameters V50 holiday group
        public const int NET_DVR_GET_CARD_RIGHT_PLAN_TEMPLATE_V50 = 2322; //Access card right parameters V50 plan template
        public const int NET_DVR_SET_CARD_RIGHT_PLAN_TEMPLATE_V50 = 2323; //Set card right parameters V50 plan template

        #endregion

        #region card reader verification mode and door status planning parameters configuration

        public const int NET_DVR_GET_DOOR_STATUS_PLAN = 2110; //get door status plan parameter 
        public const int NET_DVR_SET_DOOR_STATUS_PLAN = 2111; //set door status plan parameter 
        public const int NET_DVR_GET_CARD_READER_PLAN = 2142; //get card reader verify plan parameter 
        public const int NET_DVR_SET_CARD_READER_PLAN = 2143; //get card reader verify plan parameter 

        #endregion

        #region card number associated with the user information parameter configuration

        public const int NET_DVR_GET_CARD_USERINFO_CFG = 2163; //get card userinfo cfg 
        public const int NET_DVR_SET_CARD_USERINFO_CFG = 2164; //set card userinfo cfg 

        #endregion

        #region event card linkage

        public const int NET_DVR_GET_EVENT_CARD_LINKAGE_CFG_V50 = 2181; //get event card linkage cfg 
        public const int NET_DVR_SET_EVENT_CARD_LINKAGE_CFG_V50 = 2182; //set event card linkage cfg 

        #endregion

        public const int NET_DVR_DEL_FINGERPRINT_CFG_V50 = 2517;    //delete fingerprint parameter V50
        public const int NET_DVR_GET_EVENT_CARD_LINKAGE_CFG_V51 = 2518; //get event card linkage cfg V51
        public const int NET_DVR_SET_EVENT_CARD_LINKAGE_CFG_V51 = 2519; //set event card linkage cfg V51

        public const int NET_DVR_JSON_CONFIG = 2550;
        public const int NET_DVR_FACE_DATA_RECORD = 2551;
        public const int NET_DVR_FACE_DATA_SEARCH = 2552;
        public const int NET_DVR_FACE_DATA_MODIFY = 2553;

        #region net configuration

        public const int NET_DVR_GET_NETCFG_V30 = 1000;//Get network parameter configuration 
        public const int NET_DVR_SET_NETCFG_V30 = 1001;//Set network parameter configuration 
        public const int NET_DVR_GET_NETCFG_V50 = 1015;    //Get network parameter configuration (V50) 
        public const int NET_DVR_SET_NETCFG_V50 = 1016;    //Set network parameter configuration (V50) 

        #endregion

        #region video call

        public const int NET_DVR_VIDEO_CALL_SIGNAL_PROCESS = 16032;    //video call signal process

        #endregion

        #endregion // HCNetSDK.dll macro definition

        #region ACS_FACE_PARAM
        public const int WM_MSG_SET_FACE_PARAM_FINISH = 1002;
        public const int WM_MSG_GET_FACE_PARAM_FINISH = 1003;
        public const int WM_MSG_ADD_FACE_PARAM_TOLIST = 1004;
        #endregion

        #region HCNetSDK.dll structure definition

        //structure definition

        #region common use

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DATE
        {
            public ushort wYear;        //year
            public byte byMonth;        //month    
            public byte byDay;        //day                        
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SIMPLE_DAYTIME
        {
            public byte byHour; //hour
            public byte byMinute; //minute
            public byte bySecond; //second
            public byte byRes;
        }

        // Time correction structure
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_TIME
        {
            public int dwYear;
            public int dwMonth;
            public int dwDay;
            public int dwHour;
            public int dwMinute;
            public int dwSecond;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_TIME_EX
        {
            public ushort wYear;
            public byte byMonth;
            public byte byDay;
            public byte byHour;
            public byte byMinute;
            public byte bySecond;
            public byte byRes;
        }

        // Long config callback type
        public enum NET_SDK_CALLBACK_TYPE
        {
            NET_SDK_CALLBACK_TYPE_STATUS = 0,        // Status
            NET_SDK_CALLBACK_TYPE_PROGRESS,            // Progress
            NET_SDK_CALLBACK_TYPE_DATA                // Data
        }

        // Long config status value
        public enum NET_SDK_CALLBACK_STATUS_NORMAL
        {
            NET_SDK_CALLBACK_STATUS_SUCCESS = 1000,        // Success
            NET_SDK_CALLBACK_STATUS_PROCESSING,            // Processing
            NET_SDK_CALLBACK_STATUS_FAILED,                // Failed
            NET_SDK_CALLBACK_STATUS_EXCEPTION,            // Exception
            NET_SDK_CALLBACK_STATUS_LANGUAGE_MISMATCH,    // Language mismatch
            NET_SDK_CALLBACK_STATUS_DEV_TYPE_MISMATCH,    // Device type mismatch
            NET_DVR_CALLBACK_STATUS_SEND_WAIT,           // send wait
        }
        public enum LONG_CFG_SEND_DATA_TYPE_ENUM
        {
            ENUM_DVR_VEHICLE_CHECK = 1, //vehicle Black list check
            ENUM_MSC_SEND_DATA = 2,  //screen control data type
            ENUM_ACS_SEND_DATA = 3, //access card data type
            ENUM_TME_CARD_SEND_DATA = 4, //Parking Card data type
            ENUM_TME_VEHICLE_SEND_DATA = 5, //TME Vehicle Info data type
            ENUM_DVR_DEBUG_CMD = 6, //Debug Cmd
            ENUM_DVR_SCREEN_CTRL_CMD = 7, //Screen interactive
            ENUM_CVR_PASSBACK_SEND_DATA = 8, //CVR get passback task executable data type
            ENUM_ACS_INTELLIGENT_IDENTITY_DATA = 9,  //intelligent identity data type
            ENUM_VIDEO_INTERCOM_SEND_DATA = 10,  //video intercom send data
            ENUM_SEND_JSON_DATA = 11    //send json data
        }

        public enum ENUM_UPGRADE_TYPE
        {
            ENUM_UPGRADE_DVR = 0, //other device
            ENUM_UPGRADE_ACS = 1,  //acs device
        }

        public enum NET_SDK_GET_NEXT_STATUS
        {
            NET_SDK_GET_NEXT_STATUS_SUCCESS = 1000,    // Get data successfully, Call API NET_DVR_RemoteConfigGetNext after processing this data.
            NET_SDK_GET_NETX_STATUS_NEED_WAIT,        // Need wait, keep calling NET_DVR_RemoteConfigGetNext
            NET_SDK_GET_NEXT_STATUS_FINISH,            // Get data finish, call API NET_DVR_StopRemoteConfig
            NET_SDK_GET_NEXT_STATUS_FAILED,            // Get data failed, call API NET_DVR_StopRemoteConfig
        }

        public enum LONG_CFG_RECV_DATA_TYPE_ENUM
        {
            ENUM_DVR_ERROR_CODE = 1, //Error code
            ENUM_MSC_RECV_DATA = 2, //screen control data type
            ENUM_ACS_RECV_DATA = 3 //ACS control data type
        }

        public enum ACS_DEV_SUBEVENT_ENUM
        {
            EVENT_ACS_HOST_ANTI_DISMANTLE = 0,
            EVENT_ACS_OFFLINE_ECENT_NEARLY_FULL,
            EVENT_ACS_NET_BROKEN,
            EVENT_ACS_NET_RESUME,
            EVENT_ACS_LOW_BATTERY,
            EVENT_ACS_BATTERY_RESUME,
            EVENT_ACS_AC_OFF,
            EVENT_ACS_AC_RESUME,
            EVENT_ACS_SD_CARD_FULL,
            EVENT_ACS_LINKAGE_CAPTURE_PIC,
            EVENT_ACS_IMAGE_QUALITY_LOW,
            EVENT_ACS_FINGER_PRINT_QUALITY_LOW,
            EVENT_ACS_BATTERY_ELECTRIC_LOW,
            EVENT_ACS_BATTERY_ELECTRIC_RESUME,
            EVENT_ACS_FIRE_IMPORT_SHORT_CIRCUIT,
            EVENT_ACS_FIRE_IMPORT_BROKEN_CIRCUIT,
            EVENT_ACS_FIRE_IMPORT_RESUME,
            EVENT_ACS_MASTER_RS485_LOOPNODE_BROKEN,
            EVENT_ACS_MASTER_RS485_LOOPNODE_RESUME,
            EVENT_ACS_LOCAL_CONTROL_OFFLINE,
            EVENT_ACS_LOCAL_CONTROL_RESUME,
            EVENT_ACS_LOCAL_DOWNSIDE_RS485_LOOPNODE_BROKEN,
            EVENT_ACS_LOCAL_DOWNSIDE_RS485_LOOPNODE_RESUME,
            EVENT_ACS_DISTRACT_CONTROLLER_ONLINE,
            EVENT_ACS_DISTRACT_CONTROLLER_OFFLINE,
            EVENT_ACS_FIRE_BUTTON_TRIGGER,
            EVENT_ACS_FIRE_BUTTON_RESUME,
            EVENT_ACS_MAINTENANCE_BUTTON_TRIGGER,
            EVENT_ACS_MAINTENANCE_BUTTON_RESUME,
            EVENT_ACS_EMERGENCY_BUTTON_TRIGGER,
            EVENT_ACS_EMERGENCY_BUTTON_RESUME,
            EVENT_ACS_MAC_DETECT
        }
        public enum ACS_ALARM_SUBEVENT_ENUM
        {
            EVENT_ACS_ALARMIN_SHORT_CIRCUIT = 0,
            EVENT_ACS_ALARMIN_BROKEN_CIRCUIT,
            EVENT_ACS_ALARMIN_EXCEPTION,
            EVENT_ACS_ALARMIN_RESUME,
            EVENT_ACS_CASE_SENSOR_ALARM,
            EVENT_ACS_CASE_SENSOR_RESUME
        }

        public enum ACS_DOOR_SUBEVENT_ENUM
        {
            EVENT_ACS_LEADER_CARD_OPEN_BEGIN = 0,
            EVENT_ACS_LEADER_CARD_OPEN_END,
            EVENT_ACS_ALWAYS_OPEN_BEGIN,
            EVENT_ACS_ALWAYS_OPEN_END,
            EVENT_ACS_ALWAYS_CLOSE_BEGIN,
            EVENT_ACS_ALWAYS_CLOSE_END,
            EVENT_ACS_LOCK_OPEN,
            EVENT_ACS_LOCK_CLOSE,
            EVENT_ACS_DOOR_BUTTON_PRESS,
            EVENT_ACS_DOOR_BUTTON_RELEASE,
            EVENT_ACS_DOOR_OPEN_NORMAL,
            EVENT_ACS_DOOR_CLOSE_NORMAL,
            EVENT_ACS_DOOR_OPEN_ABNORMAL,
            EVENT_ACS_DOOR_OPEN_TIMEOUT,
            EVENT_ACS_REMOTE_OPEN_DOOR,
            EVENT_ACS_REMOTE_CLOSE_DOOR,
            EVENT_ACS_REMOTE_ALWAYS_OPEN,
            EVENT_ACS_REMOTE_ALWAYS_CLOSE,
            EVENT_ACS_NOT_BELONG_MULTI_GROUP,
            EVENT_ACS_INVALID_MULTI_VERIFY_PERIOD,
            EVENT_ACS_MULTI_VERIFY_SUPER_RIGHT_FAIL,
            EVENT_ACS_MULTI_VERIFY_REMOTE_RIGHT_FAIL,
            EVENT_ACS_MULTI_VERIFY_SUCCESS,
            EVENT_ACS_MULTI_VERIFY_NEED_REMOTE_OPEN,
            EVENT_ACS_MULTI_VERIFY_SUPERPASSWD_VERIFY_SUCCESS,
            EVENT_ACS_MULTI_VERIFY_REPEAT_VERIFY_FAIL,
            EVENT_ACS_MULTI_VERIFY_TIMEOUT,
            EVENT_ACS_REMOTE_CAPTURE_PIC,
            EVENT_ACS_DOORBELL_RINGING,
            EVENT_ACS_SECURITY_MODULE_DESMANTLE_ALARM,
            EVENT_ACS_CALL_CENTER,
            EVENT_ACS_FIRSTCARD_AUTHORIZE_BEGIN,
            EVENT_ACS_FIRSTCARD_AUTHORIZE_END,
            EVENT_ACS_DOORLOCK_INPUT_SHORT_CIRCUIT,
            EVENT_ACS_DOORLOCK_INPUT_BROKEN_CIRCUIT,
            EVENT_ACS_DOORLOCK_INPUT_EXCEPTION,
            EVENT_ACS_DOORCONTACT_INPUT_SHORT_CIRCUIT,
            EVENT_ACS_DOORCONTACT_INPUT_BROKEN_CIRCUIT,
            EVENT_ACS_DOORCONTACT_INPUT_EXCEPTION,
            EVENT_ACS_OPENBUTTON_INPUT_SHORT_CIRCUIT,
            EVENT_ACS_OPENBUTTON_INPUT_BROKEN_CIRCUIT,
            EVENT_ACS_OPENBUTTON_INPUT_EXCEPTION,
            EVENT_ACS_DOORLOCK_OPEN_EXCEPTION,
            EVENT_ACS_DOORLOCK_OPEN_TIMEOUT,
            EVENT_ACS_FIRSTCARD_OPEN_WITHOUT_AUTHORIZE,
            EVENT_ACS_CALL_LADDER_RELAY_BREAK,
            EVENT_ACS_CALL_LADDER_RELAY_CLOSE,
            EVENT_ACS_AUTO_KEY_RELAY_BREAK,
            EVENT_ACS_AUTO_KEY_RELAY_CLOSE,
            EVENT_ACS_KEY_CONTROL_RELAY_BREAK,
            EVENT_ACS_KEY_CONTROL_RELAY_CLOSE,
            EVENT_ACS_REMOTE_VISITOR_CALL_LADDER,
            EVENT_ACS_REMOTE_HOUSEHOLD_CALL_LADDER,
            EVENT_ACS_LEGAL_MESSAGE,
            EVENT_ACS_ILLEGAL_MESSAGE
        }

        public enum ACS_CARD_READER_SUBEVENT_ENUM
        {
            EVENT_ACS_STRESS_ALARM = 0,
            EVENT_ACS_CARD_READER_DESMANTLE_ALARM,
            EVENT_ACS_LEGAL_CARD_PASS,
            EVENT_ACS_CARD_AND_PSW_PASS,
            EVENT_ACS_CARD_AND_PSW_FAIL,
            EVENT_ACS_CARD_AND_PSW_TIMEOUT,
            EVENT_ACS_CARD_MAX_AUTHENTICATE_FAIL,
            EVENT_ACS_CARD_NO_RIGHT,
            EVENT_ACS_CARD_INVALID_PERIOD,
            EVENT_ACS_CARD_OUT_OF_DATE,
            EVENT_ACS_INVALID_CARD,
            EVENT_ACS_ANTI_SNEAK_FAIL,
            EVENT_ACS_INTERLOCK_DOOR_NOT_CLOSE,
            EVENT_ACS_FINGERPRINT_COMPARE_PASS,
            EVENT_ACS_FINGERPRINT_COMPARE_FAIL,
            EVENT_ACS_CARD_FINGERPRINT_VERIFY_PASS,
            EVENT_ACS_CARD_FINGERPRINT_VERIFY_FAIL,
            EVENT_ACS_CARD_FINGERPRINT_VERIFY_TIMEOUT,
            EVENT_ACS_CARD_FINGERPRINT_PASSWD_VERIFY_PASS,
            EVENT_ACS_CARD_FINGERPRINT_PASSWD_VERIFY_FAIL,
            EVENT_ACS_CARD_FINGERPRINT_PASSWD_VERIFY_TIMEOUT,
            EVENT_ACS_FINGERPRINT_PASSWD_VERIFY_PASS,
            EVENT_ACS_FINGERPRINT_PASSWD_VERIFY_FAIL,
            EVENT_ACS_FINGERPRINT_PASSWD_VERIFY_TIMEOUT,
            EVENT_ACS_FINGERPRINT_INEXISTENCE,
            EVENT_ACS_FACE_VERIFY_PASS,
            EVENT_ACS_FACE_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_FP_VERIFY_PASS,
            EVENT_ACS_FACE_AND_FP_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_FP_VERIFY_TIMEOUT,
            EVENT_ACS_FACE_AND_PW_VERIFY_PASS,
            EVENT_ACS_FACE_AND_PW_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_PW_VERIFY_TIMEOUT,
            EVENT_ACS_FACE_AND_CARD_VERIFY_PASS,
            EVENT_ACS_FACE_AND_CARD_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_CARD_VERIFY_TIMEOUT,
            EVENT_ACS_FACE_AND_PW_AND_FP_VERIFY_PASS,
            EVENT_ACS_FACE_AND_PW_AND_FP_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_PW_AND_FP_VERIFY_TIMEOUT,
            EVENT_ACS_FACE_AND_CARD_AND_FP_VERIFY_PASS,
            EVENT_ACS_FACE_AND_CARD_AND_FP_VERIFY_FAIL,
            EVENT_ACS_FACE_AND_CARD_AND_FP_VERIFY_TIMEOUT,
            EVENT_ACS_EMPLOYEENO_AND_FP_VERIFY_PASS,
            EVENT_ACS_EMPLOYEENO_AND_FP_VERIFY_FAIL,
            EVENT_ACS_EMPLOYEENO_AND_FP_VERIFY_TIMEOUT,
            EVENT_ACS_EMPLOYEENO_AND_FP_AND_PW_VERIFY_PASS,
            EVENT_ACS_EMPLOYEENO_AND_FP_AND_PW_VERIFY_FAIL,
            EVENT_ACS_EMPLOYEENO_AND_FP_AND_PW_VERIFY_TIMEOUT,
            EVENT_ACS_EMPLOYEENO_AND_FACE_VERIFY_PASS,
            EVENT_ACS_EMPLOYEENO_AND_FACE_VERIFY_FAIL,
            EVENT_ACS_EMPLOYEENO_AND_FACE_VERIFY_TIMEOUT,
            EVENT_ACS_FACE_RECOGNIZE_FAIL,
            EVENT_ACS_EMPLOYEENO_AND_PW_PASS,
            EVENT_ACS_EMPLOYEENO_AND_PW_FAIL,
            EVENT_ACS_EMPLOYEENO_AND_PW_TIMEOUT,
            EVENT_ACS_HUMAN_DETECT_FAIL
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_XML_CONFIG_INPUT
        {
            public uint dwSize;                    //size of NET_DVR_XML_CONFIG_INPUT
            public IntPtr lpRequestUrl;                //command string
            public uint dwRequestUrlLen;            //command string length
            public IntPtr lpInBuffer;                //input buffer ，XML format
            public uint dwInBufferSize;            //input buffer length
            public uint dwRecvTimeOut;                //receive timeout，unit：ms，0 represent 5s
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] byRes;  //reserve
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_XML_CONFIG_OUTPUT
        {
            public uint dwSize;                    //size of NET_DVR_XML_CONFIG_OUTPUT
            public IntPtr lpOutBuffer;                //output buffer，XMLformat
            public uint dwOutBufferSize;            //input buffer length
            public uint dwReturnedXMLSize;            //the real receive Xml size
            public IntPtr lpStatusBuffer;            //return status(XML format),no assignment with success, If you don't care about it ,just set it NULL
            public uint dwStatusSize;                //status length(unit byte)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] byRes;  //reserve
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_JSON_DATA_CFG
        {
            public uint dwSize;                    //size of NET_DVR_JSON_DATA_CFG
            public IntPtr lpJsonData;                //Json data
            public uint dwJsonDataSize;            //Json data size
            public IntPtr lpPicData;                //picture data
            public uint dwPicDataSize;            //picture data size
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] byRes;  //reserve
        }

        #endregion

        #region acs event upload

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_LOG_V30
        {
            public NET_DVR_TIME strLogTime;
            public uint dwMajorType;//Main type 1- alarm;  2- abnormal;  3- operation;  0xff- all 
            public uint dwMinorType; //Hypo- Type 0- all; 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPanelUser;//user ID for local panel operation
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNetUser;//user ID for network operation
            public NET_DVR_IPADDR struRemoteHostAddr;//remote host IP
            public uint dwParaType;//parameter type,  for 9000 series MINOR_START_VT/MINOR_STOP_VT,  channel of the voice talking
            public uint dwChannel;//channel number
            public uint dwDiskNumber;//HD number
            public uint dwAlarmInPort;//alarm input port
            public uint dwAlarmOutPort;//alarm output port
            public uint dwInfoLen;
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = LOG_INFO_LEN)]
            public string sInfo;
        }

        //  ACS event informations
        public struct NET_DVR_ACS_EVENT_INFO
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; // card No, 0 means invalid 
            public byte byCardType; // card type,1-ordinary card,2-disable card,3-black list card, 4-patrol card,5-stress card,6-super card,7-client card, 0 means invalid
            public byte byWhiteListNo;  // white list No, 1-8, 0 means invalid
            public byte byReportChannel; // report channel, 1-alarmin updata, 2-center group 1, 3-center group 2, 0 means invalid
            public byte byCardReaderKind; // card reader type: 0-invalid, 1-IC card reader, 2-Id card reader, 3-Qr code reader, 4-Fingerprint head
            public uint dwCardReaderNo;  // card reader No, 0 means invalid
            public uint dwDoorNo;   // door No(floor No), 0 means invalid
            public uint dwVerifyNo;  // mutilcard verify No. 0 means invalid
            public uint dwAlarmInNo;  // alarm in No, 0 means invalid
            public uint dwAlarmOutNo;  // alarm out No 0 means invalid
            public uint dwCaseSensorNo;   // case sensor No 0 means invalid
            public uint dwRs485No;  // RS485 channel,0 means invalid
            public uint dwMultiCardGroupNo;  // multicard group No.
            public ushort wAccessChannel;      // Staff channel number 
            public byte byDeviceNo;  // device No,0 means invalid
            public byte byDistractControlNo;  // distract control,0 means invalid
            public uint dwEmployeeNo;   // employee No,0 means invalid
            public ushort wLocalControllerID; // On the controller number, 0 - access the host, 1-64 on behalf of the local controller 
            public byte byInternetAccess;  // Internet access ID (1-uplink network port 1, 2-uplink network port 2,3- downstream network interface 1
            public byte byType; // protection zone type, 0-real time, 1-24 hours, 2-delay, 3-internal, 4-the key, 5-fire, 6-perimeter, 7-24 hours of silent
            // 8-24 hours auxiliary, 9-24 hours vibration, 10-door emergency open, 11-door emergency shutdown, 0xff-null
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr; // mac addr 0 means invalid
            public byte bySwipeCardType;// swipe card type, 0-invalid,1-Qr code
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 13, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        // Entrance guard alarm information structure
        public struct NET_DVR_ACS_ALARM_INFO
        {
            public uint dwSize;
            public uint dwMajor;  // alarm major, reference to macro
            public uint dwMinor;  // alarm minor, reference to macro
            public NET_DVR_TIME struTime;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_NAMELEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sNetUser;  // net operator user
            public NET_DVR_IPADDR struRemoteHostAddr; // remote host address
            public NET_DVR_ACS_EVENT_INFO struAcsEventInfo;
            public uint dwPicDataLen; // picture length, when 0 ,means has no picture
            public IntPtr pPicData;  // picture data
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        //Alarm Device Infor
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_ALARMER
        {
            public byte byUserIDValid; /* Whether userID is valid,  0- invalid 1- valid. */
            public byte bySerialValid; /* Whether serial number is valid,  0- invalid 1- valid.  */
            public byte byVersionValid; /* Whether version number is valid,  0- invalid 1- valid. */
            public byte byDeviceNameValid; /* Whether device name is valid,  0- invalid 1- valid. */
            public byte byMacAddrValid; /* Whether MAC address is valid,  0- invalid 1- valid. */
            public byte byLinkPortValid; /* Whether login port number is valid,  0- invalid 1- valid. */
            public byte byDeviceIPValid; /* Whether device IP is valid,  0- invalid 1- valid.*/
            public byte bySocketIPValid; /* Whether socket IP is valid,  0- invalid 1- valid. */
            public int lUserID; /* NET_DVR_Login () effective when establishing alarm upload channel*/
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sSerialNumber; /* Serial number. */
            public uint dwDeviceVersion; /* Version number,  2 high byte means the major version,  2 low byte means the minor version*/
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = NAME_LEN)]
            public string sDeviceName; /* Device name. */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMacAddr; /* MAC address */
            public ushort wLinkPort; /* link port */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sDeviceIP; /* IP address */
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 128)]
            public string sSocketIP; /* alarm push- mode socket IP address. */
            public byte byIpProtocol;  /* IP protocol:  0- IPV4;  1- IPV6. */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }


        //Alarm protection structure parameters
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SETUPALARM_PARAM
        {
            public uint dwSize;
            public byte byLevel;  //Arming priority: 0-high, 1-middle, 2-low
            public byte byAlarmInfoType;//Upload alarm information types（Intelligent traffic camera support）：0- old（NET_DVR_PLATE_RESULT），1- new(NET_ITS_PLATE_RESULT)
            public byte byRetAlarmTypeV40; //0- Ret NET_DVR_ALARMINFO_V30 or Older, 1- if Device Support NET_DVR_ALARMINFO_V40,  Ret NET_DVR_ALARMINFO_V40, else Ret NET_DVR_ALARMINFO_V30 Or NET_DVR_ALARMINFO
            public byte byRetDevInfoVersion; //CVR alarm 0-COMM_ALARM_DEVICE, 1-COMM_ALARM_DEVICE_V40
            public byte byRetVQDAlarmType; //Exptected VQD alarm type,0-upload NET_DVR_VQD_DIAGNOSE_INFO,1-upload NET_DVR_VQD_ALARM
            //1-(INTER_FACE_DETECTION),0-(INTER_FACESNAP_RESULT)
            public byte byFaceAlarmDetection;
            //Bit0 - indicates whether the secondary protection to upload pictures: 0 - upload, 1 - do not upload 
            //Bit1 - said open data upload confirmation mechanism; 0 - don't open, 1 - to open
            public byte bySupport;
            //broken Net Http 
            //bit0-Vehicle Detection(IPC) (0 - not continuingly, 1 - continuingly)
            //bit1-PDC(IPC)  (0 - not continuingly, 1 - continuingly)
            //bit2-HeatMap(IPC)  (0 - not continuingly, 1 - continuingly)
            public byte byBrokenNetHttp;
            public ushort wTaskNo;//Tasking number and the (field dwTaskNo corresponding data upload NET_DVR_VEHICLE_RECOG_RESULT the same time issued a task structure NET_DVR_VEHICLE_RECOG_COND corresponding fields in dwTaskNo
            public byte byDeployType;//deploy type:0-client deploy,1-real time deploy
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public byte byAlarmTypeURL;//bit0-(NET_DVR_FACESNAP_RESULT),0-binary,1-URL
            public byte byCustomCtrl;//Bit0- Support the copilot face picture upload: 0-Upload,1-Do not upload
        }

        #endregion

        #region card parameters configuration
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VALID_PERIOD_CFG
        {
            public byte byEnable; //whether to enable , 0-disable 1-enable
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_TIME_EX struBeginTime; //valid begin time
            public NET_DVR_TIME_EX struEndTime; //valid end time 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_CFG_V50
        {
            public uint dwSize;
            public uint dwModifyParamType;
            // the card parameter need to modify, valid when set card parameter, use by bit, every bit means a kind of parameter, 1 means modify, 0 means not 
            // #define CARD_PARAM_CARD_VALID       0x00000001 //card valid parameter 
            // #define CARD_PARAM_VALID            0x00000002  //valid period parameter
            // #define CARD_PARAM_CARD_TYPE        0x00000004  //card type parameter
            // #define CARD_PARAM_DOOR_RIGHT       0x00000008  //door right parameter
            // #define CARD_PARAM_LEADER_CARD      0x00000010  //leader card parameter
            // #define CARD_PARAM_SWIPE_NUM        0x00000020  //max swipe time parameter
            // #define CARD_PARAM_GROUP            0x00000040  //belong group parameter
            // #define CARD_PARAM_PASSWORD         0x00000080  //card password parameter
            // #define CARD_PARAM_RIGHT_PLAN       0x00000100  //card right plan parameter
            // #define CARD_PARAM_SWIPED_NUM       0x00000200  //has swiped card times parameter
            // #define CARD_PARAM_EMPLOYEE_NO      0x00000400  //employee no
            // #define CARD_PARAM_NAME             0x00000800  //name
            // #define CARD_PARAM_DEPARTMENT_NO    0x00001000  //department no
            // #define CARD_SCHEDULE_PLAN_NO       0x00002000  //schedule plan no
            // #define CARD_SCHEDULE_PLAN_TYPE     0x00004000  //schedule plan type
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public byte byCardValid; //whether is a valid card,0-invalid,1-valid(use to delete card, 0 means delete card when setting, it will be 1 when getting)
            public byte byCardType; //card type ,1-ordinary card,2-disabled card,3-black list card, 4-patrol card,5-stress card,6-super card,7-guest card,8-remove card, 9-employee card,10-emergency card,11-emergency management card,default ordinary card 
            public byte byLeaderCard; //whether is leader card, 0-no, 1-yes
            public byte byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byDoorRight; //door right (floor right), accord to bit, 1-has right 0-no right, from low bit to high bit means door 1-N have right
            public NET_DVR_VALID_PERIOD_CFG struValid; //valid period parameter
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_GROUP_NUM_128, ArraySubType = UnmanagedType.I1)]
            public byte[] byBelongGroup; //Subordinate to the group, in public bytes, 1 - belongs to, 0 - does not belong to 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CARD_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardPassword; //card password 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256 * MAX_CARD_RIGHT_PLAN_NUM, ArraySubType = UnmanagedType.I1)]
            public ushort[] wCardRightPlan; //card right plan, value is from plan template No. use or method when same door has different plan template
            public uint dwMaxSwipeTime; //max card time, 0 means infinite time
            public uint dwSwipeTime; //has swiped card
            public ushort wRoomNumber;  //room number
            public short wFloorNumber;   //floor number
            public uint dwEmployeeNo;   //employee no
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byName;   //name
            public ushort wDepartmentNo;   //department no
            public ushort wSchedulePlanNo;   //schedule plan no
            public byte bySchedulePlanType;  //schedule plan type:0-no mean,1-personal,2-department
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public uint dwLockID;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_LOCK_CODE_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byLockCode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_CODE_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byRoomCode;

            //bit，0-no，1-yes
            //bit0：low voltage alarm
            //bit1：open door with prompt tone
            //bit2：limit customer card 
            //bit3：channel
            //bit4：open locked door
            //bit5：patrol function
            public uint dwCardRight;
            public uint dwPlanTemplate;
            public uint dwCardUserId;
            public byte byCardModelType;// 0-NULL,1-MIFARE,2-S50MIFARE,3-S70FM1208,4-CPUFM1216,5-CPUGMB Algorithm CPU,6-ID Card,7-NFC
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 83, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;

            public void Init()
            {
                byDoorRight = new byte[CHCNetSDKCard.MAX_DOOR_NUM_256];
                byBelongGroup = new byte[CHCNetSDKCard.MAX_GROUP_NUM_128];
                wCardRightPlan = new ushort[CHCNetSDKCard.MAX_DOOR_NUM_256 * CHCNetSDKCard.MAX_CARD_RIGHT_PLAN_NUM];
                byCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
                byCardPassword = new byte[CHCNetSDKCard.CARD_PASSWORD_LEN];
                byName = new byte[CHCNetSDKCard.NAME_LEN];
                byRes2 = new byte[3];
                byLockCode = new byte[CHCNetSDKCard.MAX_LOCK_CODE_LEN];
                byRoomCode = new byte[CHCNetSDKCard.MAX_DOOR_CODE_LEN];
                byRes3 = new byte[83];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_CFG_COND
        {
            public uint dwSize;
            public uint dwCardNum; //card number, 0xffffffff means to get all card information when getting
            public byte byCheckCardNo; //whether to verify card No. 0-not to verify, 1-verify
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public ushort wLocalControllerID; //On-site controller serial number, said to the local controller issued offline card parameters, 0 is access control host 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public uint dwLockID;  //lock ID
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_CFG_SEND_DATA
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No 
            public uint dwCardUserId;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_COND
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader; //enable card reader:0-invalid,1-valid
            public uint dwFaceNum; //face number
            public byte byFaceID; //face id:1-2,0xff present this card all face
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 127, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes = new byte[127];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_CFG
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public uint dwFaceLen; //face length
            public IntPtr pFaceBuffer; //face buffer
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader; //enable card reader:0-invalid,1-valid
            public byte byFaceID; //face id:1-2,0xff present this card all face
            public byte byFaceDataType; //face data type:0-module(default),1-picture
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 126, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes = new byte[126];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_STATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderRecvStatus; //card reader receive status:0-fail,1-success,2-face of poor quality,3-memory full,4-face already exist,5-illegal face ID
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg; //error message:when byCardReaderRecvStatus is 4,present face already exist correspond card number
            public uint dwCardReaderNo; //card reader No
            public byte byTotalStatus; //total status:0-not set all card readers face,1-set all card readers face
            public byte byFaceID; //face id:1-2
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 130, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

       [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FACE_COND
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CAPTURE_FACE_CFG
        {
            public uint dwSize;
            public uint dwFaceTemplate1Size;
            public IntPtr pFaceTemplate1Buffer;
            public uint dwFaceTemplate2Size;
            public IntPtr pFaceTemplate2Buffer;
            public uint dwFacePicSize;
            public IntPtr pFacePicBuffer;
            public byte byFaceQuality1;
            public byte byFaceQuality2;
            public byte byCaptureProgress;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 125, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ACS_PARAM_TYPE
        {
            public uint dwSize;
            public uint dwParamType;
            //parameter type,bitwise representation 
            //#define ACS_PARAM_DOOR_STATUS_WEEK_PLAN        0x00000001 //door status week plan
            //#define ACS_PARAM_VERIFY_WEEK_PALN             0x00000002 //card reader week plan
            //#define ACS_PARAM_CARD_RIGHT_WEEK_PLAN         0x00000004 //card right week plan
            //#define ACS_PARAM_DOOR_STATUS_HOLIDAY_PLAN     0x00000008 //door status holiday plan 
            //#define ACS_PARAM_VERIFY_HOLIDAY_PALN          0x00000010 //card reader holiday plan
            //#define ACS_PARAM_CARD_RIGHT_HOLIDAY_PLAN      0x00000020 //card right holiday plan
            //#define ACS_PARAM_DOOR_STATUS_HOLIDAY_GROUP    0x00000040 //door status holiday group plan
            //#define ACS_PARAM_VERIFY_HOLIDAY_GROUP         0x00000080 //card reader verify  holiday group plan
            //#define ACS_PARAM_CARD_RIGHT_HOLIDAY_GROUP     0x00000100 //card right holiday group plan
            //#define ACS_PARAM_DOOR_STATUS_PLAN_TEMPLATE    0x00000200 // door status plan template 
            //#define ACS_PARAM_VERIFY_PALN_TEMPLATE         0x00000400 //card reader verify plan template 
            //#define ACS_PARAM_CARD_RIGHT_PALN_TEMPLATE     0x00000800 //card right plan template 
            //#define ACS_PARAM_CARD                         0x00001000 //card configure
            //#define ACS_PARAM_GROUP                        0x00002000 //group configure
            //#define ACS_PARAM_ANTI_SNEAK_CFG               0x00004000 //anti-sneak configure
            //#define ACS_PAPAM_EVENT_CARD_LINKAGE           0x00008000 //event linkage card
            //#define ACS_PAPAM_CARD_PASSWD_CFG              0x00010000 //open door by password 
            public ushort wLocalControllerID; //On-site controller serial number[1,64],0 represent guard host
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] byRes;
        }

        #endregion

        #region door parameters configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_DOOR_CFG
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = DOOR_NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byDoorName;//door name
            public byte byMagneticType;//magnetic type, 0-always close 1-always open
            public byte byOpenButtonType;//open button type,  0-always close 1-always open
            public byte byOpenDuration;//open duration time, 1-255s(ladder control relay action time)
            public byte byDisabledOpenDuration;//disable open duration , 1-255s  
            public byte byMagneticAlarmTimeout;//magnetic alarm time out , 0-255s,0 means not to alarm
            public byte byEnableDoorLock;//whether to enable door lock, 0-disable, 1-enable
            public byte byEnableLeaderCard;//whether to enable leader card , 0-disable, 1-enable
            public byte byLeaderCardMode;//First card mode, 0 - first card function is not enabled, and 1 - the first card normally open mode, 2 - the first card authorization mode (using this field, the byEnableLeaderCard is invalid ) 
            public uint dwLeaderCardOpenDuration;//leader card open duration 1-1440min
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = STRESS_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byStressPassword;//stress ppassword
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SUPER_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] bySuperPassword; //super password
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = UNLOCK_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byUnlockPassword;
            public byte byUseLocalController; //Read-only, whether the connection on the local controller, 0 - no, 1 - yes
            public byte byRes1;
            public ushort wLocalControllerID; //Read-only, on-site controller serial number, 1-64, 0 on behalf of unregistered 
            public ushort wLocalControllerDoorNumber; //Read-only, on-site controller door number, 1-4, 0 represents the unregistered 
            public ushort wLocalControllerStatus; //Read-only, on-site controller online status: 0 - offline, 1 - online, 2 - loop of RS485 serial port 1 on 1, 3 - loop of RS485 serial port 2 on 2, 4 - loop of RS485 serial port 1, 5 - loop of RS485 serial port 2, 6 - loop 3 of RS485 serial port 1, 7 - the loop on the RS485 serial port on the 3 4 2, 8 - loop on the RS485 serial port 1, 9 - loop 4 of RS485 serial port 2 (read-only) 
            public byte byLockInputCheck; //Whether to enable the door input detection (1 public byte, 0 is not enabled, 1 is enabled, is not enabled by default) 
            public byte byLockInputType; //Door lock input type 
            public byte byDoorTerminalMode; //Gate terminal working mode 
            public byte byOpenButton; //Whether to enable the open button 
            public byte byLadderControlDelayTime; //ladder control delay time,1-255min
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 43, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                byDoorName = new byte[DOOR_NAME_LEN];
                byStressPassword = new byte[STRESS_PASSWORD_LEN];
                bySuperPassword = new byte[SUPER_PASSWORD_LEN];
                byUnlockPassword = new byte[UNLOCK_PASSWORD_LEN];
                byRes2 = new byte[43];
            }
        }
        #endregion

        #region group parameters configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_GROUP_CFG
        {
            public uint dwSize;
            public byte byEnable;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_VALID_PERIOD_CFG struValidPeriodCfg;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = GROUP_NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byGroupName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

        }

        #endregion

        #region user parameters configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ALARM_DEVICE_USER
        {
            public uint dwSize; //Structure size
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;
            public NET_DVR_IPADDR struUserIP;//User IP (0 stands for no IP restriction)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byAMCAddr;
            public byte byUserType;    //0- general user, 1- administrator user
            public byte byAlarmOnRight;//Arming authority
            public byte byAlarmOffRight; //Disarming authority
            public byte byBypassRight; //Bypass authority
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_RIGHT, ArraySubType = UnmanagedType.I1)]
            public byte[] byOtherRight;//Other authority 
            // 0 -- log
            // 1 -- reboot/shutdown
            // 2 -- set parameter
            // 3 -- get parameter
            // 4 -- resume
            // 5 -- siren 
            // 6 -- PTZ
            // 7 -- remote upgrade
            // 8 -- preview
            // 9 -- manual record
            // 10 --remote playback
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPreviewRight;// preview channels,eg. bit0-channel 1,0-no permission 1-permission enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetRecordRight; // record channels,eg. bit0-channel 1,0-no permission 1-permission enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPlaybackRight; // playback channels,eg. bit0-channel 1,0-no permission 1-permission enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_VIDEO_CHAN / 8, ArraySubType = UnmanagedType.I1)]
            public byte[] byNetPTZRight; // PTZ channels,eg. bit0-channel 1,0-no permission 1-permission enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sOriginalPassword;        // Original password
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 152, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
        }

        #endregion

        #region cardreader configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_READER_CFG_V50
        {
            public uint dwSize;
            public byte byEnable; //whether to enable, 1-enable, 0-disable
            public byte byCardReaderType; //card reader type,1-DS-K110XM/MK/C/CK,2-DS-K192AM/AMP,3-DS-K192BM/BMP,4-DS-K182AM/AMP,5-DS-K182BM/BMP,6-DS-K182AMF/ACF,7-wiegand or 485 not online,8- DS-K1101M/MK,9- DS-K1101C/CK,10- DS-K1102M/MK/M-A
            //11- DS-K1102C/CK,12- DS-K1103M/MK,13- DS-K1103C/CK,14- DS-K1104M/MK,15- DS-K1104C/CK,16- DS-K1102S/SK/S-A,17- DS-K1102G/GK,18- DS-K1100S-B,19- DS-K1102EM/EMK,20- DS-K1102E/EK,
            //21- DS-K1200EF,22- DS-K1200MF,23- DS-K1200CF,24- DS-K1300EF,25- DS-K1300MF,26- DS-K1300CF,27- DS-K1105E,28- DS-K1105M,29- DS-K1105C,30- DS-K182AMF,31- DS-K196AMF,32-DS-K194AMP
            //33-DS-K1T200EF/EF-C/MF/MF-C/CF/CF-C,34-DS-K1T300EF/EF-C/MF/MF-C/CF/CF-C,35-DS-K1T105E/E-C/M/M-C/C/C-C,36-DS-K1T803F/MF/SF/EF,37-DS-K1A801F/MF/SF/EF,38-DS-K1107M/MK,39-DS-K1107E/EK,
            //40-DS-K1107S/SK,41-DS-K1108M/MK,42-DS-K1108E/EK,43-DS-K1108S/SK,44-DS-K1200F,45-DS-K1S110-I,46-DS-K1T200M-PG/PGC,47-DS-K1T200M-PZ/PZC,48-DS-K1109H
            public byte byOkLedPolarity; //OK LED polarity,0-negative,1-positive
            public byte byErrorLedPolarity; //Error LED polarity,0-negative,1-positive
            public byte byBuzzerPolarity; //buzzer polarity,0-negative,1-positive
            public byte bySwipeInterval; //swipe interval, unit: second
            public byte byPressTimeout;  //press time out, unit:second
            public byte byEnableFailAlarm; //whether to enable fail alarm, 0-disable 1-enable
            public byte byMaxReadCardFailNum; //max reader card fail time
            public byte byEnableTamperCheck;  //whether to support tamper check, 0-disable ,1-enable
            public byte byOfflineCheckTime;  //offline check time, Uint second
            public byte byFingerPrintCheckLevel; //fingerprint check lever,1-1/10,2-1/100,3-1/1000,4-1/10000,5-1/100000,6-1/1000000,7-1/10000000,8-1/100000000,9-3/100,10-3/1000,11-3/10000,12-3/100000,13-3/1000000,14-3/10000000,15-3/100000000,16-Automatic Normal,17-Automatic Secure,18-Automatic More Secure
            public byte byUseLocalController; //read only,weather connect with local control:0-no,1-yes
            public byte byRes1;
            public ushort wLocalControllerID; //read only,local controller ID, byUseLocalController=1 effective,1-64,0 present not register
            public ushort wLocalControllerReaderID; //read only,local controller reader ID,byUseLocalController=1 effective,0 present not register
            public ushort wCardReaderChannel; //read only,card reader channel,byUseLocalController=1 effective,0-wiegand or offline,1-RS485A,2-RS485B
            public byte byFingerPrintImageQuality; //finger print image quality,0-no effective,1-weak qualification(V1),2-moderate qualification(V1),3-strong qualification(V1),4-strongest qualification(V1),5-weak qualification(V2),6-moderate qualification(V2),7-strong qualification(V2),8-strongest qualification(V2)
            public byte byFingerPrintContrastTimeOut; //finger print contrast time out,0-no effective,1-20 present:1s-20s,0xff-infinite
            public byte byFingerPrintRecogizeInterval; //finger print recognize interval,0-no effective,1-10 present:1s-10s,0xff-no delay
            public byte byFingerPrintMatchFastMode; //finger print match fast mode,0-no effective,1-5 present:fast mode 1-fast mode 5,0xff-auto
            public byte byFingerPrintModuleSensitive; //finger print module sensitive,0-no effective,1-8 present:sensitive level 1-sensitive level 8
            public byte byFingerPrintModuleLightCondition; //finger print module light condition,0-no effective,1-out door,2-in door
            public byte byFaceMatchThresholdN; //range 0-100
            public byte byFaceQuality; //face quality,range 0-100
            public byte byFaceRecogizeTimeOut; //face recognize time out,1-20 present:1s-20s,0xff-infinite
            public byte byFaceRecogizeInterval; //face recognize interval,0-no effective,1-10 present:1s-10s,0xff-no delay
            public ushort wCardReaderFunction; //read only,card reader function
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CARD_READER_DESCRIPTION, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderDescription; //read only,card reader description
            public ushort wFaceImageSensitometry; //face image sensitometry,range 0-65535
            public byte byLivingBodyDetect; //living body detect,0-no effective,1-disable,2-enable
            public byte byFaceMatchThreshold1; //range 0-100
            public ushort wBuzzerTime; //buzzer time,range 0-5999(s) 0 present yowl
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 254, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardReaderDescription = new byte[CARD_READER_DESCRIPTION];
                byRes = new byte[254];
            }
        }

        #endregion

        #region fingerprint configuration
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_CFG
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card NO
            public uint dwFingerPrintLen;     //fingerprint len
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //the card reader which finger print send to,according to the values,0-not send,1-send
            public byte byFingerPrintID;     //finger print ID,[1,10]
            public byte byFingerType;       //finger type  0-normal,1-stress
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_FINGER_PRINT_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byFingerData;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes1 = new byte[30];
                byFingerData = new byte[MAX_FINGER_PRINT_LEN];
                byRes = new byte[64];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_STATUS
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderRecvStatus;  //Fingerprint reader state, press the public bytes, 0 - failure, 1 -, 2 - the fingerprint module is not online, 3 - try again or poor quality of fingerprint, 4 - memory is full, 5 - existing the fingerprints, 6 - existing the fingerprint ID, illegal fingerprint ID, 7-8 - don't need to configure the fingerprint module 
            public byte byFingerPrintID;     //finger print ID,[1,10]
            public byte byFingerType;        //finger type  0-normal,1-stress
            public byte byTotalStatus;  //
            public byte byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg; //Issued false information, when the byCardReaderRecvStatus is 5, said existing fingerprint matching card number 
            public uint dwCardReaderNo;  //Grain number card reader, can be used to return issued by mistake
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byCardReaderRecvStatus = new byte[MAX_CARD_READER_NUM_512];
                byErrorMsg = new byte[ERROR_MSG_LEN];
                byRes = new byte[24];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_COND
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //which card reader to send,according to the values
            public uint dwFingerPrintNum; //the number send or get. if get,0xffffffff means all
            public byte byFingerPrintID;     //finger print ID,[1,10],   0xff means all
            public byte byCallbackMode;     //
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 26, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes1 = new byte[26];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_CFG_V50
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card NO
            public uint dwFingerPrintLen;     //fingerprint len
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //the card reader which finger print send to,according to the values,0-not send,1-send
            public byte byFingerPrintID;     //finger print ID,[1,10]
            public byte byFingerType;       //finger type  0-normal,1-stress
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_FINGER_PRINT_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byFingerData;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byLeaderFP;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes1 = new byte[30];
                byFingerData = new byte[MAX_FINGER_PRINT_LEN];
                byEmployeeNo = new byte[NET_SDK_EMPLOYEE_NO_LEN];
                byLeaderFP = new byte[MAX_DOOR_NUM_256];
                byRes = new byte[128];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_STATUS_V50
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderRecvStatus;  //Fingerprint reader state, press the public bytes, 0 - failure, 1 -, 2 - the fingerprint module is not online, 3 - try again or poor quality of fingerprint, 4 - memory is full, 5 - existing the fingerprints, 6 - existing the fingerprint ID, illegal fingerprint ID, 7-8 - don't need to configure the fingerprint module 
            public byte byFingerPrintID;     //finger print ID,[1,10]
            public byte byFingerType;        //finger type  0-normal,1-stress
            public byte byTotalStatus;  //
            public byte byRecvStatus;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg; //Issued false information, when the byCardReaderRecvStatus is 5, said existing fingerprint matching card number 
            public uint dwCardReaderNo;  //Grain number card reader, can be used to return issued by mistake
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byCardReaderRecvStatus = new byte[MAX_CARD_READER_NUM_512];
                byErrorMsg = new byte[ERROR_MSG_LEN];
                byEmployeeNo = new byte[NET_SDK_EMPLOYEE_NO_LEN];
                byErrorEmployeeNo = new byte[NET_SDK_EMPLOYEE_NO_LEN];
                byRes = new byte[128];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_COND_V50
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //which card reader to send,according to the values
            public uint dwFingerPrintNum; //the number send or get. if get,0xffffffff means all
            public byte byFingerPrintID;     //finger print ID,[1,10],   0xff means all
            public byte byCallbackMode;     //
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[MAX_CARD_READER_NUM_512];
                byRes2 = new byte[2];
                byEmployeeNo = new byte[NET_SDK_EMPLOYEE_NO_LEN];
                byRes1 = new byte[128];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYCARD
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //be enable card reader,according to the values
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_FINGER_PRINT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byFingerPrintID;        //finger print ID,according to the values,0-not delete,1-delete
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 34, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYREADER
        {
            public uint dwCardReaderNo;
            public byte byClearAllCard;  //clear all card,0-delete by card,1-delete all card
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 548, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_BYCARD
        {
            public uint dwSize;
            public byte byMode;          //delete mode,0-delete by card,1-delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;

            public NET_DVR_FINGER_PRINT_BYCARD struByCard;   //delete by card
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;

        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_BYREADER
        {
            public uint dwSize;
            public byte byMode;          //delete mode,0-delete by card,1-delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;

            public NET_DVR_FINGER_PRINT_BYREADER struByReader;  //delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;

        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYCARD_V50
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;  //be enable card reader,according to the values
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_FINGER_PRINT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byFingerPrintID;        //finger print ID,according to the values,0-not delete,1-delete
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_BYREADER_V50
        {
            public uint dwCardReaderNo;
            public byte byClearAllCard;  //clear all card,0-delete by card,1-delete all card
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 516, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_BYCARD_V50
        {
            public uint dwSize;
            public byte byMode;          //delete mode,0-delete by card,1-delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;
            public NET_DVR_FINGER_PRINT_BYCARD_V50 struByCard;   //delete by card
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_CTRL_BYREADER_V50
        {
            public uint dwSize;
            public byte byMode;          //delete mode,0-delete by card,1-delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes1;
            public NET_DVR_FINGER_PRINT_BYREADER_V50 struByReader;  //delete by reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGER_PRINT_INFO_STATUS_V50
        {
            public uint dwSize;
            public uint dwCardReaderNo; //card reader no
            public byte byStatus;   //status:0-invalid,1-processing,2-failed,3-success
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 63)]
            public byte[] byRes;
        }

        //[StructLayoutAttribute(LayoutKind.Sequential)]
        //public const int DEL_FINGER_PRINT_MODE_LEN = 588; //联合体大小
        //public union NET_DVR_DEL_FINGER_PRINT_MODE
        //{
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 588, ArraySubType = UnmanagedType.I1)]
        //    public byte[] uLen;
        //    public NET_DVR_FINGER_PRINT_BYCARD struByCard;     //delete by card
        //    public NET_DVR_FINGER_PRINT_BYREADER struByReader;   //delete by reader
        //}

        //[StructLayoutAttribute(LayoutKind.Sequential)]
        //public struct NET_DVR_FINGER_PRINT_INFO_CTRL
        //{
        //    public uint dwSize;
        //    public byte byMode;          //delete mode,0-delete by card,1-delete by reader
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
        //    public byte[] byRes1;
        //    public NET_DVR_DEL_FINGER_PRINT_MODE struProcessMode;  //delete mode
        //    [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
        //    public byte[] byRes;
        //}

        #endregion

        #region Acs_Face_Param
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FAILED_FACE_INFO
        {
            public int dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            public byte byErrorCode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 127)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_CTRL_ByCard
        {
            public int dwSize;
            public byte byMode;//0 del by card,1 del by card reader
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_FACE_PARAM_BYCARD struProcessMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes1 = new byte[3];
                byRes = new byte[64];
                struProcessMode = new NET_DVR_FACE_PARAM_BYCARD();
                struProcessMode.Init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_CTRL_ByReader
        {
            public int dwSize;
            public byte byMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_FACE_PARAM_BYREADER struProcessMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes1 = new byte[3];
                byRes = new byte[64];
                struProcessMode = new NET_DVR_FACE_PARAM_BYREADER();
                struProcessMode.Init();
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_BYCARD
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byEnableCardReader;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.MAX_FACE_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byFaceID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 42, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;

            public void Init()
            {
                byCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
                byEnableCardReader = new byte[CHCNetSDKCard.MAX_CARD_READER_NUM_512];
                byFaceID = new byte[CHCNetSDKCard.MAX_FACE_NUM];
                byRes1 = new byte[42];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_PARAM_BYREADER
        {
            public int dwCardReaderNo;
            public byte byClearAllCard;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 548, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes1 = new byte[3];
                byCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
                byRes = new byte[548];
            }
        }
        #endregion

        #region plan configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_TIME_SEGMENT
        {
            public NET_DVR_SIMPLE_DAYTIME struBeginTime;  //begin time
            public NET_DVR_SIMPLE_DAYTIME struEndTime;    //end time
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_SINGLE_PLAN_SEGMENT
        {
            public byte byEnable; //whether to enable, 1-enable, 0-disable
            public byte byDoorStatus; //door status(control ladder status),0-invaild, 1-always open(free), 2-always close(forbidden), 3-ordinary status(used by door plan)
            public byte byVerifyMode;  //verify method, 0-invaild, 1-swipe card, 2-swipe card +password(used by card verify ) 3-swipe card(used by card verify) 4-swipe card or password(used by card verify)
            //5-fingerprint, 6-fingerprint and passwd, 7-fingerprint or swipe card, 8-fingerprint and swipe card, 9-fingerprint and passwd and swipe card,
            //10-face or finger print or swipe card or password,11-face and finger print,12-face and password,13-face and swipe card,14-face,15-employee no and password,
            //16-finger print or password,17-employee no and finger print,18-employee no and finger print and password,
            //19-face and finger print and swipe card,20-face and password and finger print,21-employee no and face,22-face or face and swipe card
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_TIME_SEGMENT struTimeSegment;  //time segment parameter 

            public void Init()
            {
                byRes = new byte[5];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_WEEK_PLAN_CFG
        {
            public uint dwSize;
            public byte byEnable;  //whether to enable, 1-enable, 0-disable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DAYS * MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SINGLE_PLAN_SEGMENT[] struPlanCfg; //week plan parameter
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                struPlanCfg = new NET_DVR_SINGLE_PLAN_SEGMENT[MAX_DAYS * MAX_TIMESEGMENT_V30];
                foreach (NET_DVR_SINGLE_PLAN_SEGMENT singlStruPlanCfg in struPlanCfg)
                {
                    singlStruPlanCfg.Init();
                }
                byRes1 = new byte[3];
                byRes2 = new byte[16];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HOLIDAY_PLAN_CFG
        {
            public uint dwSize;
            public byte byEnable;  //whether to enable, 1-enable, 0-disable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_DATE struBeginDate;  //holiday begin date
            public NET_DVR_DATE struEndDate;  //holiday end date
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_TIMESEGMENT_V30, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_SINGLE_PLAN_SEGMENT[] struPlanCfg;  //time segment parameter 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] byRes2;

            public void Init()
            {
                struPlanCfg = new NET_DVR_SINGLE_PLAN_SEGMENT[MAX_TIMESEGMENT_V30];
                foreach (NET_DVR_SINGLE_PLAN_SEGMENT singlStruPlanCfg in struPlanCfg)
                {
                    singlStruPlanCfg.Init();
                }
                byRes1 = new byte[3];
                byRes2 = new byte[16];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HOLIDAY_GROUP_CFG
        {
            public uint dwSize;
            public byte byEnable; //whether to enable, 1-enable, 0-disable 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = HOLIDAY_GROUP_NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byGroupName; //holiday group name 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOLIDAY_PLAN_NUM, ArraySubType = UnmanagedType.U4)]
            public uint[] dwHolidayPlanNo; //holiday plan No. fill in from the front side, invalid when meet zero.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                byGroupName = new byte[HOLIDAY_GROUP_NAME_LEN];
                dwHolidayPlanNo = new uint[MAX_HOLIDAY_PLAN_NUM];
                byRes1 = new byte[3];
                byRes2 = new byte[32];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PLAN_TEMPLATE
        {
            public uint dwSize;
            public byte byEnable; //whether to enable, 1-enable, 0-disable 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = TEMPLATE_NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byTemplateName; //template name 
            public uint dwWeekPlanNo; //week plan no. 0 invalid
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_HOLIDAY_GROUP_NUM, ArraySubType = UnmanagedType.U4)]
            public uint[] dwHolidayGroupNo; //holiday group. fill in from the front side, invalid when meet zero.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                byTemplateName = new byte[TEMPLATE_NAME_LEN];
                dwHolidayGroupNo = new uint[MAX_HOLIDAY_GROUP_NUM];
                byRes1 = new byte[3];
                byRes2 = new byte[32];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HOLIDAY_PLAN_COND
        {
            public uint dwSize;
            public uint dwHolidayPlanNumber; //Holiday plan number 
            public ushort wLocalControllerID; //On the controller serial number [1, 64]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void Init()
            {
                byRes = new byte[106];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_WEEK_PLAN_COND
        {
            public uint dwSize;
            public uint dwWeekPlanNumber; //Week plan number 
            public ushort wLocalControllerID; //On the controller serial number [1, 64]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[106];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_HOLIDAY_GROUP_COND
        {
            public uint dwSize;
            public uint dwHolidayGroupNumber; //Holiday group number 
            public ushort wLocalControllerID; //On the controller serial number [1, 64]
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[106];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PLAN_TEMPLATE_COND
        {
            public uint dwSize;
            public uint dwPlanTemplateNumber; //Plan template number, starting from 1, the maximum value from the entrance guard capability sets 
            public ushort wLocalControllerID; //On the controller serial number[1,64], 0 is invalid 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[106];
            }
        }

        #endregion

        #region card reader verification mode and door status planning parameters configuration

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DOOR_STATUS_PLAN
        {
            public uint dwSize;
            public uint dwTemplateNo;  // plan template No. 0 means cancel relation,resolve default status(ordinary status)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[64];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_READER_PLAN
        {
            public uint dwSize;
            public uint dwTemplateNo; // plan template No. 0 means cancel relation,resolve default status(swipe card)
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[64];
            }
        }

        #endregion

        #region card number associated with the user information parameter configuration

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_USER_INFO_CFG
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN)]
            public byte[] byUsername;// user name
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
            public byte[] byRes2; // byRes2[0]--user number for alarm host
        }

        #endregion

        #region user login managed
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
        public struct NET_DVR_DEVICEINFO_V40
        {
            public NET_DVR_DEVICEINFO_V30 struDeviceV30;
            public byte bySupportLock;        //the device support lock function,this byte assigned by SDK.when bySupportLock is 1,dwSurplusLockTime and byRetryLoginTime is valid 
            public byte byRetryLoginTime;        //retry login times
            public byte byPasswordLevel;      //PasswordLevel,0-invalid,1-default password,2-valid password,3-risk password       
            public byte byProxyType;  //Proxy Type,0-not use proxy, 1-use socks5 proxy, 2-use EHome proxy
            public uint dwSurplusLockTime;    //surplus locked time
            public byte byCharEncodeType;     //character encode type
            public byte byRes1;
            public byte bySupport;  //能力集扩展，位与结果：0- 不支持，1- 支持
            // bySupport & 0x1:  0-保留
            // bySupport & 0x2:  0-不支持变化上报 1-支持变化上报
            public byte byRes;
            public uint dwOEMCode;
            public byte bySupportDev5;//Support v50 version of the device parameters, device name and device type name length is extended to 64 bytes 
            public byte byLoginMode; //登录模式 0-Private登录 1-ISAPI登录
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 246)]
            public byte[] byRes2;
        }

        //DVR device parameters
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DEVICECFG_V40
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN)]
            public byte[] sDVRName;//DVR name
            public uint dwDVRID;    //DVR ID //V1.4 (0- 99) ,  V1.5 (0- 255) 
            public uint dwRecycleRecord;  //cycle record, 0-disable, 1-enable
            //the following to the end is Read-only
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN)]
            public byte[] sSerialNumber;//SN
            public uint dwSoftwareVersion;  	//Software version,Major version:16 MSB,minor version:16 LSB
            public uint dwSoftwareBuildDate;  	//Build, 0xYYYYMMDD
            public uint dwDSPSoftwareVersion;      //DSP Version: 16 high bit is the major version, and 16 low bit is the minor version
            public uint dwDSPSoftwareBuildDate;  // DSP Build, 0xYYYYMMDD
            public uint dwPanelVersion;        // Front panel version,Major version:16 MSB,minor version:16 LSB
            public uint dwHardwareVersion;	// Hardware version,Major version:16 MSB,minor version:16 LSB
            public byte byAlarmInPortNum;  //DVR Alarm input
            public byte byAlarmOutPortNum;  //DVR Alarm output
            public byte byRS232Num;  	//DVR 232 port number
            public byte byRS485Num;  	//DVR 485 port number 
            public byte byNetworkPortNum;  //Network port number
            public byte byDiskCtrlNum;  	//DVR HDD number
            public byte byDiskNum;    //DVR disk number
            public byte byDVRType;    //DVRtype, 1:DVR 2:ATM DVR 3:DVS ......
            public byte byChanNum;    //DVR channel number
            public byte byStartChan;  	//start,e.g.1: DVR 2: ATM DVR 3: DVS ......- - 
            public byte byDecordChans;  	//DVR decoding channels
            public byte byVGANum;    //VGA interface number 
            public byte byUSBNum;    //USB interface number 
            public byte byAuxoutNum;  	//Aux output number
            public byte byAudioNum;  	//voice interface number
            public byte byIPChanNum;  	//Max. IP channel number  8 LSB ，8 MSB with byHighIPChanNum 
            public byte byZeroChanNum;  	//Zero channel number
            public byte bySupport;        //Ability set，0 represent not support ，1 represent support,
            //bySupport & 0x1, smart search
            //bySupport & 0x2, backup
            //bySupport & 0x4, compression ability set
            //bySupport & 0x8, multiple network adapter
            //bySupport & 0x10, remote SADP
            //bySupport & 0x20, support Raid
            //bySupport & 0x40, support IPSAN
            //bySupport & 0x80, support RTP over RTSP
            public byte byEsataUseage;  //Default E-SATA: 0- backup, 1- record
            public byte byIPCPlug;  	//0- disable plug-and-play, 1- enable plug-and-play
            public byte byStorageMode;  //Hard Disk Mode:0-group,1-quota,2-draw frame,3-Auto
            public byte bySupport1;  //Ability set，0 represent not support ，1 represent support,
            //bySupport1 & 0x1, support snmp v30
            //bySupport1 & 0x2, support distinguish download and playback
            //bySupport1 & 0x4, support deployment level	
            //bySupport1 & 0x8, support vca alarm time extension 
            //bySupport1 & 0x10, support muti disks(more than 33)
            //bySupport1 & 0x20, support rtsp over http	
            public ushort wDevType;//Device type
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = DEV_TYPE_NAME_LEN)]
            public byte[] byDevTypeName;//Device model name
            public byte bySupport2;  //The ability to set extension, bit 0 indicates does not support one expressed support for
            //bySupport2 & 0x1, Whether to support extended the OSD character overlay (terminal and capture machine expansion distinguish)
            public byte byAnalogAlarmInPortNum; //Analog alarm in number
            public byte byStartAlarmInNo;    //Analog alarm in Start No.
            public byte byStartAlarmOutNo;  //Analog alarm Out Start No.
            public byte byStartIPAlarmInNo;   //IP alarm in Start No.  0-Invalid
            public byte byStartIPAlarmOutNo; //IP Alarm Out Start No.  0-Invalid
            public byte byHighIPChanNum;     //Ip Chan Num High 8 Bit 
            public byte byEnableRemotePowerOn;//enable the equipment in a dormant state remote boot function, 0- is not enabled, the 1- enabled
            public ushort wDevClass; //device class 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public byte[] byRes2;
        }

        /* Asynchronous login callback function
         * [out] lUserID - NET_DVR_Login_V40 return value
         * [out] dwResult - asynchronous login status, 0:failed,1:success
         * [out] NET_DVR_DEVICEINFO_V30 - device informations
         * [out] pUser - user input data
         */
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
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 120, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_PREVIEWINFO
        {
            public int lChannel;    //Channel no.
            public uint dwStreamType;   //Stream type 0-main stream,1-sub stream,2-third stream,3-forth stream, and so on
            public uint dwLinkMode; //Protocol type: 0-TCP, 1-UDP, 2-Muticast, 3-RTP,4-RTP/RTSP, 5-RSTP/HTTP
            public IntPtr hPlayWnd; //Play window's handle;  set NULL to disable preview
            public uint bBlocked;   //If data stream requesting process is blocked or not: 0-no, 1-yes
            //if true, the SDK Connect failure return until 5s timeout  , not suitable for polling to preview.
            public uint bPassbackRecord;    //0- not enable  ,1 enable
            public byte byPreviewMode;  //Preview mode 0-normal preview,2-delay preview
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = STREAM_ID_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byStreamID;   //Stream ID
            public byte byProtoType;    //0-private,1-RTSP
            public byte byRes1;
            public byte byVideoCodingType;
            public uint dwDisplayBufNum;    //soft player display buffer size(number of frames), range:1-50, default:1
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 216, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        #endregion

        #region network configuration
        /*IP address*/
        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_IPADDR
        {

            /// char[16]
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string sIpV4;

            /// BYTE[128]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byIPv6;

            public void Init()
            {
                byIPv6 = new byte[128];
            }
        }

        /* Network structure(sub struct)(9000 extension)*/
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ETHERNET_V30
        {
            public NET_DVR_IPADDR struDVRIP;//DVR IP address
            public NET_DVR_IPADDR struDVRIPMask;//DVR IP address mask
            public uint dwNetInterface;//net card: 1-10MBase-T 2-10MBase-T Full duplex 3-100MBase-TX 4-100M Full duplex 5-10M/100M adaptive
            public ushort wDVRPort;//port
            public ushort wMTU;//MTU default:1500。
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byMACAddr;// mac address
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;// reserve
        }

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_PPPOECFG
        {
            public uint dwPPPOE;//0-disable,1-enable
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPPPoEUser;//PPPoE user name
            [MarshalAsAttribute(UnmanagedType.ByValTStr, SizeConst = PASSWD_LEN)]
            public string sPPPoEPassword;// PPPoE password
            public NET_DVR_IPADDR struPPPoEIP;//PPPoE IP address
        }

        //network configuration struct(9000 extension)
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_NETCFG_V30
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_ETHERNET_V30[] struEtherNet;//Ethernet 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPADDR[] struRes1;//reserve
            public NET_DVR_IPADDR struAlarmHostIpAddr;// alarm host IP address
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U2)]
            public ushort[] wRes2;
            public ushort wAlarmHostIpPort;
            public byte byUseDhcp;
            public byte byIPv6Mode;//IPv6 distribute methods，0-Routing announcement，1-manually，2-Enable the DHCP allocation
            public NET_DVR_IPADDR struDnsServer1IpAddr; // primary dns server
            public NET_DVR_IPADDR struDnsServer2IpAddr; // secondary dns server
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byIpResolver;
            public ushort wIpResolverPort;
            public ushort wHttpPortNo;
            public NET_DVR_IPADDR struMulticastIpAddr; // Multicast group address
            public NET_DVR_IPADDR struGatewayIpAddr; // The gateway address
            public NET_DVR_PPPOECFG struPPPoE;
            public byte byEnablePrivateMulticastDiscovery;  //Private multicast search，0~default，1~enable ，2-disable
            public byte byEnableOnvifMulticastDiscovery;  //Onvif multicast search，0~default，1~enable，2-disable
            public byte byEnableDNS; //DNS Atuo enable, 0-Res,1-open, 2-close
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 61, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                struEtherNet = new NET_DVR_ETHERNET_V30[MAX_ETHERNET];
                struAlarmHostIpAddr = new NET_DVR_IPADDR();
                struDnsServer1IpAddr = new NET_DVR_IPADDR();
                struDnsServer2IpAddr = new NET_DVR_IPADDR();
                byIpResolver = new byte[MAX_DOMAIN_NAME];
                struMulticastIpAddr = new NET_DVR_IPADDR();
                struGatewayIpAddr = new NET_DVR_IPADDR();
                struPPPoE = new NET_DVR_PPPOECFG();
            }
        }


        //Network Configure Structure(V50)
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_NETCFG_V50
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ETHERNET, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_ETHERNET_V30[] struEtherNet;        //Network Port
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPADDR[] struRes1;                            /*reserve*/
            public NET_DVR_IPADDR struAlarmHostIpAddr;                    /* IP address of remote management host */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;                                        /* reserve */
            public ushort wAlarmHostIpPort;                                /* Port of remote management Host */
            public byte byUseDhcp;                                      /* Whether to enable the DHCP 0xff- invalid 0- enabled 1- not enabled */
            public byte byIPv6Mode;                                        //IPv6 allocation, 0- routing announcement, 1- manually, 2- enable DHCP allocation 
            public NET_DVR_IPADDR struDnsServer1IpAddr;                    /* IP address of the domain name server 1  */
            public NET_DVR_IPADDR struDnsServer2IpAddr;                    /* IP address of the domain name server 2  */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byIpResolver;                    /* IP parse server domain name or IP address */
            public ushort wIpResolverPort;                                /* Parsing IP server port number */
            public ushort wHttpPortNo;                                    /* HTTP port number  */
            public NET_DVR_IPADDR struMulticastIpAddr;                    /* Multicast group address */
            public NET_DVR_IPADDR struGatewayIpAddr;                        /* Gateway address  */
            public NET_DVR_PPPOECFG struPPPoE;
            public byte byEnablePrivateMulticastDiscovery;                //Private multicast search, 0- default, 1- enabled, 2 - disabled 
            public byte byEnableOnvifMulticastDiscovery;                //Onvif multicast search, 0- default, 1- enabled, 2 - disabled 
            public ushort wAlarmHost2IpPort;                                /* Alarm host 2 port */
            public NET_DVR_IPADDR struAlarmHost2IpAddr;                    /* Alarm host 2 IP addresses */
            public byte byEnableDNS; //DNS Enabled, 0-close,1-open 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 599, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void Init()
            {
                struEtherNet = new NET_DVR_ETHERNET_V30[MAX_ETHERNET];
                struRes1 = new NET_DVR_IPADDR[2];
                struAlarmHostIpAddr = new NET_DVR_IPADDR();
                struAlarmHost2IpAddr = new NET_DVR_IPADDR();
                struDnsServer1IpAddr = new NET_DVR_IPADDR();
                struDnsServer2IpAddr = new NET_DVR_IPADDR();
                byIpResolver = new byte[MAX_DOMAIN_NAME];
                struMulticastIpAddr = new NET_DVR_IPADDR();
                struGatewayIpAddr = new NET_DVR_IPADDR();
                struPPPoE = new NET_DVR_PPPOECFG();
                byRes = new byte[599];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPDEVINFO_V31
        {
            public byte byEnable;//Valid status for IP device
            public byte byProType;                 //Protocol type,  0- private (default) ,  1-  Panasonic,  2-  SONY
            public byte byEnableQuickAdd;          //0-  does not support quick adding of IP device;  1-   enable quick adding of IP device
            //Quick add of device IP and protocol,  fill in the other parameters as system default 
            public byte byRes1;                     //reserved as 0

            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;//user name
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;//Password
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byDomain;//Domain name of the device
            public NET_DVR_IPADDR struIP;//IP
            public ushort wDVRPort;// Port number
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = DEV_ID_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] szDeviceID;  //Device ID 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;                 //Reserved as 0

            public void Init()
            {
                sUserName = new byte[NAME_LEN];
                sPassword = new byte[PASSWD_LEN];
                byDomain = new byte[MAX_DOMAIN_NAME];
                szDeviceID = new byte[DEV_ID_LEN];
                byRes2 = new byte[2];
            }
        }

        #endregion

        #region event card linkage

        [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        public struct NET_DVR_EVENT_CARD_LINKAGE_COND
        {
            public uint dwSize;
            public uint dwEventID; //Event ID 
            public ushort wLocalControllerID; //On the controller serial number [1, 64]
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 106, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EVENT_LINKAGE_INFO
        {
            public ushort wMainEventType;                     //main event type,0-device,1-alarmin,2-door,3-card reader
            public ushort wSubEventType;                      //sub event type
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 28, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }


        [StructLayoutAttribute(LayoutKind.Explicit)]
        public struct NET_DVR_EVETN_CARD_LINKAGE_UNION
        {
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            [FieldOffsetAttribute(0)]
            public byte[] byCardNo;
            [FieldOffsetAttribute(0)]
            public NET_DVR_EVENT_LINKAGE_INFO struEventLinkage;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MACADDR_LEN, ArraySubType = UnmanagedType.I1)]
            [FieldOffsetAttribute(0)]
            public byte[] byMACAddr;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            [FieldOffsetAttribute(0)]
            public byte[] byEmployeeNo;
        }


        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EVENT_CARD_LINKAGE_CFG_V50
        {
            public uint dwSize;
            public byte byProMode;                          //linkage type,0-by event,1-by card, 2-by mac
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwEventSourceID;                    //event source ID,when the main event is device ,it not use; when the main event is door ,it is the door No; when the main event is card reader ,it is the card reader No; when the main event is alarmin,it is the alarmin ID; 0xffffffff means all
            public NET_DVR_EVETN_CARD_LINKAGE_UNION uLinkageInfo;  //Linkage mode parameters 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMOUT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmout;            //linkage alarmout NO,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byOpenDoor;     //whether linkage open door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byCloseDoor;    //whether linkage close door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byNormalOpen;   //whether linkage normal open door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byNormalClose;  //whether linkage normal close door,according to the values,0-not linkage,1-linkage
            public byte byMainDevBuzzer;                    //whether linkage main device buzzer, 0-not linkage,1-linkage
            public byte byCapturePic;                    //whether linkage capture picture, 0-no, 1-yes
            public byte byRecordVideo;                   //whether linkage record video, 0-no, 1-yes
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 29, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byReaderBuzzer; //linkage reader buzzer,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMOUT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutClose;            //Associated alarm output shut down, in bytes, 0-not linkage,1-linkage 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInSetup;  //Associated slip protection, in bytes, 0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInClose;  //Removal associated protection zones, in bytes, 0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 500, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes1 = new byte[3];
                byAlarmout = new byte[MAX_ALARMHOST_ALARMOUT_NUM];
                byOpenDoor = new byte[MAX_DOOR_NUM_256];
                byCloseDoor = new byte[MAX_DOOR_NUM_256];
                byNormalOpen = new byte[MAX_DOOR_NUM_256];
                byNormalClose = new byte[MAX_DOOR_NUM_256];
                byRes3 = new byte[29];
                byReaderBuzzer = new byte[MAX_CARD_READER_NUM_512];
                byAlarmOutClose = new byte[MAX_ALARMHOST_ALARMOUT_NUM];
                byAlarmInSetup = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byAlarmInClose = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byRes = new byte[500];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_EVENT_CARD_LINKAGE_CFG_V51
        {
            public uint dwSize;
            public byte byProMode;                          //linkage type,0-by event,1-by card, 2-by mac, 3-by employee No
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public uint dwEventSourceID;                    //event source ID,when the main event is device ,it not use; when the main event is door ,it is the door No; when the main event is card reader ,it is the card reader No; when the main event is alarmin,it is the alarmin ID; 0xffffffff means all
            public NET_DVR_EVETN_CARD_LINKAGE_UNION uLinkageInfo;  //Linkage mode parameters 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMOUT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmout;            //linkage alarmout NO,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byOpenDoor;     //whether linkage open door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byCloseDoor;    //whether linkage close door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byNormalOpen;   //whether linkage normal open door,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byNormalClose;  //whether linkage normal close door,according to the values,0-not linkage,1-linkage
            public byte byMainDevBuzzer;                    //whether linkage main device buzzer, 0-not linkage,1-linkage
            public byte byCapturePic;                    //whether linkage capture picture, 0-no, 1-yes
            public byte byRecordVideo;                   //whether linkage record video, 0-no, 1-yes
            public byte byMainDevStopBuzzer;                   //whether linkage record video, 0-no, 1-yes
            public ushort wAudioDisplayID;
            public byte byAudioDisplayMode;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 25, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byReaderBuzzer; //linkage reader buzzer,according to the values,0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMOUT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutClose;            //Associated alarm output shut down, in bytes, 0-not linkage,1-linkage 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInSetup;  //Associated slip protection, in bytes, 0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInClose;  //Removal associated protection zones, in bytes, 0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byReaderStopBuzzer;  //Removal associated protection zones, in bytes, 0-not linkage,1-linkage
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 512, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes1 = new byte[3];
                byAlarmout = new byte[MAX_ALARMHOST_ALARMOUT_NUM];
                byRes2 = new byte[32];
                byOpenDoor = new byte[MAX_DOOR_NUM_256];
                byCloseDoor = new byte[MAX_DOOR_NUM_256];
                byNormalOpen = new byte[MAX_DOOR_NUM_256];
                byNormalClose = new byte[MAX_DOOR_NUM_256];
                byRes3 = new byte[25];
                byReaderBuzzer = new byte[MAX_CARD_READER_NUM_512];
                byAlarmOutClose = new byte[MAX_ALARMHOST_ALARMOUT_NUM];
                byAlarmInSetup = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byAlarmInClose = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byReaderStopBuzzer = new byte[MAX_CARD_READER_NUM_512];
                byRes = new byte[512];
            }
        }

        #endregion

        #region DVR IP channel configuration
        /* Alarm output parameters */
        /* Alarm output channel */

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTINFO
        {
            public byte byIPID;                     /* ID of IP device,  the range:  1 to MAX_IP_DEVICE */
            public byte byAlarmOut;                 /* Alarm output NO. */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;                 /* Reserved */
        }

        /* IP Alarm output configuration */
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTCFG
        {
            public uint dwSize;                                                 /*struct size */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMOUT, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMOUTINFO[] struIPAlarmOutInfo; /* IP alarm output */
        }
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTINFO_V40
        {
            public uint dwIPID;                    /* ID of IP device,  the range:  1 to MAX_IP_DEVICE*/
            public uint dwAlarmOut;                /* Alarm Out NO. */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;                 /* Reserved */
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMOUTCFG_V40
        {
            public uint dwSize;
            public uint dwCurIPAlarmOutNum;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN_V40, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMOUTINFO_V40[] struIPAlarmOutInfo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        /* IP Alarm input configuration */
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMININFO
        {
            public byte byIPID;                     /* ID of IP device,  the range:  1 to MAX_IP_DEVICE */
            public byte byAlarmIn;                 /* Alarm input NO. */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 18, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;                 /* Reserved */
        }
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMINCFG
        {
            public uint dwSize;                                              /*struct size */
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMININFO[] struIPAlarmInInfo;  /* IP alarm input */
        }
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMININFO_V40
        {
            public uint dwIPID;                    /* ID of IP device,  the range:  1 to MAX_IP_DEVICE */
            public uint dwAlarmIn;                /* Alarm input NO. */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_IPALARMINCFG_V40
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_IP_ALARMIN_V40, ArraySubType = UnmanagedType.Struct)]
            public NET_DVR_IPALARMININFO_V40[] struIPAlarmInInfo;/* IP alarmin */
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
        }

        /* IP Channel parameters */
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_IPCHANINFO
        {
            public byte byEnable;                     //0- Failed to connect IP device; 1- Successfully; 
            public byte byIPID;                     //ID of IP device,  low 8 bit 
            public byte byChannel;                 //Channel No. 
            public byte byIPIDHigh;                //ID of IP device,  high 8 bit 
            public byte byTransProtocol;            //Trans Protocol Type 0-TCP/auto (Determined by the device),1-UDP 2-Multicast 3-only TCP 4-auto
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 31, ArraySubType = UnmanagedType.I1)]
            public byte[] byres;                    /* Reserved */
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_IPSERVER_STREAM
        {
            public byte byEnable;   //Is enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public NET_DVR_IPADDR struIPServer;   //IPServer Address
            public ushort wPort;                   //IPServer port
            public ushort wDvrNameLen;             //DVR Name Length
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byDVRName;    //DVR Name
            public ushort wDVRSerialLen;           //Serial Length
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U2)]
            public ushort[] byRes1;               //reserved
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byDVRSerialNumber;    //DVR Serial
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byUserName;               //DVR User name
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byPassWord;             //DVR User password
            public byte byChannel;                         //DVR channel
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;              //Reserved
            public void Init()
            {
                byRes = new byte[3];
                byRes1 = new ushort[2];
                byUserName = new byte[NAME_LEN];
                byPassWord = new byte[PASSWD_LEN];
                byDVRSerialNumber = new byte[SERIALNO_LEN];
                byDVRName = new byte[NAME_LEN];
                byRes2 = new byte[11];
            }
        }

        /*the configuration of stream server*/
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_STREAM_MEDIA_SERVER_CFG
        {
            public byte byValid;            //Is enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            public NET_DVR_IPADDR struDevIP;  //stream server IP    
            public ushort wDevPort;            //stream server Port    
            public byte byTransmitType;        //Protocol: 0-TCP, 1-UDP
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 69, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public void Init()
            {
                byRes1 = new byte[3];
                byRes2 = new byte[69];
            }
        }

        //device information
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DEV_CHAN_INFO
        {
            public NET_DVR_IPADDR struIP;            //DVR IP address
            public ushort wDVRPort;                 //DVR PORT
            public byte byChannel;                //Channel
            public byte byTransProtocol;        //Transmit protocol:0-TCP,1-UDP
            public byte byTransMode;            //Stream mode: 0－mian stream 1－sub stream
            public byte byFactoryType;            /*IPC factory type*/
            public byte byDeviceType; //Device type(Used by videoplatfom VCA card),1-decoder(use decode channel No. or display channel depends on byVcaSupportChanMode in videoplatform ability struct),2-coder
            public byte byDispChan;//Display channel No. used by VCA configuration
            public byte bySubDispChan;//Display sub channel No. used by VCA configuration
            public byte byResolution;    //Resolution: 1-CIF 2-4CIF 3-720P 4-1080P 5-500w used by big screen controler
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_DOMAIN_NAME, ArraySubType = UnmanagedType.I1)]
            public byte[] byDomain;    //Device domain name
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;    //Remote device user name
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassword;    //Remote device password
            public void Init()
            {
                byRes = new byte[2];
                byDomain = new byte[MAX_DOMAIN_NAME];
                sUserName = new byte[NAME_LEN];
                sPassword = new byte[PASSWD_LEN];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_PU_STREAM_CFG
        {
            public uint dwSize;
            public NET_DVR_STREAM_MEDIA_SERVER_CFG struStreamMediaSvrCfg;
            public NET_DVR_DEV_CHAN_INFO struDevChanInfo;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_DDNS_STREAM_CFG
        {
            public byte byEnable;   //Is Enable.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            NET_DVR_IPADDR struStreamServer;   //Stream server IP
            public ushort wStreamServerPort;           //Stream server Port   
            public byte byStreamServerTransmitType;  //Stream protocol
            public byte byRes2;
            NET_DVR_IPADDR struIPServer;      //IPserver IP
            public ushort wIPServerPort;               //IPserver Port
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDVRName;     //DVR Name
            public ushort wDVRNameLen;            //DVR Name Len
            public ushort wDVRSerialLen;          //Serial Len
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sDVRSerialNumber;    //Serial number
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sUserName;   //the user name which is used to login DVR.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] sPassWord; //the password which is used to login DVR.
            public ushort wDVRPort;        //DVR port
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes4;
            public byte byChannel;       //channel
            public byte byTransProtocol; //protocol 
            public byte byTransMode;     //transform mode
            public byte byFactoryType;   //The type of factory who product the device.
            public void Init()
            {
                byRes1 = new byte[3];
                byRes3 = new byte[2];
                sDVRSerialNumber = new byte[SERIALNO_LEN];
                sUserName = new byte[NAME_LEN];
                sPassWord = new byte[PASSWD_LEN];
                byRes4 = new byte[2];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_PU_STREAM_URL
        {
            public byte byEnable;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = URL_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] strURL;
            public byte byTransPortocol; // transport protocol type  0-tcp  1-UDP
            public ushort wIPID;  //Device ID,wIPID = iDevInfoIndex + iGroupNO*64 +1
            public byte byChannel;  //channel NO.
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void Init()
            {
                byRes = new byte[7];
                strURL = new byte[URL_LEN];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_HKDDNS_STREAM
        {
            public byte byEnable;   //Is enable
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byDDNSDomain;    // hiDDNS domain
            public ushort wPort;                   //IPServer port
            public ushort wAliasLen;               //Alias Length
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlias;         //Alias
            public ushort wDVRSerialLen;           //Serial Length
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;               //reserved
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = SERIALNO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byDVRSerialNumber;    //DVR Serial
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byUserName;               //DVR User name
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = PASSWD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byPassWord;             //DVR User passward
            public byte byChannel;                          //DVR channel
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 11, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;              //Reserved
            public void Init()
            {
                byRes = new byte[3];
                byDDNSDomain = new byte[64];
                byAlias = new byte[NAME_LEN];
                byRes1 = new byte[2];
                byDVRSerialNumber = new byte[SERIALNO_LEN];
                byUserName = new byte[NAME_LEN];
                byPassWord = new byte[PASSWD_LEN];
                byRes2 = new byte[11];
            }
        }

        public const int NET_DVR_GET_IPPARACFG_V40 = 1062;
        public const int NET_DVR_SET_IPPARACFG_V40 = 1063;
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_IPCHANINFO_V40
        {
            public byte byEnable;                /* Enable */
            public byte byRes1;
            public ushort wIPID;                  //IP ID
            public uint dwChannel;                //channel
            public byte byTransProtocol;        //Trans protocol,0-TCP,1-UDP
            public byte byTransMode;            //Trans mode 0－main, 1－sub
            public byte byFactoryType;            /*Factory type*/
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 241, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;
            public void Init()
            {
                byRes = new byte[241];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_GET_STREAM_UNION
        {
            public NET_DVR_IPCHANINFO struChanInfo;	//Get stream from Device.
            public NET_DVR_IPSERVER_STREAM struIPServerStream;  // //Get stream from Device which register the IPServer
            public NET_DVR_PU_STREAM_CFG struPUStream;     //Get stream from stream server.
            public NET_DVR_DDNS_STREAM_CFG struDDNSStream;     //Get stream by IPserver and stream server.
            public NET_DVR_PU_STREAM_URL struStreamUrl;        //get stream through stream server by url.
            public NET_DVR_HKDDNS_STREAM struHkDDNSStream;   //get stream through hiDDNS
            public NET_DVR_IPCHANINFO_V40 struIPChan; //Get stream from device(Extend)
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_STREAM_MODE
        {
            public byte byGetStreamType; //the type of gettin stream:0-Get stream from Device, 1-Get stream fram stream server, 
            //2-Get stream from Device which register the IPServer, 3.Get stream by IPserver and stream server
            //4-get stream by url,5-hkDDNS,6-Get stream from Device,NET_DVR_IPCHANINFO_V40,7- Get Stream by Rtsp Protocal 
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public byte[] byRes;
            public NET_DVR_GET_STREAM_UNION uGetStream;    //the union of different getting stream type.
        }
        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_IPPARACFG_V40
        {
            public uint dwSize;
            public uint dwGroupNum;                    //The number of group    
            public uint dwAChanNum;                    //The number of simulate channel
            public uint dwDChanNum;                  //the number of IP channel
            public uint dwStartDChan;                //the begin NO. of IP channel
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30)]
            public byte[] byAnalogChanEnable;       //Is simulate channel enable? represent by bit
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_IP_DEVICE_V40)]
            public NET_DVR_IPDEVINFO_V31[] struIPDevInfo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_CHANNUM_V30)]
            public NET_DVR_STREAM_MODE[] struStreamMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
            public byte[] byRes2;
        }

        #endregion

        #region Remote Control
        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_JPEGPARA
        {
            /*Note:  If encoding resolution is VGA, it supports grabbing 0=CIF,  1=QCIF,  2=D1 image.
            But if encoding resolution is 3=UXGA (1600x1200) ,  4=SVGA (800x600) ,  5=HD720p (1280x720) ,  6=VGA,  7=XVGA,  and 8=HD900p it only support grabbing image with current resolution*/
            /*
               0-CIF,           1-QCIF,           2-D1,         3-UXGA(1600x1200), 4-SVGA(800x600),5-HD720p(1280x720),
               6-VGA,           7-XVGA,           8-HD900p,     9-HD1080,     10-2560*1920,
               11-1600*304,     12-2048*1536,     13-2448*2048,  14-2448*1200, 15-2448*800,
               16-XGA(1024*768), 17-SXGA(1280*1024),18-WD1(960*576/960*480),      19-1080i,      20-576*576,
               21-1536*1536,     22-1920*1920,      23-320*240,    24-720*720,    25-1024*768,
               26-1280*1280,     27-1600*600,       28-2048*768,   29-160*120,    55-3072*2048,
               64-3840*2160,     70-2560*1440,      75-336*256,
               78-384*256,         79-384*216,        80-320*256,    82-320*192,    83-512*384,
               127-480*272,      128-512*272,       161-288*320,   162-144*176,   163-480*640,
               164-240*320,      165-120*160,       166-576*720,   167-720*1280,  168-576*960,
               180-180*240,      181-360*480,       182-540*720,    183-720*960,  184-960*1280,
               185-1080*1440     215-1080*720(occupied untested),  216-360x640(occupied untested),
               500-384*288,
               0xff-Auto(Use resolution of current stream)
               */
            public short wPicSize;
            public short wPicQuality;/* 0 -  the best,  1 -  better,  2 -  average;  */
        }
        #endregion

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_ACS_WORK_STATUS_V50
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byDoorLockStatus;//door lock status(relay status), 0 normally closed,1 normally open, 2 damage short - circuit alarm, 3 damage breaking alarm, 4 abnormal alarm
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byDoorStatus; //Door status(floor status), 1 - dormancy, 2 - normally open state, 3 - normally closed state, 4 - ordinary state 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byMagneticStatus; //magnetic status 0 normally closed,1 normally open, 2 damage short - circuit alarm, 3 damage breaking alarm, 4 abnormal alarm
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CASE_SENSOR_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byCaseStatus; //case status, 0-no input, 1-input    
            public ushort wBatteryVoltage; //vattery voltage , multiply 10, unit: V
            public byte byBatteryLowVoltage; //Is battery in low voltage, 0-no 1-yes
            public byte byPowerSupplyStatus; //power supply status, 1-alternating current supply, 2-battery supply
            public byte byMultiDoorInterlockStatus;//multi door interlock status, 0-close 1-open
            public byte byAntiSneakStatus; //anti sneak status, 0-close 1-open
            public byte byHostAntiDismantleStatus; //host anti dismantle status, 0-close, 1-open
            public byte byIndicatorLightStatus; //Indicator Light Status 0-offLine,1-Online
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderOnlineStatus; //card reader online status, 0-offline 1-online
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderAntiDismantleStatus; //card reader anti dismantle status, 0-close 1-open
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_CARD_READER_NUM_512, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardReaderVerifyMode; //card reader verify mode, 1-swipe 2-swipe+password 3-swipe card 4-swipe card or password
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] bySetupAlarmStatus;//alarm in setup alarm status,0- alarm in disarm status, 1 - alarm in arm status
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMIN_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmInStatus; //alarm in status, 0-alarm in no alarm, 1-alarm in has alarm 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_ALARMHOST_ALARMOUT_NUM, ArraySubType = UnmanagedType.I1)]
            public byte[] byAlarmOutStatus; //alarm out status, 0-alarm out no alarm, 1-alarm out has alarm 
            public uint dwCardNum; //add card number
            public byte byFireAlarmStatus; //Fire alarm status is displayed: 0 - normal, short-circuit alarm 1 -, 2 - disconnect the alarm 
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 123, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;

            public void Init()
            {
                byDoorLockStatus = new byte[MAX_DOOR_NUM_256];
                byDoorStatus = new byte[MAX_DOOR_NUM_256];
                byMagneticStatus = new byte[MAX_DOOR_NUM_256];
                byCaseStatus = new byte[MAX_CASE_SENSOR_NUM];
                byCardReaderOnlineStatus = new byte[MAX_CARD_READER_NUM_512];
                byCardReaderAntiDismantleStatus = new byte[MAX_CARD_READER_NUM_512];
                byCardReaderVerifyMode = new byte[MAX_CARD_READER_NUM_512];
                bySetupAlarmStatus = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byAlarmInStatus = new byte[MAX_ALARMHOST_ALARMIN_NUM];
                byAlarmOutStatus = new byte[MAX_ALARMHOST_ALARMOUT_NUM];
                byRes2 = new byte[123];
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_ACS_EVENT_COND
        {
            public uint dwSize;
            public uint dwMajor;
            public uint dwMinor;
            public CHCNetSDKCard.NET_DVR_TIME struStartTime;
            public CHCNetSDKCard.NET_DVR_TIME struEndTime;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byName;
            public uint dwBeginSerialNo;
            public byte byPicEnable;
            public byte byTimeType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes2;
            public uint dwEndSerialNo;
            public uint dwIOTChannelNo;
            public ushort wInductiveEventType;
            public byte bySearchType;
            public byte byRes1;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CHCNetSDKCard.NET_SDK_MONITOR_ID_LEN)]
            public string szMonitorID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.NET_SDK_EMPLOYEE_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 140, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[CHCNetSDKCard.ACS_CARD_NO_LEN];
                byName = new byte[CHCNetSDKCard.NAME_LEN];
                byRes2 = new byte[2];
                byEmployeeNo = new byte[CHCNetSDKCard.NET_SDK_EMPLOYEE_NO_LEN];
                byRes = new byte[140];
            }
        }



        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_ACS_EVENT_CFG
        {
            public uint dwSize;
            public uint dwMajor;
            public uint dwMinor;
            public CHCNetSDKCard.NET_DVR_TIME struTime;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.MAX_NAMELEN)]
            public byte[] sNetUser;
            public CHCNetSDKCard.NET_DVR_IPADDR struRemoteHostAddr;
            public CHCNetSDKCard.NET_DVR_ACS_EVENT_DETAIL struAcsEventInfo;
            public uint dwPicDataLen;
            public IntPtr pPicData;  // picture data
            public ushort wInductiveEventType;
            public byte byTimeType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 61)]
            public byte[] byRes;
        }

        public struct NET_DVR_ACS_EVENT_DETAIL
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.ACS_CARD_NO_LEN)]
            public byte[] byCardNo;
            public byte byCardType;
            public byte byWhiteListNo;
            public byte byReportChannel;
            public byte byCardReaderKind;
            public uint dwCardReaderNo;
            public uint dwDoorNo;
            public uint dwVerifyNo;
            public uint dwAlarmInNo;
            public uint dwAlarmOutNo;
            public uint dwCaseSensorNo;
            public uint dwRs485No;
            public uint dwMultiCardGroupNo;
            public ushort wAccessChannel;//word
            public byte byDeviceNo;
            public byte byDistractControlNo;
            public uint dwEmployeeNo;
            public ushort wLocalControllerID;//word
            public byte byInternetAccess;
            public byte byType;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.MACADDR_LEN)]
            public byte[] byMACAddr;
            public byte bySwipeCardType;
            public byte byRes2;
            public uint dwSerialNo;
            public byte byChannelControllerID;
            public byte byChannelControllerLampID;
            public byte byChannelControllerIRAdaptorID;
            public byte byChannelControllerIREmitterID;
            public uint dwRecordChannelNum;
            public IntPtr pRecordChannelData;
            public byte byUserType;
            public byte byCurrentVerifyMode;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public byte[] byRe2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CHCNetSDKCard.NET_SDK_EMPLOYEE_NO_LEN)]
            public byte[] byEmployeeNo;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public byte[] byRes;
        }

        #region video call struct

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VIDEO_CALL_COND
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[128];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_VIDEO_CALL_PARAM
        {
            public uint dwSize;
            public uint dwCmdType;//command type:0-request call;1-cancel this call;2-answer this call;3-deny local call;4-called timeout;5-finish this call;6-device is busy;7-client is busy;8-indoor offline
            public ushort wPeriod;//period number
            public ushort wBuildingNumber;//building number
            public ushort wUnitNumber;//unit number
            public ushort wFloorNumber;//floor number
            public ushort wRoomNumber;//room number
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 118, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[118];
            }
        }

        public struct NET_DVR_CLIENTINFO
        {
            public Int32 lChannel;
            public uint lLinkMode;
            public IntPtr hPlayWnd;
            public string sMultiCastIP;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct NET_DVR_VOLUME_CFG
        {
            public uint dwSize;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = MAX_AUDIOOUT_PRO_TYPE)]
            public ushort[] wVolume;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public byte[] byRes;
        }

        #endregion

        #endregion //HCNetSDK.dll structure definition

        #region HCNetSDK.dll function definition
        // function definition
        /* The SDK initialization function */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_Init();

        /* Release the SDK resources, before the end of the procedure call*/
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_Cleanup();

        /* Enable to write the log file function
         * [in] nLogLevel(default 0) - log level, 0:close, 1:ERROR, 2:ERROR and DEBUG, 3-ALL
         * [in] strLogDir - file directory to save, default:"C:\\SdkLog\\"(win)and "/home/sdklog/"(linux)
         * [in] bAutoDel - whether to delete log file by auto, TRUE is default
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetLogToFile(int nLogLevel, string strLogDir, bool bAutoDel);

        /* Returns the last error code of the operation */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern uint NET_DVR_GetLastError();

        /* Returns the last error code information of the operation */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern IntPtr NET_DVR_GetErrorMsg(ref int pErrorNo);

        /* Alarm host device user configuration function(following two:get and set)
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] lUserIndex - index of user
         * [in] lpDeviceUser - lookup NET_DVR_ALARM_DEVICE_USER definition
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_GetAlarmDeviceUser(int lUserID, int lUserIndex, ref NET_DVR_ALARM_DEVICE_USER lpDeviceUser);

        /* Get device configuration information function
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] lChannel - channel number with command related, 0xFFFFFFFF represent invalid
         * [out] lpOutBuffer - a pointer to a buffer to receive data
         * [in] dwOutBufferSize- the receive data buffer size, don't assign 0, unit:byte
         * [out] lpBytesReturned - pointer to the length of the data received, e.g. a int type pointer, can't be NULL
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpOutBuffer, uint dwOutBufferSize, ref uint lpBytesReturned);

        /* Set device configuration information function
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] lChannel - channel number with command related, 0xFFFFFFFF represent invalid
         * [in] lpInBuffer - a pointer to a buffer of send data
         * [in] dwInBufferSize- the send data buffer size, unit:byte
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRConfig(int lUserID, uint dwCommand, int lChannel, IntPtr lpInBuffer, uint dwInBufferSize);

        /* Long connection call back function
         * [out] dwType - refer enum NET_SDK_CALLBACK_TYPE
         * [out] lpBuffer - pointer to data buffer(user manual for more details)
         * [out] dwBufLen - the buffer size
         * [out] pUserData - pointer to user input data
         */
        public delegate void RemoteConfigCallback(uint dwType, IntPtr lpBuffer, uint dwBufLen, IntPtr pUserData);

        // Long connection configuration function
        /* Start the remote configuration
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] lpInBuffer - a pointer to a buffer of send data
         * [in] dwInBufferLen - the send data buffer size, unit:byte
         * [in] cbStateCallback - the callback function
         * [in] pUserData - pointer to user input data
         */
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StartRemoteConfig(int lUserID, uint dwCommand, IntPtr lpInBuffer, Int32 dwInBufferLen, RemoteConfigCallback cbStateCallback, IntPtr pUserData);

        /* Send a long connection data
         * [in] lHandle - handle ,NET_DVR_StartRemoteConfig return value
         * [in] dwDataType - refer enum LONG_CFG_SEND_DATA_TYPE_ENUM, associated with NET_DVR_StartRemoteConfig command parameters
         *                   (user manual for more details)
         * [in] pSendBuf - a pointer to a buffer of send data, associated with dwDataType
         * [in] dwBufSize - the send data buffer size, unit:byte
         */
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SendRemoteConfig(int lHandle, uint dwDataType, IntPtr pSendBuf, uint dwBufSize);

        // stop a long connection
        // [in] lHandle - handle ,NET_DVR_StartRemoteConfig return value
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_StopRemoteConfig(int lHandle);

        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_Upgrade_V40(int lUserID, uint dwUpgradeType, string sFileName, IntPtr pInbuffer, Int32 dwInBufferLen);

        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetUpgradeProgress(int lUpgradeHandle);

        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_CloseUpgradeHandle(int lUpgradeHandle);

        /* get long connection configuration status
         * [in] lHandle - handle ,NET_DVR_StartRemoteConfig return value
         * [out] pState - the return status pointer
         */
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_GetRemoteConfigState(int lHandle, IntPtr pState);

        /* obtain the result of the information one by one
         * [in] lHandle - handle ,NET_DVR_StartRemoteConfig return value
         * [out] lpOutBuff - a pointer to a buffer to receive data(user manual for more details)
         * [in] dwOutBuffSize- the receive data buffer size, unit:byte
         */
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_GetNextRemoteConfig(int lHandle, IntPtr lpOutBuff, uint dwOutBuffSize);

        /* Batch for device configuration information (with sending data)
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] dwCount - the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64
         * [in] lpInBuffer - a pointer to conditions buffer(user manual for more details)
         * [in] dwInBufferSize- the conditions buffer size, unit:byte
         * [out] lpStatusList - a pointer to the error code list, One to one correspondence(user manual for more details)
         * [out] lpOutBuffer - a pointer to receive data buffer, One to one correspondence(user manual for more details)
         * [in] dwOutBufferSize- the receive data buffer size, unit:byte
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpOutBuffer, uint dwOutBufferSize);

        /* Batch for device configuration information (with sending data)
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] dwCount - the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64
         * [in] lpInBuffer - a pointer to conditions buffer(user manual for more details)
         * [in] dwInBufferSize- the conditions buffer size, unit:byte
         * [out] lpStatusList - a pointer to the error code list, One to one correspondence(user manual for more details)
         * [out] lpInParamBuffer - a pointer to set parameters for the device buffer, One to one correspondence(user manual for more details)
         * [in] dwInParamBufferSize- the correspond data buffer size, unit:byte
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDeviceConfig(int lUserID, uint dwCommand, uint dwCount, IntPtr lpInBuffer, uint dwInBufferSize, IntPtr lpStatusList, IntPtr lpInParamBuffer, uint dwInParamBufferSize);


        /* The remote control function
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwCommand - the configuration command(usually with NET_DVR_ prefix)
         * [in] dwCount - the number of configuration at a time, 0 and 1 represent one, in order to increase, maximum:64
         * [in] lpInBuffer - a pointer to send data buffer(user manual for more details)
         * [in] dwInBufferSize- the correspond buffer size, unit:byte
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_RemoteControl(int lUserID, uint dwCommand, IntPtr lpInBuffer, uint dwInBufferSize);

        /* login
         * [in] pLoginInfo - login parameters
         * [in] lpDeviceInfo - device informations
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_Login_V40(ref NET_DVR_USER_LOGIN_INFO pLoginInfo, ref NET_DVR_DEVICEINFO_V40 lpDeviceInfo);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_Logout_V30(Int32 lUserID);

        public delegate void RealDataCallBack(int lPlayHandle, uint dwDataType, IntPtr pBuffer, uint dwBufSize, IntPtr pUser);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_V40(int lUserID, ref NET_DVR_PREVIEWINFO lpPreviewInfo, RealDataCallBack fRealDataCallBack_V30, IntPtr pUser);

        // alarm

        /* Set up alarm upload channel, to obtain the information such as alarm*/
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SetupAlarmChan(int lUserID);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SetupAlarmChan_V30(int lUserID);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SetupAlarmChan_V41(int lUserID, ref NET_DVR_SETUPALARM_PARAM lpSetupParam);

        /* shut down alarm upload channel, to obtain the information such as alarm*/
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseAlarmChan(int lAlarmHandle);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_CloseAlarmChan_V30(int lAlarmHandle);


        /* Alarm information callback function
         * [out] lCommand - message type upload(user manual for more details) entrance guard device : COMM_ALARM_ACS
         * [out] pAlarmer -  information of alarm device
         * [out] pAlarmInfo - alarm information (NET_DVR_ACS_ALARM_INFO)
         * [out] dwBufLen - size of pAlarmInfo
         * [out] pUser - user data
         */
        public delegate void MSGCallBack(int lCommand, ref NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);

        public delegate bool MSGCallBack_V31(int lCommand, ref NET_DVR_ALARMER pAlarmer, IntPtr pAlarmInfo, uint dwBufLen, IntPtr pUser);

        /* Alarm information registered callback function
         * [in] iIndex - iIndex, scope:[0,15] 
         * [in] fMessageCallBack - callback function
         * [in] pUser - user data
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V50(int iIndex, MSGCallBack fMessageCallBack, IntPtr pUser);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetDVRMessageCallBack_V31(MSGCallBack_V31 fMessageCallBack, IntPtr pUser);

        /* NET_DVR_GetDeviceAbility get device ability
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] dwAbilityType - the configuration command(ACS_ABILITY)
         * [in] pInBuf - a pointer to send data buffer(user manual for more details)
         * [in] dwInLength - the correspond buffer size, unit:byte
         * [out] pOutBuf- out buff(ACS_ABILITY is described with XML)
         * [in] dwOutLength - the correspond buffer size, unit:byte
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_GetDeviceAbility(int lUserID, uint dwAbilityType, IntPtr pInBuf, uint dwInLength, IntPtr pOutBuf, uint dwOutLength);

        /* Get to the SDK version information*/
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern uint NET_DVR_GetSDKVersion();

        /* Get version number of the SDK and build information*/
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern uint NET_DVR_GetSDKBuildVersion();

        /** remote control gateway
         * [in] lUserID - NET_DVR_Login_V40 return value
         * [in] lGatewayIndex - 1-begin 0xffffffff-all
         * [in] dwStaic - : 0-close，1-open，2-always open，3-always close
         */
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_ControlGateway(int lUserID, int lGatewayIndex, uint dwStaic);


        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_STDXMLConfig(int lUserID, IntPtr lpInputParam, IntPtr lpOutputParam);

        public delegate void REALDATACALLBACK(Int32 lRealHandle, UInt32 dwDataType, ref byte pBuffer, UInt32 dwBufSize, IntPtr pUser);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_RealPlay_V30(int iUserID, ref NET_DVR_CLIENTINFO lpClientInfo, REALDATACALLBACK fRealDataCallBack_V30, IntPtr pUser, UInt32 bBlocked);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_StopRealPlay(int iRealHandle);

        public delegate void VOICEDATACALLBACKV30(int lVoiceComHandle, string pRecvDataBuffer, uint dwBufSize, byte byAudioFlag, System.IntPtr pUser);
        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_StartVoiceCom_V30(int lUserID, uint dwVoiceChan, bool bNeedCBNoEncData, VOICEDATACALLBACKV30 fVoiceDataCallBack, IntPtr pUser);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_SetVoiceComClientVolume(int lVoiceComHandle, ushort wVolume);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_StopVoiceCom(int lVoiceComHandle);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport(@"HCNetSDK\HCNetSDK.dll")]
        public static extern bool NET_DVR_CaptureJPEGPicture(int lUserID, int lChannel, ref CHCNetSDKCard.NET_DVR_JPEGPARA lpJpegPara, IntPtr sPicFileName);
        #endregion

        #region 门禁卡，指纹，人脸接口优化新增命令码及结构体
        public const int NET_DVR_GET_CARD = 2560;
        public const int NET_DVR_SET_CARD = 2561;
        public const int NET_DVR_DEL_CARD = 2562;
        public const int NET_DVR_GET_FINGERPRINT = 2563;
        public const int NET_DVR_SET_FINGERPRINT = 2564;
        public const int NET_DVR_DEL_FINGERPRINT = 2565;
        public const int NET_DVR_GET_FACE = 2566;
        public const int NET_DVR_SET_FACE = 2567;

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_COND
        {
            public uint dwSize;
            public uint dwCardNum; //card number, 0xffffffff means to get all card information when getting
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 64, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byRes = new byte[64];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_RECORD
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public byte byCardType;
            public byte byLeaderCard;
            public byte byUserType;
            public byte byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public byte[] byDoorRight;
            public NET_DVR_VALID_PERIOD_CFG struValid;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_GROUP_NUM_128, ArraySubType = UnmanagedType.I1)]
            public byte[] byBelongGroup;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = CARD_PASSWORD_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardPassword;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_DOOR_NUM_256, ArraySubType = UnmanagedType.I1)]
            public ushort[] wCardRightPlan;
            public uint dwMaxSwipeTimes;
            public uint dwSwipeTimes;
            public uint dwEmployeeNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = NAME_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byName;
            //按位表示，0-无权限，1-有权限
            //第0位表示：弱电报警
            //第1位表示：开门提示音
            //第2位表示：限制客卡
            //第3位表示：通道
            //第4位表示：反锁开门
            //第5位表示：巡更功能
            public uint dwCardRight;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 256, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byDoorRight = new byte[MAX_DOOR_NUM_256];
                byBelongGroup = new byte[MAX_GROUP_NUM_128];
                byCardPassword = new byte[CARD_PASSWORD_LEN];
                wCardRightPlan = new ushort[MAX_DOOR_NUM_256];
                byName = new byte[NAME_LEN];
                byRes = new byte[256];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_COND
        {
            public uint dwSize;
            public uint dwFingerPrintNum; //the number send or get. if get,0xffffffff means all
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo;
            public uint dwEnableReaderNo;
            public byte byFingerPrintID;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 131, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes = new byte[131];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_COND
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public uint dwFaceNum; //the number send or get. if get,0xffffffff means all
            public uint dwEnableReaderNo;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 124, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes = new byte[124];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_SEND_DATA
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 16, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes = new byte[16];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_RECORD
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public uint dwFaceLen;
            public IntPtr pFaceBuffer;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 128, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes = new byte[128];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_CARD_STATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public uint dwErrorCode;
            public byte byStatus; //0-fail, 1-success
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 23, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes = new byte[23];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FACE_STATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg; //下发错误信息，当byCardReaderRecvStatus为4时，表示已存在人脸对应的卡号
            public uint dwReaderNo; //人脸读卡器编号，可用于下发错误返回
            public byte byRecvStatus; //人脸读卡器状态，按字节表示，0-失败，1-成功，2-重试或人脸质量差，3-内存已满(人脸数据满)，4-已存在该人脸，5-非法人脸ID
            //,6-算法建模失败，7-未下发卡权限，8-未定义（保留），9-人眼间距小距小，10-图片数据长度小于1KB，11-图片格式不符（png/jpg/bmp）,12-图片像素数量超过上限，13-图片像素数量低于下限，14-图片信息校验失败，15-图片解码失败，16-人脸检测失败，17-人脸评分失败
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 131, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byErrorMsg = new byte[ERROR_MSG_LEN];
                byRes = new byte[131];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_RECORD
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //card No
            public uint dwFingerPrintLen; //指纹数据长度
            public uint dwEnableReaderNo; //需要下发指纹的读卡器编号
            public byte byFingerPrintID; //手指编号，有效值范围为1-10
            public byte byFingerType; //指纹类型  0-普通指纹，1-胁迫指纹
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 30, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes1;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = MAX_FINGER_PRINT_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byFingerData; //指纹数据内容
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 96, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byRes1 = new byte[30];
                byFingerData = new byte[MAX_FINGER_PRINT_LEN];
                byRes = new byte[96];
            }
        }

        [StructLayoutAttribute(LayoutKind.Sequential)]
        public struct NET_DVR_FINGERPRINT_STATUS
        {
            public uint dwSize;
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ACS_CARD_NO_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byCardNo; //指纹关联的卡号
            public byte byCardReaderRecvStatus; //指纹读卡器状态，按字节表示，0-失败，1-成功，2-该指纹模组不在线，3-重试或指纹质量差，4-内存已满，5-已存在该指纹，6-已存在该指纹ID，7-非法指纹ID，8-该指纹模组无需配置
            public byte byFingerPrintID; //手指编号，有效值范围为1-10
            public byte byFingerType; //指纹类型  0-普通指纹，1-胁迫指纹
            public byte byRecvStatus; //主机错误状态：0-成功，1-手指编号错误，2-指纹类型错误，3-卡号错误（卡号规格不符合设备要求），4-指纹未关联工号或卡号（工号或卡号字段为空），5-工号不存在，6-指纹数据长度为0，7-读卡器编号错误，8-工号错误
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = ERROR_MSG_LEN, ArraySubType = UnmanagedType.I1)]
            public byte[] byErrorMsg; //下发错误信息，当byCardReaderRecvStatus为5时，表示已存在指纹对应的卡号
            public uint dwCardReaderNo; //当byCardReaderRecvStatus为5时，表示已存在指纹对应的指纹读卡器编号，可用于下发错误返回。0时表示无错误信息
            [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 20, ArraySubType = UnmanagedType.I1)]
            public byte[] byRes;

            public void Init()
            {
                byCardNo = new byte[ACS_CARD_NO_LEN];
                byErrorMsg = new byte[ERROR_MSG_LEN];
                byRes = new byte[20];
            }
        }

        // 新增接口一个
        [DllImportAttribute(@"HCNetSDK\HCNetSDK.dll")]
        public static extern int NET_DVR_SendWithRecvRemoteConfig(int lHandle, IntPtr lpInBuff, uint dwInBuffSize, IntPtr lpOutBuff, uint dwOutBuffSize, ref uint dwOutDataLen);

        // 用户调用SendwithRecv接口时，接口返回的状态
        public enum NET_SDK_SENDWITHRECV_STATUS
        {
            NET_SDK_CONFIG_STATUS_SUCCESS = 1000,    // 成功读取到数据，客户端处理完本次数据后需要再次调用NET_DVR_SendWithRecvRemoteConfig获取下一条数据
            NET_SDK_CONFIG_STATUS_NEEDWAIT,          // 配置等待，客户端可重新NET_DVR_SendWithRecvRemoteConfig
            NET_SDK_CONFIG_STATUS_FINISH,            // 数据全部取完，此时客户端可调用NET_DVR_StopRemoteConfig结束
            NET_SDK_CONFIG_STATUS_FAILED,            // 配置失败，客户端可重新NET_DVR_SendWithRecvRemoteConfig
            NET_SDK_CONFIG_STATUS_EXCEPTION,         // 配置异常，此时客户端可调用NET_DVR_StopRemoteConfig结束
        }

        #endregion
    }
}
