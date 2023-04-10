using System;
using System.Collections.Generic;

namespace SortingAlgorithms.Algorithms
{
    public class Shell<T> : Insertion<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            int movimiento = array.Length;
            do
            {
                movimiento = movimiento / 2;
                for (int i = 0; i < movimiento; i++)
                {
                    InsertionSortWithSpaces(movimiento, i);
                }
            } while (movimiento > 1);

            TakeSnapshot();
            return array;
        }
    }
}
         
