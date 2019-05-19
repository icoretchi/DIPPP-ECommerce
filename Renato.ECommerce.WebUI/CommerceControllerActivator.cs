using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Renato.ECommerce.Domain.Repositories.Interfaces;
using Renato.ECommerce.Domain.Services;
using Renato.ECommerce.Domain.Services.Interfaces;
using Renato.ECommerce.SQLDataAccess;
using Renato.ECommerce.WebUI.Controllers;
using System;

namespace Renato.ECommerce.WebUI
{
    public class CommerceControllerActivator : IControllerActivator
    {
        private readonly CommerceConfiguration configuration;

        // Singletons
        private readonly IUserContext userContext;

        public CommerceControllerActivator(CommerceConfiguration configuration)
        {
            this.configuration = configuration ?? 
                throw new ArgumentNullException(nameof(configuration));

            // Create singletons
            this.userContext = new AspNetUserContextAdapter();
        }

        public object Create(ControllerContext context) =>
            this.Create(context.ActionDescriptor.ControllerTypeInfo.AsType());

        public void Release(ControllerContext context, object controller) =>
            (controller as IDisposable)?.Dispose();

        public Controller Create(Type type)
        {
            // Create Scoped components
            var context = new CommerceContext(this.configuration.ConnectionString);

            // Create Transient components
            switch (type.Name)
            {
                case nameof(HomeController):
                    return new HomeController(
                        new ProductService(
                            this.CreateProductRepository(context),
                            this.userContext));

                //case nameof(AccountController):
                //    return new AccountController(...);

                //case nameof(UserController):
                //    return new UserController(...)

                //case nameof(LoginController):
                //    return new LoginController(...);

                default: throw new InvalidOperationException($"Unknown controller {type}.");
            }
        }

        // --- Start code Listing 5.16 ----
        private IProductRepository CreateProductRepository(CommerceContext context) =>
            (IProductRepository)Activator.CreateInstance(this.configuration.ProductRepositoryType, context);
        // --- End code Listing 5.16 ----
    }
}
