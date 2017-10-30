using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{

    public GameObject leftBoundary, rightBoundary;
    private GameObject console;
    public bool right, left, flying, boost;
    public int moveSpeed, flySpeed, rotSpeed;
    public float boostMultiplier;
    private float minX, maxX;
    private float rotZ;

    // Use this for initialization
    void Start()
    {
        rotZ = this.transform.rotation.z;
        minX = leftBoundary.transform.position.x+0.3f;
        maxX = rightBoundary.transform.position.x-0.3f;
        console = GameObject.FindGameObjectWithTag("Console");
    }

    // Update is called once per frame
    void Update()
    {
        if (console.GetComponent<Console>().inGame)
        {
            //Key Down
            if (CrossPlatformInputManager.GetAxis("Horizontal") >= 0)
            {
                right = true;
                left = false;
            }
            if (CrossPlatformInputManager.GetAxis("Horizontal") < 0)
            {
                left = true;
                right = false;
            }
            if (Input.GetKeyDown(KeyCode.W))
                boost = true;

            //Key Up
            if (Input.GetKeyUp(KeyCode.D))
                right = false;
            if (Input.GetKeyUp(KeyCode.A))
                left = false;
            if (Input.GetKeyUp(KeyCode.W))
                boost = false;

            //ROTATION
            //if (right)
            //{
            //    rotZ -= rotSpeed;
            //    if (this.transform.localScale.x > 0)
            //        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            //    if (rotZ < -60)
            //        rotZ = -60;

            //}
            //if (left)
            //{
            //    rotZ += rotSpeed;
            //    if (this.transform.localScale.x < 0)
            //        this.transform.localScale = new Vector3(-this.transform.localScale.x, this.transform.localScale.y, this.transform.localScale.z);
            //    if (rotZ > 60)
            //        rotZ = 60;



            //}
            this.transform.rotation = Quaternion.Euler(0, 0, CrossPlatformInputManager.GetAxis("Horizontal")*-45);

            //FLYYY
            float speed = flySpeed;
            if (boost)
            {
                speed *= boostMultiplier;
            }
            this.transform.Translate(Vector2.up * speed * Time.deltaTime);

            //BOUNDS OF PLAYER
            if (this.transform.position.x <= minX)
                this.transform.position = new Vector3(minX, this.transform.position.y, this.transform.position.z);
            if (this.transform.position.x >= maxX)
                this.transform.position = new Vector3(maxX, this.transform.position.y, this.transform.position.z);

            float posY = this.transform.position.y;
            if (this.transform.position.y > -2)
                posY = -2;

            this.transform.position = new Vector2(this.transform.position.x, posY);
        }
        else
        {
            left = false;
            right = false;
        }
    }
}
