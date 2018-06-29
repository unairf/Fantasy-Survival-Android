using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[CreateAssetMenu(fileName = "New GameEvent", menuName = "Modular/GameEvent")]
public class GameEvent : ScriptableObject {

#if UNITY_EDITOR
    public bool debug;
    [Title("Showing listeners in edit mode.")]
    [ShowIf("debug")]
    [ShowInInspector]
    private readonly List<GameEventListener> debugListeners = new List<GameEventListener>();  

#endif

    [ShowInInspector]
    private readonly List<GameEventListener> listeners = new List<GameEventListener>();

    [Button]
	public void Raise()
	{
		for (int i = listeners.Count - 1; i >= 0; i--)
			listeners [i].OnEventRaised ();
	}

	public void RegisterListener(GameEventListener listener)
	{
            listeners.Add(listener);
	}

    public void DebugRegisterListener(GameEventListener listener)
    {
            debugListeners.Add(listener);  
    }

    public void UnregisterListener(GameEventListener listener)
	{
		    listeners.Remove (listener);
	}

    public void RemoveEmptyListeners() {
        foreach (GameEventListener listener in listeners) {
            if (listener == null)
                listeners.Remove(listener);
        }
    }
}
