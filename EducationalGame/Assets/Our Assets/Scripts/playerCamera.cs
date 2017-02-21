using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {
    public float speed = 1f;
    public bool selecting;

    private float leftBound, rightBound;
    private Vector2 mouseOrigin;
    private bool panning;

    void Awake()
    {
        this.leftBound = GameObject.Find("Left Bound").transform.position.x + (Camera.main.orthographicSize * Screen.width / Screen.height) ;
        this.rightBound = GameObject.Find("Right Bound").transform.position.x - (Camera.main.orthographicSize * Screen.width / Screen.height);
    }

	// Use this for initialization
	void Start () {
        this.panning = false;
        this.selecting = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.selecting)
        {
            if (!this.panning)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    this.mouseOrigin = Input.mousePosition;
                    this.panning = true;
                }
            }

            else
            {
                if (Input.GetMouseButton(0))
                {
                    Vector2 pos = Camera.main.ScreenToViewportPoint(this.mouseOrigin - new Vector2(Input.mousePosition.x, Input.mousePosition.y));
                    Vector2 move = new Vector2(pos.x * this.speed, 0);

                    this.transform.Translate(move);
                    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.leftBound, this.rightBound), this.transform.position.y, this.transform.position.z);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    this.panning = false;
                }
            }
        }

	}
}
