using System;
using System.Collections.Generic;

namespace app.infrastructure.containers.simple
{
    public interface IRegisterComponentsIntoTheContainer : IDictionary<Type,ICreateASingleDependency>
    {
        void register_instance<Contract>(Contract instance);
        ICreateASingleDependency register<Contract, Implementation>() where Implementation : Contract;
        void register<Contract>();
    }
}