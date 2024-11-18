public static int[] GetFirstEvenNumbers(int count)
        {
            var array = new int[count];
            for (int i = 0; i < array.Length; i++)
                array[i] = 2*(i+1);
            return array;
        }

    }

