using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bool", menuName = "Modular/Bool")]
public class SpriteVariable : ScriptableObject{

	#if UNITY_EDITOR
	[Multiline]
	public string DeveloperDescription = "";
	#endif

	public Sprite Value;

	public void SetValue(Sprite value)
	{
		Value = value;
	}

	public void SetValue(SpriteVariable value)
	{
		Value = value.Value;
	}

}
