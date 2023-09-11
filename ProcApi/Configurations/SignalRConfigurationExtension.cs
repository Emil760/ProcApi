using Microsoft.AspNetCore.SignalR.StackExchangeRedis;
using ProcApi.Services.Concreates;

namespace ProcApi.Configurations
{
    public static class SignalRConfigurationExtension
    {
        public static void AddCustomSignalR(this IServiceCollection services, IConfiguration configuration)
        {
            //ClientTimeoutInterval.Определяет время, в течение которого клиент должен отправить серверу сообщение.
            //Если в течение данного времени никаких сообщенй от клиента на сервер не пришло, то сервер закрывает соединение.
            //По умолчанию равно 30 секунд.

            //HandshakeTimeout.После подключения к серверу клиент должен отправить серверу в качестве самого первого сообщения специальное сообщение - HandshakeRequest.
            //Это свойство устанавливает допустимое время таймаута, которое может пройти до получения от клиента первого сообщения об установки соединения.
            //Если в течение этого периода клиент не отправит первое сообщение, то подключение закрывается.
            //По умолчанию равно 15 секунд.

            //KeepAliveInterval: если в течение этого периода сервер не отправит никаких сообшений, то автоматически отправляется ping - сообщение для поддержания подключения открытым.
            //При изменении этого свойства Microsoft рекомендует изменить на стророне клиента параметр serverTimeoutInMilliseconds(клиент javascript)/ ServerTimeout(клиент.NET), которое рекомендуется устанавливать в два раза больше, чем KeepAliveInterval.
            //По умолчанию равно 15 секунд.

            //SupportedProtocols определяет поддерживаемые протоколы. По умолчанию поддерживаются все протоколы.

            //EnableDetailedErrors при значении true возвращает клиенту детальное описание возникшей ошибки(при ее возникновении).
            //Поскольку подобные сообщения могут содержать критически важную для безопасности информацию, то по умолчанию имеет значение false.

            var connectionString = configuration.GetSection(nameof(RedisOptions)).GetChildren().ElementAt(0).Value;

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
                options.KeepAliveInterval = System.TimeSpan.FromMinutes(10);
            }).AddStackExchangeRedis(connectionString);
        }

        public static void MapHubs(this WebApplication builder)
        {
            builder.MapHub<ChatHub>("hub-chat");
        }
    }
}