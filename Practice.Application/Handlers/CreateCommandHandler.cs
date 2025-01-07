using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Commands;
using Practice.Application.Interfaces;

namespace Practice.Application.Handlers
{
    public class CreateCommandHandler<T> : IRequestHandler<CreateCommand<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public CreateCommandHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> Handle(CreateCommand<T> request, CancellationToken cancellationToken)
        {
            var res = await _repository.InsertDataAsync(request.Entity);
            return res;
        }
    }
}
