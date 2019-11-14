using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class CameraScript : MonoBehaviour
{
	public Player _player;
	public AudioClip[] _audiosSources;
	public GameObject _backGround;
	float _timer;
	AudioSource _playerAudio;
	Camera _camera;
	private void Start()
	{
		int randomNumber = Random.Range(0, _audiosSources.Length);
		_playerAudio = GetComponent<AudioSource>();
		_playerAudio.clip = _audiosSources[randomNumber];
		_playerAudio.Play();
		_timer = 0;
		_camera = Camera.main;
	}
	void Update()
	{
		if (_player != null)
		{
			transform.position = new Vector3(_player.transform.position.x, _player.transform.position.y + 4, transform.position.z);
		}

		Music();
		ResizeBackground();
	}

	void Music()
	{
		if (_timer > _playerAudio.clip.length)
		{
			int randomNumber = Random.Range(0, _audiosSources.Length);
			AudioClip newClip = _audiosSources[randomNumber];
			if (newClip != _playerAudio.clip)
			{
				_playerAudio.clip = newClip;
				_playerAudio.Play();
			}
			_timer = 0;
		}
		else
		{
			_timer += Time.deltaTime;
		}
	}

	void ResizeBackground()
	{
		if(_backGround!= null)
		{
			_backGround.transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.07f, _backGround.transform.localScale.z);
		}
	}
}
