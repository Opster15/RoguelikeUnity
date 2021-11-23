using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomTemplates : MonoBehaviour
{

    public GameObject[] allBRooms;
    public GameObject[] allTRooms;
    public GameObject[] allLRooms;
    public GameObject[] allRRooms;
    public GameObject[] singleBRooms;
    public GameObject[] singleTRooms;
    public GameObject[] singleLRooms;
    public GameObject[] singleRRooms;
    public GameObject[] resetRooms;
    public GameObject[] enemySpawner;

    public GameObject closedRoom;
    public GameObject entryRoom;
    public GameObject boss;

    public List<GameObject> rooms;

    public float bossWaitTime = 7;
    public float roomWaitTime = 5;
    bool spawnedBoss,smol;
    public int maxRoomCount, minRoomCount;



    private void Update()
    {
        if (bossWaitTime <= 0 && spawnedBoss == false)
        {
            for (int i = 0; i < rooms.Count; i++)
            {
                if (i == rooms.Count - 1)
                {
                    Instantiate(boss, rooms[i].transform.position, Quaternion.identity);
                    spawnedBoss = true;
                    AddEnemies();
                }
            }
        }
        else
        {
            bossWaitTime -= Time.deltaTime;
        }

        #region roomSize

        if (roomWaitTime <= 0 && smol == false)
        {
            if (rooms.Count <= minRoomCount)
            {
                resetRooms = GameObject.FindGameObjectsWithTag("Rooms");
                for (int i = 0; i < resetRooms.Length; i++)
                {
                    Destroy(resetRooms[i].gameObject);
                }
                rooms.Clear();
                smol = true;
                Invoke("TooSmall", 0.5f);
            }
        }
        else
        {
            roomWaitTime -= Time.deltaTime;
        }

        if (rooms.Count >= maxRoomCount)
        {
            resetRooms = GameObject.FindGameObjectsWithTag("Rooms");
            for (int i = 0; i < resetRooms.Length; i++)
            {
                Destroy(resetRooms[i].gameObject);
            }
            rooms.Clear();
            Invoke("TooBig", 0.5f);
        }
    }

    public void TooBig()
    {
        Instantiate(entryRoom, transform.position, Quaternion.identity);
        roomWaitTime = 1;
        bossWaitTime = 5;
    }

    public void TooSmall()
    {
        Instantiate(entryRoom, transform.position, Quaternion.identity);
        roomWaitTime = 1;
        bossWaitTime = 5;
        smol = false;
    }

    #endregion

    public void AddEnemies()
    {
        enemySpawner = GameObject.FindGameObjectsWithTag("EnemySpawner");
        for (int i = 0; i < enemySpawner.Length; i++)
        {
            enemySpawner[i].GetComponent<EnemySpawner>().Spawn();
        }
    }
}
