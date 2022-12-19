using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Constants;
using Common.ExcelHelpers;
using Common.Models;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;

namespace Common.Extensions
{
    public class StudentDistribution
    {
        private static readonly string PathToExcel;

        static StudentDistribution()
        {
            PathToExcel = Path.Combine(PathInfo.SolutionDirectory,
                $"{nameof(Common)}/Documents/StudentDistribution.xlsx");
        }

        public static double GetFunctionValue(double y, int n)
        {
            var values = GetValues();

            var result = values.FirstOrDefault(_ => _.Y == y).Values[n];
            return result;
        }

        private static StudentDistributionValue[] GetValues()
        {
            var value = new List<StudentDistributionValue>();

            using (FileStream fs = new FileStream(PathToExcel, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (SpreadsheetDocument doc = SpreadsheetDocument.Open(fs, false))
                {
                    WorkbookPart workbookPart = doc.WorkbookPart;
                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    Worksheet sheet = worksheetPart.Worksheet;

                    var rows = sheet
                        .Descendants<Row>()
                        .Where(_ => !SpreedsheetHelper.GetRowCells(_).All(cell => cell.CellValue is null));

                    foreach (var cell in rows.First().Elements<Cell>())
                    {
                        value.Add(new StudentDistributionValue(double.Parse(cell.CellValue.Text),
                            new Dictionary<int, double>()));
                    }

                    foreach (Row row in rows.Skip(1))
                    {
                        var cells = SpreedsheetHelper.GetRowCells(row);
                        var n = cells.First().CellValue is null
                            ? Int32.MaxValue
                            : int.Parse(cells.First().CellValue.Text);

                        for (int i = 1; i < cells.Count(); i++)
                        {
                            value[i - 1].Values.Add(n, Math.Round(double.Parse(cells.ElementAt(i).CellValue.Text), 3));
                        }
                    }
                }
            }

            return value.ToArray();
        }
    }
}