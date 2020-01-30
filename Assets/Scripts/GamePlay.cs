using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GamePlay : MonoBehaviour {
    public void Show() {
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}
