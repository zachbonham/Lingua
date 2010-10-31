using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;

namespace Lingua.Tests.Helpers
{
    public class ResxHelpers
    {
        public static string GetValue(string filename, string key)
        {
            var result = string.Empty;

            using (var r = new ResourceReader(filename))
            {
                var rr = r.GetEnumerator();


                while (rr.MoveNext())
                {

                    if (rr.Key.Equals(key))
                    {
                        result = rr.Value as string;
                    }
                }
                

            }

            return result;

        }
    }
}
