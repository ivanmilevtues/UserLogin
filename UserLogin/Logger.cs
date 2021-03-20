using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace UserLogin
{
    static public class Logger
    {
        static private List<string> currentSessionActivities = new List<string>();

        static public void LogActivity(string activity)
        {
            string activityLine = DateTime.Now + ";" + LoginValidation.CurrentUserRole + ";" + LoginValidation.CurrentUserRole + ";" + activity + "\n";
            currentSessionActivities.Add(activityLine);
            if (File.Exists("logs.txt"))
            {
                File.AppendAllText("logs.txt", activityLine);
            }
        }

        static public IEnumerable<String> GetLogs(string filter)
        {
            var logs = new List<String>();
            if(File.Exists("logs.txt"))
            {
                logs = (from line in File.ReadLines("logs.txt") where line.Contains(filter) select line).ToList();
            }
            return logs;
        }

        static public IEnumerable<String> GetCurrentSessionActivities()
        {
            return currentSessionActivities;

        }
    }
}
