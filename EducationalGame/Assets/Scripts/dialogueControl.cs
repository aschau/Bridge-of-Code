using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class dialogueControl : MonoBehaviour {
    public int index = 0;
    public bool locked;

    private Button advanceButton;
    //private TextAsset textFile;
    private Text textBox;
    private string[] textList;

    void Awake()
    {
        this.textBox = this.transform.FindChild("Text").GetComponent<Text>();
        this.advanceButton = this.transform.FindChild("Image").GetComponent<Button>();
        //textFile = (TextAsset)Resources.Load(SceneManager.GetActiveScene().name);
    }

	// Use this for initialization
	void Start () {
        this.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startDialogue(TextAsset textFile, int index)
    {
        if (textFile)
        {
            this.index = index;
            this.textList = textFile.text.Split(new string[] { System.Environment.NewLine + "|" + System.Environment.NewLine }, StringSplitOptions.None);
            if (this.textList[this.index][0] == '*')
            {
                this.locked = true;
            }

            else
            {
                this.locked = false;
            }
                this.printText();
        }
    }

    public void advanceIndex()
    {
        this.index++;
        if (this.index >= this.textList.Length)
        {
            sceneControl.toggleLock();
            sceneControl.togglePause();
            this.gameObject.SetActive(false);
        }
        else
        {
            if (this.textList[this.index][0] == '*')
            {
                this.advanceButton.interactable = false;
                this.locked = true;
                sceneControl.toggleLock();
                sceneControl.togglePause();
            }

            else
            {
                this.locked = false;
                this.advanceButton.interactable = true;
            }
            this.printText();
        }
    }

    private void printText()
    {
        if (this.locked)
        {
            this.textBox.text = this.textList[this.index].Substring(1);
        }
        else
        {
            this.textBox.text = this.textList[this.index];
        }
    }
}
