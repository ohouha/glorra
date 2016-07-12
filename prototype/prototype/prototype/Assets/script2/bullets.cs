using UnityEngine;
using System.Collections;

public class bullets : MonoBehaviour {

	// Use this for initialization
	public float speed;
	private float leftBorder,rightBorder;
    public int Number;
    public bool hit;
	public int playerNumber;
	private controller controll;
	void Start () {
		float dist = (transform.position - Camera.main.transform.position).z;
		leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
		rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
		controll = GameObject.Find ("controller").GetComponent<controller> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += transform.right * speed;
		if (transform.position.x > rightBorder||transform.position.x<leftBorder) 
		{
			Destroy (this.gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D other)
    {

		if (other.gameObject.tag == "player") {
			/*if(other.gameObject.GetComponent<player2>().playerNumber!=playerNumber){
				getHurt (other.gameObject);
				Destroy (this.gameObject);
			}*/
		} else {
			int myselfNumber = this.gameObject.GetComponent<bullets> ().Number;
			int otherNumber = other.gameObject.GetComponent<bullets> ().Number;

			if (myselfNumber == 1) {
				if (otherNumber == 2) {

					if (this.gameObject != null) { 
				
						Destroy (this.gameObject);
					}
				}
				if (otherNumber == 3) {
					if (other.gameObject != null) {
						Destroy (other.gameObject);
					}
				}
			}
			if (myselfNumber == 2) {
				if (otherNumber == 3) {
					if (this.gameObject != null) {
						Destroy (this.gameObject);
					}
				}
				if (otherNumber == 1) {
					if (other.gameObject != null) {
						Destroy (other.gameObject);
					}
				}
			}
			if (myselfNumber == 3) {
				if (otherNumber == 1) {
					if (this.gameObject != null) {
						Destroy (this.gameObject);
					}
				}
				if (otherNumber == 2) {
					if (other.gameObject != null) {
						Destroy (other.gameObject);
					}
				}
			}
		}
        }


}
