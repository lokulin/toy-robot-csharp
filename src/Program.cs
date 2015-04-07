using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Reflection;

namespace com.lauchlin.toyrobot
{
    class MainClass
    {
        public static void SendCommand (Robot robot, string commandline)
        {
            Match match = Regex.Match (commandline, @"^([A-Z]+)( (\d),(\d),([A-Z]+)){0,1}$");
            if (match.Success) {
                string methodName = match.Groups [1].Value;
                MethodInfo method = typeof(Robot).GetMethod (methodName.Substring (0, 1) 
                    + methodName.Substring (1).ToLower ());
                if (method != null && method.DeclaringType == typeof(Robot)) {
                    if (method.GetParameters ().Length == 0) {
                        method.Invoke (robot, null);
                    } else {
                        object[] args = {   Int32.Parse(match.Groups[3].Value), 
                            Int32.Parse(match.Groups[4].Value), 
                            match.Groups[5].Value
                        };
                        method.Invoke (robot, args);
                    }
                }
            }
        }

        public static void Main (string[] args)
        {
            try {
                if (args.Length == 1) {
                    Robot robot = new Robot (new Table (new Point (0, 0), new Point (4, 4)));
                    foreach (string readLine in File.ReadLines(args[0]))
                        SendCommand (robot, readLine);
                } else {
                    Console.WriteLine ("usage: toyrobot <input.txt>");
                }
            } catch (System.IO.IOException) {        
                Console.WriteLine ("File not found.");
            }
        }
    }
}
