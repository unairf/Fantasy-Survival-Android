using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorrarStringReference : MonoBehaviour {

    public StringReference borrarstringReference;
    private void OnEnable()
    {
        borrarstringReference.Variable.RegisterReference(this.gameObject);
    }
    private void OnDisable()
    {
        borrarstringReference.Variable.UnregisterReference(this.gameObject);
    }
}
