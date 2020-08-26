using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralJw.Models
{
    public interface ICourse
    {
        string Name { get; set; }
        string Teacher { get; set; }
        string Classroom { get; set; }
    }
}
