using coreHotelRoomBookingAdminPortal.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectMS
{
    [TestClass]
    public class UnitTest1
    {

        static HTypeController controller;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {

            //Arrange Globally
            controller = new HTypeController();

            context.WriteLine("Home controller Instance Created");
        }


        [TestMethod]
        public void TestMethod1()
        {
        }
    }
}
