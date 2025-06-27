using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Com;

namespace MyCodeGenerator.Decorator
{
    public abstract class Decorator : Component
    {
        /// <summary>
        /// 名称
        /// </summary>
        protected string Name;

        protected Component _component;

        public Decorator(Component component, string name) : base()
        {
            _component = component;
            Name = name;
        }

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetComponent(Component component)
        {
            this._component = component;
        }

        public override string GenerateCode()
        {
            if (this._component != null)
            {
                return this._component.GenerateCode();
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
