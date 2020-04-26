using HtmlAgilityPack;
using System;
using System.Text;
using System.Net;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace Wpfparser
{
    public class Parser
    {
        public static string[] LentaParse(string args)
        {
            try
            {
                var txtHTML = GetPage(args);
                var doc = new HtmlDocument();
                doc.LoadHtml(txtHTML);
                HtmlNode node = doc.DocumentNode.SelectSingleNode("//*/div[@class='b-text clearfix js-topic__text']");
                var txtTitle = FindText(txtHTML, @"<title>", @"</title>");
                var content1 = node.InnerText;
                var content2 = content1.Replace(".", ". ");
                return new string[] { txtTitle, content2 };
            }
            catch
            {
                return new string[] {"Что-то пошло не так", ""};
            }
        }
        public static string[] UniParse(string args)
        {
            try
            {
                var txtHTML = GetPage(args);
                var doc = new HtmlDocument();
                doc.LoadHtml(txtHTML);
                var txtTitle = FindText(txtHTML, @"<title>", @"</title>");
                var txtP = FindText(txtHTML, @"<p>", @"</p>");
                var content = RemoveUnwantedTags(txtP);
                return new string[] { txtTitle, content };
            }
            catch
            {
                return new string[] { "Что-то пошло не так", ""};
            }
        }
        public static string RemoveUnwantedTags(string data)
        {
            if (string.IsNullOrEmpty(data)) return string.Empty;

            var document = new HtmlDocument();
            document.LoadHtml(data);

            var acceptableTags = new String[] { "strong", "em", "u" };

            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (!acceptableTags.Contains(node.Name) && node.Name != "#text")
                {
                    var childNodes = node.SelectNodes("./*|./text()");

                    if (childNodes != null)
                    {
                        foreach (var child in childNodes)
                        {
                            nodes.Enqueue(child);
                            parentNode.InsertBefore(child, node);
                        }
                    }

                    parentNode.RemoveChild(node);

                }
            }

            return document.DocumentNode.InnerHtml;
        }
        public static String FindText(string source, string prefix, string suffix)
        {
            var prefixPosition = source.IndexOf(prefix, StringComparison.OrdinalIgnoreCase);
            var suffixPosition = source.IndexOf(suffix, prefixPosition + prefix.Length, StringComparison.OrdinalIgnoreCase);
            if ((prefixPosition >= 0) && (suffixPosition >= 0) && (suffixPosition > prefixPosition) && ((prefixPosition + prefix.Length) <= suffixPosition))
            {
                return source.Substring(prefixPosition + prefix.Length, suffixPosition - prefixPosition - prefix.Length);
            }
            else
            {
                return String.Empty;
            }
        }
        public static string GetPage(string url)
        {
            var result = String.Empty;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var responseStream = response.GetResponseStream();
                if (responseStream != null)
                {
                    StreamReader streamReader;
                    if (response.CharacterSet != null)
                    {
                        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
                        streamReader = new StreamReader(responseStream, Encoding.GetEncoding(response.CharacterSet));
                    }
                    else
                        streamReader = new StreamReader(responseStream);
                    result = streamReader.ReadToEnd();
                    streamReader.Close();
                }
                response.Close();
            }
            return result;
        }
    }
}
