using System.Collections.Generic;

namespace Quiz
{
    public class Shuffle
    {
        public static List<T> List<T>(List<T> list)
        {
            int rnd;

            for (int i = 0; i < list.Count; i++)
            {
                rnd = UnityEngine.Random.Range(0, list.Count);

                (list[i], list[rnd]) = (list[rnd], list[i]);
            }
            return list;
        }

        public static T[] Array<T>(T[] array)
        {
            int rnd;

            for (int i = 0; i < array.Length; i++)
            {
                rnd = UnityEngine.Random.Range(0, array.Length);

                (array[i], array[rnd]) = (array[rnd], array[i]);
            }
            return array;
        }
    }
}
