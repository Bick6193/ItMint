using System.Reflection;
using AutoMapper;

namespace DAL.Mapping
{
    public static class Mapping
    {
        public static void Init()
        {
            Mapper.Initialize(configuration =>
            {
                //configuration.ShouldMapField = ShouldMap;
                //configuration.ShouldMapProperty = ShouldMap;

                configuration.AddProfile<RequestConfiguration>();
            });

            //precompile
            Mapper.Configuration.CompileMappings();
        }

        public static bool ShouldMap(FieldInfo field)
        {
            return field.IsPublic || field.IsAssembly;
        }

        public static bool ShouldMap(PropertyInfo property)
        {
            return property.GetMethod.IsPublic || property.GetMethod.IsAssembly;
        }
    }
}