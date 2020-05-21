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
            string text = "";
            for (int startind = 0; startind <= source.Length;)
            {
                int prefixPosition = source.IndexOf(prefix, startind, StringComparison.OrdinalIgnoreCase);
                int suffixPosition = source.IndexOf(suffix, prefixPosition + prefix.Length, StringComparison.OrdinalIgnoreCase);
                if ((prefixPosition >= 0) && (suffixPosition >= 0) && (suffixPosition > prefixPosition) && ((prefixPosition + prefix.Length) <= suffixPosition))
                {
                    text += source.Substring(prefixPosition + prefix.Length, suffixPosition - prefixPosition - prefix.Length);
                    startind = suffixPosition;
                }
                else
                {
                    break;
                }
            }
            return text;
        }
        public static string GetPage(string url)
        {
            string result = String.Empty;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Stream responseStream = response.GetResponseStream();
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
