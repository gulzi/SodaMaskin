using Microsoft.VisualStudio.TestTools.UnitTesting;
using HGSodaMachine;

namespace SodaMachineTests
{
    [TestClass]
    public class MoneyBankTests
    {

        [TestMethod]
        public void Inserting_Coin_1_Should_Return_True()
        {
            MoneyBank account = new MoneyBank();
            bool result  = account.InsertCoin(1);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Inserting_Coin_5_Should_Return_True()
        {
            MoneyBank account = new MoneyBank();
            bool result = account.InsertCoin(5);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Inserting_Coin_10_Should_Return_True()
        {
            MoneyBank account = new MoneyBank();
            bool result = account.InsertCoin(10);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Inserting_Coin_20_Should_Return_True()
        {
            MoneyBank account = new MoneyBank();
            bool result = account.InsertCoin(20);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void Inserting_Coin_15_Should_Return_False()
        {
            MoneyBank account = new MoneyBank();
            bool result = account.InsertCoin(15);
            Assert.IsFalse(result);
        }
        [TestMethod]
        public void Return_Credit_Should_Return_5_Inserted_Coins()
        {
            MoneyBank account = new MoneyBank();
            bool result = account.InsertCoin(5);
            int credit = account.ReturnCredit();
            if (result)
            {
                Assert.AreEqual(5,credit);
            }
            
        }

        [TestMethod]
        public void Process_Transaction_Should_True_When_Processing_Trasaction_Of_10_Coins()
        {
            MoneyBank account = new MoneyBank();
            account.InsertCoin(20);
            bool result = account.ProcessTransaction(10);            
            Assert.IsTrue(result);
            

        }
    }
}
