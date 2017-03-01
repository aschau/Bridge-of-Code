using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {
    public float speed = 1f;
    public bool selecting;

    private Vector2 leftCorner, rightCorner;
    private Vector2 mouseOrigin;
    private float cameraWidth, cameraHeight;
    private bool panning;
    private sceneControl sceneController;

    void Awake()
    {
        this.leftCorner = GameObject.Find("Left Bound").transform.position;
        this.rightCorner = GameObject.Find("Right Bound").transform.position;
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
    }

	// Use this for initialization
	void Start () {
        this.panning = false;
        this.selecting = false;
        this.cameraWidth = Camera.main.orthographicSize * Screen.width / Screen.height;
        this.cameraHeight = Camera.main.orthographicSize;
	}
	
	// Update is called once per frame
	void Update () {
        if (!this.selecting && !this.sceneController.paused)
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
                    Vector2 move = new Vector2(pos.x * this.speed, pos.y * this.speed);

                    this.transform.Translate(move);
                    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.leftCorner.x + this.cameraWidth, this.rightCorner.x - this.cameraWidth), Mathf.Clamp(this.transform.position.y, this.leftCorner.y + this.cameraHeight, this.rightCorner.y - this.cameraHeight), this.transform.position.z);
                }

                if (Input.GetMouseButtonUp(0))
                {
                    this.panning = false;
                }
            }
        }

	}
}
