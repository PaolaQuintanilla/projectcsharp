namespace C_.Concepts.Helpers
{
    using System;

    public class CustomArray
    {
        int[] numbers = { 5, 2, 9, 1, 5, 6 };
        string[] fruits = { "Apple", "Banana", "Cherry", "Date" };
        object[] mixedArray = { 1, "Hello", 3.14, true };
        public string[] GetStrings()
        {
            return fruits;
        }
        public object[] GetMixedArray()
        {
            return mixedArray;
        }
        public int[] GetIntegers()
        {
            return numbers;

        }

        internal void Sort(int[] arrayInt)
        {
            for(int i = 0; i < arrayInt.Length-1; i++)
            {
                var currentVal = arrayInt[i];
                for(int j = i+1; j < arrayInt.Length; j++)
                {
                    if (arrayInt[j] < currentVal)
                    {
                        arrayInt[i] = arrayInt[j];
                        arrayInt[j] = currentVal;
                        currentVal = arrayInt[i];
                    }
                }
            }
        }

        internal int[] Reverse(int[] arrayInt)
        {
            for (int i = 0;i < arrayInt.Length - 1; i++)
            {

            }
            return arrayInt;
        }
    }

}
