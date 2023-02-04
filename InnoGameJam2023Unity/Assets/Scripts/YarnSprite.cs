using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Spine.Unity;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class YarnSprite : MonoBehaviour
{
    [YarnCommand("ShowCharacter")]
    public static void ShowCharacter(String refName, bool state) {
        foreach (YarnSprite yarnSprite in FindObjectsOfType<YarnSprite>()) {
            if (yarnSprite.name != refName) continue;
            yarnSprite.SetState(state);
            break;
        }
        
        
    }

    void Start() {
        GetComponent<MaskableGraphic>().color = Color.white.WithAlpha(0.0f);
    }

    void SetState(bool state) {
        GetComponent<MaskableGraphic>().DOFade(state ? 1.0f : 0.0f, 2.0f);
    }
}
