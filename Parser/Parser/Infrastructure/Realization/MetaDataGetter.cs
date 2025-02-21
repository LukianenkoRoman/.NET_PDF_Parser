using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;

namespace Parser.Infrastructure.Realization
{
    public class MetaDataGetter
    {
        private string inputPath;
        public MetaDataGetter(string inputChekPath) 
        { 
            inputPath = inputChekPath;
        }

        public string getMetaData()               
        {
            string directory = Path.GetDirectoryName(inputPath); 
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(inputPath); 
            string extension = Path.GetExtension(inputPath);
            var outputPath = Path.Combine(directory, $"{fileNameWithoutExtension}{"_Modified"}{extension}");  

            PdfSharp.Pdf.PdfDocument document = PdfSharp.Pdf.IO.PdfReader.Open(inputPath, PdfDocumentOpenMode.Modify); //opening file to read
            string DocumentTitle = document.Info.Title; //getting title from metadata

            return DocumentTitle;
        }
    }
}
