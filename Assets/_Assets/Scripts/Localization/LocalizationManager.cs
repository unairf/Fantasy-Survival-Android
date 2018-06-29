using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

public class LocalizationManager : SerializedScriptableObject {

    public string directory;
    [ListDrawerSettings(AlwaysAddDefaultValue =true,ListElementLabelName = "languageName")]
    public List<LanguageContainer> languages;
    private List<LanguageContainer> temporalLanguages = new List<LanguageContainer>();


    [Button]
    public void SaveTest() {
        foreach (LanguageContainer language in languages) {
            Save();
        }
    }

    [Button]
    public List<string> GetFilesInDirectory() {
        List<string> files = new List<string>();
       
        foreach (string file in System.IO.Directory.GetFiles(directory, "*.xml"))
        {
            
            string[] completePath = file.Split('\\');
            Debug.Log(completePath[completePath.Length - 1]); //Nombre del archivo
            files.Add(file);
        }
        return files;
    }



    [Button]
    public void Load() {
        if (GetFilesInDirectory().Count == 0) {
            Debug.LogError("No hay archivos en el directorio");
            return;
        }

        BackupFiles();
        languages.Clear();
        foreach (string file in System.IO.Directory.GetFiles(directory, "*.xml"))
        {
            

            var serializer = new XmlSerializer(typeof(LanguageContainer));
            var stream = new FileStream(file, FileMode.Open);
            var container = serializer.Deserialize(stream) as LanguageContainer;
            
                languages.Add(container);
            stream.Close();
        }
       

        
        
    }

    [Button]
    public void Save() {
        List<LanguageText> tempLanguageTexts = new List<LanguageText>();

        foreach (LanguageContainer language in languages) {

            var serializer = new XmlSerializer(typeof(LanguageContainer));
            var stream = new FileStream(directory+ language.languageName + ".xml", FileMode.Create);
            serializer.Serialize(stream, language);
            stream.Close();
        }
    }

    public void BackupFiles() {
        if(temporalLanguages.Count > 0)
            temporalLanguages.Clear();
        foreach (LanguageContainer languageContainer in languages) {
            temporalLanguages.Add(languageContainer);
        }
    }

   
/*
    public void LoadLanguage(string fileName) {
        //TODO falta
        string filePath = Path.Combine(Application.streamingAssetsPath, fileName);
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            //LocalizationData loadedData = JsonUtility.FromJson<LocalizationData>(dataAsJson);

            for (int i = 0; i < loadedData.items.Length; i++) {
                localizedText.Add(loadedData.items[i].key, loadedData.items[i].value);
            }

            Debug.Log("Datos cargados, el diccionario contiene" + localizedText.Count + " entradas");
        }
        else {
            Debug.LogError("Cannot find file");
        }
    }

    */
}
