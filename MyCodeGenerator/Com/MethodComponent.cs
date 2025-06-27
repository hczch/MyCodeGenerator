using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Info;

namespace MyCodeGenerator.Com
{
    public class MethodComponent : Component
    {
        private IEnumerable<MethodDetail> _methods;

        /// <summary>
        /// 默认返回带方法体的method
        /// </summary>
        private MethodEnum _methodType = MethodEnum.ClassMethod;

        public MethodComponent(IEnumerable<MethodDetail> methods)
        {
            _methods = methods;
        }

        /// <summary>
        /// 设置带方法体的method
        /// </summary>
        public void SetClassMethodMode()
        {
            _methodType = MethodEnum.ClassMethod;
        }

        /// <summary>
        /// 设置不带方法体的method
        /// </summary>
        public void SetInterfaceMethodMode()
        {
            _methodType = MethodEnum.InterfaceMethod;
        }

        /// <summary>
        /// 获取方法主体
        /// </summary>
        /// <param name="returnType">返回值</param>
        /// <param name="methodName">方法名</param>
        /// <param name="methodArgs">方法参数</param>
        /// <returns></returns>
        private string GetMethodBody(string returnType, string methodName, string methodArgs)
        {
            var body = $@"
                                public {returnType} {methodName} ({methodArgs}) 
                                {{
                                    return default({returnType});
                                }}";

            if(_methodType == MethodEnum.InterfaceMethod)
            {
                body = $"{returnType} {methodName} ({methodArgs});";
            }

            return body;
        }

        public override string GenerateCode()
        {
            StringBuilder sb = new StringBuilder();
            foreach (MethodDetail method in _methods)
            {
                sb.AppendLine(@$"
                        /// <summary>
                        /// {method.Remark}
                        /// </summary>");


                var args = string.Empty;
                var attStr = string.Empty;
                if (method.ParamList != null)
                {
                    foreach (var param in method.ParamList)
                    {
                        sb.AppendLine($"/// <param name=\"{param.Name}\">{param.Remark}</param>");

                        if (param.AttributeList != null)
                        {
                            var attributeList = param.AttributeList.Split(",");
                            foreach (var att in attributeList)
                            {
                                attStr += $"[{att}]";
                            }
                        }
                    }

                    args = string.Join(", ", method.ParamList.Select(t => $"{attStr}{t.Type} {t.Name}"));
                }
                sb.AppendLine($"/// <returns>{method.ReturnType}</returns>");
                if (method.AttributeList != null)
                {
                    var attributeList = method.AttributeList.Split(",");
                    foreach (var attribute in attributeList)
                    {
                        sb.AppendLine($"[{attribute}]");
                    }
                }
                    
                sb.AppendLine($"{GetMethodBody(method.ReturnType, method.Name, args)}");
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// 方法类型
    /// </summary>
    internal enum MethodEnum
    {
        /// <summary>
        /// 带方法体的method
        /// </summary>
        ClassMethod,
        /// <summary>
        /// 接口声明的method
        /// </summary>
        InterfaceMethod
    }

}
