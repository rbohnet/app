using System;
using System.Reflection;

namespace app.infrastructure.containers
{
    public class GreediestContructorPicker:IChooseTheConstructorForAType
    {
        public ConstructorInfo get_the_applicable_constructor_on(Type type)
        {
            ConstructorInfo result = null;
            ConstructorInfo[] constructorInfo = type.GetConstructors();
            int max_params = 0;
            foreach (var info in constructorInfo)
            {
                if (info.GetParameters().Length > max_params)
                {
                    result = info;
                    max_params = info.GetParameters().Length;
                }
            }
            return result;
        }
    }
}