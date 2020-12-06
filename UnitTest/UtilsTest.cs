namespace UnitTest
{
    using NUnit.Framework;
    using UploadImage.Utils;

    public class UtilsTest
    {
        [Test]
        public void ValidateUtilsValidateSizeTrueTest()
        {
            string fileName = "prueba.jpg";
            string path = "C:/ApiC#/UploadImage/UnitTest/Images/test.jpg";

            bool responseUtils = ValidateImage.ValidateSize(path, fileName);
            Assert.IsTrue(responseUtils);
        }

        [Test]
        public void ValidateUtilsValidateSizeFalseTest()
        {
            string fileName = "test.jpg";
            string path = "";

            bool responseUtils = ValidateImage.ValidateSize(path, fileName);
            Assert.IsFalse(responseUtils);
        }

        [Test]
        public void ValidateUtilsValidateExtensionTrueTest()
        {
            string fileName = "prueba.jpg";

            bool responseUtils = ValidateImage.ValidateExtension(fileName);
            Assert.IsTrue(responseUtils);
        }

        [Test]
        public void ValidateUtilsValidateExtensionFalseTest()
        {
            string fileName = "test.png";

            bool responseUtils = ValidateImage.ValidateExtension(fileName);
            Assert.IsFalse(responseUtils);
        }
    }
}