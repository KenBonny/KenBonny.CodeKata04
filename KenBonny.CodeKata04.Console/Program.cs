using System.Reflection;
using CommandLine;
using KenBonny.CodeKata04.Console.Options;
using KenBonny.CodeKata04.Console.Requests;
using KenBonny.CodeKata04.DataAccess.Weather;
using KenBonny.CodeKata04.Weather;
using LightInject;
using MediatR;
using MediatR.Pipeline;

namespace KenBonny.CodeKata04.Console
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            var parser = new Parser(settings =>
            {
                settings.EnableDashDash = true;
            });

            IRequest request = null;
            IMediator mediator = null;
            parser.ParseArguments<WeatherOptions>(args)
                .WithParsed<WeatherOptions>(option =>
                {
                    request = new FindSmallestWeatherSpreadRequest();
                    mediator = BuildMediator(option.FileLocation);
                });

            mediator.Send(request);
        }

        private static IMediator BuildMediator(string weatherDataFileLocation)
        {
            var container = new ServiceContainer();
            container.Register<IMediator, Mediator>();
            container.RegisterAssembly(typeof(IMediator).GetTypeInfo().Assembly,
                (serviceType, implementingType) => !serviceType.GetTypeInfo().IsClass);
            container.RegisterInstance(System.Console.Out);
            
            container.RegisterAssembly(typeof(FindSmallestWeatherSpreadRequest).GetTypeInfo().Assembly, (serviceType, implementingType) =>
            {
                return serviceType.IsConstructedGenericType &&
                       (
                           serviceType.GetGenericTypeDefinition() == typeof(IRequestHandler<,>) ||
                           serviceType.GetGenericTypeDefinition() == typeof(IAsyncRequestHandler<,>) ||
                           serviceType.GetGenericTypeDefinition() == typeof(ICancellableAsyncRequestHandler<,>) ||
                           serviceType.GetGenericTypeDefinition() == typeof(INotificationHandler<>) ||
                           serviceType.GetGenericTypeDefinition() == typeof(IAsyncNotificationHandler<>) ||
                           serviceType.GetGenericTypeDefinition() == typeof(ICancellableAsyncNotificationHandler<>
                           ));
            });
            
            container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            container.Register(typeof(IPipelineBehavior<,>), typeof(RequestPostProcessorBehavior<,>));
//            container.Register(typeof(IPipelineBehavior<,>), typeof(GenericPipelineBehavior<,>));
//            container.Register(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));
//            container.Register(typeof(IRequestPostProcessor<,>), typeof(GenericRequestPostProcessor<,>));
            
            container.Register<SingleInstanceFactory>(factory => type => factory.GetInstance(type));
            container.Register<MultiInstanceFactory>(factory => type => factory.GetAllInstances(type));

            const string weatherDataLocation = "WeatherDataLocation";
            container.RegisterInstance<string>(weatherDataFileLocation, weatherDataLocation);
            container.RegisterAssembly(typeof(ITemperatureParser).GetTypeInfo().Assembly,
                (serviceType, implementingType) => !serviceType.GetTypeInfo().IsClass);
            container.Register<IWeatherRepository>(
                factory => new CsvWeatherRepository(factory.GetInstance<string>(weatherDataLocation)));

            return container.GetInstance<IMediator>();
        }
    }
}