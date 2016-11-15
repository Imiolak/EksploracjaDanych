using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace EuroFunds.DataLoader.ResourceLoader.Reader
{
    public class OpenXmlResourceReader : IResourceReader
    {
        public IEnumerable<string[]> ReadRows(FileInfo resource)
        {
            var rows = new List<string[]>();

            using (var document = SpreadsheetDocument.Open(resource.FullName, isEditable: false))
            {
                var workbook = document.WorkbookPart;
                var stringTable = workbook.SharedStringTablePart;
                var sheet = workbook.WorksheetParts.First();
                var sheetData = sheet.Worksheet.Elements<SheetData>().First();
                var cellsInRow = sheetData.Elements<Row>().ElementAt(5).Elements<Cell>().Count();
                
                foreach (var row in sheetData.Elements<Row>().Skip(4))
                {
                    var cellValues = new string[cellsInRow];

                    var cells = row.Elements<Cell>().ToArray();
                    for (var i = 0; i < cellsInRow; i++)
                    {
                        var cell = cells[i];

                        if (IsCellNumber(cell))
                        {
                            cellValues[i] = cell.CellValue.Text;
                        }
                        else
                        {
                            cellValues[i] = stringTable.SharedStringTable.ElementAt(int.Parse(cell.CellValue.Text)).InnerText;
                        }
                    }

                    rows.Add(cellValues);
                }
            }

            return rows;
        }

        private static bool IsCellNumber(CellType cell)
        {
            return cell.DataType == null;
        }
    }
}
