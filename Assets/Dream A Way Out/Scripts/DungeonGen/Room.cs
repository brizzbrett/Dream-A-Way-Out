using UnityEngine;
using System.Collections;

public class Room : MonoBehaviour
{

    public Vector3 pos;

    public Room nroom;
    public Room sroom;
    public Room wroom;
    public Room eroom;

    public Door south;
    public Door north;
    public Door east;
    public Door west;

    public GameObject r;
    public GameObject player;
    public Player playerScript;
    
    public Sprite[] sprites = new Sprite[20];

    public int gamemode { get; set; }

    void Start()
    {
       
        pos = this.gameObject.transform.position;
        r = this.gameObject;

        playerScript = player.GetComponent<Player>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = SpritePicker();
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject == player)
        {
            this.gameObject.layer = 9;
            if(this.gameObject.transform.FindChild("sdoor").gameObject.activeSelf)
            {
                this.gameObject.transform.FindChild("sdoor").gameObject.layer = 9;
            }
            if (this.gameObject.transform.FindChild("ndoor").gameObject.activeSelf)
            {
                this.gameObject.transform.FindChild("ndoor").gameObject.layer = 9;
            }
            if (this.gameObject.transform.FindChild("edoor").gameObject.activeSelf)
            {
                this.gameObject.transform.FindChild("edoor").gameObject.layer = 9;
            }
            if (this.gameObject.transform.FindChild("wdoor").gameObject.activeSelf)
            {
                this.gameObject.transform.FindChild("wdoor").gameObject.layer = 9;
            }
        }
    }
    public void RoomLink(Room l, Room r, int split)
    {
        if (split == 0) 
        {

            if (l.south == null || r.north == null)
            {
                return;
            }
            l.south.target = r.north;
            r.north.target = l.south;
           
        }
        else if (split == 1)
        {

            if (l.east == null || r.west == null)
            {
                return;
            }
            l.east.target = r.west;
            r.west.target = l.east;
        }
    }
    public Sprite SpritePicker()
    {
        int number;

        if (nroom == null)
        {
            if (nroom == null && sroom == null)
            {
                number = Random.Range(2, 4);
                //Debug.Log(number);
                return sprites[number];
            }
            else if (eroom == null && nroom == null)
            {
                number = 5;
                //Debug.Log(number);
                return sprites[number];
            } 
            else if (wroom == null && nroom == null)
            {
                number = 7;
                //Debug.Log(number);
                return sprites[number];
            }
            else
            {
                number = 10;
                //Debug.Log(number);
                return sprites[number];
            }
        }
        else if (sroom == null)
        {
            if (wroom == null && sroom == null)
            {
                number = 4;
                //Debug.Log(number);
                return sprites[number];
            }
            else if (eroom == null && sroom == null)
            {
                number = 6;
                //Debug.Log(number);
                return sprites[number];
            }
            else
            {
                number = 11;
                //Debug.Log(number);
                return sprites[number];
            }
        }
        else if (wroom == null)
        {
            if (wroom == null && eroom == null)
            {
                number = Random.Range(0, 2);
                //Debug.Log(number);
                return sprites[number];
            }
            else
            {
                number = 12;
                //Debug.Log(number);
                return sprites[number];
            }
        }
        else if (eroom == null)
        {
            if (wroom == null && eroom == null)
            {
                number = Random.Range(0, 2);
                //Debug.Log(number);
                return sprites[number];
            }
            else
            {
                number = 13;
                //Debug.Log(number);
                return sprites[number];
            }
        }
        else
        {
            number = Random.Range(8, 10);
            //Debug.Log(number);
            return sprites[number];
        }
    }
}
