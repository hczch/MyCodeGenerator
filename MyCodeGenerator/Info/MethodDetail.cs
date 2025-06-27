using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCodeGenerator.Info
{
    public class MethodDetail
    {
        /// <summary>
        /// 方法名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 方法返回值
        /// </summary>
        public string ReturnType { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string? Remark { get; set; }

        /// <summary>
        /// 参数列表
        /// </summary>
        public List<PropertyDetail>? ParamList { get; set; }

        /// <summary>
        /// 特性列表
        /// </summary>
        public string? AttributeList { get; set; }
    }
}
