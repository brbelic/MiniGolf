using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {

    public Button startButton;

    private int sceneIndex;

    // Use this for initialization
    void Start () {
        startButton.onClick.AddListener(StartTheGame);
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void StartTheGame ()
    {
        SceneManager.LoadScene(sceneIndex + 1);
    }
}
