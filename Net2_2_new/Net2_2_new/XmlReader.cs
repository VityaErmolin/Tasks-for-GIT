using System.Xml;

namespace Net2_2_new
{
    public class XmlReader
    {
        private readonly Config _configs;

        public XmlReader()
        {
            _configs = new Config();
        }

        public Config XmlRead()
        {
            var xmlDoc = new XmlDocument();

            xmlDoc.Load(@"./XML file/Users.xml");

            foreach (XmlElement xmlElement in xmlDoc.GetElementsByTagName("login"))
            {
                var windowName = xmlElement.GetAttribute("name");

                var user = new User(windowName);
                foreach (XmlElement xmlWindow in xmlElement.GetElementsByTagName("window"))
                {
                    int? windowTop = null;
                    int? windowLeft = null;
                    int? windowWidth = null;
                    int? windowHeight = null;
                    var title = xmlWindow.GetAttribute("title");

                    foreach (XmlNode childNode in xmlWindow.ChildNodes)
                    {
                        switch (childNode.Name)
                        {
                            case "top":
                                windowTop = int.Parse(childNode.InnerText);
                                break;
                            case "left":
                                windowLeft = int.Parse(childNode.InnerText);
                                break;
                            case "width":
                                windowWidth = int.Parse(childNode.InnerText);
                                break;
                            case "height":
                                windowHeight = int.Parse(childNode.InnerText);
                                break;
                        }
                    }

                    var wnd = new Window(windowTop, windowLeft, windowWidth, windowHeight, title);
                    user.Add(wnd);
                }

                _configs.Add(user);
            }

            return _configs;
        }

        public override string ToString()
        {
            return _configs.ToString();
        }
    }
}