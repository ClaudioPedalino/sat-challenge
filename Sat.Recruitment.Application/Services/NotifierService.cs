using MediatR;
using Sat.Recruitment.Application.Helpers;
using System.Threading;
using System.Threading.Tasks;

namespace Sat.Recruitment.Application.Services
{
    public interface INotifierService
    {
        void Notify(string message);
    }

    public class NotifierService : INotifierService
    {
        private readonly IMediator _mediator;

        public NotifierService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public void Notify(string message)
        {
            _mediator.Publish(new NotificationMessage { EventMessage = message });
        }
    }

    public class NotificationMessage : INotification
    {
        public string EventMessage { get; set; }
    }

    public class NotificationSubscriber1 : INotificationHandler<NotificationMessage>
    {
        public Task Handle(NotificationMessage notification, CancellationToken cancellationToken)
        {
            ConsolePrinterHelper.PrintString(
                $"[{nameof(NotificationSubscriber1)}] recibed Event:  {notification.EventMessage}");

            return Task.CompletedTask;
        }
    }
}
