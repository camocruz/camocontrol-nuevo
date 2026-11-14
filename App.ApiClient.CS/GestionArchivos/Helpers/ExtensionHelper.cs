using System;
using System.Collections.Generic;
using System.Linq;

namespace App.ApiClient.CS.GestionArchivos.Helpers
{
    public static class ExtensionHelper
    {
        public static List<string> ParseExtensions(
            string extensions)
        {
            if (string.IsNullOrWhiteSpace(extensions))
            {
                return new List<string>();
            }

            return extensions
                .Split(';')
                .Select(x => x.Trim().ToLower())
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .ToList();
        }

        public static bool IsAllowed(
            string extension,
            string configurationExtensions)
        {
            return ParseExtensions(
                configurationExtensions)
                .Contains(
                    extension.Trim()
                             .Replace(".", "")
                             .ToLower());
        }
    }
}