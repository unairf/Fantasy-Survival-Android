using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Int", menuName = "Modular/String")]
public class StringVariable : ScriptableObject{

	#if UNITY_EDITOR

	[Multiline]
	public string DeveloperDescription = "";
     
	#endif

	public string Value;

    public List<GameObject> references;

	public void SetValue(string value)
	{
		Value = value;
	}

	public void SetValue(StringVariable value)
	{
		Value = value.Value;
	}


	public void ApplyChange(string amount)
	{
		Value += amount;
	}

	public void ApplyChange(StringVariable amount)
	{
		Value += amount.Value;
	}

    public void RegisterReference(GameObject reference)
    {
        references.Add(reference);
    }

    public void UnregisterReference(GameObject reference)
    {
        references.Remove(reference);
    }
}
