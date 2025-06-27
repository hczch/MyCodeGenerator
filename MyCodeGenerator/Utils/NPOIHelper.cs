using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCodeGenerator.Info;

namespace MyCodeGenerator.Utils
{
    public static class NPOIHelper
    {
        public static List<ModelDetail> GetModelData()
        {
            List<ModelDetail> list = new List<ModelDetail>();

            using (FileStream fs = new FileStream(@"D:\User\Document\WorkDoc\MyCodeGenerator\CodeGenTemplate.xlsx", FileMode.Open, FileAccess.Read))
            {
                XSSFWorkbook workBook = new XSSFWorkbook(fs);
                ISheet sheet = workBook.GetSheet("Model");

                var rowNum = sheet.LastRowNum;
                var colNum = sheet.GetRow(0).LastCellNum;
                for (int r = 1; r < rowNum; r++)
                {
                    var model = new ModelDetail()
                    {
                        Name = sheet.GetRow(r).GetCell(0).StringCellValue,
                        PropertyList = new List<PropertyDetail>()
                    };
                    list.Add(model);
                }
                
                Console.WriteLine(sheet.LastRowNum);
                Console.WriteLine(sheet.GetRow(0).LastCellNum);
                for (int r = 0; r < 10; r++)
                {
                    for (int c = 0; c < 10; c++)
                    {
                        // 读取单元格内容（前提是单元格存在）
                        Console.WriteLine(sheet.GetRow(r).GetCell(c));

                    }
                }
            }

            return new List<ModelDetail>();
        }
    }
}
