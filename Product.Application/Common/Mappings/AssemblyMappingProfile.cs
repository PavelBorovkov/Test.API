using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Reflection;

namespace TestTask.Application.Common.Mappings
{
    public class AssemblyMappingProfile : Profile
    {
        public AssemblyMappingProfile(Assembly assembly) =>
            ApplyMappingsFromAssembly(assembly);
        
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            //данный метод сканирует сборку и ищет любые типы которые реализуют интерфейс IMapWith
            var types = assembly.GetExportedTypes()
                .Where(type => type.GetInterfaces()
                    .Any(i => i.IsGenericType &&
                    i.GetGenericTypeDefinition()==typeof(IMapWith<>)))
                .ToList();

            foreach (var type in types)
            {
                //вызывает метод mapping от наследованного типа или из интерфейса, если тип не реализует этот метод
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod("Mapping");
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }


    }
}
