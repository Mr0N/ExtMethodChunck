using System.Linq;

var result = Enumerable.Range(0, 100).ChunckLazy(12);

foreach (var collection in result)
{
    Console.WriteLine(new String('-',50));
    foreach (var item in collection)
    {
        Console.Write("|"+item+"|");
    }
    Console.WriteLine();
}
Console.ReadKey();




static class EnumeratorExt
{
    public static IEnumerable<IEnumerable<T>> ChunckLazy<T>(this IEnumerable<T> enumerable,int size)
    {
        int count = 0;
        return enumerable.GroupBy(a =>
        {
            count++;
            if (count >= size)
                count = 0;
            return count;
        }).Select(a => a.AsEnumerable());
    }

}