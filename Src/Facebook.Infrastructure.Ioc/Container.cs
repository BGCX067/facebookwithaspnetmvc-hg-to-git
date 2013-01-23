using System;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace Facebook.Infrastructure.Ioc
{
    /// <summary>
    /// This class acts as a facade to make easy the access to the default unity container of the app.
    /// </summary>
    public static class Container
    {
        public static readonly IUnityContainer Instance = new UnityContainer(); //.LoadConfiguration();
    }


}
