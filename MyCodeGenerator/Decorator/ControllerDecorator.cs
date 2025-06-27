using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Com;
using MyCodeGenerator.Info;

namespace MyCodeGenerator.Decorator
{
    public class ControllerDecorator : Decorator
    {
        /// <summary>
        /// 特性列表
        /// </summary>
        private IEnumerable<string> AttributeList;

        public ControllerDecorator(Component component, string name, string attributes) : base(component, name)
        {
            AttributeList = attributes.Split(',');
        }

        public override string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();

            if (AttributeList != null)
            {
                foreach (var attribute in AttributeList)
                {
                    sb.AppendLine($"                    [{attribute}]");
                }
            }
            sb.AppendLine($"public class {Name}Controller : Controller \n{{ \n\t#region 引用 \n\tpublic {Name}Controller() \n\t{{ \n\t}} \n\t#endregion 引用 \n\t{base.GenerateCode()} \n}}");

            return sb.ToString();
        }
    }
}
