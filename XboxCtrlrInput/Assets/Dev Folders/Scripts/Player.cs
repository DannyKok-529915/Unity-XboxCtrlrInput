using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XboxCtrlrInput;

public class Player : MonoBehaviour
{
	public float speed;
	public float jumpA;
	public float jumpB;
	public float jumpX;
	public float jumpY;
	public XboxController controller;
	private bool canJump;
	private Vector2 nextPos;
	private Rigidbody2D rb;

	private void Start()
	{
		canJump = true;
		rb = GetComponent<Rigidbody2D>();
	}

	private void Update()
	{
		nextPos = transform.position;
		float axisX = XCI.GetAxis(XboxAxis.LeftStickX, controller);
		nextPos = nextPos + new Vector2(axisX * speed * Time.deltaTime, 0);
		transform.position = nextPos;


		if (XCI.GetButton(XboxButton.Start, controller) && canJump)
		{
			speed = speed * 2;
		}

		if (XCI.GetButton(XboxButton.A, controller) && canJump)
		{
			canJump = false;
			rb.velocity = new Vector2(0, jumpA);
		}
	}
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			canJump = true;
		}
	}
}
