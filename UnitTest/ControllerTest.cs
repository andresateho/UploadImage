namespace UnitTest
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using NUnit.Framework;
    using System.IO;
    using System.Text;
    using UploadImage.Controllers;
    using UploadImage.Model;
    using Xunit;

    public class ControllerTest
    {
        [Test, Fact]
        public void ValidatePostControllerFailValidateSizeTest()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "Bearer 12345";
            httpContext.Request.Headers["ConsumerId"] = "12345";

            IFormFile mockImage = new FormFile(
                new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 
                0, 
                0, 
                "Image", 
                "test.jpg");

            var image = new FileImageModel { Image = mockImage };

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var controller = new FileImageController() 
            {
                ControllerContext = controllerContext,
            };

            IActionResult res = controller.Post(image);

            var statusCodeResult = res as StatusCodeResult;
            var statusCode = (int)statusCodeResult.StatusCode;

            Assert.IsInstanceOf<StatusCodeResult>(res);
            Assert.AreEqual(400, statusCode);
        }

        [Test, Fact]
        public void ValidatePostControllerFailValidateHeadersTest()
        {
            var httpContext = new DefaultHttpContext();
            httpContext.Request.Headers["Authorization"] = "Bearer 12345";
            httpContext.Request.Headers["ConsumerId"] = "12345";

            IFormFile mockImage = new FormFile(
                new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 
                0, 
                0, 
                "Image", 
                "test.png");

            var image = new FileImageModel { Image = mockImage };

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var controller = new FileImageController()
            {
                ControllerContext = controllerContext,
            };

            IActionResult res = controller.Post(image);

            var statusCodeResult = res as StatusCodeResult;
            var statusCode = (int)statusCodeResult.StatusCode;

            Assert.IsInstanceOf<StatusCodeResult>(res);
            Assert.AreEqual(400, statusCode);
        }

        [Test, Fact]
        public void ValidatePostControllerFailValidateExtensionTestAsync()
        {
            var httpContext = new DefaultHttpContext(); // or mock a `HttpContext`
            httpContext.Request.Headers["Authorization"] = "fail";
            httpContext.Request.Headers["ConsumerId"] = "fail";

            IFormFile mockImage = new FormFile(
                new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 
                0, 
                0, 
                "Image", 
                "test.jpg");

            var image = new FileImageModel { Image = mockImage };

            var controllerContext = new ControllerContext()
            {
                HttpContext = httpContext,
            };

            var controller = new FileImageController()
            {
                ControllerContext = controllerContext,
            };

            IActionResult res = controller.Post(image);

            var statusCodeResult = res as StatusCodeResult;
            var statusCode = (int)statusCodeResult.StatusCode;

            Assert.IsInstanceOf<StatusCodeResult>(res);
            Assert.AreEqual(400, statusCode);
        }
    }
}
