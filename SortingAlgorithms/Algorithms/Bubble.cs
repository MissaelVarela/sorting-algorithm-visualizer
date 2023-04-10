using SortingAlgorithms;

namespace SortingAlgorithms.Algorithms
{
    public class Bubble<T> : Algorithm<T>
    {
        public override T[] Sort(T[] array) 
        {
            this.array = array;

            SnapshotLog = new Queue<Snapshot<T>>();
            TakeSnapshot();

            for (int i = array.Length - 1; i > 0; i--)
            {
                BubbleIteration(array, 1, i);
            }

            TakeSnapshot();
            return array;
        }

        protected bool BubbleIteration(T[] array, int gap, int limit)
        {
            bool swapped = false;
            for (int i = 0; i < limit; i++)
            {
                TakeSnapshot(i);
                if (ComparisonMethod(array[i], array[i + gap]))
                {
                    Swap(i, i + gap);
                    swapped = true; 
                }
            }
            return swapped;
        }
    }
}
