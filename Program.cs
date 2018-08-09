
//************
//
// This code was tested using 
//
//************
//
// ESP8266 Serial WIFI Witty ESP-12F
//
// When connected to my computer 5 volts were required
//
// Firmware version
// AT version:1.3.0.0(Jul 14 2016 18:54:01)
// SDK version:2.0.0(5a875ba)
// v1.0.0.3
// Mar 13 2018 09:37:06
//
//***********
//
// ESP-WROOM-S2 Wireless Wi-Fi Module
//
// When connected to my computer 3.3 volts were adequate
//
// Firmware version
// AT version:1.1.0.0(May 11 2016 18:09:56)
// SDK version:1.5.4(baaeaebb)
// compile time:May 20 2016 15:31:17
//
//*************



using System;
using System.Threading;
using nanoframework.serial.driver;
using Windows.Devices.Gpio;

namespace nanoframework.serial
{
    public class Program
    {
        const string CrLf = "\r\n";

        public static void Main()
        {
           
           // Netduino 3 D7 pin
           // PinNumber is a local method
           GpioPin D7 = GpioController.GetDefault().OpenPin(PinNumber('A', 1));

           // Netduino 3 D8 pin
           GpioPin D8 = GpioController.GetDefault().OpenPin(PinNumber('A', 0));

           // Local method not used in testing 
           // Use if needed
           // ResetDevice(D7, D8);
          
           // Constructor for ESP8266 serial WiFi
           WiFi ESP8266 = new WiFi();

            // Get firmware version
            ESP8266.GetVersion();


           ESP8266.Connect("SSID", "Password");

            //***Rem Uncomment to set time
            //ESP8266.SetTime();
           
            ESP8266.StartServer();

            //***Rem Uncomment for AP mode
           // ESP8266.StartAPMode();

          Console.WriteLine("IP Address: >> " + ESP8266.GetIPAddress());

            while (true)
                {

                Thread.Sleep(1000);

                 }
        }
   
        /// <summary>
        /// GH_PD must be pulled high to enable the signal
        /// GPIO0 must be pulled high, if set to low the chip will be in flash boot mode 
        /// Toggle the pins to reset the chip
        /// </summary>
        private static void ResetDevice(GpioPin GIO0CpuPin, GpioPin CH_PDCpuPin)
        {

            GIO0CpuPin.SetDriveMode(GpioPinDriveMode.Output);

            CH_PDCpuPin.SetDriveMode(GpioPinDriveMode.Output);

           GIO0CpuPin.Write(GpioPinValue.Low);

            CH_PDCpuPin.Write(GpioPinValue.Low);

            Thread.Sleep(2000);

            GIO0CpuPin.Write(GpioPinValue.High);

            CH_PDCpuPin.Write(GpioPinValue.High);

            Thread.Sleep(2000);

        }
       
        static int PinNumber(char port, byte pin)
        {

            if (port < 'A' || port > 'J')
            {

                throw new ArgumentException();

            }

            return ((port - 'A') * 16) + pin;

        }

    }

}


