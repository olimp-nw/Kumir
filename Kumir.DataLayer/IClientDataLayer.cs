using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kumir.Model;

namespace Kumir.DataLayer
{
    public interface IClientDataLayer
    {
        Line parseFileKumir(string nameKumirFile);
    }
}
