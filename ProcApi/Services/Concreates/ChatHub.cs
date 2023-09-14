using Microsoft.AspNetCore.SignalR;
using ProcApi.Services.Abstracts;

namespace ProcApi.Services.Concreates
{
    public class ChatHub : Hub<IChatClient>
    {
        private readonly IConnectedUsersService _connectedUsersService;

        public ChatHub(IConnectedUsersService connectedUsersService)
        {
            _connectedUsersService = connectedUsersService;
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await _connectedUsersService.RemoveConnectionIdAsync(Context.ConnectionId);
            await base.OnDisconnectedAsync(exception);
        }

        //ConnectionId: возвращает уникальный идентификатор подключения в виде строки.

        //ConnectionAborted: возвращает объект CancellationToken, который извещает о закрытии подключения

        //User: возвращает объект ClaimsPrincipal, ассоциированный с текущим пользователем.
        //По сути это аналог свойства HttpContext.User, которое доступно в констроллерах

        //UserIdentifier: возвращает идентификатор пользователя.По умолчанию индентификатор пользователя представляет клейм ClaimTypes.
        //NameIdentifier объекта ClaimsPrincipal, который ассоциирован с данным подключением.

        //Items: возвращает словарь значений, ассоциированных с текущим подключением.
        //Данный словарь позволяет хранить данные для определенного клиента между его запросами

        //Features: возвращает коллекцию возможностей HTTP, ассоциированных с текущим подключением

        //Также класс HubCallerContext определяет пару методов:

        //Abort(): принудительно завершает текущее подключение

        //GetHttpContext(): возвращает объект HttpContext для текущего подключения или null, если подключение не ассоциировано с запросом HTTP.

        //Подключение и отключение клиентов
        //Класс Hub определяет два метода, которые мы можем переопределить в классах-наследниках:

        //OnConnectedAsync(): срабатывает при подключении нового клиента

        //OnDisconnectedAsync(Exception exception): срабатывает при отключении клиента, в качестве параметра передается сообщение об ошибке,
        //которая описывает, почему произошло отключение.


        //Clients
        //All: представляет всех подключенных клиентов

        //Caller: представляет только текущего клиента, который обратился к хабу

        //Others: представляет всех клиентов за исключением текущего клиента, который обратился к хабу

        //Кроме свойств объект Clients имеет ряд методов:

        //AllExcept(IReadOnlyList<string> connectionIds) : представляет всех клиентов за исключением тех,
        //id которых передаются в метод

        //Client(string connectionId) : вызывает метод у клиента по id подключения

        // Clients(IReadOnlyList<string> connectionIds): вызывает метод у клиентов, id которых передаются в метод

        //Group(string groupName) : вызывает метод у клиентов определенной группы

        //GroupExcept(string groupName, IReadOnlyList<string> connectionIds) : вызывает метод у клиентов группы по имени groupName за исключением тех клиентов,
        //id которых передаются в качестве второго параметра

        //Groups(IReadOnlyList<string> groupNames) : вызывает метод у клиентов групп, названия которых передаются в метод

        // OthersInGroup(string OthersInGroup): вызывает метод у клиентов определенной группы за исключением текущего клиента

        //User(string userId) : вызывает метод у пользователя по id

        //Users(IReadOnlyList<string> userIds) : вызывает метод у пользователей, id которых передаются в метод
    }
}