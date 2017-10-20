using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {
    private int sceneIndex;

    void Start()
    {

        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (sceneIndex == 1)
        {
            gameObject.GetComponent<AudioSource>().volume = 0.124f;
        }
        
    }
}
