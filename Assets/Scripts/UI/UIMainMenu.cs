﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using Zenject;

public class UIMainMenu : MonoBehaviour {
    [SerializeField] private Button _startButton;
    [SerializeField] private CanvasGroup _canvasGroup;
    [SerializeField] VideoPlayer _videoPlayer;

    [Inject] private EventManager _eventManager;

    private void Awake() {
        _startButton.onClick.AddListener(OnStart);
        _videoPlayer.Play();
        StartCoroutine(DelayerStart());
    }

    private IEnumerator DelayerStart() {
        yield return new WaitForSeconds(42f);
        OnStart();
    }

    private void OnStart() {
        _eventManager.HandleStartGame();
    }

    public void Show() {
        gameObject.SetActive(true);

        _canvasGroup.DOFade(1, 1);
        transform.DOScale(1, 1).OnComplete(() => {
            _startButton.interactable = true;
        });
    }

    public void Hide() {
        _startButton.interactable = false;
        _canvasGroup.DOFade(0, 1);
        transform.DOScale(2, 1).OnComplete(() => {
            gameObject.SetActive(false);
        });
    }
}
