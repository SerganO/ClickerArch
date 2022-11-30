using UnityEngine;
using System;
using System.IO;

public class ReadWriteManager
{
    public static string EnvDirectory
    {
        get
        {
            string envDirectory = "";
#if UNITY_ANDROID && !UNITY_EDITOR
            envDirectory = Application.persistentDataPath;
#else
            envDirectory = Application.dataPath;
#endif
            Debug.Log("Env Directory - " + envDirectory);
            return envDirectory;
        }
    }

    public static string PathForSubdirectory(string sub)
    {
        return Path.Combine(EnvDirectory, sub);
    }
    

    public static void Save<T>(string subdirectory, string name, T objectToSave)
    {
        Debug.Log("Save Start");
        var directory = PathForSubdirectory(subdirectory);
        var pathToSave = Path.Combine(directory, name + ".json");
        try
        {
            if (!Directory.Exists(directory))
            {
                DirectoryInfo di = Directory.CreateDirectory(directory);
            }

            File.WriteAllText(pathToSave, JsonUtility.ToJson(objectToSave));
        }
        catch (Exception e)
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
            Debug.Log("The process failed:" + e.ToString());
        }
        Debug.Log("Save Finish");
    }

    public static T LoadUserDataFromFile<T>(string subdirectory, string name)
    {
        var directory = PathForSubdirectory(subdirectory);
        var pathToLoad = Path.Combine(directory, name);

        if (File.Exists(pathToLoad))
        {
            try
            {
                return JsonUtility.FromJson<T>(File.ReadAllText(pathToLoad));
            }
            catch (Exception err)
            {
                Debug.Log("File for load not exist!" + err.Message);
            }
        }
        else
        {
            Debug.Log("File for load not exist!" + pathToLoad);
        }

        return default(T);
    }


}
