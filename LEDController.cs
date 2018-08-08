using System;
using Windows.Devices.Gpio;


    class LEDController
    {

        // User pin number
        const int LedNumber = 10;
        
        // Go Ports pin numbers
        const int Led1Number = 73;
        const int Led2Number = 75;
        const int Led3Number = 78;

        // Leds to toggle
        public static GpioPin  LEDUser = GpioController.GetDefault().OpenPin(LedNumber);

        public static GpioPin LED1 = GpioController.GetDefault().OpenPin(Led1Number);

        public static GpioPin LED2 = GpioController.GetDefault().OpenPin(Led2Number);

        public static GpioPin LED3 = GpioController.GetDefault().OpenPin(Led3Number);

        public static Boolean PinOn = false;

        private static Boolean Initialized = false;

        private static void Initialize()
        {

            LEDUser.SetDriveMode(GpioPinDriveMode.Output);

            LED1.SetDriveMode(GpioPinDriveMode.Output);

            LED2.SetDriveMode(GpioPinDriveMode.Output);

            LED3.SetDriveMode(GpioPinDriveMode.Output);

        }

        /// <summary>
        /// Toggles Netduino 3 LED's
        /// <param name="LEDGpioPin"></param>
        /// LED to toggle
        /// <param name="On"></param>
        /// true or false
        public static void ToggleLED(GpioPin LEDGpioPin, Boolean On)
        {
            if(Initialized == false)
            {
                Initialize();

                Initialized = true;

            }


            if (On)
            {

                LEDGpioPin.Write(GpioPinValue.High);

            }

            else

            { 

                LEDGpioPin.Write(GpioPinValue.Low);

            }

        }
 
    }

