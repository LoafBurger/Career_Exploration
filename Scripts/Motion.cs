using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Com.Nameofcompany.nameofgame
namespace Com.CE.CareerExploration
{
    public class Motion : MonoBehaviour //make sure that the class name is the same as the script (scriptname : MonoBehaviour)
    {
        public float speed;

        private Rigidbody rig;  //rig = getcomponent    //once you add this rigid body, contact will apply to everything else you touch

        private void Start()
        {
            Camera.main.enabled = false;    //this disables the main camera that you start with and uses the other camera (usually the player)
            rig = GetComponent<Rigidbody>(); //This line will grab rigidbody on the game object that this script is on
        }

        // use fixedupdate if you are doing anything related to physics (something over-time)
        void FixedUpdate()
        {
            //t_ usually means temp in c#
            //how much is the axis is being moved on a certain direction
            float t_hmove = Input.GetAxisRaw("Horizontal"), t_vmove = Input.GetAxisRaw("Vertical"); //get axis raw stops the player from sliding

            Vector3 t_direction = new Vector3(t_hmove, 0, t_vmove);    //directional vector (x, y, z)
            t_direction.Normalize();    //if they are moving forward and to the right, then their speed will be forward times 1 and right times 1, so faster diagoinally if not normalized.


            rig.velocity = transform.TransformDirection(t_direction) * speed * Time.deltaTime; //don't forget the time.delta time to avoid framerate issues
        }
    }
}

//when you are testing with the actual player, make sure to freeze rotation on all axes
//make sure to save your changes!!


/*To do:
 * look into getting the assets and creating the environment
 * potentially start looking into ai movement around the office
 */

//Office low Poly - ChompyLunchbox
//Simple Office Interiors - Cartoon Assets - Synty Studios