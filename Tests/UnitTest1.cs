using CardBuilderApp;

namespace Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            CardBuilder.MakeTestJson("cards.json");
            CardBuilder.BuildCards("cards.json", "cards.png");
            Assert.True(File.Exists("cards.png"));
        }
    }
}
