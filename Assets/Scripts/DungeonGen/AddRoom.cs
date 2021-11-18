using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoom : MonoBehaviour
{

    public RoomTemplates templates;


    void Start()
    {
        templates = FindObjectOfType<RoomTemplates>();
        templates.rooms.Add(this.gameObject);
    }

}
