using MyCodeGenerator.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Info
{
    public class ControllerDetail
    {
        /// <summary>
        /// 命名空间名称
        /// </summary>
        [Display(Name = "命名空间")]
        public string NameSpace { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name = "名称")]
        public string Name { get; set; }

        /// <summary>
        /// 特性
        /// </summary>
        [Display(Name = "特性")]
        public string Attributes { get; set; }

        /// <summary>
        /// 方法列表
        /// </summary>
        [Display(Name = "方法列表")]
        public List<MethodDetail> MethodList { get; set; }
    }
}
