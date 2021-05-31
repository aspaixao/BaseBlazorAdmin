using BaseBlazorAdmin.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseBlazorAdmin.Shared.Responses
{
    public class ApiResponse
    {
        public List<Message> Messages { get; set; }

        public bool ExecutedOK { get; set; }

    }

    public class ApiResponse<T> : ApiResponse
    {
        public T Data { get; set; }
    }

}
