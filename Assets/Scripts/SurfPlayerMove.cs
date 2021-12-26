using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurfPlayerMove : MonoBehaviour
{
    [SerializeField] private SwipeDetector detector;
    [SerializeField] private Transform mainCamera;
    public Swipe lastSwipe;
    private Rigidbody rb;
    public bool OnGround = false, OnTrain = false, IsAlive = true, goesDown = false;
    public float speed, jumpForce, downForce, strafeJumpSpeed, xLeft, xMiddle, xRight, strafeSpeed, camNormal, camUp, camSpeed;
    public int xState = 0, cameraState = 0;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        detector.SwipeEvent += SwipeHandler;
    }

    private void FixedUpdate()
    {
        if(IsAlive)
            rb.MovePosition(rb.position + Vector3.forward * speed * Time.fixedDeltaTime);

        MoveX();
        CameraMove();
    }

    private void SwipeHandler(Swipe swipe)
    {
        lastSwipe = swipe;
        SwipeDirection dir = swipe.Direction;

        if (swipe.Direction == SwipeDirection.Up && (OnGround || OnTrain))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }
        else if (swipe.Direction == SwipeDirection.Left)
        {
            if (xState > -1f)
                xState--;

            rb.MovePosition(rb.position += Vector3.up * strafeJumpSpeed);
        }
        else if (swipe.Direction == SwipeDirection.Right)
        {
            if (xState < 1f)
                xState++;

            rb.MovePosition(rb.position += Vector3.up * strafeJumpSpeed);
        }
        else if(swipe.Direction == SwipeDirection.Down)
        {
            rb.AddForce(Vector3.down * downForce);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            OnGround = true;

            cameraState = 0;
        }
        else if (collision.gameObject.CompareTag("Train"))
        {
            OnTrain = true;

            cameraState = 1;
        }
        else if (collision.gameObject.CompareTag("DieObject"))
        {
            IsAlive = false;

            detector.SwipeEvent -= SwipeHandler;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sideway"))
        {
            if (xState == 1 || xState == -1)
            {
                xState = 0;
            }
            else
            {
                if (lastSwipe.Direction == SwipeDirection.Right)
                {
                    xState = -1;
                }
                else
                {
                    xState = 1;
                }
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Platform"))
        {
            OnGround = false;
        }
        else if (collision.gameObject.CompareTag("Train"))
        {
            OnTrain = false;
        }
    }

    public void MoveX()
    {
        if (xState == -1)
        {
            Vector3 vector = new Vector3(xLeft, rb.position.y, rb.position.z);

            rb.MovePosition(Vector3.MoveTowards(rb.position, vector, strafeSpeed * Time.fixedDeltaTime));
        }
        else if (xState == 0)
        {
            Vector3 vector = new Vector3(xMiddle, rb.position.y, rb.position.z);

            rb.MovePosition(Vector3.MoveTowards(rb.position, vector, strafeSpeed * Time.fixedDeltaTime));
        }
        else if (xState == 1)
        {
            Vector3 vector = new Vector3(xRight, rb.position.y, rb.position.z);

            rb.MovePosition(Vector3.MoveTowards(rb.position, vector, strafeSpeed * Time.fixedDeltaTime));
        }
    }

    public void CameraMove()
    {
        if (cameraState == 0)
        {
            Vector3 vector = new Vector3(mainCamera.position.x, camNormal, mainCamera.position.z);

            mainCamera.position = Vector3.MoveTowards(mainCamera.position, vector, camSpeed * Time.fixedDeltaTime);
        }
        else if (cameraState == 1)
        {
            Vector3 vector = new Vector3(mainCamera.position.x, camUp, mainCamera.position.z);

            mainCamera.position = Vector3.MoveTowards(mainCamera.position, vector, camSpeed * Time.fixedDeltaTime);
        }
    }
}
