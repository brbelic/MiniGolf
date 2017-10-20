using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class FinishHoleScript : MonoBehaviour {

    public ParticleSystem ballInTargetParticles;

    private int sceneIndex;

    public bool isFinished;

    // Use this for initialization
    void Start () {
        sceneIndex = SceneManager.GetActiveScene().buildIndex;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ball")
        {
            StartCoroutine(GoToNextScene());
        }
    }

    IEnumerator GoToNextScene()
    {
        isFinished = true;
        ballInTargetParticles.Play();

        yield return new WaitForSeconds(2);

        if (sceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(sceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
}
