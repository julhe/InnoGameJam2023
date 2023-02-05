using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

[RequireComponent(typeof(Image))]
public class YarnBackground : MonoBehaviour {
    Image image;

    
    void Start() {
        image = GetComponent<Image>();
        Color clearWhite = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        image.color = clearWhite;
    }
    
    
    [YarnCommand("SetBackground")]
    public static void SetBackground(string refName) {
        foreach (YarnBackground yarnBackground in FindObjectsOfType<YarnBackground>()) { 
            yarnBackground.image.DOFade(yarnBackground.name == refName ? 1.0f : 0.0f, 2.0f);
        }
    }
}
