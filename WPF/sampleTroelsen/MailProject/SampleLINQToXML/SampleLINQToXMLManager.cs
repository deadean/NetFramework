using System;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Xml;
using System.Xml.Linq;
using WpfApplicationForSampleLINQToXML;

namespace SampleLINQToXML
{
    public class SampleLINQToXMLManager
    {
        private const string CsXmlResults = "XMLResults/";
        public void StartSample()
        {
            //Sample1();
            //Sample2();
            Sample3();
            //Sample4();
        }

        [STAThread]
        private void Sample4()
        {
            Thread t = new Thread(() =>
            {
                Application app = new Application();
                app.Run(new MainWindow());
            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
        }

        private void Sample3()
        {
            // Build an XElement from string.
            string myElement =
                @"<Car ID ='3'>
                    <Color>Yellow</Color>
                    <Make>Yugo</Make>
                    </Car>";
            XElement newElement = XElement.Parse(myElement);
            Console.WriteLine(newElement);
            Console.WriteLine();

            // Load the SimpleInventory.xml file.
            XDocument myDoc = XDocument.Load(CsXmlResults+"SimpleInventory.xml");
            Console.WriteLine(myDoc);
        }

        private void Sample2()
        {
            var people = new[]
            {
                new {FirstName = "Mandy", Age = 32},
                new {FirstName = "Andrew", Age = 40},
                new {FirstName = "Dave", Age = 41},
                new {FirstName = "Sara", Age = 31}
            };
            XElement peopleDoc =
                new XElement("People",
                    from c in people
                    select new XElement("Person", new XAttribute("Age", c.Age),
                        new XElement("FirstName", c.FirstName))
                    );
            
            Console.WriteLine(peopleDoc);
        }

        private void Sample1()
        {
            BuildXMLDocumentWithDOM();
            BuildXMLDocumentWithLinqToXml();
            CreateFullXDocument();
        }

        private void BuildXMLDocumentWithDOM()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement inventory = doc.CreateElement("Inventory");

            XmlElement car = doc.CreateElement("Car");
            car.SetAttribute("ID", "1000");

            XmlElement name = doc.CreateElement("PetName");
            name.InnerText = "Jimbo";
            XmlElement color = doc.CreateElement("Color");
            color.InnerText = "Red";
            XmlElement make = doc.CreateElement("Make");
            make.InnerText = "Ford";

            car.AppendChild(name);
            car.AppendChild(color);
            car.AppendChild(make);

            inventory.AppendChild(car);

            doc.AppendChild(inventory);
            doc.Save(CsXmlResults+"Inventory.xml");
        }

        private void BuildXMLDocumentWithLinqToXml()
        {
            XElement doc = new XElement("Inventory",
                new XElement("Car", new XAttribute("ID", "1000"),
                    new XElement("PetName", "Jimbo"),
                    new XElement("Color", "Red"),
                    new XElement("Make", "Saab")
                    ),
                new XElement("Car", new XAttribute("ID", "1000"),
                    new XElement("PetName", "Jimbo"),
                    new XElement("Color", "Red"),
                    new XElement("Make", "Saab")
                    )
                );
            doc.Descendants("PetName").Remove();
            doc.Save(CsXmlResults+"InventoryWithLinqCreate.xml");
        }

        private void CreateFullXDocument()
        {
            XDocument inventoryDoc =
                new XDocument(
                    new XDeclaration("1.0", "utf-8", "yes"),
                    new XComment("Current Inventory of cars!"),
                    new XProcessingInstruction("xml-stylesheet",
                        "href='MyStyles.css' title='Compact' type='text/css'"),
                    new XElement("Inventory",
                        new XElement("Car", new XAttribute("ID", "1"),
                            new XElement("Color", "Green"),
                            new XElement("Make", "BMW"),
                            new XElement("PetName", "Stan")
                            ),
                        new XElement("Car", new XAttribute("ID", "2"),
                            new XElement("Color", "Pink"),
                            new XElement("Make", "Yugo"),
                            new XElement("PetName", "Melvin")
                            )
                        )
                    );
            // Save to disk.
            inventoryDoc.Save(CsXmlResults+"SimpleInventory.xml");
        }
    }
}
