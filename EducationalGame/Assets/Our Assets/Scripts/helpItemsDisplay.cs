using UnityEngine;
using UnityEngine.UI;

public class helpItemsDisplay : MonoBehaviour
{
	public Text title;
	public Text description;


    public helpItem item; 
	// Use this for initialization
	void Start () {
	    if(item!= null) Prime(item); 
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Prime(helpItem item)
    {
        this.item = item;

        this.title.text = item.title;
        this.description.text = item.description;


    }
}
