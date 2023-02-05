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
    [YarnCommand("SetAnimation")]
    public static void SetAnimation(String refName, String animationName, bool play) {
        foreach (YarnSprite yarnSprite in FindObjectsOfType<YarnSprite>()) {
            if (yarnSprite.name != refName) continue;

            if (!yarnSprite.TryGetComponent(out SkeletonGraphic skeletonGraphic)) continue;

            if (play) {
                skeletonGraphic.AnimationState.SetAnimation(1, animationName, true);
            }
            else {
                skeletonGraphic.AnimationState.SetEmptyAnimation(1, 1.0f);
            }
        }
    }

    void Start() {
        Color clearWhite = new Color(1.0f, 1.0f, 1.0f, 0.0f);
        GetComponent<MaskableGraphic>().color = clearWhite;


    }

    void SetState(bool state) {
        GetComponent<MaskableGraphic>().DOFade(state ? 1.0f : 0.0f, 2.0f);
    }
    

}
