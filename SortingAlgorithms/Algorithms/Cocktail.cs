using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms.Algorithms
{
    public class Cocktail<T> : Algorithm<T>
    {
        public override T[] Sort(T[] array)
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            int right = array.Length - 1, left = 0;
            while (right > left)
            {
                for (int j = left; j < right; j++)
                {
                    TakeSnapshot(j);
                    if (ComparisonMethod(array[j], array[j + 1]))
                        Swap(j, j + 1);
                }
                right--;
                for (int k = right; k > left; k--)
                {
                    TakeSnapshot(k);
                    if (ComparisonMethod(array[k - 1], array[k]))
                        Swap(k, k - 1);
                }
                left++;
            }

            TakeSnapshot();
            return array;
        }

    }
}
