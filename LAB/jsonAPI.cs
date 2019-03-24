using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.IO;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace LAB
{
    public class jsonAPI
    {
        private static string dbPath;
        private static JObject jsonObj;

        public jsonAPI(string path)
        {
            dbPath = System.AppDomain.CurrentDomain.BaseDirectory + path;
            string jsonString = File.ReadAllText(dbPath);
            jsonObj = JObject.Parse(jsonString);
        }

        public void writeToDB()
        {
            string content = JsonConvert.SerializeObject(jsonObj);
            File.WriteAllText(dbPath, content);
        }

        public void addToDB(MessageObject message)
        {
            try
            {
                string JsonData = JsonConvert.SerializeObject(message);
                JsonData = JsonData.ToLower();
                JObject jsonMerge = JObject.Parse(@"{ " + MainWindow.RemoteUser + " : [ "+ JsonData +"]}");
                jsonObj.Merge(jsonMerge, new JsonMergeSettings { MergeArrayHandling = MergeArrayHandling.Concat });
            }
            catch(Exception e) {
                System.Windows.MessageBox.Show(e.ToString());
            }
        }

        public ObservableCollection<string> Search(string userName)
        {
            ObservableCollection<string> tmpObs = new ObservableCollection<string>();
            var users = from user in jsonObj.Properties().Select(p => p.Name).ToList() where user.Contains(userName) select user;
            foreach (var u in users)
            {
                tmpObs.Add(u);
            }
            
            return tmpObs;
        }

        public ObservableCollection<MessageObject> GetChat(string userName) 
        {
            ObservableCollection<MessageObject> tmpObs = new ObservableCollection<MessageObject>();
            foreach (dynamic convo in jsonObj[userName])
            {
                tmpObs.Add(new MessageObject() { Who = convo["who"], Type = convo["type"], Data = convo["data"] });
            }
            return tmpObs;
        }
    }
}
