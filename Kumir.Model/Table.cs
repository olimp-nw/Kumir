using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kumir.Model
{
    public class Line
    {
        private Client client { get; set; }
        private List<Task> tasks { get; set; }
        private long sumCount { get; set; }
        private DateTime sumTime { get; set; }
    }
    public class Table
    {
        private List<Line> table { get; set; }
    }
}
