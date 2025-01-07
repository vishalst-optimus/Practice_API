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
    public class GetAllDataQueryhandler<T> : IRequestHandler<GetAllDataQuery<T>, IEnumerable<T>> where T : class
    {
        private readonly IGenericRepository<T> _repository;
        public GetAllDataQueryhandler(IGenericRepository<T> repository)
        {
            _repository = repository;
        }
        public async Task<IEnumerable<T>> Handle(GetAllDataQuery<T> request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAsync();
        }
    }
}
