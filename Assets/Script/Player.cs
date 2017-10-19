using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {

    Vector3 velocity;
    float gravity = -20f;
    public float minJumpHeight = 1;
    public float maxJumpHeight = 4;
    public float timeToJumpApex = 0.4f;

    public float maxDashTime = 1f;
    public float dashForce = 50.0f;
    public float dashStoppingSpeed = 0.1f;

    private float currentDashTime;

    float maxJumpVelocity;
    float minJumpVelocity;
    float accelerationTimeAirborne = .2f;
    float accelerationTimeGrounded = .1f;
    float velocityXSmoothing;
    public float moveSpeed;

    Vector3 aimDirection;

    public Vector2 wallJumpClimb;
    public Vector2 wallJumpOff;
    public Vector2 wallLeap;
    public float wallSlideSpeedMax = 3;
    public float wallStickTime = .25f;
    float timeToWallUnstick;
    Controller2D controller;

	// Use this for initialization
	void Start () {


        controller = GetComponent<Controller2D>();

        aimDirection = Vector3.right;
        currentDashTime = maxDashTime;

        gravity = -(2 * maxJumpHeight) / Mathf.Pow(timeToJumpApex, 2);
        maxJumpVelocity = Mathf.Abs(gravity) * timeToJumpApex;
        minJumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(gravity) * minJumpHeight);
        print("Gravity: " + gravity + " Jump Velocity: " + maxJumpVelocity);

	}
	
	// Update is called once per frame
	void Update () {

        //Time.timeScale = 1f;
        Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        int wallDirX = (controller.collisions.left) ? -1 : 1;

        float targetVelocityX = input.x * moveSpeed;
        velocity.x = Mathf.SmoothDamp(velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below) ? accelerationTimeGrounded : accelerationTimeAirborne);

        if (input.x != 0)
        {
            aimDirection = Mathf.Sign(input.x) == 1 ? Vector3.right : Vector3.left;//constantly check which direction is the player looking at
        }
        

        bool wallSliding = false;

        if ((controller.collisions.left || controller.collisions.right) && !controller.collisions.below && velocity.y < 0){
            wallSliding = true;
            if (velocity.y < -wallSlideSpeedMax)
            {
                velocity.y = -wallSlideSpeedMax;
            }

            if (timeToWallUnstick > 0)
            {
                velocityXSmoothing = 0;
                velocity.x = 0;
                if (input.x != wallDirX && input.x != 0)
                {
                    timeToWallUnstick -= Time.deltaTime;
                }
                else
                {
                    timeToWallUnstick = wallStickTime;
                }
                
            }
            else
            {
                timeToWallUnstick = wallStickTime;
            }
        }

        if (Input.GetKeyDown(KeyCode.C))//start dash
        {
            currentDashTime = 0f;
            controller.collisions.isDashing = true;

        }

        if(currentDashTime < maxDashTime)//dash still activated?
        {
            float direction = Mathf.Sign(velocity.x);
            //velocity.x += ((direction == 1) ? dashForce : -dashForce);
            velocity.x += aimDirection.x * dashForce;
            velocity.y = 0f;
            currentDashTime += dashStoppingSpeed;

            

        }
        else //dash is finished
        {
            controller.collisions.isDashing = false;
            //velocity.x = 0f;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (wallSliding)
            {
                if (wallDirX == input.x)
                {
                    velocity.x = -wallDirX * wallJumpClimb.x;
                    velocity.y = wallJumpClimb.y;

                }
                else if(input.x == 0)
                {
                    velocity.x = -wallDirX * wallJumpOff.x;
                    velocity.y = wallJumpOff.y;
                }
                else 
                {
                    velocity.x = -wallDirX * wallLeap.x;
                    velocity.y = wallLeap.y;
                }
            }
            if (controller.collisions.below)
            {
                velocity.y = maxJumpVelocity;
            }
            

        }
        if (Input.GetKeyUp(KeyCode.Space)){
            if (velocity.y > minJumpVelocity)
            {
                velocity.y = minJumpVelocity;
            }
            
        }

       
        if (!controller.collisions.isDashing)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        
        controller.Move(velocity * Time.deltaTime, input);
        


        if (controller.collisions.above || controller.collisions.below)
        {

            velocity.y = 0;
        }

       // Debug.Log(velocity);

    }
}
