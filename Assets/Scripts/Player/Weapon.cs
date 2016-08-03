using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public float fireRate = 0;
	public float damage = 10;

	float timeToFire = 0;
	public Transform firePoint;
	public GameObject BulletPrefab;
	public GameObject MuzzleFlashPrefab;
	public Transform Bullets;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (fireRate == 0) {
			if (Input.GetButtonDown ("Fire1")) {
				Shoot ();
			}
		} else {
			if (Input.GetButton ("Fire1") && Time.time > timeToFire) {
				timeToFire = Time.time + 1 / fireRate;
				Shoot ();
			}
		}
	}

	private void Shoot(){
		GameObject bullet = Instantiate (BulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
		bullet.transform.parent = Bullets;
		GameObject clone = Instantiate (MuzzleFlashPrefab, firePoint.position, firePoint.rotation) as GameObject;
		clone.transform.parent = firePoint;
		float size = Random.Range (0.6f, 0.9f);
		clone.transform.localScale = new Vector3 (size, size, size);
		Destroy (clone.gameObject, 0.02f);
	}
}
