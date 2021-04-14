using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueText : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public GameObject continueButton;
    public GameObject dialogue;
    //MẢNG SENTENCES CHỨA HỘI THOẠI INDEX
    public string[] sentences;
    public float typingSpeed;
    // HỘI THOẠI INDEX
    private int index;

    private void Start() {
        StartCoroutine(Type());
    }
    private void Update() {
        if (textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
    }
    public IEnumerator Type()
    {
        // DUYỆT TỪNG PHẨN TỬ LETTER TRONG MẢNG SENTENCES[INDEX]
        foreach (char letter in sentences[index].ToCharArray())
        {
            // IN TỪNG PHẦN TỬ LETTER RA Ô TEXT (TEXTDISPLAY.TEXT)
            textDisplay.text += letter;
            // THỜI GIAN ĐỢI TYPINGSPEED SAU MỖI LẦN LẶP FOREACH
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    
    // HÀM CONTINUE CHO HỘI THOẠI
    public void NextSentences()
    {
        continueButton.SetActive(false);
        // NẾU PHẦN TỬ TRONG INDEX NHỎ HƠN 1 CÂU HAY SENTENCES - 1
        if (index < sentences.Length - 1)
        {
            index ++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        // CHO TỚI KHI KHÔNG CÒN PHÀN TỬ TRONG CENTENCES
        else 
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialogue.SetActive(false);
        }
    }
}
