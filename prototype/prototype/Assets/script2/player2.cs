using UnityEngine;
using System.Collections;

public class player2 : MonoBehaviour
{

    // Use this for initialization
    public float speed;
    public joystick joysticker;
    public joystick2 joy2;
    private Vector3 addOn;
    private float leftBorder, rightBorder, topBorder, bottomBorder;

    void Start()
    {
        float dist = (transform.position - Camera.main.transform.position).z;
        leftBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).x;
        rightBorder = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, dist)).x;
        topBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, dist)).y;
        bottomBorder = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, dist)).y;
        Debug.Log(topBorder);
        Debug.Log(bottomBorder);
    }

    // Update is called once per frame
    void Update()
    {
       
        addOn = new Vector3(joysticker.Horizontal(), joysticker.Vertical(), 0f);
        transform.position += addOn * speed * Time.deltaTime;
        float x = Mathf.Clamp(transform.position.x, leftBorder, rightBorder);
        float y = Mathf.Clamp(transform.position.y, bottomBorder, topBorder);
        transform.position = new Vector3(x, y, 0);

        //Vector3 pos = target.transform.position - transform.position;
        //float angle = Mathf.Atan2(pos.y, pos.x) * Mathf.Rad2Deg;
        //transform.rotation = Quaternion.AngleAxis(joy2.Rotation(), Vector3.forward);
        if (joy2.draggable == true) { 
        transform.rotation = Quaternion.Euler(0, 0, joy2.Rotation());
        }

    }

}
