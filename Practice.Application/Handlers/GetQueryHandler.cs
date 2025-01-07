using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Practice.Application.Interfaces;
using Practice.Application.Queries;

namespace Practice.Application.Handlers
{
    public class GetQueryHandler<T> : IRequestHandler<GetQuery<T>, T> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GetQueryHandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<T> Handle(GetQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
