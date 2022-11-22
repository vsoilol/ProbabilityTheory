using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace IndividualTask2.Helpers
{
    public class WordprocessingHelper
    {
        public string GetSize(int size) => (size * 2).ToString();

        public Paragraph CreateParagraphWithText(string text, string styleId)
        {
            return new Paragraph(
                new ParagraphProperties(new ParagraphStyleId { Val = styleId }),
                new Run(new Text(text)));
        }

        public Paragraph CreateParagraphWithText(string text,
            string fontSize = "24",
            JustificationValues justificationValues = JustificationValues.Left)
        {
            return new Paragraph(
                new ParagraphProperties(new Justification { Val = justificationValues }),
                new Run(new RunProperties(new FontSize { Val = fontSize }),
                    new Text(text)));
        }

        public Paragraph CreateEmptyParagraph(string fontSize = "24")
        {
            var para = new Paragraph();
            var paraProps = new ParagraphProperties();
            var paraRunProps = new ParagraphMarkRunProperties();
            var runStyl = new RunStyle { Val = "Table9Point" };
            paraRunProps.Append(runStyl);
            var runFont = new FontSize { Val = fontSize };
            paraRunProps.Append(runFont);
            paraProps.Append(paraRunProps);
            para.Append(paraProps);

            return para;
        }

        public Paragraph CreateBoldParagraph(string text, string fontSize = "24",
            JustificationValues justificationValues = JustificationValues.Left)
        {
            return new Paragraph(
                new ParagraphProperties(new Justification { Val = justificationValues }),
                new Run(new RunProperties(new FontSize { Val = fontSize }, new Bold()),
                    new Text(text)));
        }

        public Paragraph CreateItalicParagraph(string text, string fontSize = "24",
            JustificationValues justificationValues = JustificationValues.Left)
        {
            var para = new Paragraph(new ParagraphProperties(new Justification { Val = justificationValues }));

            var run = new Run(new RunProperties(new FontSize { Val = fontSize }, new Italic()), new Text(text));
            para.Append(run);

            return para;
        }

        public void AddNewStyle(StyleDefinitionsPart styleDefinitionsPart,
            string styleid, string stylename)
        {
            // Get access to the root element of the styles part.
            Styles styles = styleDefinitionsPart.Styles;

            // Create a new paragraph style and specify some of the properties.
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = styleid,
                CustomStyle = true
            };
            StyleName styleName1 = new StyleName() { Val = stylename };
            BasedOn basedOn1 = new BasedOn() { Val = "Normal" };
            NextParagraphStyle nextParagraphStyle1 = new NextParagraphStyle() { Val = "Normal" };
            style.Append(styleName1);
            style.Append(basedOn1);
            style.Append(nextParagraphStyle1);

            // Create the StyleRunProperties object and specify some of the run properties.
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            Bold bold1 = new Bold();
            Color color1 = new Color() { ThemeColor = ThemeColorValues.Accent2 };
            RunFonts font1 = new RunFonts() { Ascii = "Lucida Console" };
            Italic italic1 = new Italic();
            // Specify a 12 point size.
            FontSize fontSize1 = new FontSize() { Val = "24" };
            styleRunProperties1.Append(bold1);
            styleRunProperties1.Append(color1);
            styleRunProperties1.Append(font1);
            styleRunProperties1.Append(fontSize1);
            styleRunProperties1.Append(italic1);

            // Add the run properties to the style.
            style.Append(styleRunProperties1);

            // Add the style to the styles part.
            styles.Append(style);
        }

        public void AddAllNeededStyles(WordprocessingDocument wordDocument)
        {
            // Get the Styles part for this document.
            StyleDefinitionsPart part =
                wordDocument.MainDocumentPart.StyleDefinitionsPart;

            // If the Styles part does not exist, add it and then add the style.
            if (part == null)
            {
                part = AddStylesPartToPackage(wordDocument);
            }

            part.Styles.Append(CreateHeading1Style(), CreateHeading2Style(), CreateTableGridStyle());
        }

        private StyleDefinitionsPart AddStylesPartToPackage(WordprocessingDocument doc)
        {
            StyleDefinitionsPart part;
            part = doc.MainDocumentPart.AddNewPart<StyleDefinitionsPart>();
            Styles root = new Styles();
            root.Save(part);
            return part;
        }

        private Style CreateHeading1Style()
        {
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = Constants.Styles.Heading1,
                BasedOn = new BasedOn() { Val = "Normal" },
                NextParagraphStyle = new NextParagraphStyle() { Val = "Normal" }
            };

            StyleName styleName1 = new StyleName() { Val = "heading 1" };
            style.Append(styleName1);
            style.Append(new PrimaryStyle());
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            styleRunProperties1.Append(new Bold());

            styleRunProperties1.Append(new RunFonts()
            {
                Ascii = Constants.Fonts.TimesNewRoman,
                HighAnsi = Constants.Fonts.TimesNewRoman,
                EastAsia = Constants.Fonts.TimesNewRoman,
                ComplexScript = Constants.Fonts.TimesNewRoman
            });
            styleRunProperties1.Append(new FontSize() { Val = GetSize(16) });
            style.Append(styleRunProperties1);

            StyleParagraphProperties styleParagraphProperties =
                new StyleParagraphProperties(
                    new SpacingBetweenLines
                        { Line = "240", After = "240", Before = "240", LineRule = LineSpacingRuleValues.Auto },
                    new Justification { Val = JustificationValues.Center },
                    new OutlineLevel { Val = 0 });
            style.Append(styleParagraphProperties);

            return style;
        }

        private Style CreateHeading2Style()
        {
            Style style = new Style()
            {
                Type = StyleValues.Paragraph,
                StyleId = Constants.Styles.Heading2,
                BasedOn = new BasedOn() { Val = "Normal" },
                NextParagraphStyle = new NextParagraphStyle() { Val = "Normal" }
            };

            StyleName styleName1 = new StyleName() { Val = "heading 2" };
            style.Append(styleName1);
            style.Append(new PrimaryStyle());
            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            styleRunProperties1.Append(new Bold());

            styleRunProperties1.Append(new RunFonts()
            {
                Ascii = Constants.Fonts.TimesNewRoman,
                HighAnsi = Constants.Fonts.TimesNewRoman,
                EastAsia = Constants.Fonts.TimesNewRoman,
                ComplexScript = Constants.Fonts.TimesNewRoman
            });
            styleRunProperties1.Append(new FontSize() { Val = GetSize(14) });

            style.Append(styleRunProperties1);

            StyleParagraphProperties styleParagraphProperties =
                new StyleParagraphProperties(
                    new Indentation { FirstLine = "709" },
                    new SpacingBetweenLines() { Line = "240", LineRule = LineSpacingRuleValues.Auto },
                    new Justification { Val = JustificationValues.Both },
                    new OutlineLevel { Val = 1 });
            style.Append(styleParagraphProperties);

            return style;
        }

        private Style CreateTableGridStyle()
        {
            Style style = new Style()
            {
                Type = StyleValues.Table,
                StyleId = Constants.Styles.TableGrid,
                BasedOn = new BasedOn() { Val = "Normal Table" }
            };

            StyleName styleName1 = new StyleName() { Val = "Table Grid" };
            style.Append(styleName1);

            StyleRunProperties styleRunProperties1 = new StyleRunProperties();
            styleRunProperties1.Append(new Bold());

            styleRunProperties1.Append(new RunFonts()
            {
                Ascii = Constants.Fonts.TimesNewRoman,
                HighAnsi = Constants.Fonts.TimesNewRoman,
                EastAsia = Constants.Fonts.TimesNewRoman,
                ComplexScript = Constants.Fonts.TimesNewRoman
            });
            styleRunProperties1.Append(new FontSize() { Val = GetSize(12) });

            style.Append(styleRunProperties1);

            StyleParagraphProperties styleParagraphProperties =
                new StyleParagraphProperties(
                    new SpacingBetweenLines() { Line = "240", After = "0", LineRule = LineSpacingRuleValues.Auto });
            style.Append(styleParagraphProperties);

            StyleTableProperties styleTableProperties = new StyleTableProperties
            {
                TableBorders = new TableBorders
                {
                    TopBorder = new TopBorder { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                    LeftBorder = new LeftBorder { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                    BottomBorder = new BottomBorder { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                    RightBorder = new RightBorder { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                    InsideHorizontalBorder = new InsideHorizontalBorder
                        { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                    InsideVerticalBorder = new InsideVerticalBorder
                        { Val = BorderValues.Single, Size = 4, Space = 0, Color = "auto" },
                },
                TableIndentation = new TableIndentation
                {
                    Width = 0,
                    Type = TableWidthUnitValues.Dxa,
                },
                TableCellMarginDefault = new TableCellMarginDefault
                {
                    TopMargin = new TopMargin{Width = "0", Type = TableWidthUnitValues.Dxa},
                    BottomMargin = new BottomMargin{Width = "0", Type = TableWidthUnitValues.Dxa},
                    TableCellLeftMargin = new TableCellLeftMargin{Width = 108, Type = TableWidthValues.Dxa},
                    TableCellRightMargin = new TableCellRightMargin{Width = 108, Type = TableWidthValues.Dxa}
                },
            };

            style.Append(styleTableProperties);
            
            /*StyleTableCellProperties styleTableCellProperties = new StyleTableCellProperties
            {
                Tab
            }*/

            return style;
        }
    }
}