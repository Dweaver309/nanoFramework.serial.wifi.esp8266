﻿
namespace nanoframework.serial
{
    class WebPages
    {
        private const string CrLf = "\r\n";

        public static string DefaultPage(string Status)
        {
           
            string t = string.Empty;

            t += CrLf + "<html>";
            t += CrLf + "<head>";
            t += CrLf + "<meta http-equiv=\"Content-Language\" content=\"en-us\">";
            t += CrLf + "<meta http-equiv=\"Content-Type\" content=\"text/html; charset=windows-1252\">";
            t += CrLf + "<meta name=\"theme-color\" content=\"#ffffff\">";
            t += CrLf + "<span style=\"color:Gray;background-color:Transparent;border-color:White;font-family:Arial;font-size:Medium; left: 32px; position: absolute; top: 8px\">";
            t += CrLf + "</span>";
            t += CrLf + "<title>LED Controler</title>";
            t += CrLf + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\">";
            t += CrLf + "</head>";
            t += CrLf + "<body>";
            t += CrLf + "<form method=\"GET\" action=\"default.html\">";
            t += CrLf + "	<p align=\"left\"><font face=\"Arial\" size=\"4\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ";
            t += CrLf + "	LED Controller</font></p>";
            t += CrLf + "	<p><font face=\"Arial\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LED 1:&nbsp;&nbsp; </font><input type=\"submit\" value=\"On\" name=\"LED1On\">&nbsp;&nbsp;&nbsp;";
            t += CrLf + "	<font face=\"Arial\">";
            t += CrLf + "	<input type=\"submit\" value=\"Off\" name=\"LED1Off\">&nbsp;&nbsp; </font></p>";
            t += CrLf + "	<p><font face=\"Arial\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp; LED 2:&nbsp;&nbsp; </font>";
            t += CrLf + "	<input type=\"submit\" value=\"On\" name=\"LED2On\">&nbsp; &nbsp;";
            t += CrLf + "	<font face=\"Arial\">";
            t += CrLf + "	<input type=\"submit\" value=\"Off\" name=\"LED2Off\">&nbsp;&nbsp;</font></p>";
            t += CrLf + "	<p><font face=\"Arial\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LED 3:&nbsp;&nbsp; </font>";
            t += CrLf + "	<input type=\"submit\" value=\"On\" name=\"LED3On\">&nbsp;&nbsp;&nbsp;";
            t += CrLf + "	<font face=\"Arial\">";
            t += CrLf + "	<input type=\"submit\" value=\"Off\" name=\"LED3Off\">&nbsp;&nbsp; </font></p>";
            t += CrLf + "	<p><font face=\"Arial\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; LED 4:&nbsp;&nbsp; </font>";
            t += CrLf + "	<input type=\"submit\" value=\"On\" name=\"LEDUserOn\">&nbsp;&nbsp;&nbsp;";
            t += CrLf + "	<font face=\"Arial\">";
            t += CrLf + "	<input type=\"submit\" value=\"Off\" name=\"LEDUserOff\">&nbsp;&nbsp; </font></p>";
            t += CrLf + "	</form>";
            t += CrLf + "	<p align=\"left\"><font face=\"Arial\" size=\"4\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; ";
            t += CrLf + Status + " </ font ></ p > ";
            t += CrLf + "<p>&nbsp;</p>";
            t += CrLf + "</body>";
            t += CrLf + "</html>";


            return t;
        }

        public static string RouterSettingsPage()
        {
            string t = string.Empty;

            // t += "<html xmlns=""http://www.w3.org/1999/xhtml"" >"
            t += CrLf + "<head><title>";
            t += CrLf + "	Router Settings";
            t += CrLf + "</title></head>";
            t += CrLf + "<meta name=\"viewport\" content=\"width=device-width; initial-scale=1.0; maximum-scale=1.0;\"></head>";
            t += CrLf + "<body bgcolor=\"whitesmoke\">";
            t += CrLf + "    <form name=\"form1\" method=\"get\" action=\"RouterSettings.html\" id=\"form1\">";
            t += CrLf + "    <div>";
            t += CrLf + "        <span style=\"color:Gray;background-color:Transparent;border-color:White;font-family:Arial;font-size:Medium; left: 16px; position: absolute; top: 8px\">";
            t += CrLf + "</span>";
            // Title
            t += CrLf + "        <span style=\"display:inline-block;font-family:Arial;font-size:Large;width:200px;";
            t += CrLf + "            left: 30px; position: absolute; top: 16px\">Router Settings</span>";
            // SSID
            t += CrLf + "        <span  style=\"font-family:Arial;z-index: 100; left: 16px;";
            t += CrLf + "            position: absolute; top: 56px\">SSID:</span>";
            t += CrLf + "        <input name=\"SSID\" type=\"text\" value=\"\"  style=\"width:120px;z-index: 101; left: 120px; position: absolute;";
            t += CrLf + "            top: 56px\" />";

            // Password
            t += CrLf + "        <span  style=\"display:inline-block;font-family:Arial;width:168px;z-index: 103; left: 16px;";
            t += CrLf + "            position: absolute; top: 96px\">Password:</span>";
            t += CrLf + "        <input name=\"Password\" type=\"text\" value=\"\"  style=\"width:120px;z-index: 104; left: 120px; position: absolute;";
            t += CrLf + "            top: 96px\" />";

            // Save SSID
            t += CrLf + "        <input type=\"submit\" name=\"Save\" value=\"Save\"  style=\"width:104px;z-index: 102; left: 120px; position: absolute;";
            t += CrLf + "            top: 146px\" />";
            t += CrLf + "    ";
            t += CrLf + "    </div>";
            t += CrLf + "    </form>";
            t += CrLf + "</body>";
            t += CrLf + "</html>";
            t += CrLf + CrLf;

            return t;
        }

        /// <summary>
        /// icon converted to hex 
        /// Converted online from http://tomeko.net/online_tools/file_to_hex.php?lang=en
        /// Convert to byte array
        /// </summary>
        /// <returns></returns>
        public static byte[] faviconpage()
        {
            byte[] favicon = {0x00, 0x00, 0x01, 0x00, 0x01, 0x00, 0x10, 0x10, 0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x68, 0x04,
0x00, 0x00, 0x16, 0x00, 0x00, 0x00, 0x28, 0x00, 0x00, 0x00, 0x10, 0x00, 0x00, 0x00, 0x20, 0x00,
0x00, 0x00, 0x01, 0x00, 0x20, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x04, 0x00, 0x00, 0x12, 0x0B,
0x00, 0x00, 0x12, 0x0B, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFE, 0xFD,
0xFC, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xE3, 0xD7, 0xD0, 0xFF, 0x97, 0x65, 0x41, 0xFF, 0x92, 0x65,
0x47, 0xFF, 0xE5, 0xDC, 0xD7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xB8, 0x7A, 0x3F, 0xFF, 0xC7, 0x76, 0x0E, 0xFF, 0xA3, 0x53,
0x00, 0xFF, 0x90, 0x60, 0x41, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xF9, 0xF7, 0xF7, 0xFF, 0xD6, 0x96, 0x46, 0xFF, 0xFF, 0xCD, 0x59, 0xFF, 0xDC, 0x91,
0x25, 0xFF, 0x94, 0x5A, 0x2F, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE,
0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF0, 0xDC, 0xC3, 0xFF, 0xE1, 0xA6, 0x4F, 0xFF, 0xBF, 0x7F,
0x36, 0xFF, 0xDB, 0xC9, 0xBD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFC, 0xFB, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xE0, 0xC5, 0xAC, 0xFF, 0xED, 0xDA, 0xC5, 0xFF, 0xFA, 0xFD, 0xFF, 0xFF, 0xF9, 0xFC,
0xFF, 0xFF, 0xF3, 0xE3, 0xC4, 0xFF, 0xE9, 0xD4, 0xB3, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF2, 0xEA,
0xE3, 0xFF, 0xC0, 0x62, 0x0A, 0xFF, 0xD6, 0x7C, 0x0B, 0xFF, 0xEB, 0xB6, 0x62, 0xFF, 0xEE, 0xBD,
0x65, 0xFF, 0xF1, 0xAC, 0x15, 0xFF, 0xEF, 0xB0, 0x1D, 0xFF, 0xF9, 0xF4, 0xED, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFE, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDE, 0xCF, 0xC8, 0xFF, 0xF7, 0xF5,
0xF6, 0xFF, 0xEF, 0xCE, 0xA6, 0xFF, 0xD9, 0x85, 0x1B, 0xFF, 0xE1, 0x83, 0x00, 0xFF, 0xED, 0x97,
0x02, 0xFF, 0xF7, 0xB8, 0x2C, 0xFF, 0xFF, 0xEF, 0xB7, 0xFF, 0xF4, 0xF3, 0xF4, 0xFF, 0xE5, 0xD9,
0xCB, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFD, 0xFB,
0xFA, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xDC, 0xC9, 0xBD, 0xFF, 0x9A, 0x3C, 0x00, 0xFF, 0xC1, 0x86,
0x54, 0xFF, 0xF2, 0xF1, 0xF1, 0xFF, 0xFB, 0xFA, 0xFA, 0xFF, 0xF5, 0xE5, 0xD2, 0xFF, 0xF7, 0xE8,
0xD3, 0xFF, 0xFB, 0xFA, 0xFA, 0xFF, 0xEC, 0xE9, 0xF1, 0xFF, 0xE1, 0xBE, 0x69, 0xFF, 0xE8, 0xBA,
0x25, 0xFF, 0xF1, 0xE6, 0xCE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFB, 0xFF, 0xFD, 0xFC,
0xFC, 0xFF, 0xF3, 0xF2, 0xF3, 0xFF, 0xF5, 0xED, 0xE6, 0xFF, 0xBC, 0x75, 0x34, 0xFF, 0xB1, 0x4C,
0x00, 0xFF, 0xC3, 0x6B, 0x12, 0xFF, 0xE1, 0xAB, 0x62, 0xFF, 0xF2, 0xD1, 0x99, 0xFF, 0xF2, 0xD6,
0xA0, 0xFF, 0xEB, 0xC3, 0x7A, 0xFF, 0xED, 0xB3, 0x2D, 0xFF, 0xFD, 0xC6, 0x15, 0xFF, 0xFF, 0xE3,
0x69, 0xFF, 0xFE, 0xFC, 0xF0, 0xFF, 0xF0, 0xEC, 0xEE, 0xFF, 0xFD, 0xFD, 0xFD, 0xFF, 0xC5, 0xAC,
0x9E, 0xFF, 0x81, 0x3D, 0x10, 0xFF, 0xD5, 0xC2, 0xB7, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xD6, 0xAC,
0x86, 0xFF, 0xC3, 0x6C, 0x18, 0xFF, 0xCF, 0x6B, 0x00, 0xFF, 0xE0, 0x7F, 0x01, 0xFF, 0xEB, 0x93,
0x00, 0xFF, 0xF4, 0xA4, 0x04, 0xFF, 0xF9, 0xBA, 0x2B, 0xFF, 0xFD, 0xE1, 0x9B, 0xFF, 0xFC, 0xFF,
0xFF, 0xFF, 0xE2, 0xD2, 0xB8, 0xFF, 0xDE, 0xB6, 0x47, 0xFF, 0xEA, 0xDB, 0xB9, 0xFF, 0xC6, 0xAA,
0x95, 0xFF, 0x7E, 0x31, 0x00, 0xFF, 0x8C, 0x3B, 0x03, 0xFF, 0xBD, 0x94, 0x76, 0xFF, 0xF2, 0xF3,
0xF6, 0xFF, 0xF7, 0xF8, 0xFA, 0xFF, 0xEB, 0xD9, 0xCC, 0xFF, 0xE9, 0xCA, 0xAB, 0xFF, 0xEE, 0xCF,
0xAC, 0xFF, 0xF4, 0xE2, 0xCE, 0xFF, 0xF7, 0xF4, 0xFB, 0xFF, 0xEA, 0xE8, 0xF1, 0xFF, 0xD9, 0xBE,
0x81, 0xFF, 0xF1, 0xCB, 0x3E, 0xFF, 0xFF, 0xE1, 0x51, 0xFF, 0xFB, 0xEC, 0xBE, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xD8, 0xC3, 0xB3, 0xFF, 0x9C, 0x54, 0x18, 0xFF, 0x9C, 0x3F, 0x00, 0xFF, 0xAC, 0x59,
0x11, 0xFF, 0xCF, 0x99, 0x60, 0xFF, 0xEB, 0xCD, 0xA3, 0xFF, 0xF5, 0xE2, 0xC0, 0xFF, 0xF5, 0xE3,
0xC2, 0xFF, 0xEE, 0xD6, 0xAA, 0xFF, 0xE3, 0xBC, 0x6D, 0xFF, 0xE7, 0xB3, 0x28, 0xFF, 0xFB, 0xD2,
0x28, 0xFF, 0xFF, 0xE3, 0x5F, 0xFF, 0xFD, 0xF2, 0xCF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD,
0xFC, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF4, 0xED, 0xE8, 0xFF, 0xCB, 0xA0, 0x7A, 0xFF, 0xB9, 0x6A,
0x20, 0xFF, 0xBE, 0x5B, 0x00, 0xFF, 0xD1, 0x6C, 0x00, 0xFF, 0xE2, 0x85, 0x00, 0xFF, 0xEC, 0x97,
0x00, 0xFF, 0xF3, 0xA5, 0x02, 0xFF, 0xFB, 0xB4, 0x0D, 0xFF, 0xFF, 0xD0, 0x41, 0xFF, 0xFD, 0xE9,
0x9B, 0xFF, 0xFE, 0xFA, 0xEF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFD, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFE, 0xFD, 0xFC, 0xFF, 0xFE, 0xFE, 0xFE, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0xF6, 0xF1,
0xEE, 0xFF, 0xE4, 0xCA, 0xB5, 0xFF, 0xDF, 0xB2, 0x86, 0xFF, 0xE3, 0xAE, 0x6E, 0xFF, 0xEA, 0xB8,
0x70, 0xFF, 0xF2, 0xCA, 0x8C, 0xFF, 0xF6, 0xDF, 0xBB, 0xFF, 0xFB, 0xF7, 0xF1, 0xFF, 0xFF, 0xFF,
0xFF, 0xFF, 0xFF, 0xFF, 0xFE, 0xFF, 0xFF, 0xFF, 0xFD, 0xFF, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, };

            return favicon;
        }

    }
}
