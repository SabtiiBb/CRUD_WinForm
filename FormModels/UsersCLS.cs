using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_WinForm.FormModels
{
    public class UsersCLS
    {
        public int IdUser { get; set; }
        public string UserName { get; set; }
        public string Pass { get; set; }
        public string ConfirmPass { get; set; }
        public int IdRol { get; set; }
    }
}
