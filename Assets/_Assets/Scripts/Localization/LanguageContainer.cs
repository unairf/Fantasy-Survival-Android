using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using Sirenix.OdinInspector;

[XmlRoot("LanguageCollection")]
public class LanguageContainer {


    
    [XmlElement("languageName")]
    public string languageName;

    [XmlElement("languageCode")]
    public string languageCode;
    [ListDrawerSettings(AlwaysAddDefaultValue = true, ListElementLabelName = "value",NumberOfItemsPerPage = 20)]
    [XmlArray("LanguageTexts")]
    [XmlArrayItem("Text")]
    public List<LanguageText> languageTexts = new List<LanguageText>();
}
