using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class virtualcamera : MonoBehaviour
{
	Renderer targetRenderer; // 判定したいオブジェクトのrendererへの参照

	void Start()
	{
		targetRenderer = GetComponent<Renderer>();
	}
	void Update()
	{
		if (targetRenderer.isVisible)
		{
			// 表示されている場合の処理
			ShowText("画面に表示されてるよ");
		}
		else
		{
			// 表示されていない場合の処理
			ShowText("画面から消えたよ");
		}
	}

	// 以下はサンプルのUI表示用
	[SerializeField]
	Text uiText;
	void ShowText(string message)
	{
		uiText.text = message;
	}
}