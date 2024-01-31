    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    /*Define which direction the room that spawns needs a door
    1 --> SOUTH
    2 --> WEST
    3 --> NORTH
    4 --> EAST
    */

    private RoomTemplate room;
    private int rand;
    private bool spawned;


    //Gets the arrays of room prefabs so it knows what prefabs should be used, 
    //then invoke the Spawn function within the 0.1 inteval.
    void Start() 
    {
        room = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RoomTemplate>();
        Invoke("Spawn", 0.1f);
    }

    /*
    The main function to spawn rooms.
    It will only execute if a room is not already spawned there indicated by the "spawned" variable.
    It checks the opening direction of the previous room and determines which array should be used to randomly 
    choose a room. At the end sets the spawned variable to true to mke sure that another rooms does not spawn on 
    top of it.
    */
    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                rand = Random.Range(0, room.southRooms.Length);
                Instantiate(room.southRooms[rand], transform.position, room.southRooms[rand].transform.rotation);
            }
            else if (openingDirection == 2)
            {
                rand = Random.Range(0, room.westRooms.Length);
                Instantiate(room.westRooms[rand], transform.position, room.westRooms[rand].transform.rotation);
            }
            else if (openingDirection == 3)
            {
                rand = Random.Range(0, room.northRooms.Length);
                Instantiate(room.northRooms[rand], transform.position, room.northRooms[rand].transform.rotation);
            }
            else if (openingDirection == 4)
            {
                rand = Random.Range(0, room.eastRooms.Length);
                Instantiate(room.eastRooms[rand], transform.position, room.eastRooms[rand].transform.rotation);
            }
            spawned = true;
        }
    }
   
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Instantiate(room.closedRooms, transform.position + new Vector3(0, 0, 0), Quaternion.identity);
                Destroy(gameObject);
            }
            spawned = true;
        }
    }
}
