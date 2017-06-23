using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayAgainButton : MonoBehaviour {
//    void OnMouseOver(){
//        if (Input.GetMouseButtonDown(0)){
//           
//        }
//    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
}
