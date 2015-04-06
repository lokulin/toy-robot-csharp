namespace com.lauchlin.toyrobot
{
    public struct Table
    {
        private Point lowerLeftCorner;
        private Point upperRightCorner;

        public Table (Point lowerLeftCorner, Point upperRightCorner)
        {
            this.lowerLeftCorner = lowerLeftCorner;
            this.upperRightCorner = upperRightCorner;
        }

        public bool Contains(Point p) {
            return p >= lowerLeftCorner && p <= upperRightCorner;
        }
    }
}

