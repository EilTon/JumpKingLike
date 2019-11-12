using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public Player _player;
	Camera _camera;
	private void Start()
	{
		_camera = Camera.main;
	}
	void Update()
	{

		transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 4, transform.position.z);
	}
}
