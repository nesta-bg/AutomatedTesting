using TestWarrior.Mocking;

namespace TestWarrior.UnitTests.Mocking
{
    public class FakeFileReader : IFileReader
    {
        public string Read(string path)
        {
            return "";
        }
    }
}
