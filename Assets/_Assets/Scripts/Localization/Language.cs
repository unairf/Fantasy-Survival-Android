using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;
using Sirenix.OdinInspector;

public class Language {

    [Multiline]
    [XmlAttribute("languageName")]
    public string  languageName;

    [XmlAttribute("languageDescription")]
    public string languageDescription;

    [XmlAttribute("languageCode")]
    public string languageCode;

    [XmlAttribute("languageTexts")]
    public List<LanguageText> languageTexts;

    public Language(string _languageName, string _languageDescription, string _languageCode, List<LanguageText> _languageTexts) {

        languageName = _languageName;
        languageDescription = _languageDescription;
        languageCode = _languageCode;
        languageTexts = _languageTexts;
    }

    public Language() { }
	
}
