using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Practice.Application.Commands
{
    public class DeleteCommand<T> : IRequest<bool> where T : class
    {
        public int Id;
        public DeleteCommand(int id)
        {
            Id = id;
        }
    }
}
