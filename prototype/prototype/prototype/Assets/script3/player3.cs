using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class player3 : MonoBehaviour{

	// Use this for initialization
	public float speed2;
	private Vector3 addOn;
	private float leftBorder, rightBorder, topBorder, bottomBorder; 
	private bool hold=false;
	private float distance;
	public Vector3 velocityUp;
	public Vector3 velocityDown;
	public buttons but;
	private float newValue=0;
	public float playerNumber;
	private float rightOrigin;

	//

	void Start()
	{
		float dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		rightOrigin = rightBorder;
		distance = rightBorder;
		rightBorder /= 2;
		topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;

	}

	// Update is called once per frame
	void Update()
	{

		/*addOn = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
		transform.position += addOn * speed2 * Time.deltaTime;
		float x = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
		float y = Mathf.Clamp(transform.position.y, bottomBorder, topBorder);
		transform.position = new Vector3(x, y, 0);*/

		if(but.holddown==true)//Input.GetKey(KeyCode.Space)
		{
			hold = true;
		}
		else
		{
			hold = false;
		}
		if (hold ==true) {
			
			transform.position += velocityUp * Time.deltaTime;
		} 
		else 
		{
			transform.position += velocityDown * Time.deltaTime;
		}
		float x=0f;
		if(playerNumber==1)
		{
			x=leftBorder+ distance * newValue;
			x = Mathf.Clamp(x, leftBorder, rightBorder);
		}
		if(playerNumber==2)
		{
			x=rightOrigin+distance * newValue;
			x = Mathf.Clamp(x, leftBorder, rightOrigin);
		}
		float y = Mathf.Clamp(transform.position.y, bottomBorder, topBorder);
		transform.position = new Vector3(x, y, 0);

	}
		
	public void moveHorizontal(float value)
	{
		newValue = value;
	}


	/*
	 if (elapsedTime == 0) {
			rb.AddForce (-1 * transform.up ); 
		} 
		else {
			if (elapsedTime > maxExtraJump) {
				elapsedTime = maxExtraJump;

			}

			rb.AddForce (transform.up * (elapsedTime * extraPower)); 
		}
	*/

}
