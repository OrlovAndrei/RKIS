        public static int MaxIndex(double[] array)
        {
            var max = double.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (max < array[i])
                {
                    max = array[i];
                    index = i;
                }
            }
            return index;
        }
    }
}
