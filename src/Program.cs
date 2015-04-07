using System;
using System.IO;

namespace com.lauchlin.toyrobot
{
    class MainClass
    {

        public static void Main (string[] args)
        {
            if (args.Length == 1) {
                Robot robot = new Robot (new Table (new Point (0, 0), new Point (4, 4)));
                foreach (string readLine in File.ReadLines(args[0]))
                    robot.SendCommand (readLine);
            } else {
                Console.WriteLine ("usage: toyrobot <input.txt>");
            }
        }
    }
}
