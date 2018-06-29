using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using System.Xml.Serialization;

//[SerializeField]
public class LanguageText {
    
    //[XmlAttribute("key")]
    public string key;
   // [XmlAttribute("value")]
    public string value;

    public LanguageText(string _key, string _value) {
        key = _key;
        value = _value;
    }

    public LanguageText() { }
}
