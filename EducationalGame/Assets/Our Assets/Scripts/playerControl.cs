using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class playerControl : MonoBehaviour {
    public float speed = 450f;
    public bool dead;
    private List<codePlacement> walkPoints;
    private int currentPoint;
    private Animator anim;


    void Awake()
    {
        this.walkPoints = new List<codePlacement>(GameObject.FindObjectsOfType<codePlacement>());
        this.walkPoints = this.walkPoints.OrderBy(x => Vector2.Distance(this.transform.position, x.transform.position)).ToList();
        this.anim = this.GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
        this.dead = false;
        this.currentPoint = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.dead)
        {
            if (this.walkPoints[this.currentPoint].activated)
            {
                this.anim.Play("playerRolling");
                this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector2(this.walkPoints[this.currentPoint].transform.position.x, this.transform.position.y), this.speed * Time.deltaTime);
            }

            if (this.transform.position.x == this.walkPoints[this.currentPoint].transform.position.x)
            {
                this.anim.Play("playerIdle");
                if (this.currentPoint < this.walkPoints.Count - 1)
                {
                    this.currentPoint++;
                }
            }
        }
	}
}
