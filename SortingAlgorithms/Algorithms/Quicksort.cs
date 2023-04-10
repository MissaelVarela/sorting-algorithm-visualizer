using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    public class Quicksort<T> : Algorithm<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();

            Metodo(0, array.Length - 1);

            TakeSnapshot();
            return array;
        }

        private void Metodo(int left, int right)
        {   
            int pivot;
            if (left < right)
            {
                TakeSnapshot();
                pivot = Partition(left, right);
                if (pivot > 1)//Si el lado izq tiene 2 o mas elementos
                {
                    Metodo(left, pivot - 1);
                }
                if (pivot + 1 < right)//Si el lado der tiene 2 o mas elementos.
                {
                    Metodo(pivot + 1, right);
                }
            }      
        }

        private int Partition(int left, int right)
        {   
            T pivot;
            pivot = array[left];
            TakeSnapshot(left);

            while (true)
            {
                while (ComparisonMethod(pivot, array[left])) left++;
                while (ComparisonMethod(array[right], pivot)) right--;
                if (left < right)
                {
                    if (array[left].Equals(array[right])) return right;
                    Swap(right, left);
                    TakeSnapshot(right);
                }
                else
                {
                    return right;
                }
            }
        }
    }
}
