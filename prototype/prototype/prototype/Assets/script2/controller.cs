using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.UI;

public class controller : MonoBehaviour {

	// Use this for initialization
	private bool chooseRock, chooseScissors, choosePaper;
	public Image image;
    public Image image2;
	public Button rock, scissors, paper,rock2,scissors2,paper2;
	private List<Button> buttons;
	private int pressButton;
	public float waitTime;
	public float selectionTime;
    public player2 player;
    public player2 player1;

	void Start () {
		buttons = new List<Button>();
		buttons.Add (rock);
		buttons.Add (scissors);
		buttons.Add (paper);
        buttons.Add(rock2);
        buttons.Add(scissors2);
        buttons.Add(paper2);
        //start coroutine for selection disapearAndDisable()!
        StartCoroutine(selection(selectionTime));
		pressButton = 0;
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

	public void hasChoose(Buttons button)
	{
		disapearAndDisable (button);
        button.button.GetComponent<Image> ().color=new Color(255,255,255,1f);
    }

	//disappear and show picture
	void disapearAndDisable(Buttons button)
	{
        pressButton++;
        if (button.playerNumber==1)
        {
            for(int i=0;i<3;i++)
            {
                buttons[i].GetComponent<Image>().color = new Color(255, 255, 255, 0f);
                buttons[i].interactable = false;
            }
            image.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            player1.shot = button.bullet;
            player1.shotSpawn = button.shotSpawn;
            player1.canShoot = true;
        }
        if (button.playerNumber == 2)
        {
            for (int i = 3; i < buttons.Count; i++)
            {
                buttons[i].GetComponent<Image>().color = new Color(255, 255, 255, 0f);
                buttons[i].interactable = false;
            }
            image2.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            player.shot = button.bullet;
            player.shotSpawn = button.shotSpawn;
            player.canShoot = true;
        }
        //start another coroutine for waitting new round->appearAndEnable()
        if (pressButton == 2)
        {
            StartCoroutine(waitting(waitTime));
        }
	}
    void disapearAndDisable2()
    {
        foreach (Button butt in buttons)
        {
            butt.GetComponent<Image>().color = new Color(255, 255, 255, 0f);
            butt.interactable = false;
        }
        StartCoroutine(waitting(waitTime));
    }
    void appearAndEnable()
	{
        pressButton = 0;
        player.canShoot = false;
        foreach (Button butt in buttons)
		{
			butt.GetComponent<Image> ().color=new Color(255,255,255,1f);
			butt.interactable = true;
		}
		image.GetComponent<Image> ().color = new Color (255, 255, 255, 1f);
        image2.GetComponent<Image>().color = new Color(255, 255, 255, 1f);
        //start coroutine for selection disapearAndDisable()!
        StartCoroutine(selection(selectionTime));
	}

	//wirte function here for start coroutine for selection disapearAndDisable
	IEnumerator selection(float timing)
	{
		yield return new WaitForSeconds (timing);

		if (pressButton<2) {
			disapearAndDisable2();

		}

	}
	//wirte function here for waitting new round->appearAndEnable
	IEnumerator waitting(float timing)
	{
		yield return new WaitForSeconds (timing);
		appearAndEnable ();
	}
	//shooting, collider, lose, restart
}
