using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GUIControll : MonoBehaviour {

    public Slider slider;
    public Image fill;
    public Color minForce = Color.yellow;
    public Color maxForce = Color.red;

    public Text strokesNumber;
    public Text totalStrokesNumber;
    public Text levelName;
    public Text wonMessage;
    public Text completedHolesMessage;

    public ballControllScript ballScript;
    public FinishHoleScript finishHoleScript;

    private int levelIndex;

	// Use this for initialization
	void Start () {

        levelName.text = SceneManager.GetActiveScene().name;
        levelIndex = SceneManager.GetActiveScene().buildIndex;
        wonMessage.enabled = false;
        completedHolesMessage.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {

        if (finishHoleScript.isFinished)
        {
            wonMessage.enabled = true;
        }

        if (finishHoleScript.isFinished && levelIndex == SceneManager.sceneCountInBuildSettings - 1)
        {
            completedHolesMessage.enabled = true;
        }

        //controlling force slider's value and color
        slider.value = (ballScript.shootForce / ballScript.maxShootForce);
        fill.color = Color.Lerp(minForce, maxForce, slider.value);

        strokesNumber.text = "STROKES: " + ballScript.strokes;
        totalStrokesNumber.text = "TOTAL STROKES: " + ballControllScript.totalStrokes;
    }
}
