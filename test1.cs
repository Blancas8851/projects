namespace eIntern {     
    class Robot {
        string type;
        double speed;
        public void SetRobot(double speed) {
            type = "hover";
            speed = speed;
        }
        public void Output() {
            Console.WriteLine(type +"bot has speed " + speed);
        }
    }
    class Program {
        static void Main(string[] args) {
            Robot droid = new Robot();
            droid.SetRobot(32);
            droid.Output();
        }
    }
}