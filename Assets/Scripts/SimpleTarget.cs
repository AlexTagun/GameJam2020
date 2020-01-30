using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class SimpleTarget : MonoBehaviour {
    [Inject] private EventManager _eventManager;

    private void OnMouseDown() {
        if (EventSystem.current.IsPointerOverGameObject()) return;
        _eventManager.HandleMainMenu();
    }
}
