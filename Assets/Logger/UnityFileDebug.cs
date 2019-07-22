using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityFileDebug : MonoBehaviour
{
    public bool useAbsolutePath = true;
    public string fileName = "ShopkinsDebug";

    public string absolutePath = "A:/UnityLogs";

    public string filePath;
    public string filePathFull;
    public int count = 0;

    System.IO.StreamWriter fileWriter;

    void OnEnable()
    {
        UpdateFilePath();
        if (Application.isPlaying)
        {
            count = 0;
            fileWriter = new System.IO.StreamWriter(filePathFull, false);
            fileWriter.AutoFlush = true;
            fileWriter.WriteLine("[");
            Application.logMessageReceived += HandleLog;
        }
    }

    void OnDisable()
    {
        ConstantUpdateLogger logger = GetComponent<ConstantUpdateLogger>();
        if (Application.isPlaying)
        {
            Debug.Log(logger.GetAverageUpdatesPerSecond() + " AVERAGE UPDATES THIS RUN.", DLogType.Content);
            Debug.Log(logger.GetAverageFixedUpdatesPerSecond() + " AVERAGE FIXEDUPDATES THIS RUN.", DLogType.Content);
            Application.logMessageReceived -= HandleLog;
            fileWriter.WriteLine("\n]");
            fileWriter.Close();
        }
    }

    public void UpdateFilePath()
    {
        filePath = useAbsolutePath ? absolutePath : Application.persistentDataPath;
        filePathFull = System.IO.Path.Combine(filePath, fileName + "." +
            System.DateTime.Now.ToString("MM.dd.HH.mm") + ".json");
    }

    void HandleLog(string logString, string stackTrace, LogType type)
    {
        LogJSON j = new LogJSON();
        if (type == LogType.Assert)
        {
            j.t = "Assert";
            j.l = logString;
        }
        else if (type == LogType.Exception)
        {
            j.t = "Exception";
            j.l = logString;
        }
        else
        {
            int end = logString.IndexOf("]");
            j.t = logString.Substring(1, end - 1); // was -1
            j.l = logString.Substring(end + 2);
        }

        j.s = stackTrace;
        j.tm = System.DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss");

        fileWriter.Write((count == 0 ? "" : ",\n") + JsonUtility.ToJson(j));
        count++;
    }
}