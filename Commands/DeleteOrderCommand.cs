using MediatR;

namespace OrderManagementApp.Api.Commands
{
    public class DeleteOrderCommand : IRequest<Unit>
    {
        public Guid Id { get; }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }
}