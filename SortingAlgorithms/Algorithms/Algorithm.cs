using SortingAlgorithms;
using System.Collections.Generic;
using System.Reflection.Metadata;

namespace SortingAlgorithms.Algorithms
{
    public abstract class Algorithm<T>
    {
        protected T[] array;
        protected Queue<Snapshot<T>> SnapshotLog;
        protected Func<T, T, bool> ComparisonMethod;

        public Algorithm()
        {
            array = Array.Empty<T>();
            SnapshotLog = new Queue<Snapshot<T>>();
            ComparisonMethod = (x, y) => false;
        }

        public Algorithm(Func<T, T, bool> comparisonMethod)
        {
            array = Array.Empty<T>();
            SnapshotLog = new Queue<Snapshot<T>>();
            ComparisonMethod = comparisonMethod;
        }

        // En las implementacion de Sort se debe reiniciar el SnapshotLog y actualizar el this.array
        public abstract T[] Sort(T[] array);

        public void SetComparisonMethod(Func<T, T, bool> method)
        {
            ComparisonMethod = method;
        }

        public Queue<Snapshot<T>> GetSnapshotLog()
        {
            return SnapshotLog;
        }

        protected void Swap(int i, int j)
        {
            (array[i], array[j]) = (array[j], array[i]);
            
        }

        protected void TakeSnapshot(int currentIndex)
        {
            T[] arrayState = new T[array.Length];
            Array.Copy(array, arrayState, array.Length);
            SnapshotLog.Enqueue(new Snapshot<T>(arrayState, currentIndex));
        }

        protected void TakeSnapshot()
        {
            TakeSnapshot(-1);
        }
    }
}
