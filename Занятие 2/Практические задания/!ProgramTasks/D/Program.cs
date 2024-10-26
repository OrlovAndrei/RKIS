
﻿
using System;

namespace D
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Test(true, "boss", 150); 
            Test(true, "boss", 30); 
            Test(true, "boss", 70);  
            Test(false, "boss", 14);  
            Test(true, "bot", 90);    
            Test(false, "bot", 100000); 
        }

        public static void Test(bool enemyInFront, string enemyName, int robotHealth)
        {
            Console.WriteLine(ShouldFire(enemyInFront, enemyName, robotHealth) == ShouldFire2(enemyInFront, enemyName, robotHealth));
        }

        public static bool ShouldFire(bool enemyInFront, string enemyName, int robotHealth)
        {
            if (!enemyInFront)
            {
                return false; 
            }

            if (enemyName == "boss")
            {
                if (robotHealth < 50) return false; 
                if (robotHealth > 100) return true; 
            }

            return false;
        }

        public static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            return enemyInFront && (enemyName != "boss" || robotHealth > 50);
            //я не понимаю почему код упорно выдает True на 14. Я уже не знаю, что с ним сделать:(
        }
    }
}
