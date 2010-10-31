using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lingua.Tests.Helpers;
using System.Threading;
using System.IO;

namespace Lingua.Tests
{
    [TestClass]
    public class FileRepositoryTests
    {
        [TestMethod]
        public void FileRepository_Should_CreateResourceFile()
        {
            IResourceRepository repo = new FileResourceRepository();


            string key = "MyLabel";
            string value = "Some Text";

            var filename = repo.New("MyView", key, value, Thread.CurrentThread.CurrentUICulture.Name);


            string actual = ResxHelpers.GetValue(filename, "MyLabel");

            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual));
            Assert.IsTrue(value == actual);

        }

        /// <summary>
        /// Got to be a better way of testing this?  Or maybe a better way of handing in the repository class - we don't want to create a new resource entity.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void FileRepository_Should_NotOverwriteExistingResx()
        {
            IResourceRepository repo = new FileResourceRepository();

            string key = "MyLabel";
            string value = "Some Text";

            var filename = repo.New("MyView", key, value, Thread.CurrentThread.CurrentUICulture.Name);

            filename = repo.New("MyView", key, value, Thread.CurrentThread.CurrentUICulture.Name);

        }


    }
}
