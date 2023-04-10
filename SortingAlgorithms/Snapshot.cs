
namespace SortingAlgorithms
{
    public class Snapshot<T>
    {
        public T[] ArrayState;
        public int CurrentIndex;

        public Snapshot(T[] arrayState, int currentIndex)
        {
            ArrayState = arrayState;
            CurrentIndex = currentIndex;
        }
    }
}
