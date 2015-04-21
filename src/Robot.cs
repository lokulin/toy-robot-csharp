using System;

namespace com.lauchlin.toyrobot
{
    public class Robot
    {
        private Table table;
        private Point location = new Point(0,0);
        private int facing = -1;
        private string[] DIRECTIONS = {"NORTH", "EAST", "SOUTH", "WEST"}; 

        public Robot (Table table)
        {
            this.table = table;
        }

        public void Move()
        {
            if (Placed () && table.Contains (LookingAt ())) {
                location = LookingAt ();
            }
        }

        public void Left()
        {
            // Floored mod
            facing = Placed() ? (((facing -1) % 4) + 4) % 4 : facing;
        }

        public void Right()
        {
            facing = Placed() ? (facing + 1)%4 : facing;
        }

        public void Report() {
            if (Placed()) {
                Console.WriteLine (location.x + "," + location.y + "," + DIRECTIONS[facing]);
            }
        }

        public void Place(int x, int y, string direction) {
            if (table.Contains(new Point(x,y)) && Array.IndexOf (DIRECTIONS, direction) != -1) {
                this.location = new Point (x, y);
                this.facing = Array.IndexOf (DIRECTIONS, direction);
            }
        }

        private Point LookingAt() {
            int nx = (int) Math.Round (Math.Sin (Math.PI * facing / 2.0));
            int ny = (int) Math.Round (Math.Cos (Math.PI * facing / 2.0));
            return location.plus(new Point(nx,ny));
        }

        private bool Placed() {
            return facing != -1;
        }

    }
}
