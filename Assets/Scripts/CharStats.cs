using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharStats : MonoBehaviour {


    public string charName;
    public int playerLevel = 1;
    public int currentExp;
    public int[] expToNextLevel;
    public int maxLevel = 100;
    public int baseEXP = 1000;

    public int currentHP;
    public int maxHP = 100;
    public int currentMP;
    public int maxMP = 30;
    public int[] mpLvlBonus;
    public int strength;
    public int defense;
    public int weaponPwr;
    public int armrPwr;
    public string equippedWpn;
    public string equippedArmr;
    public Sprite charImage;

	// Use this for initialization
	void Start () {

        //setting up player at level one and initializing level up curve array
        expToNextLevel = new int[maxLevel];
        expToNextLevel[1] = baseEXP;

        for (int i = 2; i < expToNextLevel.Length; i++)
        {

            expToNextLevel[i] = Mathf.FloorToInt(expToNextLevel[i - 1] * 1.05f); // builing the level curve

            
        }
        
        
		
	}
	
	// Update is called once per frame
	void Update () {
        //DEV: for testing level up only
		if (Input.GetKeyDown(KeyCode.K))
        {
            AddExp(500);
        }
	}

    //function to manage leveling up player and managing stats that player gets as they level up
    public void AddExp(int expToAdd)
    {
        currentExp += expToAdd;

        if (playerLevel < maxLevel)
        {
            if (currentExp > expToNextLevel[playerLevel])
            {
                currentExp -= expToNextLevel[playerLevel];

                playerLevel++;

                //determine whether to add strength or armor based on odd / even
                if (playerLevel % 2 == 0)
                {
                    strength++;
                }
                else
                {
                    defense++;
                }

                maxHP = Mathf.FloorToInt(maxHP * 1.05f);
                currentHP = maxHP; // heal player to full health on level up

                maxMP += mpLvlBonus[playerLevel];
                currentMP = maxMP;
            }
        }

        if (playerLevel >= maxLevel)
        {
            currentExp = 0;
        }
        
    }
}
