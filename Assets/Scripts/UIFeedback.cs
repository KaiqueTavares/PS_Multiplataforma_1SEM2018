using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFeedback : MonoBehaviour {

    public static int pontos;
    public Text pontosTXT, resetTxt;
	
	void Start () {
      pontos = PlayerPrefs.GetInt("UltimosPontos", 0);
    }
	
	// Update is called once per frame
	void Update () {
        VerificandoDados();
        pontosTXT.text = "Pontos: " + pontos.ToString();
        if (CharacterMove.reset)
        {
            StartCoroutine(FeedbackReset());
        }
    }

    void VerificandoDados()
    {
        if(pontos > PlayerPrefs.GetInt("UltimosPontos", 0))
        {
            PlayerPrefs.SetInt("UltimosPontos", pontos);
        }
    }

    IEnumerator FeedbackReset()
    {
        resetTxt.enabled = true;
        yield return new WaitForSeconds(0.2f);
        resetTxt.enabled = false;
        yield return new WaitForSeconds(0.2f);
        resetTxt.enabled = true;
        yield return new WaitForSeconds(0.2f);
        resetTxt.enabled = false;
        yield return new WaitForSeconds(0.2f);
        resetTxt.enabled = true;
        yield return new WaitForSeconds(0.2f);
        resetTxt.enabled = false;
        yield return new WaitForSeconds(0.2f);
    }
}
