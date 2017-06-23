using UnityEngine;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {
    void OnMouseOver(){
        if (Input.GetMouseButtonDown(0)){
            Application.LoadLevel(0);
        }
    }
}
