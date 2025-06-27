using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyCodeGenerator.Com;

namespace MyCodeGenerator.Decorator
{
    public class ModelDecorator : Decorator
    {

        public ModelDecorator(Component component, string name) : base(component, name)
        {

        }

        public override string GenerateCode()
        {
            return $"public class {Name} \n\t{{ \n\t{base.GenerateCode()} \n\t}}";
        }
    }
}
