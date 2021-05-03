using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 200f;
    public float moveForwardSpeed = 3f;
    private Vector3 LeftPosition;
    private Vector3 RightPosition;
    private Vector3 TopPosition;
    private Vector3 FloorPosition;
    private GameObject LeftRightCollidDetector;
    private GameObject TopButtomCollidDetector;
    private bool movingToRight = false;
    private bool movingToLeft = false;
    private bool movingToTop = false;
    private bool movingToButtom = false;

    // Start is called before the first frame update
    void Start()
    {
        LeftPosition = new Vector3(-4.5f, 0f, 0f);
        RightPosition = new Vector3(4.5f, 0f, 0f);
        TopPosition = new Vector3(0f, 4.5f, 0f);
        FloorPosition = new Vector3(0f, -4.5f, 0f);
        //LeftRightCollidDetector = this.transform.Find("LeftRightCollidDetector").gameObject;
        //LeftRightCollidDetector = this.transform.Find("TopButtomCollidDetector").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            movingToLeft = true;
            movingToRight = false;
            movingToTop = false;
            movingToButtom = false;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            movingToLeft = false;
            movingToRight = true;
            movingToTop = false;
            movingToButtom = false;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            movingToLeft = false;
            movingToRight = false;
            movingToTop = true;
            movingToButtom = false;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            movingToLeft = false;
            movingToRight = false;
            movingToTop = false;
            movingToButtom = true;
        }
    }

    private void FixedUpdate()
    {
        LeftPosition.z = this.transform.position.z;
        RightPosition.z = this.transform.position.z;
        TopPosition.z = this.transform.position.z;
        FloorPosition.z = this.transform.position.z;

        if (movingToLeft && (this.transform.position != LeftPosition))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, LeftPosition, speed * Time.deltaTime);
        }
        else if (movingToRight && (this.transform.position != RightPosition))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, RightPosition, speed * Time.deltaTime);
        }
        else if (movingToTop && (this.transform.position != TopPosition))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, TopPosition, speed * Time.deltaTime);
        }
        else if (movingToButtom && (this.transform.position != FloorPosition))
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position, FloorPosition, speed * Time.deltaTime);
        }

        if (Vector3.Distance(this.transform.position, LeftPosition) < 1f)
        {
            this.transform.position = LeftPosition;
            movingToLeft = false;
        }
        if (Vector3.Distance(this.transform.position, RightPosition) < 1f)
        {
            this.transform.position = RightPosition;
            movingToRight = false;
        }
        if (Vector3.Distance(this.transform.position, TopPosition) < 1f)
        {
            this.transform.position = TopPosition;
            movingToTop = false;
        }
        if (Vector3.Distance(this.transform.position, FloorPosition) < 1f)
        {
            this.transform.position = FloorPosition;
            movingToButtom = false;
        }
        this.transform.Translate(0f, 0f, moveForwardSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blocker")
        {
            Debug.Log("Game Over");
            this.GetComponent<PlayerMovement>().enabled = false;
        }
        if (other.tag == "Reward")
        {
            Debug.Log("Reward!!!");
        }
    }

    //public void CollisionDetected(LeftRightCollidDetector childScript)
    //{
    //    Debug.Log("child collided");
    //}
}
