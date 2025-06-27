using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeGenerator.Info
{
    public class ModelDetail
    {
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 属性列表
        /// </summary>
        public List<PropertyDetail> PropertyList { get; set; }
    }
}
