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


            var filename = repo.New("MyView", Thread.CurrentThread.CurrentUICulture.Name);


            Assert.IsTrue( File.Exists(filename));

        }

        /// <summary>
        /// Got to be a better way of testing this?  Or maybe a better way of handing in the repository class - we don't want to create a new resource entity.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(IOException))]
        public void FileRepository_Should_NotOverwriteExistingResx()
        {
            IResourceRepository repo = new FileResourceRepository();

            
            var filename = repo.New("MyView", Thread.CurrentThread.CurrentUICulture.Name);

            // should never actually get here because of expected exception
            //
            Assert.IsTrue(filename == string.Empty);
            
        }

        [TestMethod]
        public void FileRepository_Should_AddValueToResourceFileForDefaultCulture()
        {
            IResourceRepository repo = new FileResourceRepository();

            string entity = Guid.NewGuid().ToString();
            string key = "MyLabel";
            string value = "Some Text";

            var filename = repo.New(entity, Thread.CurrentThread.CurrentUICulture.Name);

            repo.AddItem(entity, key, value, Thread.CurrentThread.CurrentUICulture.Name);

            string actual = ResxHelpers.GetValue(filename, key);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual));
            Assert.IsTrue(value == actual);

        }

        [TestMethod]
        public void FileRepository_Should_AddValueToResourceFileForSpecificCulture()
        {
            IResourceRepository repo = new FileResourceRepository();

            string entity = Guid.NewGuid().ToString();
            string key = "MyLabel";
            string value = "Some Text";
            string culture = "fr-fr";

            var filename = repo.New(entity, culture);

            repo.AddItem(entity, key, value, culture);

            string actual = ResxHelpers.GetValue(filename, key);

            Assert.IsTrue(!string.IsNullOrWhiteSpace(actual));
            Assert.IsTrue(value == actual);

        }

    }
}
