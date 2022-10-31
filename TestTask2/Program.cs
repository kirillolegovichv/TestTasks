using System.Reflection;
using TestTask2;

Type type = typeof(Cat);
ConstructorInfo info = type.GetConstructor(new Type[] { typeof(string)});
Animal cat = (Animal)info.Invoke(new object[] { "British" });

Console.WriteLine(cat.MaxAge);
Console.WriteLine(cat.Breed);
Console.WriteLine(cat.Wool);

// Также можно сделать через System.Activator (получится даже короче)
Animal cat2 = (Animal)Activator.CreateInstance(typeof(Cat), "Persian");

Console.WriteLine(cat2.MaxAge);
Console.WriteLine(cat2.Breed);
Console.WriteLine(cat2.Wool);