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
    public class DeleteCommandHandler<T> : IRequestHandler<DeleteCommand<T>, bool> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public DeleteCommandHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(DeleteCommand<T> request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteByIdAsync(request.Id);
        }
    }
}
