using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR.Pipeline;
using Slowary.Application.Common.Dao.SignAuditDetails;
using Slowary.Application.Responses.Signs;
using Slowary.Domain.Entities;

namespace Slowary.Application.Commands.Signs
{
    public class SignCreateCommandPostProcessor : IRequestPostProcessor<SignCreateCommand, SignResponse>
    {
        private readonly IAsyncSignAuditDetailAdder _auditDetailAdder;

        public SignCreateCommandPostProcessor(IAsyncSignAuditDetailAdder auditDetailAdder)
        {
            _auditDetailAdder = auditDetailAdder;
        }

        public async Task Process(SignCreateCommand request, SignResponse response, CancellationToken cancellationToken)
        {
            // supposed that sign was successfully added to database
            
            // todo: add time service
            var now = DateTime.UtcNow;

            var audit = new SignAuditDetail
            {
                SignId = response.SignId,
                Added = now,
                Modified = now,
            };

            await _auditDetailAdder.AddAsync(audit, cancellationToken);
        }
    }
}