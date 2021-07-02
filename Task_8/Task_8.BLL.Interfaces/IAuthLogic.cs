using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8.BLL.Interfaces
{
    public interface IAuthLogic
    {
        bool IsAuthentication(string userName, string password);
    }
}
