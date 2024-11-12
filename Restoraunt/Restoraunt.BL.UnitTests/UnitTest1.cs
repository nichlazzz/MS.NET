using NUnit.Framework;

namespace Restoraunt.Restoraunt.BL.UnitTests
{
    [TestFixture]
    public class TestBase
    {
        [SetUp]
        public void Setup()
        {
            //перед каждым тестом
            //создание транзакции
            //очистка данных
        }

        [TearDown]
        public void TearDown() 
        {
            //после каждого теста
            //закрытие транзакции
            //очистка данных
        }

        [OneTimeSetUp]
        public void OneTimeSetup() {
            //один раз перед всеми
            //инициализация переменных, получение настроек, создание классов
            
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() 
        {
            //один раз после всех тестов
        }

        [Test]
        [TestCase(" 8 919 ")]
        [TestCase(null)]
        [TestCase("")]
        [Category("Integration")]
        public void TestPhoneValidation(string phone)
        {
            Assert.Pass();            
        }
    }
}