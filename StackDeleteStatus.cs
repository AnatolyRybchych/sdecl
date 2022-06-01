using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class StackDeleteStatus
    {
        public bool Status { get; private set; }
        public string? Message { get; private set; }

        public StackDeleteStatus(bool status, string? message = null)
        {
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return $"stack delete {(Status ? "successful" : "failed")}{(Message == null ? "" : $"\nMessage:\n{Message}")}";
        }
    }
}
