﻿using System;

namespace app.infrastructure.containers.simple
{
    public class SimpleDependencyFactory : ICreateASingleDependency
    {
        public Func<object> creation_delegate;

        public SimpleDependencyFactory(Func<object> creation_delegate)
        {
            this.creation_delegate = creation_delegate;
        }

        public object create()
        {
            return creation_delegate();
        }

        public void as_singleton()
        {
            throw new NotImplementedException();
        }
    }
}