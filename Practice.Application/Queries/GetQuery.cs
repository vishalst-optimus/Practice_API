using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Queries
{
    public class GetQuery<T> : IRequest<T> where T : class
    {
        public int Id;
        public GetQuery(int id)
        {
            Id = id;
        }
    }
}
