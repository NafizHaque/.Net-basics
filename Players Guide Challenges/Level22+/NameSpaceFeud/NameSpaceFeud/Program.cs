
using IField;
using McDroid;
using McCow = McDroid.Cow;
using ICow = IField.Cow;

namespace NameSpaceFeud
{

    internal class Program
    {
        static void Main(string[] args)
        {
            IField.Sheep Isheep = new IField.Sheep();
            McDroid.Sheep Mcsheep = new McDroid.Sheep();

            McCow McCow = new McCow();
            ICow Icow = new ICow();
            string doubleString = "2.5";
            bool isTrue = double.TryParse(doubleString, out double parsedDouble);
            Console.WriteLine(parsedDouble + " " + isTrue);
        }
    }
}




namespace IField
{
    public class Sheep
    {
        public string Name { get; private set; }
        public void Rename(string animalname) { Name = animalname; }
    }
    public class Cow
    {
        public string Name { get; private set; }
        public void Rename(string animalname) { Name = animalname; }
    }
}

namespace McDroid
{
    public class Sheep
    {
        public string Name { get; private set; }
        public void Rename(string animalname) { Name = animalname; }
    }
    public class Cow
    {
        public string Name { get; private set; }
        public void Rename(string animalname) { Name = animalname; }
    }

}

