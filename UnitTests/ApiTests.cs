using BeezyAssesment.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTests
{
    [TestClass]
    public class ApiTests
    {
        [TestMethod]
        public async void GetComicsNotNull()
        {
            var comicWrap = await MarvelClient.Instance.GetComics();

            Assert.IsNotNull(comicWrap,"Api retrieves results");
            Assert.AreNotEqual(comicWrap?.data.count, 0);
        }
    }
}
