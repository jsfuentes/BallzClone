using UnityEngine;
using System.Collections;

public class Combos : MonoBehaviour {

	public int ComboNumber;
	// Use this for initialization
	void Start () {
	
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
		}
		if(3 <= ComboNumber &&  ComboNumber < 5){
			//nice
			GameManager.instance.ScoreManager.Score += 100;
		}
		if (5 <= ComboNumber &&  ComboNumber < 7) {
			//Great
			GameManager.instance.ScoreManager.Score += 200;
		}
		if (7 <= ComboNumber &&  ComboNumber < 10) {
			//Fuego
			GameManager.instance.ScoreManager.Score += 300;
		}
		if (10 <= ComboNumber) {
			//Deck
			GameManager.instance.ScoreManager.Score += 500;
		}
	}
}
