
        }

        public static bool ShouldFire2(bool enemyInFront, string enemyName, int robotHealth)
        {
            return enemyInFront && enemyName != "boss" || enemyInFront && (enemyName == "boss" && robotHealth >= 50);
        }
    }
}