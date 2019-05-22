using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Net2_2_new
{
    public class JsonWriter
    {
        public void Write(Config config)
        {
            List<User> users = new List<User>(config.GetUsers());

            foreach (User user in users)
            {
                foreach (Window window in user.GetWindows())
                {
                    window.Fix();
                }
                var output = JsonConvert.SerializeObject(user, Formatting.Indented);

                Directory.CreateDirectory(@".\Config\");
                var writeJson = new StreamWriter(new FileStream(@".\Config\" + user.Name + ".json", FileMode.Create,
                    FileAccess.Write)); 
                writeJson.Write(output);
                writeJson.Close();
            }
        }
    }
}