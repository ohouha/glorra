using UnityEngine;
using System.Collections;

public class player : MonoBehaviour {

    // Use this for initialization
    public float speed;
    public joystick joysticker;
    private Vector3 addOn;

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //addOn = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0f);
        addOn = new Vector3(joysticker.Horizontal(), joysticker.Vertical(), 0f);
        transform.position += addOn * speed * Time.deltaTime;
    }

}
