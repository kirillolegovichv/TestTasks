using TestTask3;

DiskSearch ds = new DiskSearch();
Console.Write("Введите вес: ");
int inputWeight = int.Parse(Console.ReadLine());
int[] d = { 13, 3, 9, 8, 4, 8, 2, 11, 7, 12, 10, 1, 5, 14, 6, 15, 16 };

int[] res = ds.Search(d, inputWeight);

foreach(var item in res)
{
    Console.WriteLine(item);
}