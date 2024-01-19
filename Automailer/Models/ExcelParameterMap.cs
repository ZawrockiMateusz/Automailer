using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automailer.Models
{
    public class ExcelParameterMap
    {
        public ExcelParameterMap() { }
        public string Name { get; set; }
        public string Cell { get; set; }
        public ParameterType ParamType { get; set; }
    }
    public class ExcelImageParameterMap : ExcelParameterMap
    {
        public ExcelImageParameterMap() { }
        public string Source { get; set; }
    }
    public enum ParameterType
    {
        Default = 0,
        Text = 1,
        Image = 2
    }
}
