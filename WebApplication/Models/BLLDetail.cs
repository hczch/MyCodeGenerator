using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Info;

namespace WebApplication.Info
{
    public class BLLDetail
    {
        /// <summary>
        /// 输出文件
        /// </summary>
        [Display(Name = "输出文件")]
        public FileOutputEnum FileOutput { get; set; }

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
        /// 方法列表
        /// </summary>
        [Display(Name = "方法列表")]
        public List<MethodDetail> MethodList { get; set; }
    }

    /// <summary>
    /// 输出文件
    /// </summary>
    public enum FileOutputEnum
    {
        [Display(Name = "仅BLL")]
        BLL,

        [Display(Name = "BLL和Interface")]
        BLLandInterface,

        [Display(Name = "仅Interface")]
        Interface,
    }
}
