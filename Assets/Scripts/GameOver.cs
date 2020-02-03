using UnityEngine;

public class GameOver : MonoBehaviour
{

    // Display game over message
    void OnGUI()
    {

        // Show player score in white on the top left of the screen
        GUI.color = Color.white;
        GUI.skin.label.alignment = TextAnchor.MiddleCenter;
        GUI.skin.label.fontSize = 40;
        GUI.skin.label.fontStyle = FontStyle.Bold;
        GUI.Label(new Rect(0, Screen.height / 4f, Screen.width, 70), "Game over");
    }
}