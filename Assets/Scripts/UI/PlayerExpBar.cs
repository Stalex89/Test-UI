﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerExpBar : MonoBehaviour {

	public int playerLevel;
	
	float playerMaxExp;

	public float playerMaxExpIncreaseCoef;
	public float playerExpGainIncrease;
	float playerCurrentExp;
	public float experienceGained;
	public Text	playerExpValue;
	public Text	playerLevelText;
	public Image playerExpFill;

	// Use this for initialization
	void Start () 
	{
		playerLevel = 0;
		playerCurrentExp = 0f;
		playerMaxExp = 200f;
		UpdatePlayerExpValueText();
		UpdatePlayerLevelText();
		playerExpFill.transform.localScale = new Vector3(0,1,1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.E))
		{
			PlayerGainExperience(experienceGained);
		}

		if (Input.GetKeyDown(KeyCode.D))
		{
			IncreasePlayerExpGain();
		}

	}

	void PlayerGainExperience(float experience)
	{
		if(playerCurrentExp + experience >= playerMaxExp)
		{
			float expDiff = experience - (playerMaxExp - playerCurrentExp);
			playerLevel++;
			playerCurrentExp = expDiff;
			playerMaxExp += playerMaxExp * playerMaxExpIncreaseCoef; 
			UpdatePlayerLevelText();
			if(expDiff > playerMaxExp)
				PlayerGainExperience(experience);
		}
		else
			playerCurrentExp += experienceGained;
		playerExpFill.transform.localScale = new Vector3((playerCurrentExp / playerMaxExp),1,1);
		UpdatePlayerExpValueText();
		Debug.Log("Gained " + experienceGained + " experience");
	}

	void IncreasePlayerExpGain()
	{
		experienceGained += experienceGained * playerExpGainIncrease;
	}

	void UpdatePlayerExpValueText()
	{
		float expValue = (float)(Math.Round((playerCurrentExp / playerMaxExp),4)*100);
		playerExpValue.text = String.Format("{0:0.00}", expValue) + "%";
	}

		void UpdatePlayerLevelText()
	{
		playerLevelText.text = "level : " + playerLevel.ToString();
	}

}
