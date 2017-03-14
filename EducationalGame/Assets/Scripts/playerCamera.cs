using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCamera : MonoBehaviour {
    public float speed = 2000f;
    public bool selecting, panning;

    private Vector2 leftCorner, rightCorner, mouseOrigin;
    private float cameraWidth, cameraHeight;
    private GameObject player;
    private sceneControl sceneController;

    void Awake()
    {
        this.leftCorner = GameObject.Find("Left Bound").transform.position;
        this.rightCorner = GameObject.Find("Right Bound").transform.position;
        this.sceneController = GameObject.Find("Scene Control").GetComponent<sceneControl>();
        this.player = GameObject.Find("Player");
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
        if (!this.selecting && !sceneControl.paused && !this.panning)
        {
            if (Input.GetMouseButton(0) && !Application.isMobilePlatform)
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                {
                    this.transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0);
                    this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.leftCorner.x + this.cameraWidth, this.rightCorner.x - this.cameraWidth), Mathf.Clamp(this.transform.position.y, this.leftCorner.y + this.cameraHeight, this.rightCorner.y), this.transform.position.z);
                }
            }

            else if (Input.touchCount > 0)
            {
                Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.position -= touchDeltaPosition;
                this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.leftCorner.x + this.cameraWidth, this.rightCorner.x - this.cameraWidth), Mathf.Clamp(this.transform.position.y, this.leftCorner.y + this.cameraHeight, this.rightCorner.y), this.transform.position.z);
            }
        }

        if (this.panning)
        {
            this.panToPlayer();
        }

	}

    private void panToPlayer()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, new Vector3(this.player.transform.position.x, this.player.transform.position.y, this.transform.position.z), this.speed * Time.deltaTime);
        this.transform.position = new Vector3(Mathf.Clamp(this.transform.position.x, this.leftCorner.x + this.cameraWidth, this.rightCorner.x - this.cameraWidth), Mathf.Clamp(this.transform.position.y, this.leftCorner.y + this.cameraHeight, this.rightCorner.y), this.transform.position.z);
    }
}
