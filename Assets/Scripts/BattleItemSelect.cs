using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleItemSelect : MonoBehaviour {

    public string itemName;
    public int spellCost;
    public Text nameText;
    public Text costText;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Press()
    {

        Debug.Log("In Press");
        if (BattleManager.instance.activeBattlers[BattleManager.instance.currentTurn].currentMP >= spellCost)
        {
            Debug.Log("In Press > IF");
            BattleManager.instance.magicMenu.SetActive(false);
            BattleManager.instance.OpenTargetMenu(itemName);
            BattleManager.instance.activeBattlers[BattleManager.instance.currentTurn].currentMP -= spellCost;
        }
        else
        {
            BattleManager.instance.battleNotice.theText.text = "Not Enough MP!";
            BattleManager.instance.battleNotice.Activate();
            BattleManager.instance.magicMenu.SetActive(false);
        }

    }


    public void ShowItems()
    {

        GameManager.instance.SortItems();


        for (int i = 0; i < GameMenu.instance.itemButtons.Length; i++)
        {
            GameMenu.instance.itemButtons[i].buttonValue = i;

            if (GameManager.instance.itemsHeld[i] != "")
            {
                GameMenu.instance.itemButtons[i].buttonImage.gameObject.SetActive(true);
                GameMenu.instance.itemButtons[i].buttonImage.sprite = GameManager.instance.GetItemDetails(GameManager.instance.itemsHeld[i]).itemSprite;
                GameMenu.instance.itemButtons[i].amountText.text = GameManager.instance.numberOfItems[i].ToString();
            }
            else
            {
                GameMenu.instance.itemButtons[i].buttonImage.gameObject.SetActive(false);
                GameMenu.instance.itemButtons[i].amountText.text = "";
            }
        }
    }
}
