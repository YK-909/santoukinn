using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

public class SelectionRestrictor : MonoBehaviour
{
    [HideInInspector] public GameObject previousSelection; // それまで選択されていたオブジェクト
    public GameObject[] Selectables; // ここにインスペクタ上でフォーカス許可オブジェクトをセットしておく

    private void Awake()
    {
        if (this.Selectables == null)
        {
            return;
        }

        // すべてのフォーカス許可オブジェクトにSelectionHookerをアタッチ
        foreach (var selectable in this.Selectables)
        {
            var hooker = selectable.AddComponent<SelectionHooker>();
            hooker.restrictor = this;
        }

        // フォーカス制限用コルーチンをスタート
        this.StartCoroutine(this.RestrictSelection());
    }

    private IEnumerator RestrictSelection()
    {
        while (true)
        {
            // currentSelectedGameObjectを監視、選択が変更されたら...
            yield return new WaitUntil(
                () => (EventSystem.current != null) && (EventSystem.current.currentSelectedGameObject != this.previousSelection));

            // それまで選択されていたオブジェクトがnull、または許可リストに入っていれば何もしないが...
            if ((this.previousSelection == null) ||
                this.Selectables.Contains(EventSystem.current.currentSelectedGameObject))
            {
                continue;
            }

            // さもなくばそれまで選択されていたオブジェクトを再選択する
            Debug.LogFormat(
                "Reselect {0}.",
                this.previousSelection.name);
            EventSystem.current.SetSelectedGameObject(this.previousSelection);
        }
    }

    private class SelectionHooker : MonoBehaviour, IDeselectHandler
    {
        public SelectionRestrictor restrictor;

        // 選択解除時に、それまで選択されていたオブジェクトを覚えておく
        public void OnDeselect(BaseEventData eventData)
        {
            this.restrictor.previousSelection = eventData.selectedObject;
            Debug.LogFormat("Previous selection:{0}", this.restrictor.previousSelection.name);
        }
    }
}
