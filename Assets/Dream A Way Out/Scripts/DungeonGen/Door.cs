using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public Door target;
    public GameObject go;
    public GameObject player;

    void Start()
    {
        go = this.gameObject;
    }
	void Update () {
        if (target == null)
        {
            this.gameObject.SetActive(false);
        }
	}
    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player"))
        {
            player = coll.gameObject;
            if(gameObject.CompareTag("sdoor"))
            {
                player.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y-1, 0);
                Camera.main.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y-2.79f, -10);

            }
            if (gameObject.CompareTag("ndoor"))
            {
                player.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y+1, 0);
                Camera.main.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y + 2.79f, -10);
            }
            if (gameObject.CompareTag("edoor"))
            {
                player.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x+1,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y, 0);
                Camera.main.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x + 4.2f,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y, -10);
            }
            if (gameObject.CompareTag("wdoor"))
            {
                player.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x-1,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y, 0);
                Camera.main.transform.position = new Vector3(
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.x - 4.2f,
                                                    this.target.gameObject.GetComponentInParent<Transform>().position.y, -10);
            }
            //this.target.gameObject.transform.parent.gameObject.layer = 9;
            this.target.gameObject.layer = 9;

        }
    }
}
