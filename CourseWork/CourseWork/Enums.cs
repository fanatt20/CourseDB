using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace CourseWork
{
    enum RoleInDB
    {
        Nothing=-1,
        Administrator = 0,
        ReadOnlyUser = 1,
        ReadWriteUser = 2,
        WriteUpdateUser = 3
    }
}
