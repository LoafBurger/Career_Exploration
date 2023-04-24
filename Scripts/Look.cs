using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Com.CE.CareerExploration
{
    public class Look : MonoBehaviour
    {
        public Transform player; //this is for looking left and right
        public Transform cams;  //this is for up and down, where we just rotate the camera
        public float xsensitivity, ysensitivity;
        public float max_angle; //This is the max angle your character can look up
        public static bool cursorLocked = true;    //static makes this variable accessible from any script

        private Quaternion cam_center;  // we don't need center for player because we aren't clamping

        void Start()
        {
            cam_center = cams.localRotation;    //set rotation origin for cameras to cam_center, so cam_center will always hold the value of the origin for local angle origin
        }

        void Update()
        {
            SetY();
            SetX();

            updateCursorLock();
        }

        //This is all about looking around for Y
        void SetY()
        {
            float t_input = Input.GetAxis("Mouse Y") * ysensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, -Vector3.right);   //the adjustment
            Quaternion t_delta = cams.localRotation * t_adj;    //this is adding the rotation

            //quaternion.angle is finding the degrees between two rotations
            //if new rotation is within the confines of that max angle
            if (Quaternion.Angle(cam_center, t_delta) < max_angle) {
                cams.localRotation = t_delta; //Setting the actual rotation to the camera
            }
        }

        void SetX()
        {
            float t_input = Input.GetAxis("Mouse X") * xsensitivity * Time.deltaTime;
            Quaternion t_adj = Quaternion.AngleAxis(t_input, Vector3.up);   //The reason we are doing up when we are dealing with horizontal motion is because we are rotating around the y axis. (think physics)
            Quaternion t_delta = player.localRotation * t_adj;    //this is adding the rotation
            player.localRotation = t_delta; //Setting the actual rotation to the player
        }

        //this just locks the cursor in place
        void updateCursorLock()
        {
            if (cursorLocked)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;

                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = false;
                }
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    cursorLocked = true;
                }
            }
        }
    }
}

//rotation in unity is actually a four dimensional vector, despite being called a 3 dimensional vector in the UI
//Quaternion basically represents the rotation of a gameobject, specifically 3 dimensional rotations.
//Addition for quaternions is actually multiplication, so it doesn't work exactly the same as vectors
//good max angle is around 60
//make sure to call the functions in update!!!