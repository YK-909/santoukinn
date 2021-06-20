using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StagPower : MonoBehaviour
{
	// 加える力の大きさ
	[SerializeField]
	float forceMagnitude = 10.0f;

	// X軸からの角度
	[SerializeField]
	float forceAngle = 45.0f;

	// 力を加える方向
	Vector3 forceDirection = new Vector3(1.0f, 1.0f, 0f);

	// 飛行中フラグ
	bool isFlying = false;

	// ボタン押下フラグ
	bool isBoostPressed = false;

	// Sphereオブジェクトの初期位置格納用ベクトル
	Vector3 initPosition = Vector3.zero;

	// Rigidbodyコンポーネントへの参照をキャッシュ
	Rigidbody rb;

	void Start()
	{
		initPosition = gameObject.transform.position;
		rb = gameObject.GetComponent<Rigidbody>();
	}

	void Update()
	{
		if (Input.GetKeyUp(KeyCode.B))
		{
			isBoostPressed = true;
		}

		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.Translate(0f, 0f, 0.1f);
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.Translate(0f, 0f, -0.1f);
		}
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.Translate(-0.1f, 0f, 0f);
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.Translate(0.1f, 0f, 0f);
		}

		// forceAngleの変更を反映する
		CalcForceDirection();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Main")
		{
			isBoostPressed = true;
		}
	}

	void FixedUpdate()
	{
		if (!isBoostPressed)
		{
			// キーまたはボタンが押されていなければ
			// 処理の切り替えをせず抜ける
			return;
		}
		if (isFlying)
		{
			// 飛行中の処理
			StopFlying();
		}
		else
		{
			// ボールを飛ばす処理
			BoostSphere();
		}
		// 飛行中フラグの切り替え
		isFlying = !isFlying;

		// どちらの処理をしてもボタン押下フラグをfalseに
		isBoostPressed = false;
	}

	void StopFlying()
	{
		// 運動の停止
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;

		// 初期位置に移動させる
		gameObject.transform.position = initPosition;
	}

	void BoostSphere()
	{
		// 向きと力の計算
		Vector3 force = forceMagnitude * forceDirection;

		// 力を加えるメソッド
		rb.AddForce(force, ForceMode.Impulse);
	}

	public void OnPressedBoostButton()
	{
		isBoostPressed = true;
	}

	void CalcForceDirection()
	{
		// 入力された角度をラジアンに変換
		float rad = forceAngle * Mathf.Deg2Rad;

		// それぞれの軸の成分を計算
		float x = Mathf.Cos(rad);
		float y = Mathf.Sin(rad);
		float z = 0f;

		// Vector3型に格納
		forceDirection = new Vector3(x, y, z);
	}
}
