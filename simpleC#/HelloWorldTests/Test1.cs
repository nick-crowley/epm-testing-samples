namespace HelloWorldTests
{
    [TestClass]
    public sealed class Tests
    {
        [TestMethod]
        public void HelloWorldTest()
        {
            Assert.AreEqual(TestClass.HelloWorld(), "Hello, World!");
        }
    }
}
