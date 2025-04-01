using C_.Concepts.Helpers;

namespace C_.Concepts
{
    public class ArraySpecs
    {
        [Fact]
        public void ReverseArray()
        {
            int[] array = new int[]  { 5, 2, 9, 1, 5, 6 };
            var reverse = array.Reverse().ToArray();
            for(int i=0; i<array.Length; i++)
            {
                Assert.Equal(array[i], reverse[reverse.Length-i-1]);
            }
            Assert.Equal(reverse.Last(), array.First());
        }

        [Fact]
        public void CloneArray()
        {
            int[] array = new CustomArray().GetIntegers();
            var array2 = array.Clone();
            Assert.Equal(array, array2);
        }

                [Fact]
        public void SetValueArray()
        {
            int[] array = new CustomArray().GetIntegers();
            array.SetValue(22, 5);
            Assert.Equal(22, array[5]);
        }

        [Fact]
        public void GetValueArray()
        {
            int[] array = new CustomArray().GetIntegers();
            object val = array.GetValue(3);
            Assert.Equal(1, val);
        }

        [Fact]
        public void IndexOfArray()
        {
            int[] array = new CustomArray().GetIntegers();
            int number = Array.IndexOf(array, 5);
            int number2 = Array.IndexOf(array, 9);
            Assert.Equal(0, number);
            Assert.Equal(2, number2);
        }

        [Fact]
        public void ClearArray()
        {
            int[] array = new CustomArray().GetIntegers();
            Array.Clear(array);
            Assert.Equal(0, array[0]);
            Assert.Equal(0, array[3]);

            string[] array2 = new CustomArray().GetStrings();
            Array.Clear(array2);
            Assert.Null(array2[0]);
            Assert.Null(array2[3]);

            object[] array3 = new CustomArray().GetMixedArray();
            Array.Clear(array3);
            Assert.Null(array3[0]);
            Assert.Null(array3[3]);
        }

        [Fact]
        public void SortArray()
        {
            int[] array = new CustomArray().GetIntegers();
            Array.Sort(array);
            Assert.Equal(1, array[0]);
            Assert.Equal(2, array[1]);
            Assert.Equal(5, array[2]);
            Assert.Equal(5, array[3]);
        }


        [Fact]
        public void SortCustomArray()
        {
            var customArray = new CustomArray();
            var arrayInt = customArray.GetIntegers();
            customArray.Sort(arrayInt);

            Assert.Equal(1, arrayInt[0]);
            Assert.Equal(2, arrayInt[1]);
            Assert.Equal(5, arrayInt[2]);
        }

        [Fact]
        public void ReverseCustomArray()
        {
            var customArray = new CustomArray();
            var arrayInt = customArray.GetIntegers();
            var reverse = customArray.Reverse(arrayInt);

            //Assert.Equal(6, arrayInt[0]);
            //Assert.Equal(5, arrayInt[1]);
            //Assert.Equal(1, arrayInt[2]);
        }
    }
}
//All arays are referebced types
//An array size is fixed, canot change
//if you need a big array, you need to copy all elements to the new array
//Array is allocated in the heap, creation of array happens upon using new
//ARrays are zero-based always start in 0 index