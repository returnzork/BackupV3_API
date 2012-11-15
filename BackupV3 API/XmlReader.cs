using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;


namespace returnzork.BackupV3_API.XmlReader
{
    public class XmlReader
    {
        private string Config;

        /// <summary>
        /// Start xml reader
        /// </summary>
        /// <param name="Config">Location of the XML configuration file</param>
        public XmlReader(string Config)
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

        /// <summary>
        /// Return all nodes in given xml document
        /// </summary>



        private string[] test;
        public string[] array()
        {
            Array.Resize(ref test, 5);


            test[0] = "test";
            test[1] = "fdsa";
            return test;
        }


        private string[] Keys;
        public string[] GetAllKeys()
        {
            XmlDocument xd = new XmlDocument();
            xd.Load(Config);


            XmlElement root = xd.DocumentElement;
            XmlNodeList nodes = root.SelectNodes("/configuration/settings/*");

            int NodeNum = 0;




            //TODO make it give the inside node instead of node name

            foreach (XmlNode node in nodes)
            {
                Array.Resize(ref Keys, NodeNum + 1);
                Keys[NodeNum] = node.Name;
                //Console.WriteLine("Current node: {0} \r\nNode is: {1} \r\n", NodeNum, node.Name);
                NodeNum++;
            }
            return Keys;
            //return array;
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
    }
}
