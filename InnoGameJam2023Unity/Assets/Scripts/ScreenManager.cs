using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ScreenManager : MonoBehaviour {
    static ScreenManager instance;

    [SerializeField] List<Screen> screens;
    [SerializeField] Image Image;

    void Awake() {
        instance = this;
    }


    [YarnCommand("SetBackground")]
    public static void SetScreen(string name) {
        instance.SetScreenInternal(name);
    }

    void SetScreenInternal(string screenName) {
        foreach (Screen screen in screens) {
            if (screen.Name != screenName) {
                continue;
            }

            DOTween.Sequence()
                .Append(Image.DOColor(Color.black, 2.0f))
                .AppendCallback(() => Image.sprite = screen.Image)
                .Append(Image.DOColor(Color.white, 2.0f));
            break;
        }
    }
    [Serializable]
    public class Screen {
        public string Name;
        public Sprite Image;
    }
}
