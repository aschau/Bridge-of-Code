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
        this.advanceButton = this.transform.FindChild("Chat Head").GetComponent<Button>();
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
            this.locked = false;

            if (textFile.name.Contains("Fail"))
            {
                string[] temp = textFile.text.Split(new string[] { System.Environment.NewLine + "|" + System.Environment.NewLine, "\n|\r\n" }, StringSplitOptions.None);
                this.textList = new string[1];
                this.textList[0] = temp[index];
                Debug.Log(index + ", " + temp[index]);
                this.index = 0;
                this.printText();
                this.gameObject.SetActive(true);
                this.advanceButton.interactable = false;
            }

            else
            {
                this.index = index;
                this.textList = textFile.text.Split(new string[] { System.Environment.NewLine + "|" + System.Environment.NewLine, "\n|\r\n" }, StringSplitOptions.None);
                if (this.textList[this.index][0] == '*')
                {
                    this.locked = true;
                }

                else
                {
                    this.locked = false;
                }
                this.printText();
                this.gameObject.SetActive(true);
            }
        }
    }

    public void advanceIndex()
    {
        this.index++;
        if (this.index >= this.textList.Length)
        {
            sceneControl.toggleLock(false);
            sceneControl.togglePause(false);

            this.gameObject.SetActive(false);
        }
        else
        {
            if (this.textList[this.index][0] == '*')
            {
                this.locked = true;
                sceneControl.toggleLock(false);
                sceneControl.togglePause(false);
            }

            else
            {
                this.locked = false;
                sceneControl.togglePause(true);
                sceneControl.toggleLock(true);
            }
            this.printText();
        }
    }

    private void printText()
    {
        if (this.locked)
        {
            this.textBox.text = this.textList[this.index].Substring(1);
            this.advanceButton.interactable = false;
        }
        else
        {
            this.textBox.text = this.textList[this.index];
            this.advanceButton.interactable = true;
        }
    }
}
