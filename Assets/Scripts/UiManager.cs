using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class UiManager : MonoBehaviour
{
    public static UiManager Instance;

    public string Name;

    public string NewUser;

    public int Score;

    private void Awake() 
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadScore();
    }

    [System.Serializable]
    
    class SaveData 
    {
        public int Score;
        public string Name;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();

        data.Score = Score;
        data.Name = Name;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json",json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";

        if(File.Exists(path))
        {
            string json = File.ReadAllText(path);

            SaveData data = JsonUtility.FromJson<SaveData>(json);

            Score = data.Score;
            Name = data.Name;
        }

    }

}
