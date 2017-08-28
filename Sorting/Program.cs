using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main()
        {
            #region
            ////created a sorted set of strings
            //var Set = new SortedSet<string>();
            ////Add elements
            //Set.Add("Jesus");
            //Set.Add("Loves");
            //Set.Add("Loves");//duplicate elements are ignored
            //Set.Add("L");
            //Set.Add("Beulah");

            ////remove
            //Set.Remove("L");

            //foreach (var v in Set)
            //{
            //    Console.WriteLine(v);
            //}
            #endregion

            #region
            //Bubblesort - slowest sort as moving manytimes
            //float like a bubble
            //comparing adjacent values and swapping them if the value to the left is greater than the value to the right.
            CArray nums = new CArray(10);
            Random rnd = new Random(100);
            for (int i = 0; i < 9; i++)
                nums.Insert((int)(rnd.NextDouble() * 100));
            #endregion
            #region
            //Bubble sort
            Console.WriteLine("Before sorting: Bubble sort");
            nums.DisplayElements();
            Console.WriteLine();
            Console.WriteLine("During sorting: Bubble sort");
            nums.BubbleSort();
            Console.WriteLine("After sorting: Bubble sort");
            nums.DisplayElements();
            #endregion

            #region
            //selection sort
            Console.WriteLine("\nBefore sorting: Selection sort");
            nums.DisplayElements();
            Console.WriteLine();
            Console.WriteLine("During sorting:  Selection sort");
            nums.SelectionSort();
            Console.WriteLine("After sorting:  Selection sort");
            nums.DisplayElements();
            #endregion
            #region
            //Insertion sort
            Console.WriteLine("\nBefore sorting:Insertion sort ");
            nums.DisplayElements();
            Console.WriteLine();
            Console.WriteLine("During sorting:Insertion sort ");
            nums.InsertionSort();
            Console.WriteLine("After sorting:Insertion sort ");
            nums.DisplayElements();
            #endregion
            #region
            //Quick sort
            Console.WriteLine("\nBefore sorting:Quick sort ");
            nums.DisplayElements();
            Console.WriteLine();
            Console.WriteLine("During sorting:Quick sort ");
            nums.quickSort();
            Console.WriteLine("After sorting:Quick sort");
            nums.DisplayElements();
            #endregion
            Console.ReadKey();
        }
    }
    class CArray
    {
        private int[] arr;
        private int upper;
        private int numElements;
        public CArray(int size)
        {
            arr = new int[size];
            upper = size - 1;
            numElements = 0;
        }
        public void Insert(int item)
        {
            arr[numElements] = item;
            numElements++;
        }
        public void DisplayElements()
        {
            for (int i = 0; i <= upper; i++)
                Console.Write(arr[i] + " ");
        }
        public void Clear()
        {
            for (int i = 0; i <= upper; i++)
                arr[i] = 0;
            numElements = 0;
        }
        //Bubblesort - slowest sort as moving manytimes
        //float like a bubble
        //comparing adjacent values and swapping them if the value to the left is greater than the value to the right.
        public void BubbleSort()
        {
            int temp;
            //the outer loop starts at the end of the array
            // and moves toward the beginning of the array.
            for (int outer = upper; outer >= 1; outer--)
            {
                // The inner loop starts at the first element of the array and ends when it
                // gets to the next to last position in the array.
                for (int inner = 0; inner <= outer - 1; inner++)
                {
                    //The inner loop compares the
                    // two adjacent positions indicated by inner and inner +1, swapping them if
                    //necessary.
                    if (arr[inner] > arr[inner + 1])
                    {
                        temp = arr[inner];
                        arr[inner] = arr[inner + 1];
                        arr[inner + 1] = temp;
                    }
                }
                //we can examine how the array changes during the sorting between inner loop and outer loop by display method
                //for viewing a record of how the values move through the array while they are being sorted.
                DisplayElements();
                Console.WriteLine();
            }
        }
        /*This sort works by starting at
the beginning of the array, comparing the first element with the other elements
in the array. The smallest element is placed in position 0, and the sort then
begins again at position 1. This continues until each position except the last
position has been the starting point for a new loop.
Two loops are used in the SelectionSort algorithm. The outer loop moves
from the first element in the array to the next to last element, whereas the inner
loop moves from the second element of the array to the last element, looking
for values that are smaller than the element currently being pointed at by the
outer loop. After each iteration of the inner loop, the most minimum value
in the array is assigned to its proper place in the array*/
        public void SelectionSort()
        {
            int min, temp;
            for (int outer = 0; outer <= upper; outer++)
            {
                min = outer;
                for (int inner = outer + 1; inner <= upper; inner++)
                    if (arr[inner] < arr[min])
                        min = inner;
                temp = arr[outer];
                arr[outer] = arr[min];
                arr[min] = temp;
                DisplayElements();
                Console.WriteLine();
            }
        }
        //The Insertion sort is an analog to the way we normally sort things numerically
        //or alphabetically
        /*The outer loop moves element by element
through the array whereas the inner loop compares the element chosen in the
outer loop to the element next to it in the array. If the element selected by the
outer loop is less than the element selected by the inner loop, array elements
are shifted over to the right to make room for the inner loop element*/
        public void InsertionSort()
        {
            int inner, temp;
            for (int outer = 1; outer <= upper; outer++)
            {
                temp = arr[outer];
                inner = outer;
                while (inner > 0 && arr[inner - 1] >= temp)
                {
                    arr[inner] = arr[inner - 1];
                    inner -= 1;
                }
                arr[inner] = temp;
                this.DisplayElements();
                Console.WriteLine();
            }
        }


        /** Quick sort function **/
        /* This function takes last element as pivot, places
   the pivot element at its correct position in sorted
    array, and places all smaller (smaller than pivot)
   to left of pivot and all greater elements to right
   of pivot */
        public void quickSort()
        {
            int i = 0, j = upper;
            int temp;
            int pivot = arr[(i + j) / 2];

            /** partition **/
            while (i <= j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    /** swap **/
                    temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;

                    i++;
                    j--;
                    DisplayElements();
                    Console.WriteLine();
                }

            }

            /** recursively sort lower half **/
            if (i < j)
                quickSort();
            /** recursively sort upper half **/
            if (i < j)
                quickSort();
        }

    }
}
