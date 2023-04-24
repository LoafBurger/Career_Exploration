 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCSystem : MonoBehaviour
{
    bool player_detection = false;


    // Start is called before the first frame update
    void Start()
    {
        print("hello");

    }

    // Update is called once per frame
    void Update()
    {
        if (player_detection && Input.GetKeyDown(KeyCode.F)) 
        {
            print("Dialogue Started");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player") {
            player_detection = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        player_detection = false;
    }

}
