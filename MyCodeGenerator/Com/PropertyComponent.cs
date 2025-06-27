using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Info;

namespace MyCodeGenerator.Com
{
    public class PropertyComponent : Component
    {
        private IEnumerable<PropertyDetail> _properties;

        public PropertyComponent(IEnumerable<PropertyDetail> properties)
        {
            _properties = properties;
        }

        public override string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();
            foreach (PropertyDetail property in _properties)
            {
                sb.AppendLine(@$"
                        /// <summary>
                        /// {property.Remark}
                        /// </summary>
                        /// <returns></returns>");

                if (property.AttributeList != null)
                {
                    var attributeList = property.AttributeList.Split(",");
                    foreach (var attribute in attributeList)
                    {
                        sb.AppendLine($"                    [{attribute}]");
                    }
                }
                sb.AppendLine($@"                   public {property.Type} {property.Name} {{ get; set; }} ");

            }
            return sb.ToString();
        }
    }
}
