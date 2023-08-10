using UnityEngine;

public class ButtonActions : MonoBehaviour {

    public delegate void OnStartGameButtonPress();
    public static event OnStartGameButtonPress onStartGameButtonPress;

    public void StartGame() {
        if(onStartGameButtonPress != null) {
            onStartGameButtonPress.Invoke();
        }
    }
}