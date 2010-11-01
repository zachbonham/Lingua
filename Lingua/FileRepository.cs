using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Resources;

namespace Lingua
{



    // new-resource "MyResourceFile" "MyKey" "MyValue" // if we leave off the culture, its created for default UI culture
    // delete-resource "MyResourceFile" "MyKey" // removes that entry from the resource file
    // 
    // new-culture "MyResourceFile" "fr-FR"  // locates "MyResourceFile" for default thread culture and copies all its keys into "fr-FR" and creates "MyResourceFile.fr-fr.resx"
        

    /// <summary>
    /// 
    /// </summary>
    public class FileResourceRepository : IResourceRepository
    {

        protected string GetResourceFilename(string entity, string culture)
        {


            var entityName = string.Format("{0}.{1}", entity, culture);

            var filename = Path.Combine(Environment.CurrentDirectory, entityName + ".resx");


            return filename;
        }

        protected void MakeWritable(string filename)
        {
            File.SetAttributes(filename, FileAttributes.Normal);
        }

        protected string GetWritableResource(string entity, string culture)
        {

            var filename = GetResourceFilename(entity, culture);

            MakeWritable(filename);
            
            return filename;

        }

        /// <summary>
        /// TODO - Refactor into just creating the resource 'MyResource'.  AddItem will handle the key/value pairs.
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="key"></param>
        /// <param name="data"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public string New(string entity, string culture)
        {

            var filename = GetResourceFilename(entity, culture);

            if (File.Exists(filename))
            {
                // TODO - Replace this with an EntityAlreadyExistsException or something similar - IOException is too generic
                //
                throw new IOException("File already exists: " + filename);
            }

            using (var writer = new ResourceWriter(filename))
            {
                writer.Generate();
            }
            return filename;
        }

        public void Delete(string entity, string key)
        {
            throw new NotImplementedException();
        }

        public void NewCulture(string entity, string culture)
        {
            throw new NotImplementedException();
        }

        public void Rename(string entity, string key, string newKey)
        {
        }


        public void AddItem(string entity, string key, string value, string culture)
        {
            var filename = GetResourceFilename(entity, culture);

            using (var writer = new ResourceWriter(filename))
            {
                writer.AddResource(key, value);
                writer.Generate();
            }

        }

        public void DeleteItem(string key)
        {
            throw new NotImplementedException();
        }
    }
}
