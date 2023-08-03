using NUnit.Framework;
using RestApiFruitWPF.Models;
using System.Net;
using System.Threading.Tasks;

namespace TestRestApiFruitWPF
{
    
    public class Tests
    {
        public  TestWPF _testClass;
        [SetUp]
        public void Setup()
        {
            _testClass = new TestWPF(new FakeWindowService());
        }

        
        [Test]
        public async Task TestSearchFruit()
        {
            int productId = 3; 
            var response = await _testClass.Search(productId);

           
            Assert.Pass();
        }

        [Test]
        public async Task TestListAll()
        {
            var fruits = await _testClass.ListAll();

           
            Assert.IsNotNull(fruits);
            Assert.IsNotEmpty(fruits);
        }

        [Test]
        public async Task TestUpdateFruit()
        {
            var fruit = new Fruits
            {
                ProductName = "Apple",
                ProductID = 124567,
                Amount = 22.0m,
                Price = 2.99m
            };

            var response = await _testClass.UpdateFruit(fruit);

            
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestDeleteFruit()
        {
            int productId = 2;

            var response = await _testClass.DeleteFruit(productId);


            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }

        [Test]
        public async Task TestSellFruit()
        {
            int id = 3; 
            decimal weight = 1.0m;

            var response = await _testClass.SellFruit(id, weight);

           
            Assert.IsNotNull(response);
            Assert.AreEqual(200, response.statusCode); 
        }
    }
}