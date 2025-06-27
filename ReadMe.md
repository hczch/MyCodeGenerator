# MyCodeGenerator



个人代码生成小工具

这个项目是根据自己使用的项目架构而设计的，用于提高开发效率的个人实践

- 可生成控制器，逻辑业务类，数据模型类的模板文件

- 可以自定义类方法，方法参数，方法返回值注释等等

- 可以自定义类属性字段类型，名称，注释等等

  

```C#
//代码格式：

//WebProjectCodeGenerator C1(WEB项目代码生成器)
//1、Model类
public class {ModelName}
{
	public {Type} {PropertyName} {get; set;}
    //...
}

//2、Interface类
public interface I{ModelName}：IDendency
{
	//...
}

//3、BLL类
public class {ModelName}BLL :  I{ModelName}
{
	//...
}

//4、Controller
public class {Controller} : Controller
{
    //...
}

//5方法
public {Type} {MethodName}()
{
	return default({Type});    
}

//命名空间
namespace {ProjectName}.{FolderName}
{

}
```

