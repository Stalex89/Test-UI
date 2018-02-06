﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TogglePanel : MonoBehaviour 
{

	public GameObject panel;

	public void TogglePanelFunction()
	{
		//PanelCamera.enabled = !PanelCamera.enabled;
		if(panel.gameObject.activeSelf == true)
			panel.gameObject.SetActive(false);
		else panel.gameObject.SetActive(true);

	}
}
