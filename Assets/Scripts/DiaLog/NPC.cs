using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject dialogPanel;
    public GameObject contiButton;
    public TextMeshProUGUI dialogText;
    public string[] dialog;
    private int index;
    public float wordSpeed;
    public bool playerIsClose;
    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose)
        {
            if (dialogPanel.activeInHierarchy)
            {
                zeroText();
            }
            else
            {
                dialogPanel.SetActive(true);
                StartCoroutine(Typing());
            }
        }
        if (dialogText.text == dialog[index])
        {
            contiButton.SetActive(true);
        }
    }
    
    public void zeroText()
    {
        dialogText.text = "";
        index= 0;
        dialogPanel.SetActive(false);
    }

    IEnumerator Typing()
    {
        foreach(char letter in dialog[index].ToCharArray())
        {
            dialogText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        contiButton.SetActive(false);
        if (index < dialog.Length - 1)
        {
            index++;
            dialogText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            zeroText();
        }
    }

   private void OnTriggerEnter2D(Collider2D other) 
   {
        if (other.CompareTag("Player"))
        {
            playerIsClose = true;
        } 
   }

   private void OnTriggerExit2D(Collider2D other) 
   {
        if (other.CompareTag("Player"))
        {
            playerIsClose = false;
        } 
   }
}

