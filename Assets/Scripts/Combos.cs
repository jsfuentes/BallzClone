using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Combos : MonoBehaviour {

	public int ComboNumber;
    public Text _comboText;
	// Use this for initialization
	void Start () {
        _comboText.text = "";
        _comboText.material.color = new Color(1f, 1f, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void StartCombo(){
		_finishCombo ();
		ComboNumber = 0;
		//Debug.Log (ComboNumber);
	}
	public void AddToCombo(){
		ComboNumber++;
		//Debug.Log (ComboNumber);
	}
	private void _finishCombo(){
		if (ComboNumber > 3) {
			//no text
            _comboText.text = "";
		}
		if(3 <= ComboNumber &&  ComboNumber < 5){
			//nice

            _comboText.text = "Nice!";
            _comboText.color = Color.white;
            StartCoroutine(FadeText());
			GameManager.instance.ScoreManager.Score += 100;
		}
		if (5 <= ComboNumber &&  ComboNumber < 7) {
			//Great
            _comboText.text = "Great!";
            _comboText.color = Color.white;
            StartCoroutine(FadeText());
            _comboText.gameObject.GetComponent<Animation>().Play();
			GameManager.instance.ScoreManager.Score += 200;
		}
		if (7 <= ComboNumber &&  ComboNumber < 10) {
			//Fuego
            _comboText.text = "Fuego!";
            _comboText.color = Color.white;
            StartCoroutine(FadeText());
			GameManager.instance.ScoreManager.Score += 300;
		}
		if (10 <= ComboNumber) {
			//Deck
            _comboText.text = "Deck";
            _comboText.color = Color.white;
            StartCoroutine(FadeText());
			GameManager.instance.ScoreManager.Score += 500;
		}
	}

    private IEnumerator FadeText()
    {
        float progress = 0;
        float timeToFade = 2.0f;

        while (progress / timeToFade < 1.0)
        {
            progress += Time.deltaTime;
            float alpha = Mathf.Lerp(1.0f, 0.0f, progress / timeToFade);

            _comboText.color = new Color(1f, 1f, 1f, alpha);
            yield return null;
        }
    }
}
