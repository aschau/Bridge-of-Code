using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeFragment : MonoBehaviour {
    public bool beingDragged = false;
    public string text;

    private float offsetX, offsetY;
    private Vector3 origin;
    private GameObject mainCamera;
    private Text codeText;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        codeText = this.transform.FindChild("Text").GetComponent<Text>();
    }

	// Use this for initialization
	void Start () {
        this.origin = this.transform.position;
        this.codeText.text = this.text;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void beginDrag()
    {
        offsetX = this.transform.position.x - Input.mousePosition.x;
        offsetY = this.transform.position.y - Input.mousePosition.y;
        this.beingDragged = true;
    }

    public void onDrag()
    {
        this.transform.position = new Vector3(Input.mousePosition.x + offsetX, Input.mousePosition.y + offsetY);
    }

    public void endDrag()
    {
        this.beingDragged = false;
        RaycastHit2D hit = checkHit(this.mainCamera);

        if (hit)
        {
            if (hit.transform.tag == "death" && !hit.transform.GetComponent<codePlacement>().activated)
            {
                hit.transform.GetChild(0).GetChild(1).gameObject.SetActive(true);
                hit.transform.GetComponentInChildren<Text>().text = this.name;
                hit.transform.GetComponent<codePlacement>().activated = true;
                if (hit.transform.name ==  this.text)
                {
                    hit.transform.GetComponent<codePlacement>().correct = true;
                }
                this.gameObject.SetActive(false);

            }

            else
            {
                this.transform.position = origin;
            }
        }
        else
        {
            this.transform.position = origin;
        }

    }

    private RaycastHit2D checkHit(GameObject camera)
    {
        return Physics2D.Raycast(new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).origin.y), new Vector2(camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.x, camera.GetComponent<Camera>().ScreenPointToRay(Input.mousePosition).direction.y));
    }
}
