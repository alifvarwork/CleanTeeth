using CleenTeeth.Application.Exceptions;
using CleenTeeth.Application.Utilities;
using FluentValidation;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace CleanTeeth.Test.Application.Utilities.Mediator
{
    [TestClass]
    public class SimpleMediatorTest
    {
        public class FalseRequest : IRequest<string>
        {
            public required string Name { get; set; }
        }

        public class FalseRequestValidator : AbstractValidator<FalseRequest>
        {
            public FalseRequestValidator()
            {
                RuleFor(x => x.Name).NotEmpty();
            }
        }

        [TestMethod]
        public async Task Send_WithRegisteredHandler_HandleIsExecuted()
        {
            var request = new FalseRequest() { Name = "example"};

            var handlerMock = Substitute.For<IRequestHandler<FalseRequest, string>>();

            var serviceProvider = Substitute.For<IServiceProvider>();

            serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>)).Returns(handlerMock);

            var mediator = new SimpleMediator(serviceProvider);

            var result = await mediator.Send(request);

            await handlerMock.Received(1).Handle(request);
        }

        [TestMethod]
        public async Task Send_WithoutRegisteredHandler_throws()
        {
            var request = new FalseRequest() { Name = "example" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            _ = serviceProvider.GetService(typeof(IRequestHandler<FalseRequest, string>))?
                .ReturnsNull();

            var mediator = new SimpleMediator(serviceProvider);

            await Assert.ThrowsAsync<MediatorException>(() => mediator.Send(request));
        }

        [TestMethod]
        public async Task Send_InvalidCommand_Throws()
        {
            var request = new FalseRequest { Name = "" };
            var serviceProvider = Substitute.For<IServiceProvider>();
            var validator = new FalseRequestValidator();

            serviceProvider.GetService(typeof(IValidator<FalseRequest>)).Returns(validator);
            var mediator = new SimpleMediator(serviceProvider);

            await Assert.ThrowsAsync<CustomValidationException>(() => mediator.Send(request));

        }
    }
}
