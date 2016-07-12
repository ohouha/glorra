using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public joystick joysticker;
	public Transform target;
    private Vector3 addOn;
	private float leftBorder, rightBorder, topBorder, bottomBorder;

	void Start () {
		float dist=(transform.position - Camera.main.transform.position).z;
		leftBorder=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder=Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		topBorder=Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
		bottomBorder=Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		Debug.Log (topBorder);
		Debug.Log (bottomBorder);
	}
	
	// Update is called once per frame
	void Update () {
		//addOn = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);  //&&transform.position.x<bottom&&transform.position.y<left&&transform.position.y<right
		addOn = new Vector3(joysticker.Horizontal(), joysticker.Vertical(), 0f);
		transform.position+=addOn * speed * Time.deltaTime;
		float x = Mathf.Clamp (transform.position.x, leftBorder, rightBorder);
		float y=Mathf.Clamp(transform.position.y,bottomBorder,topBorder);
		/*if (transformPosition.y < top && transformPosition.y > bottom && transformPosition.x > left && transformPosition.x < right) {
			transform.position = transformPosition;
		}*/ 
		transform.position = new Vector3 (x,y,0);

		Vector3 pos = target.transform.position - transform.position;
		float angle = Mathf.Atan2 (pos.y, pos.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);


    }

}
