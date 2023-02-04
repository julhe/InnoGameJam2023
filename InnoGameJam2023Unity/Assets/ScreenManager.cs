using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class ScreenManager : MonoBehaviour {
    public List<Screen> screens;

    
    public Image Image;


    void Update() {
        
    }

    public void SetScreen(string name) {
        foreach (Screen screen in screens) {
            if (!screen.Name.Equals(name, StringComparison.InvariantCultureIgnoreCase)) continue;
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
