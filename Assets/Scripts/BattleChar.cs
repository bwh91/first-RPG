﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleChar : MonoBehaviour {


    public bool isPlayer;
    public string[] movesAvailable;

    public string charName;
    public int currentHP, maxHP, currentMP, maxMP, strength, defense, wpnPower, armorPower;
    public bool hasDied;

    public bool shouldFade;
    public float fadeSpeed = 1f;

    public SpriteRenderer theSprite;
    public Sprite deadSprite, aliveSprite;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (shouldFade)
        {
            theSprite.color = new Color(Mathf.MoveTowards(theSprite.color.r, 1f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.g, 0f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.b, 0f, fadeSpeed * Time.deltaTime), Mathf.MoveTowards(theSprite.color.a, 0f, fadeSpeed * Time.deltaTime));
            if ( theSprite.color.a == 0)
            {
                gameObject.SetActive(false);
            }
        }
	}

    public void EnemyFade()
    {
        shouldFade = true;
    }
}
