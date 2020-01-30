﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager {
    
    public Action OnStartGame = new Action(() => {});

    public void HandleStartGame() {
        OnStartGame?.Invoke();
    }
    
    public Action OnMainMenu = new Action(() => {});

    public void HandleMainMenu() {
        OnMainMenu?.Invoke();
    }
}