namespace Ex08_ContosoPizza.Services.FruitService;
using Ex08_ContosoPizza.Models.Fruit;
public static class FruitService
{
  static List<Fruit> Fruits { get; }
  static int nextId = 6;
  static FruitService()
  {
    Fruits = new List<Fruit>
    {
    new Fruit { Id = 1, Name = "Apple", Price= 30, Color = "blue" },
    new Fruit { Id = 2, Name = "Kakarot", Price = 30, Color = "yellow" },
    new Fruit { Id = 3, Name = "Vegeta", Price = 30, Color = "pink" },
    new Fruit { Id = 4, Name = "Banana", Price = 30, Color = "red" },
    new Fruit { Id = 4, Name = "Orange", Price = 30, Color = "orange" },
    };
  }
  public static List<Fruit> GetAll() => Fruits;
  public static List<Fruit> GetAllOrder() => Fruits.OrderBy(fruit => fruit.Name).ToList();
  public static Fruit? Get(int id) => Fruits.FirstOrDefault(p => p.Id == id);
  public static void Add(Fruit fruit)
  {
    fruit.Id = nextId++;
    Fruits.Add(fruit);
  }
  public static void Delete(int id)
  {
    var fruit = Get(id);
    if (fruit is null)
      return;
    Fruits.Remove(fruit);
  }
  public static void Update(Fruit fruit)
  {
    var index = Fruits.FindIndex(p => p.Id == fruit.Id);
    if (index == -1)
      return;
    Fruits[index] = fruit;
  }
}