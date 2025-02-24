using System;
using System.Drawing;
using System.IO;
using Parser.Infrastructure.Interfaces;
using Spire.Pdf;
using Spire.Pdf.Texts;
using Parser.Infrastructure.Realization;
using System.Reflection.Metadata;

namespace Parser.Infrastructure.Realization
{
    public class PdfParser : IPdfParcer
    {
        private string _pdfFilePath;                //path to origin file that will be parsed(I will change for special function some time leter)
        private string _outputFilePath;             //path to output file(if you will not use db)
        private RectangleF _extractArea;            //variable to select pdf file cordinates what u will use to chose requested data

        public PdfParser(string pdfFilePath, RectangleF extractArea)
        {
            _pdfFilePath = pdfFilePath;
            _extractArea = extractArea;
        }

        public string ExtractText()
        {
            PdfDocument doc = new PdfDocument(); //instant of used library class
            doc.LoadFromFile(_pdfFilePath); //getting path to file we need
            PdfPageBase page = doc.Pages[0]; //file pages counter

            PdfTextExtractor textExtractor = new PdfTextExtractor(page); //instant of used library class
            PdfTextExtractOptions extractOptions = new PdfTextExtractOptions(); //instant of used library class

            extractOptions.ExtractArea = _extractArea; //defination of parsing cordinates
            string text = textExtractor.ExtractText(extractOptions); //variable of getted text

            return text;
        }
    }
}