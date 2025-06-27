using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Com;

namespace MyCodeGenerator.Decorator
{
    public class InterfaceDecorator : Decorator
    {
        public InterfaceDecorator(Component component, string name) : base(component, name)
        {
        }

        public override string GenerateCode()
        {
            return $"public interface I{Name} : IDenpendency \n{{ \n\t{base.GenerateCode()} \n}}";
        }
    }
}
