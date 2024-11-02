namespace Game1.program;

public class BubbleSorter<T>
{
    public static void Sort(List<T> list, CompareOp lhsIsGreater)
    {
        for (int i = 1; i < list.Count; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (lhsIsGreater(list[i], list[j]))
                {
                    T temp = list[j];
                    list[j] = list[i];
                    list[i] = temp;
                }
            }
        }
    }
}
