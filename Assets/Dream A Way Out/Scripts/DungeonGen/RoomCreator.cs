using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RoomCreator : MonoBehaviour {
    
    List<Room> rooms;
    Room currRoom;
    Room newRoom;
    Room tempRoom;
    public GameObject reference;
    public GameObject temp;

    public int yDist = 1;
    public int xDist = 2;
    
    public int maxRooms = 15;

	void Start () {
        rooms = new List<Room>();

        Level_Maker();
	}
	
    void Level_Maker()
    {
        int randPath;
        int i;
        Vector3 pos;

        pos = new Vector3(0, 0, 0);

        temp = (GameObject)Instantiate(reference, pos, Quaternion.identity);
        currRoom = temp.GetComponent<Room>();
        currRoom.gamemode = 0;
        currRoom.north = currRoom.r.transform.Find("ndoor").gameObject.GetComponent<Door>();
        currRoom.south = currRoom.r.transform.Find("sdoor").gameObject.GetComponent<Door>();
        currRoom.east = currRoom.r.transform.Find("edoor").gameObject.GetComponent<Door>();
        currRoom.west = currRoom.r.transform.Find("wdoor").gameObject.GetComponent<Door>();
        rooms.Add(currRoom);

        for (i = 1; i < maxRooms; i++)
        {
            randPath = Random.Range(0,4);
            //Debug.Log("Random: " + randPath + "\nLoop: " + i);
            if (randPath == 0)
            {
                tempRoom = Room_GetByPosition(currRoom.gameObject.transform.position.x, currRoom.gameObject.transform.position.y + yDist);
                if (currRoom.nroom != null)
                {
                    currRoom = currRoom.nroom;
                    i--;
                }
                else if (tempRoom != null)
                {
                    //currRoom.RoomLink(tempRoom, currRoom, 0);
                    //currRoom.nroom = tempRoom;
                    //tempRoom.sroom = currRoom;
                    currRoom = tempRoom.gameObject.GetComponent<Room>();
                    i--;
                }
                else
                {
                    pos = new Vector3(currRoom.gameObject.transform.position.x, currRoom.gameObject.transform.position.y + yDist, 0);

                    temp = (GameObject)Instantiate(reference, pos, Quaternion.identity);
                    newRoom = temp.GetComponent<Room>();
                    newRoom.north = newRoom.r.transform.Find("ndoor").gameObject.GetComponent<Door>();
                    newRoom.south = newRoom.r.transform.Find("sdoor").gameObject.GetComponent<Door>();
                    newRoom.east = newRoom.r.transform.Find("edoor").gameObject.GetComponent<Door>();
                    newRoom.west = newRoom.r.transform.Find("wdoor").gameObject.GetComponent<Door>();
                    rooms.Add(newRoom);

                    currRoom.nroom = newRoom;
                    newRoom.sroom = currRoom;
                    currRoom.RoomLink(newRoom, currRoom, 0);
                    currRoom = null;
                    //Debug.Log(newRoom.gameObject.transform.position);
                    currRoom = newRoom.gameObject.GetComponent<Room>();
                    newRoom = null;
                }
            }
            else if (randPath == 1)
            {
                tempRoom = Room_GetByPosition(currRoom.gameObject.transform.position.x, currRoom.gameObject.transform.position.y - yDist);
                if (currRoom.sroom != null)
                {
                    currRoom = currRoom.sroom;
                    i--;
                }
                else if (tempRoom != null)
                {
                    //currRoom.RoomLink(currRoom, tempRoom, 0);
                    //currRoom.nroom = tempRoom;
                    //tempRoom.sroom = currRoom;
                    currRoom = tempRoom.gameObject.GetComponent<Room>();
                    i--;
                }
                else
                {
                    pos = new Vector3(currRoom.gameObject.transform.position.x, currRoom.gameObject.transform.position.y - yDist, 0);

                    temp = (GameObject)Instantiate(reference, pos, Quaternion.identity);
                    newRoom = temp.GetComponent<Room>();
                    newRoom.north = newRoom.r.transform.Find("ndoor").gameObject.GetComponent<Door>();
                    newRoom.south = newRoom.r.transform.Find("sdoor").gameObject.GetComponent<Door>();
                    newRoom.east = newRoom.r.transform.Find("edoor").gameObject.GetComponent<Door>();
                    newRoom.west = newRoom.r.transform.Find("wdoor").gameObject.GetComponent<Door>();
                    rooms.Add(newRoom);

                    currRoom.sroom = newRoom;
                    newRoom.nroom = currRoom;
                    currRoom.RoomLink(currRoom, newRoom, 0);
                    currRoom = null;
                    //Debug.Log(newRoom.gameObject.transform.position);
                    currRoom = newRoom.gameObject.GetComponent<Room>();
                    newRoom = null;
                }
            }
            else if (randPath == 2)
            {
                tempRoom = Room_GetByPosition(currRoom.gameObject.transform.position.x - xDist, currRoom.gameObject.transform.position.y);
                if (currRoom.wroom != null)
                {
                    currRoom = currRoom.wroom;
                    i--;
                }
                else if (tempRoom != null)
                {
                    //currRoom.RoomLink(tempRoom, currRoom, 1);
                    //currRoom.wroom = tempRoom;
                    //tempRoom.eroom = currRoom;
                    currRoom = tempRoom.gameObject.GetComponent<Room>();
                    i--;
                }
                else
                {
                    pos = new Vector3(currRoom.gameObject.transform.position.x - xDist, currRoom.gameObject.transform.position.y, 0);

                    temp = (GameObject)Instantiate(reference, pos, Quaternion.identity);
                    newRoom = temp.GetComponent<Room>();
                    newRoom.north = newRoom.r.transform.Find("ndoor").gameObject.GetComponent<Door>();
                    newRoom.south = newRoom.r.transform.Find("sdoor").gameObject.GetComponent<Door>();
                    newRoom.east = newRoom.r.transform.Find("edoor").gameObject.GetComponent<Door>();
                    newRoom.west = newRoom.r.transform.Find("wdoor").gameObject.GetComponent<Door>();
                    rooms.Add(newRoom);

                    currRoom.wroom = newRoom;
                    newRoom.eroom = currRoom;
                    currRoom.RoomLink(newRoom, currRoom, 1);
                    currRoom = null;
                    //Debug.Log(newRoom.gameObject.transform.position);
                    currRoom = newRoom.gameObject.GetComponent<Room>();
                    newRoom = null;
                }
            }
            else
            {

                tempRoom = Room_GetByPosition(currRoom.gameObject.transform.position.x + xDist, currRoom.gameObject.transform.position.y);
                if (currRoom.eroom != null)
                {
                    currRoom = currRoom.eroom;
                    i--;
                }
                else if (tempRoom != null)
                {
                    //currRoom.RoomLink(currRoom, tempRoom, 1);
                    //currRoom.eroom = tempRoom;
                    //tempRoom.wroom = currRoom;
                    currRoom = tempRoom.gameObject.GetComponent<Room>();
                    i--;
                }
                else
                {
                    pos = new Vector3(currRoom.gameObject.transform.position.x + xDist, currRoom.gameObject.transform.position.y, 0);

                    temp = (GameObject)Instantiate(reference, pos, Quaternion.identity);
                    newRoom = temp.GetComponent<Room>();
                    newRoom.north = newRoom.r.transform.Find("ndoor").gameObject.GetComponent<Door>();
                    newRoom.south = newRoom.r.transform.Find("sdoor").gameObject.GetComponent<Door>();
                    newRoom.east = newRoom.r.transform.Find("edoor").gameObject.GetComponent<Door>();
                    newRoom.west = newRoom.r.transform.Find("wdoor").gameObject.GetComponent<Door>();
                    rooms.Add(newRoom);

                    currRoom.eroom = newRoom;
                    newRoom.wroom = currRoom;
                    currRoom.RoomLink(currRoom, newRoom, 1);
                    currRoom = null;
                    //Debug.Log(newRoom.gameObject.transform.position);
                    currRoom = newRoom.gameObject.GetComponent<Room>();
                    newRoom = null;
                }
            }
            currRoom.gamemode = Random.Range(0, 2);
        }
    }
    Room Room_GetByPosition(float x, float y)
    {
        foreach (Room r in rooms)
        {
            if (r.gameObject.transform.position.x == x && r.gameObject.transform.position.y == y)
            {
                return r;
            }
        }
        return null;
    }
}
