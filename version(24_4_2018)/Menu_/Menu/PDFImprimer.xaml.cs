/*
 * Created by SharpDevelop.
 * User: hamza
 * Date: 02/04/2018
 * Time: 13:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using SelectPdf;
using HTML_Producer;
using System.IO;

namespace Menu
{
    /// <summary>
    /// Interaction logic for Page9.xaml
    /// </summary>
    public partial class PDFImprimer : Page
    {
        public List<Listview_content> list;
        public PDFImprimer(List<Listview_content> f)
        {
            list = f;
            InitializeComponent();
        }
        static String html;
        static List<medID_qunt> List;

        private void webpage_Initialized(object sender, System.EventArgs e)
        {


            StringWriter sb = new StringWriter();
            sb.WriteLine("<?xml v='1.0'>");
            sb.WriteLine("<html>");
            sb.WriteLine("<head>");
            sb.WriteLine("</head>");
            sb.WriteLine("<body>");
            sb.WriteLine(@"<h1 Style='color:red;'>h1 title</h1>");
            sb.WriteLine("<h2>h2 title</h2>");
            sb.WriteLine("<h3>h3 title</h3>");
            sb.WriteLine("<h3>h3(2) title</h3>");
            sb.WriteLine("<h4>h4 title</h4>");
            sb.WriteLine("<h4>h4(2) title</h4>");
            sb.WriteLine("<h5>h5 title</h5>");
            sb.WriteLine("<h5>h5(2) title</h5>");
            sb.WriteLine("<h6>h6 title</h6>");
            sb.WriteLine("<h6>h6(2) title</h6>");
            sb.WriteLine("<h6>h6(3) title</h6>");
            sb.WriteLine("<h2>h2(2) title</h2>");
            sb.WriteLine("<h3>h3 title</h3>");
            sb.WriteLine("<h4>h4 title</h4>");
            sb.WriteLine("<h5>h5 title</h5>");
            sb.WriteLine("<h6>h6 title</h6>");

            sb.WriteLine("<p>p paragraph</p>");
            sb.WriteLine("<pre>pre paragraph</pre>");
            sb.WriteLine("<div class=\"b\">div paragraph (class=b)</div>");
            sb.WriteLine("<p>a link: <a href=\"http://www.foo.com\">hyperlink</a></div>");

            sb.WriteLine("<verbatim>my first <b>verbatim</b> paragraph</verbatim>");

            sb.WriteLine("<p align=\"left\">left aligned</p>");
            sb.WriteLine("<p align=\"right\">right aligned</p>");
            sb.WriteLine("<p align=\"center\">centered</p>");

            sb.WriteLine("<p>paragraph with <b>bold (b)</b> elements</p>");
            sb.WriteLine("<p>paragraph with <em>emphasized (em)</em> elements</p>");
            sb.WriteLine("<p>paragraph with <tt>typewriter (tt)</tt> elements</p>");
            sb.WriteLine("<p>paragraph with <code>code (code)</code> elements</p>");
            sb.WriteLine("<p>paragraph with <span class=\"em\">span elements (class = em)</span></p>");

            sb.WriteLine("<ul><li>Unordered</li><li>list</li></ul>");
            sb.WriteLine("<ol><li>Ordered</li><li>list</li></ol>");

            sb.WriteLine("<ol>");
            sb.WriteLine("<li>");
            sb.WriteLine("<ul><li>sub-item 1</li><li>sub item 2</li></ul>");
            sb.WriteLine("</li>");
            sb.WriteLine("<li>ordered item</li></ol>");

            sb.WriteLine("<p align=\"center\"><img src=\"actions.png\" height=\"400\" width=\"400\" /></p>");

            sb.WriteLine("</body>");
            sb.WriteLine("</html>");
          
            //Pdfizer.HtmlToPdfConverter f = new HtmlToPdfConverter();


            html = sb.ToString();
            html = SerializeHtml_v1.Output(list);



            /* MessageBox.Show( Encoding.UTF8.GetString(output.ToArray()));*/
            ((WebBrowser)sender).NavigateToString(html);




        }
        void Button_Click(object sender, RoutedEventArgs e)
        {

            File.WriteAllText("file.html", html);
            string file = "File.pdf";

            try
            {
                MessageBox.Show("Conversion  ... ");
                // read parameters from the form
                string htmlString = html;
                string baseUrl = ".";


                int webPageWidth = 1024;
                try
                {
                    webPageWidth = Convert.ToInt32(htmlString);
                }
                catch { }

                int webPageHeight = 0;
                try
                {
                    webPageHeight = Convert.ToInt32(htmlString);
                }
                catch { }

                // instantiate a html to pdf converter object
                HtmlToPdf converter = new HtmlToPdf();

                // set converter options
                converter.Options.AutoFitWidth = HtmlToPdfPageFitMode.AutoFit;
                converter.Options.PdfPageSize = PdfPageSize.A4;
                converter.Options.WebPageWidth = 630;

                converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
                converter.Options.MarginLeft = 10;
                converter.Options.MarginRight = 10;
                converter.Options.MarginTop = 20;
                converter.Options.MarginBottom = 20;


                // create a new pdf document converting an url
                PdfDocument doc = converter.ConvertHtmlString(htmlString, baseUrl);

                // save pdf document
                doc.Save(file);

                // close pdf document
                doc.Close();
            }
            catch (Exception ex)
            {

                return;
            }
            try
            {
                System.Diagnostics.Process.Start("File.pdf");
            }
            catch
            {

            }

            MessageBox.Show("Done");

        }
        static int indic = 500;
    }
}