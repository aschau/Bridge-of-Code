using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class playerControl : MonoBehaviour {
    public List<codePlacement> walkPoints;

    public float speed = 450f;
    public bool dead;
    public int currentPoint;
    public Animator anim;
    public bool move;

    public bool stopMove; 

    private playerCamera mainCamera;



    void Awake()
    {
        this.walkPoints = new List<codePlacement>(GameObject.FindObjectsOfType<codePlacement>());
        this.walkPoints = this.walkPoints.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
        this.anim = this.GetComponent<Animator>();
        this.mainCamera = GameObject.Find("Main Camera").GetComponent<playerCamera>();


    }

    // Use this for initialization
    void Start () {
        this.dead = false;
        this.currentPoint = 0;

        this.move = false;
        this.stopMove = false;
        this.walkPoints[0].GetComponent<Collider2D>().enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
        if (!sceneControl.paused)
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

            if (!this.dead)
            {
                if (this.walkPoints[this.currentPoint].activated)
                {
                    if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("playerRolling"))
                    {
                        this.anim.Play("playerRolling");
                        this.move = true; 
                    }
                    this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.walkPoints[this.currentPoint].transform.position.x, this.transform.position.y), this.speed * Time.deltaTime);
                }

                if (this.transform.position.x == this.walkPoints[this.currentPoint].transform.position.x)
                {
                    this.mainCamera.panning = false;
                    this.walkPoints[this.currentPoint].activated = false;
                    if (!this.anim.GetCurrentAnimatorStateInfo(0).IsName("playerIdle"))
                    {
                        this.anim.Play("playerIdle");
                    }
                    if (this.currentPoint < this.walkPoints.Count - 1)
                    {
                        this.currentPoint++;
                        this.walkPoints[this.currentPoint].GetComponent<Collider2D>().enabled = true;
                    }
                    else
                    {
                        stopMove = true; 

                    }
                }

                
            }

        }

        else
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeAll;
        }
	}


 
}
