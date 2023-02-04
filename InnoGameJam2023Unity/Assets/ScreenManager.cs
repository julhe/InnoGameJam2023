using System;
using System.Collections;
using System.Collections.Generic;
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
            
            Image.sprite = screen.Image;
            break;
        }
    }
    [Serializable]
    public class Screen {
        public string Name;
        public Sprite Image;
    }
}
