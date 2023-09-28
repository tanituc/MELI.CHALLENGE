using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge.ToolKit
{
    public class ExceptionManager
    {
       public class NoUserException : Exception 
        { 
            public override string Message => $"No se encontraron Usuarios con el respectivo";
        }

    }
}
