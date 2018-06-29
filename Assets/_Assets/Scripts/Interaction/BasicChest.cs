using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BasicChest : MonoBehaviour {
    public IntReference maxChestSlots;
    public GameObject playerUI, chestUI, chestCellGroup;
    public GameObject cellPrefab;
    public GameObject[] chestItems;
    public UIReferences uiReferences;
    private bool isNear = false;
    private Animator animator;

    private void Start()
    {
        //chestItems = new GameObject[maxChestSlots];
        
    }


    void OnTriggerEnter(Collider collider) {
        isNear = true;
    }

    void OnTriggerExit(Collider collider)
    {
        isNear = false;
        uiReferences.uiController.GetComponent<UIController>().ToggleOffChest();
       
        //chestUI.SetActive(false);
    }

    void OnMouseDown() {
        if (isNear) {
           
            //chestUI.SetActive(true);
            LoadCellGroup();
            uiReferences.uiController.GetComponent<UIController>().ToggleOnChest();
            
            //uiReferences.chestUI.SetActive(true);
        }
    }

   public void LoadCellGroup() {
        ClearCellGroup();
        for (int i = 0; i < maxChestSlots.Value; i++)
        {
            GameObject cell = (GameObject)Instantiate(cellPrefab, chestCellGroup.transform) as GameObject;
            Instantiate(chestItems[i], cell.transform);
            Debug.Log("Instanciado una celda");
        }
    }

    public void ClearCellGroup() {
        foreach (Transform child in chestCellGroup.transform) {
            Destroy(child.gameObject);
        }
    }
}
