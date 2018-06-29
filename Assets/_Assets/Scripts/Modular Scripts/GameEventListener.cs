using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Sirenix.OdinInspector;

public class GameEventListener : MonoBehaviour {

	[Tooltip("Event to register with.")]
    [Required]
	public GameEvent Event;

	[Tooltip("Response to invoke when Event is raised.")]
	public UnityEvent Response;

    private void OnValidate()
    {
        if(Event!= null)
            Event.DebugRegisterListener(this);
        
    }


    private void OnEnable()
	{
		Event.RegisterListener (this);
	}

	private void OnDisable()
	{
		Event.UnregisterListener (this);
	}

	public void OnEventRaised()
	{
		Response.Invoke ();
	}

    public void DebugRegister()
    {
        Event.RegisterListener(this);
    }
}
