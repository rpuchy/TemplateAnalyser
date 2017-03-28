using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml;

namespace Template_Analyser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AnalysisType_Wildcards.Checked)
            {
                label2.Text = "Wildcards";

                lstbox_wildcards.Items.Clear();

                string[] files = Directory.GetFiles(textBox1.Text);

                List<string> wildcards = new List<string>();

                foreach (string file in files)
                {
                    string docText = null;

                    using (StreamReader sr = new StreamReader(file))
                    {
                        docText = sr.ReadToEnd();
                    }

                    Regex regexText = new Regex("@@(.*?)@@");

                    Match m = regexText.Match(docText);


                    while (m.Success)
                    {
                        wildcards.Add(m.Value);

                        m = m.NextMatch();
                    }
                }

                //dedupe the list
                List<string> deduped = new List<string>(wildcards.Distinct<String>().ToList<string>());

                foreach (var wildcard in deduped)
                {

                    lstbox_wildcards.Items.Add(wildcard);
                }
            }

            if(AnalysisType_Products.Checked)
            {
                label2.Text = "Products";
                lstbox_wildcards.Items.Clear();

                string[] files = Directory.GetFiles(textBox1.Text);

                List<string> ProductTypes = new List<string>();

                foreach (string file in files)
                {
                    XmlDocument doc = new XmlDocument();

                    doc.Load(file);

                    string xpath = "//TaxWrapper/Product|//Products/Product";

                    XmlNodeList nodes = doc.SelectNodes(xpath);


                    if (nodes != null)
                    {
                        foreach (XmlNode node in nodes)
                        {
                            var type = node.SelectSingleNode(".//Type|.//type");
                            if (type != null)
                            {
                                ProductTypes.Add(type.InnerText);
                            }
                        }
                    }
                }

                //dedupe the list
                List<string> deduped = new List<string>(ProductTypes.Distinct<String>().ToList<string>());

                foreach (var wildcard in deduped)
                {

                    lstbox_wildcards.Items.Add(wildcard);
                }

            }

        }

        private void lstbox_wildcards_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wildcard = lstbox_wildcards.SelectedItem.ToString();

            string[] files = Directory.GetFiles(textBox1.Text);

            treeView1.Nodes.Clear();

            foreach (string file in files)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(file);
                string xpath = "";
                if (AnalysisType_Wildcards.Checked)
                {
                    xpath = "//*[text() = '" + wildcard + "']";
                }

                if (AnalysisType_Products.Checked)
                {
                    xpath = "//*[Type = '" + wildcard + "']";
                }

                XmlNodeList nodes = doc.SelectNodes(xpath);
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        //try get a descriptive name
                        string comp = "";
                        if (AnalysisType_Wildcards.Checked)
                        {
                            string name = node.ParentNode.SelectSingleNode("Name")?.InnerText;
                            comp = node.ParentNode.Name + "-" + name + "-" + node.Name;
                        }
                        if (AnalysisType_Products.Checked)
                        {
                            string name = node.SelectSingleNode(".//Name")?.InnerText;
                            string tax_wrapper = "";
                            if (node.ParentNode.Name == "Products")
                            {
                                tax_wrapper = node.ParentNode.ParentNode.SelectSingleNode(".//Name")?.InnerText  ;
                            }
                            else
                            {
                                tax_wrapper = node.ParentNode.SelectSingleNode(".//Name")?.InnerText;
                            }
                            comp = tax_wrapper + "-" + name + ":" + Path.GetFileName(file);
                        }
                        treeView1.Nodes.Add(new TreeNode(comp));
                        TreeNode tNode = new TreeNode();
                        tNode = treeView1.Nodes[treeView1.Nodes.Count - 1];
                        if (LoadNode.Checked)
                        {
                            AddNode(node, tNode);
                        }
                    }
                }

            }

            //treeView1.ExpandAll();

        }

        private void AddNode(XmlNode inXmlNode, TreeNode inTreeNode)
        {
            XmlNode xNode;
            TreeNode tNode;
            XmlNodeList nodeList;
            int i;

            // Loop through the XML nodes until the leaf is reached.
            // Add the nodes to the TreeView during the looping process.
            if (inXmlNode.HasChildNodes)
            {
                nodeList = inXmlNode.ChildNodes;
                for (i = 0; i <= nodeList.Count - 1; i++)
                {
                    xNode = inXmlNode.ChildNodes[i];
                    inTreeNode.Nodes.Add(new TreeNode(xNode.Name));
                    tNode = inTreeNode.Nodes[i];
                    AddNode(xNode, tNode);
                }
            }
            else
            {
                // Here you need to pull the data from the XmlNode based on the
                // type of node, whether attribute values are required, and so forth.
                inTreeNode.Text = (inXmlNode.OuterXml).Trim();
            }
        }

        private StreamWriter sr;
        // Xml tag for node, e.g. 'node' in case of <node></node>
        private const string XmlNodeTag = "node";

        // Xml attributes for node e.g. <node text="Asia" tag="" 
        // imageindex="1"></node>
        private const string XmlNodeTextAtt = "text";
        private const string XmlNodeTagAtt = "tag";
        private const string XmlNodeImageIndexAtt = "imageindex";

     

        private void button3_Click(object sender, EventArgs e)
        {
  
        }

        private void AnalysisType_Products_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (System.IO.StreamWriter file =
           new System.IO.StreamWriter(saveFileDialog1.FileName))
                {
                    foreach (TreeNode node in treeView1.Nodes)
                    {
                         file.WriteLine(node.Text);
                    }
                }
            }
            
        }
    }
}
