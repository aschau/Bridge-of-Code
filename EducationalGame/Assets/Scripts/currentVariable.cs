using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class currentVariable : MonoBehaviour {
    public int variable, output;
    private Text variableText;

    void Awake()
    {
        this.variableText = this.GetComponentInChildren<Text>();
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void updateCurrentVariable(int amount)
    {
        this.variable += amount;
        if (this.variable == this.output)
        {
            this.GetComponent<Image>().color = new Color(47f/255f, 174f/255f, 59f/255f);
        }
        this.updateVariableText();
    }

    private void updateVariableText()
    {
        this.variableText.text = "Variable:\nX = " + this.variable;
    }
}
