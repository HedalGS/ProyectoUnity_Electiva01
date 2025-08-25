using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GesturesInteractions : MonoBehaviour
{

    public Camera mainCamera;

    private float touchesPrevPosDifference, touchesCurPosDifference, zoomModifier;
    private Vector2 touchStartPosition, touchEndPosition;
    Vector2 firstTouchPrevPos, secondTouchPrevPos;
    public GameObject myObject;

    [SerializeField]
    float zoomModifierSpeed = 0.1f;

    [SerializeField]
    TextMeshProUGUI text;

    // Use this for initialization
    void Start()
    {
        text.text = "Camera FOD " + mainCamera.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {

            if (Input.touchCount == 1)
            {
                //Un Touch en vertical para hacer rotación en el objeto
                //Un Touch en horizontal para hacer traslación en el objeto
                Touch firstTouch = Input.GetTouch(0);

                if (firstTouch.phase == TouchPhase.Began)
                {
                    touchStartPosition = firstTouch.position;

                }
                else if (firstTouch.phase == TouchPhase.Moved || firstTouch.phase == TouchPhase.Ended)
                {
                    touchEndPosition = firstTouch.position;

                    float myTouchY = touchEndPosition.y - touchStartPosition.y;
                    float myTouchX = touchEndPosition.x - touchStartPosition.x; 
                    if (Mathf.Abs(myTouchY) == 0)
                    {
                        Debug.Log("Tapped");
                        
                    }
                    else if (Mathf.Abs(myTouchX) > Mathf.Abs(myTouchY))
                    {
                        //Si el touch es horizontal, desplazar el objeto en el eje X
                        Debug.Log(myTouchX > 0 ? "Right" : "Left");
                        if (myTouchX > 0)
                        {
                            myObject.transform.Translate(0.05f, 0, 0, Space.World);
                        }
                        else if (myTouchX < 0)
                        {
                            myObject.transform.Translate(-0.05f, 0, 0, Space.World);
                        }
                    }
                    else
                    {
                        //Si el touch es vertical, rotar el objeto en el eje X
                        Debug.Log(myTouchY > 0 ? "Up" : "Down");
                        if (myTouchY > 0)
                        {
                            myObject.transform.Rotate(5, 0, 0);
                        }
                        else if (myTouchY < 0)
                        {
                            myObject.transform.Rotate(-5, 0, 0);
                        }
                    }
                }
            }
           
            if (Input.touchCount == 2)
            {
                //Dos Touch para hacer Zoom In/Zoom Out
                Touch firstTouch = Input.GetTouch(0);
                Touch secondTouch = Input.GetTouch(1);

                firstTouchPrevPos = firstTouch.position - firstTouch.deltaPosition;
                secondTouchPrevPos = secondTouch.position - secondTouch.deltaPosition;

                touchesPrevPosDifference = (firstTouchPrevPos - secondTouchPrevPos).magnitude;
                touchesCurPosDifference = (firstTouch.position - secondTouch.position).magnitude;

                zoomModifier = (firstTouch.deltaPosition - secondTouch.deltaPosition).magnitude * zoomModifierSpeed;

                if (touchesPrevPosDifference > touchesCurPosDifference)
                    mainCamera.fieldOfView += zoomModifier;
                if (touchesPrevPosDifference < touchesCurPosDifference)
                    mainCamera.fieldOfView -= zoomModifier;

            }

            mainCamera.fieldOfView = Mathf.Clamp(mainCamera.fieldOfView, 2f, 100f);
            text.text = "Camera FOD " + mainCamera.fieldOfView;
        }
    }
}