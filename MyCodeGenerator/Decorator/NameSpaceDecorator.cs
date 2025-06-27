using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MyCodeGenerator.Com;

namespace MyCodeGenerator.Decorator
{
    public class NameSpaceDecorator : Decorator
    {
        public NameSpaceDecorator(Component component, string name) : base(component, name)
        {

        }

        public override string GenerateCode()
        {
            return $"namespace {Name} \n{{ \n\t{base.GenerateCode()} \n}}";
        }
    }
}
