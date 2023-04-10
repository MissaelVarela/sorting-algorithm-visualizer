using System;
using System.Collections.Generic;
using System.Text;

namespace SortingAlgorithms.Algorithms
{
    public class Insertion<T> : Algorithm<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            InsertionSortWithSpaces(1, 0);

            TakeSnapshot();
            return array;
        }

        // gap = movimiento, desfase o salto  
        // debut = desfase inicial
        protected void InsertionSortWithSpaces(int gap, int debut)
        {
            int pos;
            T current;
            for (int i = gap + debut; i < array.Length; i += gap)
            {
                current = array[i];
                pos = i;
                TakeSnapshot(pos);
                while ((pos >= gap) && ComparisonMethod(array[pos - gap], current))
                {
                    array[pos] = array[pos - gap];
                    array[pos - gap] = current;
                    pos -= gap;

                    TakeSnapshot(pos);
                }
                array[pos] = current;
            }
        }
    }
}
