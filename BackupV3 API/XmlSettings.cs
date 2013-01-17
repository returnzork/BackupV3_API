using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;


namespace returnzork.XmlSettings
{
    public class XmlSettings
    {
        private string Config;

        /// <summary>
        /// Start xml reader
        /// </summary>
        /// <param name="Config">Location of the XML configuration file</param>
        public XmlSettings(string Config)
        {
            this.Config = Config;
        }

        ///<summary>
        ///Gets key from XML configuration file
        ///</summary>
        ///<param name="key">
        ///The key you want the value from
        /// </param>
        public string GetKey(string key)
        {
            XmlDocument xd = new XmlDocument();
            XmlNode node;
            xd.Load(Config);
            node = xd.SelectSingleNode("descendant::*[name(.) = '" + key + "']");
            try
            {
                return node.InnerText.ToString();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }


        private string[] Keys = { };
        /// <summary>
        /// Return all nodes in given xml document
        /// </summary>
        public string[] GetAllKeys()
        {
            int NodeNum = 0;


            FileStream fs = new FileStream(Config, FileMode.Open);

           XmlReader rdr = XmlReader.Create(new System.IO.StreamReader(fs));


            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    Array.Resize(ref Keys, Keys.Length + 1);
                    Keys[NodeNum] = rdr.LocalName;
                    NodeNum++;
                }
            }
            rdr.Close();
            fs.Close();



            return Keys;
        }

        /// <summary>
        /// Save the key to XML config file
        /// </summary>
        /// <param name="Key">
        /// Key to save to
        /// </param>
        /// <param name="Text">
        /// Text to put into the node
        /// </param>
        public void SaveKey(string Key, string Text)
        {
            XmlDocument xd = new XmlDocument();
            XmlNode node;
            xd.Load(Config);
            node = xd.SelectSingleNode("descendant::*[name(.) = '" + Key + "']");
            node.InnerText = Text;
            xd.Save(Config);
            
        }


        /// <summary>
        /// Create the specified key
        /// </summary>
        /// <param name="Key">Key to create</param>
        public void CreateKey(string Key)
        {
            XmlDocument xd = new XmlDocument();
            FileStream filestream = new FileStream(Config, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite);



            xd.Load(filestream);



            XmlNode node1 = xd.SelectSingleNode("configuration/Settings");
            XmlNode newlink = xd.CreateNode(XmlNodeType.Element, Key, null);

            newlink.InnerText = "";

            node1.AppendChild(newlink);

            //filestream.Close();
            filestream.Close();

            xd.Save(Config);
        }
    }
}
