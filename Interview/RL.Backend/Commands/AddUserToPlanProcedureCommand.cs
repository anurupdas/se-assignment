using MediatR;

namespace RL.Backend.Commands
{
    public class AddUserToPlanProcedureCommand : IRequest<bool>
    {
        public int PlanProcedureId { get; set; }
        public int UserId { get; set; }
    }
}
