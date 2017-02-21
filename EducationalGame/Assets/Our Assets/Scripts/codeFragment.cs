using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class codeFragment : MonoBehaviour {
    public bool beingDragged = false;
    public string text;
    public Sprite deadSprite;

    private float offsetX, offsetY;
    private Vector3 origin;
    private GameObject mainCamera, player;
    private Text codeText;

    void Awake()
    {
        mainCamera = GameObject.Find("Main Camera");
        player = GameObject.Find("Player");
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
            if (hit.transform.tag == "death")
            {
                hit.transform.GetChild(0).gameObject.SetActive(true);
                hit.transform.GetChild(0).GetComponentInChildren<Text>().text = this.name;
                hit.transform.GetComponent<BoxCollider2D>().enabled = false;
                this.gameObject.SetActive(false);
            }

            //if (hit.transform.tag == "death" && hit.transform.name == this.text)
            //{
            //    this.gameObject.SetActive(false);
            //}

            //else
            //{
            //    this.player.GetComponent<SpriteRenderer>().sprite = this.deadSprite;
            //    this.transform.position = origin;
            //}
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
