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
        if (!this.selecting && !sceneControl.paused)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.GetAxis("Mouse X") > 0 || Input.GetAxis("Mouse X") < 0)
                {
                    transform.position -= new Vector3(Input.GetAxisRaw("Mouse X") * Time.deltaTime * speed, Input.GetAxisRaw("Mouse Y") * Time.deltaTime * speed, 0);
                }
            }
        }

	}
}
