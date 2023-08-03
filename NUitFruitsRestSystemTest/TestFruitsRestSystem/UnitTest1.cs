using NUnit.Framework;
using FruitsRestSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace TestFruitsRestSystem
{
    public class Tests
    {
        public static Applications application;
        public static SqlConnection con;
        [SetUp]
        public void Setup()
        {
            application = new Applications();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json") 
                .Build();

            string connectionString = config.GetConnectionString("fruitConnection");
            con = new SqlConnection(connectionString);
        }

        [Test]
        public void TestGetAllFruit()
        {
            var response = application.GetAllFruits(con);
            Assert.AreEqual(200, response.statusCode);
        }

        [Test]
        public void TestGetFruitByProductID()
        {
            var productID = 124567; 
            var response = application.GetFruitByProductID(con, productID);
            Assert.AreEqual(200, response.statusCode);
            Assert.IsNotNull(response.fruit);
            Assert.AreEqual(productID, response.fruit.ProductID);
        }

        [Test]
        public void TestGetFruitUpdateByProductID()
        {
            
            Fruits testFruit = new Fruits() { ProductID =2, ProductName = "aaa", Amount = 10, Price = 20 };
            // act
            var response = application.GetFruitUpdateByProductID(con, testFruit);
            // assert
            Assert.AreEqual(200, response.statusCode);
            Assert.IsNotNull(response.fruit);
            Assert.AreEqual(testFruit.ProductName, response.fruit.ProductName);
        }

        [Test]
        public void TestDeleteFruitByProductID()
        {
            // arrange
            var productID = 1; 
            var response = application.DeleteFruitByProductID(con, productID);
            
            Assert.AreEqual(200, response.statusCode);
        }

        [Test]
        public void TestGetFruitSaleByProductIDAndWeight()
        {
            var productID = 2; 
            var weight = 2; 

            
            var expectedSale = 20 * weight;

            var response = application.GetFruitSaleByProductIDAndWeight(con, productID, weight);

          
            Assert.AreEqual(200, response.statusCode);
            Assert.IsNotNull(response.fruit);
            Assert.AreEqual(productID, response.fruit.ProductID);

           
            Assert.AreEqual(expectedSale, Fruits.GetTotalSale());
        }

    }
}