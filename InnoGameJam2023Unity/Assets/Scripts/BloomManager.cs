using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class BloomManager : MonoBehaviour {
    public static BloomManager Instance;

    void OnEnable() {
        Instance = this;
        FillImageContainer.fillAmount = 0.0f;
        GetComponent<CanvasGroup>().alpha = 0.0f;
    }

    [SerializeField] Image BloomImageContainer, FillImageContainer, FillOutline;
    [SerializeField] Color BloomBrownish;

    [SerializeField] Sprite[] BloomSprites;
    int totalBloom;
    [YarnCommand("AddBloom")]
    public static void AddBloom(int value) {
        Instance.AddBloomInternal(value);
    }

    [YarnCommand("SetBloomImageBrown")]
    public static void SetBloomImageBrown(bool state) {
        Instance.SetBloomBrownInternal(state);
    }

    void SetBloomBrownInternal(bool state) {
        BloomImageContainer.DOColor(state ? BloomBrownish : Color.white, 3.0f).SetEase(Ease.InBounce);
    }
    
    [YarnCommand("SetBloomUIBrown")]
    public static void SetBloomUIBrown(bool state) {
        Instance.SetBloomUIBrownInternal(state);
    }

    void SetBloomUIBrownInternal(bool state) {
        FillOutline.DOColor(state ? BloomBrownish : Color.white, 3.0f).SetEase(Ease.InBounce);
    }

    [YarnCommand("SetUIVisible")]
    public static void SetUIVisible(bool state) {
        Instance.SetUIVisibleInternal(state);
    }

    void SetUIVisibleInternal(bool state) {
        GetComponent<CanvasGroup>().DOFade(state ? 1.0f : 0.0f, 2.0f);
    }
    
    void AddBloomInternal(int value) {
        totalBloom += value;
        const int maxBloom = 10;
        totalBloom = Mathf.Clamp(totalBloom, 0, maxBloom);
        float totalBloom01 = totalBloom / (float) maxBloom;
        FillImageContainer.DOFillAmount(totalBloom01, 2.0f);
        int bloomSpriteIndex = Mathf.FloorToInt(totalBloom01 * BloomSprites.Length - 1);
        BloomImageContainer.sprite = BloomSprites[Mathf.Clamp(bloomSpriteIndex, 0, BloomSprites.Length - 1)];
    }
}
