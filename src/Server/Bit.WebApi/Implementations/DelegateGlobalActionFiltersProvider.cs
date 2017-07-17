﻿using System;
using System.Web.Http;
using Bit.WebApi.Contracts;

namespace Bit.WebApi.Implementations
{
    public class DelegateGlobalActionFiltersProvider : IWebApiConfigurationCustomizer
    {
        private readonly Action<HttpConfiguration> _addGlobalActionFilters;

#if DEBUG
        protected DelegateGlobalActionFiltersProvider()
        {
        }
#endif

        public DelegateGlobalActionFiltersProvider(Action<HttpConfiguration> addGlobalActionFilters)
        {
            if (addGlobalActionFilters == null)
                throw new ArgumentNullException(nameof(addGlobalActionFilters));

            _addGlobalActionFilters = addGlobalActionFilters;
        }

        public virtual void CustomizeWebApiConfiguration(HttpConfiguration webApiConfiguration)
        {
            if (webApiConfiguration == null)
                throw new ArgumentNullException(nameof(webApiConfiguration));

            _addGlobalActionFilters(webApiConfiguration);
        }
    }
}
