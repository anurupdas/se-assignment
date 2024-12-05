using MediatR;
using RL.Data;
using RL.Data.DataModels;

namespace RL.Backend.Commands.Handlers.PlanProcedure
{
    public class AddUserToPlanProcedureCommandHandler : IRequestHandler<AddUserToPlanProcedureCommand, bool>
    {
        private readonly RLContext _context;

        public AddUserToPlanProcedureCommandHandler(RLContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(AddUserToPlanProcedureCommand request, CancellationToken cancellationToken)
        {
            var planProcedureUser = new PlanProcedureUser
            {
                PlanProcedureId = request.PlanProcedureId,
                UserId = request.UserId,
                CreateDate = DateTime.UtcNow,
                UpdateDate = DateTime.UtcNow
            };

            _context.PlanProcedureUsers.Add(planProcedureUser);
            await _context.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
