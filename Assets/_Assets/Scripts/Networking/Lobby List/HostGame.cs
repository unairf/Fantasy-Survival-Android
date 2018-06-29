using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class HostGame : MonoBehaviour {

    [SerializeField]
    private uint roomSize = 6;


    private string roomName;
    private string roomPassword = "";

    private NetworkManager networkManager;

    private void Start()
    {
        networkManager = NetworkManager.singleton;
        if (networkManager.matchMaker == null)
        {
            networkManager.StartMatchMaker();
        }
    }

    public void SetRoomName(string _name) {
        roomName = _name;
    }

    public void SetRoomSize(uint _size) {
        roomSize = _size;
    }
    public void SetRoomPassword(string _password) {
        roomPassword = _password;
    }

    public void CreateRoom() {
        if (roomName != "" && roomName != null) {
            Debug.Log("Creating room " + roomName + "with size " + roomSize);
            //Create room
            networkManager.matchMaker.CreateMatch(roomName,roomSize,true,roomPassword,"","",0,0,networkManager.OnMatchCreate);
        }
    }
	
}
