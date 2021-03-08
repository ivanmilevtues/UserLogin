using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace UserLogin
{
    static class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.currentUserRole + ";" + LoginValidation.currentUserRole + ";" + activity + "\n";
            currentSessionActivities.Add(activityLine);
            if (File.Exists("logs.txt"))
            {
                File.AppendAllText("logs.txt", activityLine);
            }
        }

        static public void ShowLogs()
        {
            StringBuilder sb = new StringBuilder();
            if(File.Exists("logs.txt"))
            {
                StreamReader sr = new StreamReader("logs.txt");
                while(!sr.EndOfStream)
                {
                    sb.Append(sr.ReadLine());
                }
                sr.Close();
            }
            Console.WriteLine(sb.ToString());
        }

        static public string GetCurrentSessionActivities()
        {
            var builder = new StringBuilder();
            foreach(var activity in currentSessionActivities)
            {
                builder.Append(activity);
            }

            return builder.ToString();
        }
    }
}
