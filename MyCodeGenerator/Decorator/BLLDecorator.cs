using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Com;

namespace MyCodeGenerator.Decorator
{
    public class BLLDecorator : Decorator
    {
        public BLLDecorator(Component component, string name) : base(component, name)
        {
        }

        public override string GenerateCode()
        {
            return $"public class {Name}BLL : I{Name} \n{{ \n\t{base.GenerateCode()} \n}}";
        }
    }
}
