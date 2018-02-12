﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelDrag : MonoBehaviour {

	float offsetX;
	float offsetY;

	public void BeginDrag()
	{
		offsetX = transform.position.x - Input.mousePosition.x;
		offsetY = transform.position.y - Input.mousePosition.y;
	}

	public void OnDrag()
	{
		transform.position = new Vector3(offsetX + Input.mousePosition.x, offsetY + Input.mousePosition.y);
	}
}
