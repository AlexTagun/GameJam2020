using System.Collections.Generic;
using UnityEngine;
using Zenject;

public enum HintType
{
    
    Rocket,
    Wood,
    Rock,
    Sand,
    None,
}

public class HintController : MonoBehaviour
{
    private WorldMarkersManagerUIObject worldMarkersManager;
    
    [SerializeField] private List<HintType> Hints;

    private int _currentHintIndex = -1;

    [Inject] private EventManager _eventManager;

    private void Awake(){
        _eventManager.OnItemPicked += OnItemPicked;
        _eventManager.OnItemPut += OnItemPut;

        worldMarkersManager = GameObject.FindWithTag("WorldMarkersManager").GetComponent<WorldMarkersManagerUIObject>();
    }

    private void Start(){
        ShowNextHint();
    }

    private void ShowNextHint(){
        _currentHintIndex++;
        if (_currentHintIndex < Hints.Count){
            worldMarkersManager.ShowMarker(Hints[_currentHintIndex]);
        }
    }

    private void OnItemPicked(){
        ShowNextHint();
    }

    private void OnItemPut(){
        ShowNextHint();
    }
}