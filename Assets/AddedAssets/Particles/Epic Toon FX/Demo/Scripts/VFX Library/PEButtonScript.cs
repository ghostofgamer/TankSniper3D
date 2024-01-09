﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Tank3D;

public enum ButtonTypes {
	NotDefined,
	Previous,
	Next
}

public class PEButtonScript : MonoBehaviour, IEventSystemHandler, IPointerEnterHandler, IPointerExitHandler {
	#pragma warning disable 414
	private AbstractButton myButton;
	#pragma warning disable 414
	public ButtonTypes ButtonType = ButtonTypes.NotDefined;

	// Use this for initialization
	void Start () {
		myButton = gameObject.GetComponent<AbstractButton> ();
	}

	public void OnPointerEnter(PointerEventData eventData) {
		// Used for Tooltip
		UICanvasManager.GlobalAccess.MouseOverButton = true;
		UICanvasManager.GlobalAccess.UpdateToolTip (ButtonType);
	}

	public void OnPointerExit(PointerEventData eventData) {
		// Used for Tooltip
		UICanvasManager.GlobalAccess.MouseOverButton = false;
		UICanvasManager.GlobalAccess.ClearToolTip ();
	}

	public void OnButtonClicked () {
		// Button Click Actions
		UICanvasManager.GlobalAccess.UIButtonClick(ButtonType);
	}
}
