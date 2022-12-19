using System;
using System.Globalization;
using System.IO;
using System.Linq;
using Common.Constants;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using IndividualTask2.Helpers;
using IndividualTask2.Models;
using Styles = Common.Constants.Styles;

namespace IndividualTask2
{
    public class DocumentService
    {
        private readonly WordprocessingHelper _wordprocessingHelper;

        private const string FontSize = "24";

        public DocumentService(WordprocessingHelper wordprocessingHelper)
        {
            _wordprocessingHelper = wordprocessingHelper;
        }

        public int[] GetNumbersFromFile(int i, int n)
        {
            int[] numbers;

            using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(PathInfo.DataDocumentPath, false))
            {
                numbers = wordDocument.MainDocumentPart.RootElement.Descendants<Paragraph>()
                    .Select(_ => _.GetFirstChild<Run>()?.InnerText)
                    .Where(_ => _ is not null)
                    .Skip(i - 1).Take(n).Select(int.Parse).ToArray();
            }

            return numbers;
        }

        public void GenerateResultDocument(MathData mathData)
        {
            using (WordprocessingDocument wordDocument =
                   WordprocessingDocument.Create(PathInfo.ResultDocumentPath, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();

                mainPart.Document = new Document();
                //mainPart.StyleDefinitionsPart = new StyleDefinitionsPart();
                Body docBody = new Body();
                SetLayoutToDocument(docBody);

                _wordprocessingHelper.AddAllNeededStyles(wordDocument);

                AddTaskOne(docBody, mathData);

                mainPart.Document.Append(docBody);
            }
        }

        private void SetLayoutToDocument(Body docBody)
        {
            var sectionProperty = new SectionProperties
            {
                InnerXml =
                    "<w:pgMar w:top=\"720\" w:right=\"720\" w:bottom=\"720\" w:left=\"720\" w:header=\"720\" w:footer=\"720\" w:gutter=\"0\" />"
            };
            docBody.Append(sectionProperty);
        }

        private void AddTaskOne(Body docBody, MathData mathData)
        {
            var taskNumber =
                _wordprocessingHelper.CreateParagraphWithText("№ 1", Styles.Heading1);

            var taskAInfo = _wordprocessingHelper.CreateParagraphWithText("а) построить дискретный статистический ряд",
                Styles.Heading2);

            Table table = new Table();

            TableProperties tblProp = new TableProperties();
            TableWidth tableWidth = new TableWidth() { Width = "5000", Type = TableWidthUnitValues.Pct };
            TableStyle tableStyle = new TableStyle() { Val = Styles.TableGrid };
            tblProp.Append(tableStyle, tableWidth);
            // Append the TableProperties object to the empty table.
            table.AppendChild<TableProperties>(tblProp);

            // Create a row.
            TableRow tableRow1 = new TableRow(new TableCell(
                new TableCellProperties
                {
                    TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto }
                },
                new Paragraph(
                    new Run(new Text("x")))));
            TableRow tableRow2 = new TableRow(new TableCell(
                new TableCellProperties
                {
                    TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto }
                },
                new Paragraph(
                    new Run(new Text("n")))));
            TableRow tableRow3 = new TableRow(new TableCell(
                new TableCellProperties
                { TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto } },
                new Paragraph(new Run(new Text("W")))));

            foreach (var statisticalData in mathData.Values)
            {
                tableRow1.Append(new TableCell(new TableCellProperties
                        { TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto } },
                    new Paragraph(new Run(new Text(statisticalData.Value.ToString())))));
                
                tableRow2.Append(new TableCell(new TableCellProperties
                        { TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto } },
                    new Paragraph(new Run(new Text(statisticalData.Count.ToString())))));
                
                tableRow3.Append(new TableCell(new TableCellProperties
                        { TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Auto } },
                    new Paragraph(new Run(new Text(statisticalData.Frequency.ToString(CultureInfo.InvariantCulture))))));
            }


            /*TableCellProperties tableCellProperties = new TableCellProperties
            {
                TableCellWidth = new TableCellWidth { Type = TableWidthUnitValues.Pct, Width = "50%" }
            };*/

            table.Append(tableRow1, tableRow2, tableRow3);

            docBody.Append(taskNumber);
            docBody.Append(taskAInfo);
            docBody.Append(table);
        }

        private void AddStyles(StyleDefinitionsPart part, WordprocessingDocument wordDocument)
        {
        }
    }
}