using System;
using System.Collections.Generic;


namespace SortingAlgorithms.Algorithms
{
    public class Comb<T> : Bubble<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            int gap = array.Length;
            bool swapped = true;
            while (gap > 1 || swapped)
            {
                if (gap != 1) gap = (int)(gap / 1.3);
                swapped = BubbleIteration(array, gap, array.Length - gap);
            }

            TakeSnapshot();
            return array;
        }
    }
}
