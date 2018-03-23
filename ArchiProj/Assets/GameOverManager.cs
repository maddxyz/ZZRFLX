using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverManager : MonoBehaviour {

	public void Quit(){
		Debug.Log("APP QUITING");
		Application.Quit();
	}

	public void Retry(){
		SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
	}

}
