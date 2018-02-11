using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kumir.Model;

namespace Kumir.DataLayer
{
    public interface IServerDataLayer
    {
        string getPassword(string nameUser);
        void changePassword(string nameUser, string passwordUser);
        void safeTable(ref Table table);
        void printTable(ref Table table);
        void loadTable(string nameFileTable);
        List<Client> getActiveClient(ref Table table);
    }
}
