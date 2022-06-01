using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sdecl
{
    internal class SelectStackStatus
    {
        public bool Status { get; private set; }
        public string? Message { get; private set; }

        public SelectStackStatus(bool status, string? message = null)
        {
            Status = status;
            Message = message;
        }

        public override string ToString()
        {
            return $"stack select {(Status ? "successful" : "failed")}{(Message == null ? "" : $"\nMessage:\n{Message}")}";
        }
    }
}
