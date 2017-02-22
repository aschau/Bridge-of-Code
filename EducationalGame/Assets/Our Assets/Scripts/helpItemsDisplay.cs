using UnityEngine;
using UnityEngine.UI;

public class helpItemsDisplay : MonoBehaviour
{
	public Text term;
	public Text description;
    public Text syntax;


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

        this.term.text = item.term;
        this.description.text = item.description;
        this.syntax.text = item.syntax; 


    }
}
