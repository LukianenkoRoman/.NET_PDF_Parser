using System;
using System.Drawing;
using System.IO;
using Spire.Pdf;
using Spire.Pdf.Texts;
using ExtractTextFromPage;
using System.Collections.Generic;
using Parser;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;

namespace ExtractTextFromPage
{
    class Program
    {
        static void Main(string[] args)
        {
            MeinMailer meinMailer = new MeinMailer();
            meinMailer.MalerMain();
        }
    }
}