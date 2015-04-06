using System;
using System.IO;

namespace com.lauchlin.toyrobot
{
    class MainClass
    {

        public static void Main (string[] args)
        {
            Robot robot = new Robot (new Table(new Point(0,0), new Point(4,4)));
            foreach (string readLine in File.ReadLines("../../examples/example5.txt")) {
                robot.SendCommand(readLine);
            }
        }
    }
}
