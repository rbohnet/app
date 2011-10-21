using System;
using System.Collections.Generic;
using app.infrastructure.containers.simple;

namespace app.tasks.startup
{
    public class ContainerRegistrationFacility : Dictionary<Type, ICreateASingleDependency>,
                                                 IRegisterComponentsIntoTheContainer
    {
        ICreateDependencyFactories dependency_factories_factory;

        public ContainerRegistrationFacility(ICreateDependencyFactories dependency_factories_factory)
        {
            this.dependency_factories_factory = dependency_factories_factory;
        }

        public void register_instance<Contract>(Contract instance)
        {
            Add(typeof(Contract), dependency_factories_factory.create_for_instance(instance));
        }

        public ICreateASingleDependency register<Contract, Implementation>() where Implementation : Contract
        {
            ICreateASingleDependency dependency_factory = dependency_factories_factory.create_for_automatic_wiring<Implementation>();
            Add(typeof(Contract), dependency_factory);
            return dependency_factory;
        }

        public void register<Contract>()
        {
            register<Contract, Contract>();
        }
    }
}