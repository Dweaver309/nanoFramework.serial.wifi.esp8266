
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



    }
}
