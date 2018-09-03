using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour {
	[SerializeField]
	GameObject prefabAsteroid;
	// Use this for initialization
	void Start () {
		float z = -Camera.main.transform.position.z;
		GameObject asteroid = Instantiate(prefabAsteroid,new Vector3(x: 0f, y: 0f, z: z),Quaternion.identity);
		asteroid.GetComponent<Asteroid>().Initialize(Direction.Up, new Vector3(0f,ScreenUtils.ScreenBottom, z));
		asteroid = Instantiate(prefabAsteroid,new Vector3(x: 0f, y: 0f, z: z),Quaternion.identity);
		asteroid.GetComponent<Asteroid>().Initialize(Direction.Down, new Vector3(0f,ScreenUtils.ScreenTop, z));
		 asteroid = Instantiate(prefabAsteroid,new Vector3(x: 0f, y: 0f, z: z),Quaternion.identity);
		asteroid.GetComponent<Asteroid>().Initialize(Direction.Left, new Vector3(ScreenUtils.ScreenRight,0f, z));
		asteroid = Instantiate(prefabAsteroid,new Vector3(x: 0f, y: 0f, z: z),Quaternion.identity);
		asteroid.GetComponent<Asteroid>().Initialize(Direction.Right, new Vector3(ScreenUtils.ScreenLeft,0f, z));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
