using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private RoomTemplates templates;
    
    public int openingDirection;
    //1 = bottom
    //2 = top
    //3 = left
    //4 = right
    private int random;
    public bool spawned = false;

    void Start()
    {
        templates = FindObjectOfType<RoomTemplates>();
        Invoke("Spawn", 0.05f);
        Destroy(gameObject, 8f);
    }


    void Spawn()
    {
        if(spawned == false)
        {
            if (openingDirection == 1)
            {
                random = Random.Range(0, templates.allBRooms.Length);
                Instantiate(templates.allBRooms[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 2)
            {
                random = Random.Range(0, templates.allTRooms.Length);
                Instantiate(templates.allTRooms[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 3)
            {
                random = Random.Range(0, templates.allLRooms.Length);
                Instantiate(templates.allLRooms[random], transform.position, Quaternion.identity);
            }
            else if (openingDirection == 4)
            {
                random = Random.Range(0, templates.allRRooms.Length);
                Instantiate(templates.allRRooms[random], transform.position, Quaternion.identity);
            }
            spawned = true; 
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SpawnPoint"))
        {
            if(other.GetComponent<RoomSpawner>().spawned == false && spawned == false)
            {
                Invoke("ClosedRoom", 1f);
            }
            spawned = true;
        }
    }

    void ClosedRoom()
    {
        Instantiate(templates.closedRoom, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
