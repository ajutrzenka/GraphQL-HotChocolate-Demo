using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AeroclubTimekeeper.Storage.Utils
{
    internal static class EmbeddedFileReader
    {
        public static string ReadContent(string resourcePath)
        {
            var assembly = Assembly.GetExecutingAssembly();

            resourcePath = Path.Combine(assembly.GetName().Name ?? string.Empty, resourcePath);
            resourcePath = resourcePath.Replace("\\", ".").Replace("/", ".");

            Stream? stream = assembly.GetManifestResourceStream(resourcePath);
            if (stream == null)
            {
                throw new InvalidOperationException($"Resource '{resourcePath}' not found.");
            }

            using Stream mystream = stream;
            using StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }
    }
}
