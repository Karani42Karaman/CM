using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;

namespace RVC.Web.Areas.Admin.Helper
{
    public class LanguageCrud
    {
        public LanguageCrud()
        {

        }


        public string FindValueByName(string name, string resxFilePath)
        {
            using (XmlTextReader reader = new XmlTextReader(resxFilePath))
            {
                while (reader.Read())
                {
                    if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "data"))
                    {
                        string key = reader.GetAttribute("name");

                        if (string.Equals(key, name, StringComparison.OrdinalIgnoreCase))
                        {
                            reader.ReadToDescendant("value");
                            return reader.ReadElementContentAsString();
                        }
                    }
                }
            }

            return "Değer bulunamadı yazılımcı ile iletişime geçin";
        }

        public bool DeleteByName(string name, string _resxFilePath)
        {
            try
            {
                string filePath = _resxFilePath;
                XDocument document = XDocument.Load(filePath);
                string silinecekSatirAdi = name;
                XElement silinecekSatir = document.Descendants("data")
                    .FirstOrDefault(element => element.Attribute("name")?.Value == silinecekSatirAdi);

                if (silinecekSatir != null)
                {
                    silinecekSatir.Remove();
                    document.Save(filePath);
                    Console.WriteLine($"{silinecekSatirAdi} satırı başarıyla silindi.");
                }
                else
                {
                    Console.WriteLine($"{silinecekSatirAdi} satırı bulunamadı.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata oluştu: {ex.Message}");
                return false;
            }
            return true;
        }


        public bool Update(string existingKey, string updatekey, string updatedValue, string _resxFilePath)
        {
            try
            {
                XDocument doc = XDocument.Load(_resxFilePath);
                XElement existingDataElement = doc.Root.Elements("data")
                    .FirstOrDefault(elem => elem.Attribute("name").Value == existingKey);

                if (existingDataElement != null)
                {
                    // name ve value alanlarını güncelle
                    existingDataElement.Attribute("name").Value = updatekey;
                    existingDataElement.Element("value").SetValue(updatedValue);

                    doc.Save(_resxFilePath);
                }


            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
    }
}

