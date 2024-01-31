using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplate : MonoBehaviour
{
    public GameObject[] southRooms;
    public GameObject[] northRooms;
    public GameObject[] westRooms;
    public GameObject[] eastRooms;

    public GameObject closedRooms;

    public List<GameObject> rooms;

    public float waitTime;
    private bool spawnedHatch = false;
    public GameObject win;

    void Update(){
        if(waitTime < 0 && spawnedHatch == false){
            for(int i = 0; i < rooms.Count; i++){
                if(i == rooms.Count - 1){
                    Instantiate(win, rooms[i].transform.position, Quaternion.identity);
                    spawnedHatch = true;
                }
            }
        }
        else {
            waitTime -= Time.deltaTime;
        }
    }
}
