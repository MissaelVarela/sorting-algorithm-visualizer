using System;
using System.Collections.Generic;

namespace SortingAlgorithms.Algorithms
{
    public class Selection<T> : Algorithm<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            for (int i = 0; i < array.Length; i++)
            {
                TakeSnapshot(i);

                int menor = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (ComparisonMethod(array[menor], array[j])) menor = j;
                }
                Swap(i, menor);

                TakeSnapshot();
            }

            TakeSnapshot();
            return array;
        }
    }
}
