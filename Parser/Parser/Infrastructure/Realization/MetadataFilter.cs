using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text.pdf;
using Parser.Infrastructure.Interfaces;
using Parser.Infrastructure.Realization;

namespace Parser.Infrastructure.Realization
{
    public class MetadataFilter : IMetadataFilter
    {
        private string chekPath;
        public MetadataFilter(string inputChek)
        {
            chekPath = inputChek;
        }

        public bool FilterByMetadata()
        { 
            MetaDataGetter metaDataGetter = new MetaDataGetter(chekPath);
            string suspectData = metaDataGetter.getMetaData();
            string correctData = "Військово-обліковий документ"; //string with data we need to have in title of file

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); //encoding configurations to get data in same encoding
            Encoding utf8 = Encoding.UTF8;
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            byte[] suspectBytes = win1251.GetBytes(suspectData);
            string suspectDataUtf8 = utf8.GetString(suspectBytes);
            byte[] correctBytes = win1251.GetBytes(correctData);
            string correctDataUtf8 = utf8.GetString(correctBytes);

            if (string.Equals(correctDataUtf8, suspectDataUtf8, StringComparison.OrdinalIgnoreCase)) //filtering by metadata
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
