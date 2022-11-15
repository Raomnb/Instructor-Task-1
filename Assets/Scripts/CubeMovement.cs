using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public bool isGameStarted; //bool for starting game;
    public float timer; // timer in seconds after which game will end;
    private float countDownTimer = 3; //setting count down timer to 3 seconds
    private int minutes; // to show timer in debug in minutes
    private int seconds; // to show timer seconds
    private float verticalInput; // to get up down keys
    private float horizontalInput; // to get left right keys
    public float rotationSpeed = 20; // speed for rotation of cube
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Fixed Update is called once per fixed interval which in our case is 1 second
    private void FixedUpdate()
    {
        if (isGameStarted) // checking if user has started game or not
        {
            if (countDownTimer > 0) //checking that count down timer is not over 
            {
                Debug.Log("Count Down Time : "); // showing text Count Down Time in Console
                
                 Debug.Log(countDownTimer); //Showing seconds remaining in count down timer
                 countDownTimer = countDownTimer - Time.deltaTime; //reducing 1 second from count down timer
            }
            if (countDownTimer <= 0) // Checking that count down timer is over
            {
                Debug.Log("Time : "); //showing text  time in Console
            
                if (timer > 0) //Checking that timer is not over
                {
                    minutes = (int)timer / 60; //converting timer to minutes
                    seconds = (int)timer - (60 * minutes); //converting timer remaining seconds to seconds
                    timer = timer - Time.deltaTime; //reducing 1 second from timer
                    Debug.Log(minutes + " Minutes " + seconds + " Seconds"); //showing timer in minutes and seconds in Console
                }

            }
        }
    }

    //Update is called once every Frame
    private void Update()
    {
        if(Input.GetKeyDown("f")) //using f key to stop game
        {
            isGameStarted = false;//using f key to stop game
        }
        if(Input.GetKeyDown("t")) //using t key to start game
        {
            isGameStarted = true; //using t key to start game
        }
        if (isGameStarted) //checking game is started by user or not
        {
            if (countDownTimer <= 0) // Checking that count down timer is over
            {
                if (timer > 0)  //Checking that timer is not over
                {
                    if (Input.GetKey("space")) // getting space key pressed 
                    {
                        transform.localScale += new Vector3(1, 1, 1) * Time.deltaTime; //  increasing siz of cube
                    }
                    else 
                    { 
                        if (transform.localScale.x > 1 && transform.localScale.y > 1 && transform.localScale.z > 1) //checking that size is not default size
                        {
                            transform.localScale -= new Vector3(1, 1, 1) * Time.deltaTime; //reducing size of cube 
                        }
                    }
                    verticalInput = Input.GetAxis("Vertical"); //assigning up down key to vertical input
                    horizontalInput = Input.GetAxis("Horizontal"); //assigning left right keys to horizontal input
                    transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput); // roatating cube up down on up down key
                    transform.Rotate(Vector3.down * rotationSpeed * Time.deltaTime * horizontalInput); // rotating cube left right on left right key 
                }
            }
        }

    }
}
