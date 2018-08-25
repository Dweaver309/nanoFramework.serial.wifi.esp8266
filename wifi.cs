
//********************
//
// AT Command Reference 
// https://github.com/espressif/ESP8266_AT/wiki
//
//********************

using System;
using System.Threading;
using System.Text;
using Windows.Devices.SerialCommunication;
using Windows.Storage.Streams;
using Windows.Devices.Gpio;


namespace nanoframework.serial.driver
{

    class WiFi
    {

        private static SerialDevice Port;

        const string CrLf = "\r\n";
        const string Cr = "\r";

        private static DataWriter outputDataWriter;

        private static string StringRead = string.Empty;

        private static string Status = string.Empty;

        // Buffer for input and output stream
        const int RMAX_BUFF = 240;
        const int SMAX_BUFF = 120;

        private static int CurrentMode = (int)Mode.Connect;

        // SendServerRequest process data for APServerMode
        private static Boolean APServerMode = false;

        enum Mode
        {
            Connect = 1,
            TCPServer = 2,
            TCPClient = 3,
            TCPSending = 4

        }


        // Used to Parse date string in GetTimeFromString
        struct StrDate
        {
            public static int Year;
            public static int Month;
            public static int Day;
            public static int Hour;
            public static int Minute;
            public static int Second;

        }

        // Set in Connect 
        private static string IPAddress = "Connecting!";

        // Pause time in MS
        public static int CommandDelay = 4000;

        // Updated in SendServerRequest
        private static string LinkedID = "0";

        // Hours to adjust UTC time
        private static int LocalTimeOffSet = -5;

        //Leds
        // User pin number
        const int LedUserNumber = 10;
        
        // Go Ports pin numbers
        const int Led1Number = 73;
        const int Led2Number = 75;
        const int Led3Number = 78;

        private GpioPin LEDUser;
        private GpioPin LED1;
        private GpioPin LED2;
        private GpioPin LED3;
        

        // Constructor for serial WiFi
        // Example:  WiFi ESP8266 = new WiFi();
        public WiFi(int UTCLocalTimeOffSet = -5, int CommandDelayMS = 4000, Boolean UseLeds = true)
        {
            // Init LED's
            LEDUser  = GpioController.GetDefault().OpenPin(LedUserNumber);
            LEDUser.SetDriveMode(GpioPinDriveMode.Output);

            LED1 = GpioController.GetDefault().OpenPin(Led1Number);
            LED1.SetDriveMode(GpioPinDriveMode.Output);

            LED2 = GpioController.GetDefault().OpenPin(Led2Number);
            LED2.SetDriveMode(GpioPinDriveMode.Output);

            LED3 = GpioController.GetDefault().OpenPin(Led3Number);
            LED3.SetDriveMode(GpioPinDriveMode.Output);




            // COM6 in Netduino 3, STM32F769IDiscovery (Tx, Rx pins exposed in Arduino header TX->D1, RX->D0)
            // Open port
            Port = SerialDevice.FromId("COM6");

            // Used to set date and time in GetTimeFromString
            LocalTimeOffSet = UTCLocalTimeOffSet;
                       
            CommandDelay = CommandDelayMS;

            // set  device parameters
            Port.BaudRate = 115200;
            Port.Parity = SerialParity.None;
            Port.StopBits = SerialStopBitCount.One;
            Port.Handshake = SerialHandshake.None;
            Port.DataBits = 8;

            // Create new DataWriter
            outputDataWriter = new DataWriter(Port.OutputStream);

            // Updated in ESPDataReceived
            DataReader inputDataReader = new DataReader(Port.InputStream);

            inputDataReader.InputStreamOptions = InputStreamOptions.Partial;

            // Return char
            Port.WatchChar = '\r';

            //  1 Sec
            Port.ReadTimeout = new TimeSpan(0, 0, 1);

            Port.WriteTimeout = new TimeSpan(0, 0, 5);

            // Received event
            Port.DataReceived += ESPDataReceived;

        }

        /// <summary>
        /// ESP8266 Version
        /// </summary>
        public void GetVersion()
        {

            SendCommand("AT+GMR");
            Thread.Sleep(1000);

        }

        // Updated in ParseIPAddress
        public string GetIPAddress()
        {

            return IPAddress;

        }

        private static string FindGetRequest()
        {
            string srd = string.Empty;

            string[] Lines;

            //Split the server request into lines
            Lines = StringRead.Split(CrLf.ToCharArray());

            string rstr = string.Empty;

            //The line found will contain the "GET" statement
            if (Lines.Length > 0)
            {
                for (var i = 0; i <= Lines.Length - 1; i++)
                {

                    if (InString(Lines[i], "+IPD"))
                    {

                        rstr = Lines[i];

                        break;

                    }
                }
            }

            //Found it 
            if (rstr.Length > 1)
            {

                // Find LinkedID
                int si = rstr.LastIndexOf("+IPD,");

                LinkedID = rstr.Substring(si + 5, 1);

            }

            return rstr;

        }

        /// <summary>
        /// Send str to device
        /// </summary>
        private static void SendDataBytes(byte[] ByteArr)
        {

            outputDataWriter.WriteBytes(ByteArr);

            // Calling the 'Store' method on the data writer sends the data
            outputDataWriter.Store();

            Console.WriteLine("Sent: >> " + ByteArr.Length + " bytes");

        }

        /// <summary>
        /// Send str to device
        /// </summary>
        private static void SendData(string str)
        {

            outputDataWriter.WriteString(str);

            // Calling the 'Store' method on the data writer sends the data
            outputDataWriter.Store();

            Console.WriteLine("String Sent: >> " + str);

        }

        private static void SendImage(string Base64String)
        {


            byte[] stringBytes = Encoding.UTF8.GetBytes(Base64String);

            outputDataWriter.WriteBytes(stringBytes);

            outputDataWriter.Store();

            //Console.WriteLine("Base64String Sent: >> " + Base64String);

        }

        /// <summary>
        /// Parse the string and set time and date
        /// Uses the LocalTimeOffSet property to set the local time
        /// Updated in ESPDataReceived
        /// </summary>
        private static void GetTimeFromString(string str)
        {
            try
            {
                string DateString = string.Empty;

                string[] Lines;

                Lines = str.Split(CrLf.ToCharArray());

                if (Lines.Length > 0)
                {
                    for (var i = 0; i <= Lines.Length - 1; i++)
                    {

                        if (InString(Lines[i], "Date:"))
                        {

                            DateString = Lines[i];

                            break;
                        }
                    }

                    if (DateString.Length > 1)
                    {

                        Console.WriteLine("Date String: >> " + DateString + " <<");

                    }

                    char Space = (char)32;

                    char Colon = (char)58;

                    string[] DateLines;

                    string HMSString = string.Empty;

                    DateLines = DateString.Split(Space);

                    for (var i = 0; i <= DateLines.Length - 1; i++)
                    {
                        if (i == 2)
                            StrDate.Day = System.Convert.ToInt32(DateLines[i]);
                        if (i == 3)
                            StrDate.Month = GetMonthFromString(DateLines[i]);
                        if (i == 4)
                            StrDate.Year = System.Convert.ToInt32(DateLines[i]);
                        if (i == 5)
                            HMSString = DateLines[i];
                    }

                    DateLines = HMSString.Split(Colon);

                    if (DateLines.Length > 2)
                    {
                        StrDate.Hour = System.Convert.ToInt32(DateLines[0]);
                        StrDate.Minute = System.Convert.ToInt32(DateLines[1]);
                        StrDate.Second = System.Convert.ToInt32(DateLines[2]);
                    }

                    DateTime UTCdate = new DateTime(StrDate.Year, StrDate.Month, StrDate.Day, StrDate.Hour, StrDate.Minute, StrDate.Second);

                    DateTime LocalDate = UTCdate;

                    LocalDate = LocalDate.AddHours(LocalTimeOffSet);

                    nanoFramework.Runtime.Native.Rtc.SetSystemTime(LocalDate);

                    Console.WriteLine("Set Date >> " + DateTime.UtcNow.ToString() + " <<");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: GetTimeFromString: " + ex.ToString());

            }
        }

        /// <summary>
        /// Called from GetTimeFromString
        /// </summary>
        private static int GetMonthFromString(string CurrentMonth)
        {
            if (InString(CurrentMonth, "Jan"))
                return 1;
            if (InString(CurrentMonth, "Feb"))
                return 2;
            if (InString(CurrentMonth, "Mar"))
                return 3;
            if (InString(CurrentMonth, "Apr"))
                return 4;
            if (InString(CurrentMonth, "May"))
                return 5;
            if (InString(CurrentMonth, "Jun"))
                return 6;
            if (InString(CurrentMonth, "Jul"))
                return 7;
            if (InString(CurrentMonth, "Aug"))
                return 8;
            if (InString(CurrentMonth, "Sep"))
                return 9;
            if (InString(CurrentMonth, "Oct"))
                return 10;
            if (InString(CurrentMonth, "Nov"))
                return 11;
            if (InString(CurrentMonth, "Dec"))
                return 12;
            return 1;
        }

        /// <summary>
        /// Gets IP Address from string
        /// Updated in ESP8266DataReceived
        /// </summary>
        private static string ParseIPAddres(string str)
        {
            try
            {
                string Str = "STAIP,";

                int IpStart = str.LastIndexOf(Str) + Str.Length;

                IPAddress = str.Substring(IpStart);

                int IPEnd = IPAddress.IndexOf(CrLf);

                IPAddress = IPAddress.Substring(1, IPEnd - 2);

            }
            catch (Exception ex)
            {

                Console.WriteLine("Error: ParseIPAddress: " + ex.ToString());

            }

            return IPAddress;
        }

        /// <summary>
        ///     ''' Connect to the router and get the IP address
        ///     ''' IPAddress is parsed from PollSerialPort after connecting to router
        ///     ''' </summary>
        public void Connect(string SSID, string Password)
        {

            SendCommand("AT+CWMODE=1");

            SendCommand("AT+CWJAP=\"" + SSID + "\",\"" + Password + "\"");

            Thread.Sleep(CommandDelay);



            Thread.Sleep(1000);

            for (int i = 0; i < 4; i++)
            {
                // Get IP 
                SendCommand("AT+CIFSR");
                if (IPAddress != "Connecting!")
                {
                    break;
                }
            }

        }



        /// <summary>
        /// Set ESP8266 to TCP mode 
        /// Close the connection
        ///     ''' </summary>
        public void SetTime()
        {

            // Save the mode
            int tempCurrentMode = CurrentMode;

            CurrentMode = (int)Mode.TCPClient;

            string str = "HEAD / HTTP/1.1" + CrLf +
              "Host: google.com" + CrLf +
              "Accept */*" + CrLf +
              "User-Agent: Mozilla/4.0 (compatible; esp8266 Lua;)" + CrLf;

            // Set multiple connection
            SendCommand("AT+CIPMUX=1");

            // Set connection
            SendCommand("AT+CIPSTART=0,\"TCP\",\"google.com\",80");

            int Length = str.Length;

            // SendCommand adds CrLF
            Length += 2;

            // Send data with link ID and data length
            SendCommand("AT+CIPSENDBUF=0," + Length);

            SendCommand(str);

            SendCommand("AT+CIPCLOSE=0");

            CurrentMode = tempCurrentMode;

        }

        /// <summary>
        /// Send command to ESP8266
        /// </summary>
        /// <param name="Cmd"></param>
        /// String to send
        /// <param name="Expected"></param>
        /// Expected string returned from ESP8266
        public static void SendCommand(string Cmd, String Expected = "OK")
        {

            Thread.Sleep(1000);

            SendData(Cmd + CrLf);

            WaitForCommand(Expected);

        }


        /// <summary>
        /// Wait for the expected return string from ESP8266
        /// </summary>
        private static void WaitForCommand(String Expected)
        {
            int count = 0;

            while (count < 20)
            {
                if (InString(StringRead, Expected)) break;
                {
                    count++;

                    Thread.Sleep(CommandDelay / 20);

                }
            }
        }


        ///<summary>
        /// Returns True if a string is part of another
        /// </summary>
        private static bool InString(string String1, string StringToFind)
        {
            try
            {
                if (String1 == string.Empty)
                    return false;

                if (StringToFind == string.Empty)
                    return false;

                if (String1.IndexOf(StringToFind) == -1)
                    return false;

                else

                    return true;
            }
            catch
            {

                return false;

            }
        }
      
        /// <summary>
        /// Called from SendServerRequest
        /// </summary>
        private  void ProcessServerRequest(string Request)
        {

            if (InString(Request, "LED1Off=Off"))

            {

                Status = "LED 1 Off";
                                
                LED1.Write(GpioPinValue.Low);

                Console.WriteLine("LED 1 Off");

                return;
            }

            else if (InString(Request, "LED1On=On"))
            {

                Status = "LED 1 On";
                
                LED1.Write(GpioPinValue.High);

                Console.WriteLine("LED 1 On");

                return;
            }

            else if (InString(Request, "LED2Off=Off"))
            {

                Status = "LED 2 Off";

                LED2.Write(GpioPinValue.Low);
                
                Console.WriteLine("LED 2 Off");

                return;
            }

            else if (InString(Request, "LED2On=On"))
            {

                Status = "LED 2 On";
                
                LED2.Write(GpioPinValue.High);

                Console.WriteLine("LED 2 Off");

                return;
            }

            else if (InString(Request, "LED3Off=Off"))
            {

                Status = "LED 3 Off";
               
                LED3.Write(GpioPinValue.Low);

                Console.WriteLine("LED 3 Off");

                return;
            }

            else if (InString(Request, "LED3On=On"))
            {

                Status = "LED 3 On";

                LED3.Write(GpioPinValue.High);

                Console.WriteLine("LED 3 On");

                return;
            }

            else if (InString(Request, "LEDUserOff=Off"))
            {

                Status = "LED 4 Off";
                
                LEDUser.Write(GpioPinValue.Low);

                Console.WriteLine("LED 4 Off");

                return;
            }

            else if (InString(Request, "LEDUserOn=On"))
            {

                Status = "LED 4 On";

                LEDUser.Write(GpioPinValue.High);

                Console.WriteLine("LED 4 On");

                return;
            }

            else
            {

                Status = string.Empty;

                return;
            }

        }
        /// <summary>
        /// Puts chip in AP Mode 
        /// Default IP address is 192.168.4.1
        /// SSID is TRM 
        /// To set SSID, Password etc.
        /// Example: Select TRM as the WiFi Router
        /// Type http://192.168.4.1 in your browser
        /// Save the Password and SSID returned
        // Ref: https://github.com/espressif/ESP8266_AT/wiki/CWSAP
        /// </summary>
        public void StartAPMode()
        {
            SendCommand("AT+CWMODE=3");

            SendCommand("AT+CWSAP=\"TRM\",\"password\",1,4");

            CurrentMode = (int)Mode.TCPServer;

            // Used in SendServerRequest for request processing
            APServerMode = true;

        }


        /// <summary>
        /// Put ESP8266 in server mode
        /// </summary>
        public void StartServer()
        {
            try
            {
                CurrentMode = (int)Mode.TCPServer;

                // Multiple connections
                SendCommand("AT+CIPMUX=1");

                SendCommand("AT+CIPSERVER=1,80");

            }

            catch (Exception ex)
            {

                Console.WriteLine("Error: StartServer: " + ex.ToString());

            }

        }


        private void ESPDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {

                // Reset bytes read
                uint bytesRead = 0;

                //Got carrage return
                if (e.EventType == SerialData.WatchChar)
                {

                    //Make sure we have the complete server request
                    if (CurrentMode == (int)Mode.TCPServer)
                    {

                        Thread.Sleep(5);

                    }

                    // Set the device
                    SerialDevice sd = (SerialDevice)sender;

                    // New DataReader
                    using (DataReader dr = new DataReader(sd.InputStream))
                    {

                        dr.InputStreamOptions = InputStreamOptions.Partial;

                        // Clear buffer if sending requested data
                        if (CurrentMode == (int)Mode.TCPSending)
                        {
                            uint br = dr.Load(RMAX_BUFF);

                            // Buffer is empty put back in server mode to get more requests
                            if (br == 0)
                            {
                                CurrentMode = (int)Mode.TCPServer;

                                Console.WriteLine(CrLf + "Send complete server mode");

                            }


                        }

                        // Not sending a server request  
                        else

                        {

                            bytesRead = dr.Load(sd.BytesToRead);

                        }

                        // We have data bytes find out what to do with it
                        if (bytesRead > 0)
                        {
                            byte[] Data = new byte[bytesRead];

                            // Read data
                            dr.ReadBytes(Data);


                            // Convert the bytes to string
                            StringRead = string.Empty;
                            for (int i = 0; i < bytesRead - 1; i++)
                            {

                                char c = Convert.ToChar(Data[i]);

                                StringRead = StringRead + c.ToString();

                            }

                            switch (CurrentMode)
                            {

                                case (int)Mode.TCPServer:

                                    if (InString(StringRead, "+IPD"))
                                    {

                                        this.SendServerRequest();

                                    }

                                    break;

                                case (int)Mode.Connect:

                                    if (InString(StringRead, "STAIP,"))
                                    {

                                        IPAddress = ParseIPAddres(StringRead);

                                    }

                                    break;

                                case (int)Mode.TCPClient:

                                    if (InString(StringRead, "Date:"))
                                    {

                                        GetTimeFromString(StringRead);

                                    }

                                    break;

                            }
                            Console.WriteLine("String Received: >> " + StringRead);


                        }

                    }

                }

            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: ESPDataReceived: " + ex.ToString());

            }
        }

        private static void SendFavicon()
        {

            CurrentMode = (int)Mode.TCPSending;

            // Send this first
            string strResp = "HTTP/1.1 200 OK" + CrLf + "Content-Type: image/x-icon; charset = UTF - 8" +
                CrLf + "Cache - Control: no - cache" + CrLf + "Connection: close" + CrLf + CrLf;

            byte[] arr = Encoding.UTF8.GetBytes(strResp);

            SendData("AT+CIPSENDBUF=" + LinkedID + "," + arr.Length + CrLf);

            SendDataBytes(arr);

            Console.WriteLine("HTTP response length: >>" + arr.Length);

            // Send the image
            byte[] icon = WebPages.faviconpage();

            Console.WriteLine("Icon Length: >> " + icon.Length);

            int BytesSent = 0;

            int FileLength = icon.Length;

            while (BytesSent < FileLength)
            {

                int BytesToRead = FileLength - BytesSent;

                if (BytesToRead > SMAX_BUFF)
                {

                    BytesToRead = SMAX_BUFF;

                }

                SendData("AT+CIPSENDBUF=" + LinkedID + "," + BytesToRead + CrLf);

                //Array.
                //string DataToSend = srd.Substring(BytesSent, BytesToRead);

                byte[] DataToSend = new byte[SMAX_BUFF];

                //int index = Array.IndexOf(icon,BytesSent,BytesToRead );
                // Array.Copy(icon, index, DataToSend);
                Array.Copy(icon, BytesSent, DataToSend, 0, BytesToRead);


                //SendDatab(DataToSend);
                SendDataBytes(DataToSend);

                BytesSent += BytesToRead;

            }

            SendData("AT+CIPCLOSE=" + LinkedID + CrLf);

        }
    

        
        
        /// <summary>
        /// Sends the data requested 
        /// </summary>
        private void SendServerRequest()
        {

            try
            {
                string srd = string.Empty;

                string rstr = FindGetRequest();

                Console.WriteLine("Server Request: >> " + rstr);

                if (InString(rstr, "favicon"))
                {

                    // Console.WriteLine("HTTP/1.1 404 NOT FOUND\r\nConnection: close\r\nContent-Length: 0" + CrLf + CrLf);
                    SendFavicon();

                }

                else
                {


                    if (APServerMode)
                    {
                        //****** Proccess AP server request here
                        srd = WebPages.RouterSettingsPage();

                    }

                    else

                    {
                        //****** Process server request here
                        this.ProcessServerRequest(rstr);

                        srd = WebPages.DefaultPage(Status) + CrLf + CrLf;

                    }





                    CurrentMode = (int)Mode.TCPSending;

                    int BytesSent = 0;

                    int FileLength = srd.Length;

                    while (BytesSent < FileLength)
                    {

                        int BytesToRead = FileLength - BytesSent;

                        if (BytesToRead > SMAX_BUFF)
                        {

                            BytesToRead = SMAX_BUFF;

                        }

                        SendData("AT+CIPSENDBUF=" + LinkedID + "," + BytesToRead + CrLf);

                        string DataToSend = srd.Substring(BytesSent, BytesToRead);

                        SendData(DataToSend);

                        BytesSent += BytesToRead;

                    }

                    SendData("AT+CIPCLOSE=" + LinkedID + CrLf);

                }
            }

            catch (Exception ex)
            {

                Console.WriteLine("Error: SendServerRequest: " + ex.ToString());

            }
        }
            
            }
}
        

    




