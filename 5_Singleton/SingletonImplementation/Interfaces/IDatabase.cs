using MoreLinq;

namespace Interfaces
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (string name in names)
                result += SingletonDatabase.Instance.GetPopulation(name);
            return result;
        }
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> _capitals;
        private static int _instanceCount; // 0
        public static int Count => _instanceCount;

        private SingletonDatabase()
        {
            _instanceCount++;
            _capitals = File.ReadAllLines(
                //"capitals.txt"
                Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName,
                "capitals.txt")
                )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }
        public int GetPopulation(string name)
        {
            return _capitals[name];
        }

        private static readonly Lazy<SingletonDatabase> _instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => _instance.Value;
    }
}
