using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class buttons : MonoBehaviour, IPointerDownHandler, IPointerUpHandler{
	
	public float holdSeconds;
	public bool holddown;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnPointerDown(PointerEventData eventData) {
		StartCoroutine(startHoldTimer());
		holddown = true;
	}

	public void OnPointerUp(PointerEventData eventData) {
		StopCoroutine(startHoldTimer());
		holddown = false;
		Debug.Log ("leave!");
	}
		

	private IEnumerator startHoldTimer() {
		yield return new WaitForSeconds(0.2f);
	}
}
