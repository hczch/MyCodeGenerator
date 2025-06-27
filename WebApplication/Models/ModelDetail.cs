using MyCodeGenerator.Info;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication.Info
{
    public class ModelDetail
    {
        /// <summary>
        /// 命名空间名称
        /// </summary>
        [Display(Name="命名空间")]
        public string NameSpace { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [Display(Name="Model名称")]
        public string Name { get; set; }

        /// <summary>
        /// 属性列表
        /// </summary>
        [Display(Name ="属性列表")]
        public List<PropertyDetail> PropertyList { get; set; }
    }
}
