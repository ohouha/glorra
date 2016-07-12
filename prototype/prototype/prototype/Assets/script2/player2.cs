using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class player2 : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public joystick joysticker;
    public joystick2 joy2;
    private Vector3 addOn;
    private float leftBorder, rightBorder, topBorder, bottomBorder,halfLeft,halfRight;
	public bool half;
	public int playerNumber;
	private float x; 
	public float cdTime;
	private float nextFire;
	public GameObject shot;
	public Transform shotSpawn;
    public bool canShoot;
	private int score;
	public Text text;

    void Start()
    {
        float dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
		halfLeft = leftBorder + (rightBorder - leftBorder) / 2-2f;
		halfRight = rightBorder - (rightBorder - leftBorder) / 2 + 2f;
		score = 10;
    }

    // Update is called once per frame
    void Update()
    {
       
        addOn = new Vector3(joysticker.Horizontal(), joysticker.Vertical(), 0f);
        transform.position += addOn * speed * Time.deltaTime;
		if (half) {
			if (playerNumber == 1) {
				x = Mathf.Clamp(transform.position.x, leftBorder, halfLeft);
			} 
			else {
				x = Mathf.Clamp(transform.position.x, halfRight, rightBorder);
			}

		} 
		else {
			x = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
		}
        float y = Mathf.Clamp(transform.position.y, bottomBorder, topBorder);
        transform.position = new Vector3(x, y, 0);

  
        if (joy2.draggable == true) { 
        transform.rotation = Quaternion.Euler(0, 0, joy2.Rotation());
        }

    }

	public void shoot()
	{
        if (canShoot)
        {
            Debug.Log("1");
            if (Time.time > nextFire)
            {
                nextFire = Time.time + cdTime;
                Debug.Log("2");
                Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            }
        }
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (playerNumber == 1 && other.gameObject.tag == "two" || playerNumber == 2 && other.gameObject.tag == "one") 
		{

			gameObject.GetComponent<SpriteRenderer> ().color = new Color (255, 0, 0, 1f);
			StartCoroutine(tryThisOne(gameObject));
			Destroy (other.gameObject);
			if (score != 0) 
			{
				score--;
				text.text = score.ToString();
			}
		}
	}
	public IEnumerator tryThisOne(GameObject gameObject)
	{
		Debug.Log ("hit1");
		yield return new WaitForSeconds (0.2f);
		Debug.Log ("hit!");
		gameObject.GetComponent<SpriteRenderer>().color = new Color(255,255,255,1f);
	}

}
