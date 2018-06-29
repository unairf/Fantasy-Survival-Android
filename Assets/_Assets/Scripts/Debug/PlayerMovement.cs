using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TouchControlsKit;

public class PlayerMovement : MonoBehaviour {

    public GameObject player;
    public float speed;
    private Transform myTransform;
	// Use this for initialization
	void Start () {
        myTransform = transform;	
	}
	
	// Update is called once per frame
	void Update () {


        Camera.main.transform.position = new Vector3(player.transform.position.x, Camera.main.transform.position.y, Camera.main.transform.position.z);




        if (TCKInput.GetAction("leftBtn", EActionEvent.Press))
        {
            Izquierda();
        }
        if (TCKInput.GetAction("rightBtn", EActionEvent.Press))
        {
            Derecha();
        }
        if (TCKInput.GetAction("upBtn", EActionEvent.Press))
        {
            Arriba();
        }
        if (TCKInput.GetAction("downBtn", EActionEvent.Press))
        {
            Abajo();
        }
    }

    void FixedUpdate() {
        Vector2 move = TCKInput.GetAxis("Joystick0");
        Vector3 moveDirection = myTransform.forward * move.x;
        //moveDirection += myTransform.right * move.y;

        //player.transform.position = moveDirection;
    }

    public void Arriba() {
       
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + speed * Time.deltaTime);
        
    }

    public void Izquierda() {
        player.transform.position = new Vector3(player.transform.position.x - speed * Time.deltaTime, player.transform.position.y, player.transform.position.z);
    }

    public void Abajo() {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - speed * Time.deltaTime);
    }

    public void Derecha() {
        player.transform.position = new Vector3(player.transform.position.x + speed * Time.deltaTime, player.transform.position.y, player.transform.position.z);
    }
}
