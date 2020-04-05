using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace B3.Infrastructure.Reflection
{
    public static class AssemblyExtensions
    {
        public static List<Type> FromAssembliesMatching<TType>(this AppDomain currentDomain, string searchPattern)
        {
            var referencedPaths = Directory.GetFiles(currentDomain.BaseDirectory, searchPattern).ToList();

            var assembly = referencedPaths.Select(path => currentDomain.Load(AssemblyName.GetAssemblyName(path)));

            var types = assembly.SelectMany(s => s.GetTypes().Where(t =>
                    typeof(TType).IsAssignableFrom(t)
                    && !t.IsInterface
                    && !t.IsAbstract))
                .ToList();

            return types;
        }
    }
}