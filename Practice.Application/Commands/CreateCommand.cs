using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Commands
{
    public class CreateCommand<T> : IRequest<T> where T : class
    {
        public T Entity;
        public CreateCommand(T entity)
        {
            Entity = entity;
        }
    }
}
