using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public AudioSource hit;
	public AudioSource grunt;

	private Animator anim;
	[System.Serializable]
	public class PlayerStats {
		public int maxHealth = 100;

		private int _curHealth;
		public int curHealth
		{
			get { return _curHealth; }
			set { _curHealth = Mathf.Clamp(value, 0, maxHealth); }
		}

		public void Init()
		{
			curHealth = maxHealth;
		}
	}

	public PlayerStats stats = new PlayerStats();

	[SerializeField]
	private StatusIndicator statusIndicator;

	void Start()
	{
		anim = GetComponent<Animator> ();
		stats.Init();

		if (statusIndicator == null)
		{
			Debug.LogError("No status indicator referenced on Player");
		}
		else
		{
			statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
		}
	}


	void Update () {
		
	}

	public void DamagePlayer (int damage) {
		stats.curHealth -= damage;
		if (stats.curHealth <= 0)
		{
			GameMaster.KillPlayer(this);
		}

		Debug.LogError("DAMAGED");
		anim.SetTrigger ("hit");
		hit.Play ();
		grunt.Play ();

		statusIndicator.SetHealth(stats.curHealth, stats.maxHealth);
	}


	void OnTriggerEnter2D(Collider2D o){
		if (o.CompareTag ("Projectile")) {
			DamagePlayer (20);
		}
	}

	void OnCollisionEnter2D(Collision2D _colInfo)
	{
		//ProjectileAnim _pr = _colInfo.collider.GetComponent<ProjectileAnim>();
		if (_colInfo.gameObject.tag == "Projectile")
		{
			DamagePlayer(20);
			//DamageEnemy(9999999);
		}
	}
}
