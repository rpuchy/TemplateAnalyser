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

            lstbox_wildcards.Items.Clear();

            string[] files = Directory.GetFiles(textBox1.Text);

            List<string> wildcards = new List<string>();

            foreach(string file in files)
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

        private void lstbox_wildcards_SelectedIndexChanged(object sender, EventArgs e)
        {
            string wildcard = lstbox_wildcards.SelectedItem.ToString();

            string[] files = Directory.GetFiles(textBox1.Text);

            treeView1.Nodes.Clear();

            foreach (string file in files)
            {
                XmlDocument doc = new XmlDocument();

                doc.Load(file);

                string xpath = "//*[text() = '" + wildcard + "']";


                XmlNodeList nodes = doc.SelectNodes(xpath);
                if (nodes != null)
                {
                    foreach (XmlNode node in nodes)
                    {
                        //try get a descriptive name
                        string name = node.ParentNode.SelectSingleNode("Name")?.InnerText;

                        treeView1.Nodes.Add(new TreeNode(node.ParentNode.Name+"-"+name+"-"+node.Name));
                        TreeNode tNode = new TreeNode();
                        tNode = treeView1.Nodes[treeView1.Nodes.Count - 1];

                        AddNode(node.ParentNode, tNode);
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

    }
}
