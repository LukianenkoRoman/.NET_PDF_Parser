using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Texts;
using Parser.Infrastructure.Interfaces;
using System.Security.Cryptography.X509Certificates;

namespace Parser.Infrastructure.Realization
{
    public class ParsCollector : IParsCollector
    {
        private string pdfFilePath;

        public ParsCollector(string filePath)
        {
            pdfFilePath = filePath;
        }

        public Dictionary<string, string> CollectedText()
        {
            RectangleF[] extractAreas = new RectangleF[]
            {
                new RectangleF(255, 100, 160, 30),
                new RectangleF(250, 150, 450, 60),
                new RectangleF(250, 220, 100, 30),
                new RectangleF(250, 255, 100, 30),
                new RectangleF(250, 290, 100, 30),
                new RectangleF(250, 330, 150, 30),
                new RectangleF(425, 220, 90, 30),
                new RectangleF(425, 255, 100, 30),
                new RectangleF(425, 290, 100, 30),
                new RectangleF(65, 330, 150, 30),
                new RectangleF(65, 410, 500, 30),
                new RectangleF(65, 460, 260, 60),
                new RectangleF(65, 530, 300, 30),
                new RectangleF(320, 460, 260, 30),
                new RectangleF(65, 565, 200, 30),
                new RectangleF(320, 565, 50, 30),
                new RectangleF(390, 565, 140, 30),
                new RectangleF(65, 640, 450, 40),
                new RectangleF(65, 690, 150, 30),
                new RectangleF(215, 690, 300, 30),
                new RectangleF(90, 730, 120, 30),
                new RectangleF(215, 735, 190, 20)
            };

            string[] collumNames = new string[]
            {
                "AaccountingStatus",
                "Name",
                "BirthDate",
                "MilitaryService",
                "DocumentDeadline",
                "WithdrawalReason",
                "RNOKPP",
                "AdjournmentTo",
                "AdjournmentType",
                "Created",
                "TCKandSP",
                "VLKDecree",
                "VLKDecree1",
                "VLKDate",
                "Rank",
                "VOC",
                "NumberInOberig",
                "Adress",
                "Phone",
                "Email",
                "IsInTime",
                "DateOfConforming"
            };

            Dictionary<string, string> extractedData = new Dictionary<string, string>();

            string key12 = "VLKDecree";
            string key13 = "VLKDecree1";
            if (extractedData.ContainsKey(key12) && extractedData.ContainsKey(key13))
            {
                string combinedValue = extractedData[key12] + " " + extractedData[key13];
                extractedData["FullVLKDecree"] = combinedValue;
                extractedData.Remove(key12);
                extractedData.Remove(key13);
            }

            for (int i = 0; i < extractAreas.Length; i++)
            {
                PdfParser extractor = new PdfParser(pdfFilePath, extractAreas[i]);
                string extractedText = extractor.ExtractText();
                string clrearData = extractedText.Replace("Evaluation Warning : The document was created with Spire.PDF for .NET. ", "");

                string key = collumNames[i];
                extractedData[key] = clrearData;
            }

            return extractedData;
        }
    }
}