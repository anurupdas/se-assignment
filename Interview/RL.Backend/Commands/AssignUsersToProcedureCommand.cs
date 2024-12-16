using MediatR;
using RL.Backend.Models;

namespace RL.Backend.Commands
{
    public class AssignUsersToProcedureCommand : IRequest<ApiResponse<Unit>>
    {
        public int PlanId { get; set; }
        public int ProcedureId { get; set; }
        public List<int> UserIds { get; set; }
    }
}