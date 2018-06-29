using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New List", menuName = "Modular/List")]
public class ListVariable : ScriptableObject
{

#if UNITY_EDITOR
    [Multiline]
    public string DeveloperDescription = "";
#endif

    public List<GameObject> Value;

    public void SetValue(List<GameObject> value)
    {
        Value = value;
    }

    public void SetValue(ListVariable value)
    {
        Value = value.Value;
    }

}
