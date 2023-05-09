using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapping
{
    public static class Mapper
    {
        public static TDestination Map<TSource, TDestination>(TSource source)
         where TSource : class
         where TDestination : class, new()
        {
            if (source == null)
            {
                return null;
            }

            var destination = new TDestination();

            var sourceProperties = typeof(TSource).GetProperties();
            var destinationProperties = typeof(TDestination).GetProperties();

            foreach (var sourceProperty in sourceProperties)
            {
                var destinationProperty = destinationProperties.FirstOrDefault(p => p.Name == sourceProperty.Name);

                if (destinationProperty != null && destinationProperty.CanWrite)
                {
                    destinationProperty.SetValue(destination, sourceProperty.GetValue(source));
                }
            }

            return destination;
        }
    }
}
