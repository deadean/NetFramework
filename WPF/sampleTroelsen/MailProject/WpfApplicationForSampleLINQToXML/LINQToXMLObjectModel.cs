using System;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace WpfApplicationForSampleLINQToXML
{
    public class LINQToXMLObjectModel
    {
        private static string CsXmlResults = "XMLResults/";

        public static XDocument GetXmlInventory()
        {
            try
            {
                XDocument inventoryDoc = XDocument.Load(CsXmlResults + "Inventory.xml");
                return inventoryDoc;
            }
            catch (System.IO.FileNotFoundException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static void InsertNewElement(string make, string color, string petName)
        {
            // Load current document.
            XDocument inventoryDoc = XDocument.Load(CsXmlResults + "Inventory.xml");
            // Generate a random number for the ID.
            Random r = new Random();
            // Make new XElement based on incoming parameters.
            XElement newElement = new XElement("Car", new XAttribute("ID", r.Next(50000)),
                new XElement("Color", color),
                new XElement("Make", make),
                new XElement("PetName", petName));
            // Add to in-memory object.
            inventoryDoc.Descendants("Inventory").First().Add(newElement);
            // Save changes to disk.
            inventoryDoc.Save(CsXmlResults + "Inventory.xml");
        }

        public static void LookUpColorsForMake(string make)
        {
            // Load current document.
            XDocument inventoryDoc = XDocument.Load(CsXmlResults + "Inventory.xml");
            // Find the colors for a given make.
            var makeInfo = from car in inventoryDoc.Descendants("Car")
                where (string) car.Element("Make") == make
                select car.Element("Color").Value;

            // Build a string representing each color.
            string data = string.Empty;
            foreach (var item in makeInfo.Distinct())
            {
                data += string.Format("- {0}\n", item);
            }
            // Show colors.
            MessageBox.Show(data, string.Format("{0} colors:", make));
        }
    }
}
