using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Connector
{
    public interface IDataManager
    {
        DataSet ExecuteQuery(string query, string nomTable, bool isNonQuery);
    }
}
