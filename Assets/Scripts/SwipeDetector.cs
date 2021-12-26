using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeDetector : MonoBehaviour
{
    public SwipeMode mode;
    public float minSwipeDifference;
    private Swipe swipe;
    public delegate void SwipeHandler(Swipe newSwipe);
    public event SwipeHandler SwipeEvent;

    private void Start()
    {
        swipe = new Swipe(Vector2.zero, Vector2.zero, SwipeDirection.Right);
    }

    private void Update()
    {
        if(Input.touchCount > 0 && mode == SwipeMode.Touch)
        {
            Touch touch = Input.GetTouch(0);

            if(touch.phase == TouchPhase.Began)
            {
                swipe.StartPosition = touch.position;
            }

            if(touch.phase == TouchPhase.Moved)
            {
                swipe.EndPosition = touch.position;
            }

            if(touch.phase == TouchPhase.Ended)
            {
                swipe.EndPosition = touch.position;

                Vector2 swipeDifference = new Vector2(
                    swipe.EndPosition.x - swipe.StartPosition.x,
                    swipe.EndPosition.y - swipe.StartPosition.y);

                if ((swipeDifference.x >= minSwipeDifference) || (swipeDifference.x <= -minSwipeDifference)
                    || (swipeDifference.y >= minSwipeDifference) || (swipeDifference.y <= -minSwipeDifference))
                {
                    if (Mathf.Abs(swipeDifference.x) > Mathf.Abs(swipeDifference.y))
                    {
                        if (swipeDifference.x > 0)
                        {
                            swipe.Direction = SwipeDirection.Right;
                        }
                        else
                        {
                            swipe.Direction = SwipeDirection.Left;
                        }
                    } else if (Mathf.Abs(swipeDifference.x) < Mathf.Abs(swipeDifference.y))
                    {
                        if (swipeDifference.y > 0)
                        {
                            swipe.Direction = SwipeDirection.Up;
                        }
                        else
                        {
                            swipe.Direction = SwipeDirection.Down;
                        }
                    }

                    SwipeEvent?.Invoke(swipe);

                    Debug.Log("SWIPE DETECTED. difference: " + swipeDifference + ", direction: " + swipe.Direction);
                }
            }
        } else if (mode == SwipeMode.Keyboard)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                swipe.Direction = SwipeDirection.Right;

                SwipeEvent?.Invoke(swipe);
            } else if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                swipe.Direction = SwipeDirection.Left;

                SwipeEvent?.Invoke(swipe);
            } else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                swipe.Direction = SwipeDirection.Up;

                SwipeEvent?.Invoke(swipe);
            } else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                swipe.Direction = SwipeDirection.Down;

                SwipeEvent?.Invoke(swipe);
            }
        }
    }
}

public struct Swipe
{
    public Vector2 StartPosition { get; set; }
    public Vector2 EndPosition { get; set; }
    public SwipeDirection Direction { get; set; }

    public Swipe(Vector2 startPos, Vector2 endPos, SwipeDirection direction)
    {
        StartPosition = startPos;
        EndPosition = endPos;
        Direction = direction;
    }
}

public enum SwipeDirection
{
    Right,
    Left,
    Up,
    Down
}

public enum SwipeMode
{
    Touch,
    Keyboard
}