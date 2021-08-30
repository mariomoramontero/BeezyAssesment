using BeezyAssesment.Services;
using BeezyAssesment.ViewModels;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests
{
    [TestClass]
    class VMTests
    {
        [TestMethod]
        public void GetComicsFilteredNotNull()
        {
            var vm = new ComicsViewModel();
            vm.FilterTitleStartsWith="hulk";
            vm.LoadItemsCommand.Execute(null);
            Assert.IsNotNull(MarvelClient.Instance.CatchedComicData, "Filtered results loaded");
            
        }
    }
}
