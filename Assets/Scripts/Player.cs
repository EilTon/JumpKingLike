using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float _powerDirection;
	public float _maxJump;
	public float _minJump;
	public float _maxDirection;
	public Image _powerBar;
	
	bool _isGround;
	bool _wallHit;
	float _jumpPower;
	float _horizontal;
	Rigidbody2D _rigibody;

	void Start()
	{
		_isGround = true;
		_wallHit = false;
		//_jumpPower = 0f;
		//_minJump = 2f;
		//_maxJump = 10f;
		//_maxDirection = 5f;
		_rigibody = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate()
	{
		Jump();
		Direction();
		WallHit();
	}

	private void Jump()
	{
		if (_isGround)
		{
			if (Input.GetKey(KeyCode.Space))
			{
				if (_jumpPower < _maxJump)
				{
					_jumpPower += Time.fixedDeltaTime * 10f;

				}
				else
				{
					_jumpPower = _maxJump;
				}
				PowerCharge();
			}


			else
			{
				if (_jumpPower > 0f)
				{
					_jumpPower = _jumpPower + _minJump;
					_rigibody.velocity = new Vector2(_horizontal, _jumpPower);
					_isGround = false;
				}
			}

		}
	}

	private void Direction()
	{
		if (Input.GetKey(KeyCode.D))
		{
			if (_horizontal < _maxDirection)
			{
				_horizontal += _powerDirection;
			}

		}

		else if (Input.GetKey(KeyCode.Q))
		{
			if (_horizontal > _maxDirection * -1f)
			{
				_horizontal -= _powerDirection;
			}
		}

		else
		{
			_horizontal = 0;
		}
	}

	private void WallHit()
	{
		if (_wallHit)
		{
			_rigibody.velocity = new Vector2(_horizontal * -1f, _jumpPower * 1f);
			_wallHit = false;
		}
	}

	private void PowerCharge()
	{
		_powerBar.fillAmount = _jumpPower / _maxJump;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("Ground"))
		{
			_powerBar.fillAmount = 0;
			_jumpPower = 0f;
			_isGround = true;
		}
		if (collision.gameObject.CompareTag("Wall"))
		{
			_wallHit = true;
		}
	}
}
