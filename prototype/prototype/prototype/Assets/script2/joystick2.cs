using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System;

public class joystick2 : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

    private Image bgImg;
    private Image joyStick;
    private Vector2 inputVector;
	private float rightBorder;
    public int playerNumber;
    public bool draggable;

    // Use this for initialization
    void Start()
    {
        bgImg = GetComponent<Image>();
        joyStick = transform.GetChild(0).GetComponent<Image>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 pos;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform,
            eventData.position,
            eventData.pressEventCamera, out pos))
        {
            //get 0-1 value
            pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
            pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

            if (playerNumber == 1)
            {
                inputVector = new Vector2(pos.x * 2 - 1, pos.y * 2 - 1);
            }
            if (playerNumber == 2)
            {
                inputVector = new Vector2(pos.x * 2 + 1, pos.y * 2 - 1);
            }

            Debug.Log(inputVector);

            inputVector = (inputVector.magnitude > 1.0) ? inputVector.normalized : inputVector;



            //move joystickImage
            joyStick.rectTransform.anchoredPosition =
                new Vector2(inputVector.x * (bgImg.rectTransform.sizeDelta.x / 3),
                inputVector.y * (bgImg.rectTransform.sizeDelta.y / 3));

            //Debug.Log(inputVector.magnitude);
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        inputVector = Vector2.zero;
        joyStick.rectTransform.anchoredPosition = Vector2.zero;
        draggable = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        draggable = true;
        OnDrag(eventData);
    }

    public float Rotation()
    {
        if (inputVector.x != 0 || inputVector.y != 0)
        {
			if (playerNumber == 1) {
				return Mathf.Atan2 (inputVector.y, inputVector.x) * Mathf.Rad2Deg;
			}
			else 
			{
				return Mathf.Atan2 (-inputVector.y, -inputVector.x) * Mathf.Rad2Deg;
			}

        }
        else
        {
            return 0f;
        }
    }

}
