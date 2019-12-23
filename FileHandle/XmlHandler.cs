using System;
using System.Xml.Linq;

namespace Calckit.FileHandle
{
   public class XmlHandler
    {
       
        //Method to load xml file
        public XElement LoadXmlFile(string file)
        {
            XElement xElement = XElement.Load(file);
            if (xElement == null)
                throw new Exception("FIle couldn't be loaded!");
            else
                return xElement;
            
        }

        //Method to write data to data xmlfile

        public void UpdateXmlFile(string file,string value,string type)
        {
            switch (type)
            {
                case "Constants": WriteConstantsXml(file, value);break;
                case "Formulas": WriteFormulasXml(file, value); break;
            }
        }
        private  void WriteConstantsXml(string file,string CSvalue)
        {
            string[] values = CSvalue.Split(',');
            XElement element = LoadXmlFile(file);
            foreach(var i in element.Elements())
            {
                if (i.Attribute("name").Value == values[0] || i.Attribute("value").Value == values[1])
                {
                    System.Windows.MessageBox.Show("Item already exit!", "Invalid input-Error");
                    return;
                }
            }
            XElement el = new XElement("constant", 
                new XAttribute("name", values[0]),
                new XAttribute("value", values[1]),
                new XAttribute("description", values[2]));

            element.Add(el);
            element.Save(file);
            System.Windows.MessageBox.Show("Item added successfully\nYou need to restart window to apply change", "Message");
        }

        private  void WriteFormulasXml(string file, string CSvalue)
        {
            string[] values = CSvalue.Split(',');
            XElement element = LoadXmlFile(file);

            foreach (var i in element.Elements())
            {
                if (i.Attribute("name").Value == values[0] || i.Attribute("value").Value == values[1])
                {
                    System.Windows.MessageBox.Show("Item already exist in file!", "Invalid input-Error");
                    return;
                }
            }

            XElement el = new XElement("formula",
                new XAttribute("name", values[0]),
                new XAttribute("value", values[1]),
                new XAttribute("description", values[2]));

            element.Add(el);
            element.Save(file);
            System.Windows.MessageBox.Show("Item added successfully\nYou need to restart window to apply change", "Message");

        }

        //Method to delete item from xml file
        private void DeleteConstant(string file,string name)
        {
            XElement element = LoadXmlFile(file);
            
            foreach(var i in element.Elements())
            {
                if (i.Attribute("name").Value.ToLower() == name||i.Attribute("value").Value.ToLower()==name)
                {
                    i.Remove();
                    break;
                }
            }
            element.Save(file);
            System.Windows.MessageBox.Show("Item removed from file\nYou need to restart window to apply change", "Message");
        }
        private void DeleteFormula(string file, string name)
        {
            XElement element = LoadXmlFile(file);

            foreach (var i in element.Elements())
            {
                if (i.Attribute("name").Value.ToLower() == name || i.Attribute("value").Value.ToLower() == name)
                {
                    i.Remove();
                    break;
                }
            }
            element.Save(file);
            System.Windows.MessageBox.Show("Item removed from file\nYou need to restart window to apply change", "Message");
        }

        public void DeleteItemFromfile(string file,string name)
        {
            switch (file)
            {
                case "../../Resources/Constants.xml": DeleteConstant(file, name); break;
                case "../../Resources/Formulas": DeleteFormula(file, name); break;
            }
        }

    }
}
