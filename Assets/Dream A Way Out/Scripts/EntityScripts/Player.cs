using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float speed = 0.5f;
    int frame;

    Vector2 direction;
    Vector3 vel;

    Animator animator;
    int leftHash = Animator.StringToHash("Left");
    int upHash = Animator.StringToHash("Up");
    int rightHash = Animator.StringToHash("Right");
    int downHash = Animator.StringToHash("Down");

	// Use this for initialization
	void Start () 
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetKey(KeyCode.S))
	    {
		    direction.y = -1;
		    vel.y = direction.y * speed;
            frame = 0;
            
	    }
        else if (Input.GetKey(KeyCode.W))
	    {
		    direction.y = 1;
		    vel.y = direction.y * speed;
            frame = 1;
	    }
	    else
	    {
		    vel.y = 0;
	    }

        if (Input.GetKey(KeyCode.A))
	    {
		    direction.x = -1;
		    vel.x = direction.x * speed;
            frame = 2;
	    }
        else if (Input.GetKey(KeyCode.D))
	    {
		    direction.x = 1;
		    vel.x = direction.x * speed;
            frame = 3;
	    }
	    else
	    {
		    vel.x = 0;
	    }
        if (frame == 0)
            animator.SetTrigger(downHash);
        if (frame == 1)
            animator.SetTrigger(upHash);
        if (frame == 2)
            animator.SetTrigger(leftHash);
        if (frame == 3)
            animator.SetTrigger(rightHash);
        transform.position += vel;
    }
}
