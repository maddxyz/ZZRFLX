using UnityEngine.Audio;
using UnityEngine;
using System.Collections;

public class GameMaster : MonoBehaviour {

	public static GameMaster gm;
	public AudioSource audio;

	void Start () {
		if (gm == null) {
			gm = GameObject.FindGameObjectWithTag ("_GM").GetComponent<GameMaster>();
		}
		if (audio == null) {
			audio = GetComponent<AudioSource> ();
		}
		//gameOverScreen.SetActive (false);
	}

	public Transform playerPrefab;
	public Transform spawnPoint;
	public float spawnDelay;
	public Transform spawnPrefab;

	[SerializeField]
	private GameObject gameOverScreen;

	/*public IEnumerator RespawnPlayer () {
		audio.Play ();
		yield return new WaitForSeconds (spawnDelay);

		Instantiate (playerPrefab, spawnPoint.position, spawnPoint.rotation);
		//GameObject clone = Instantiate (spawnPrefab, spawnPoint.position, spawnPoint.rotation) as GameObject;
		//Destroy (clone, 3f);
	}*/

	public static void KillPlayer (Player player) {
		Destroy (player.gameObject);
		gm.EndGame ();
		//gm.StartCoroutine (gm.RespawnPlayer());
	}

	public void EndGame(){
		Debug.Log ("Game Over");
		gameOverScreen.SetActive (true);
		Time.timeScale = 0;
	}

}