using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Queries
{
    public class GetAllDataQuery<T> : IRequest<IEnumerable<T>> where T : class
    {
    }
}
