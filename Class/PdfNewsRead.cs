using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ABdula.Model;
using iTextSharp.text.pdf;
using iTextSharp.text;
using iTextSharp.text.pdf.parser;
using System.IO;
using System.Text.RegularExpressions;

namespace ABdula.Class
{
    class PdfNewsRead : IReadInfo<News>
    {
        private string _Path;
        private PdfReader _Pdf;

        public ObservableCollection<News> ReadInformatin()
        {
            ObservableCollection<News> news = new ObservableCollection<News>();

            string[] Names = Directory.GetFiles(_Path);

            foreach (string Name in Names)
            {
                news.Add(ReadOneNews(Name));
            }

            return news;
        }

        public PdfNewsRead(string FileName)
        {
            _Path = FileName;
        }

        private News ReadOneNews(string FileName)
        {
            News NewsOne = new News();
            StringBuilder builder = new StringBuilder();
            using(_Pdf = new PdfReader(FileName))
            {
                for(int i = 1; i <= _Pdf.NumberOfPages; i++)
                {
                    builder.Append(PdfTextExtractor.GetTextFromPage(_Pdf, i));
                }
                NewsOne.NewsInfo = builder.ToString();
            }

            string[] lines = builder.ToString().Split('\n');

            NewsOne.Title = lines[0];

            NewsOne.DateTimePub = File.GetLastWriteTime(FileName);

            NewsOne.NewsInfo = NewsOne.NewsInfo.Remove(0, NewsOne.NewsInfo.IndexOf("\n"));
            return NewsOne;
        }
    }
}
