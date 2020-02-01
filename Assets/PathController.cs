using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PathController : MonoBehaviour
{
    [SerializeField] private List<PathStopper> PathStoppers = new List<PathStopper>();

    [Inject] private EventManager _eventManager;
    
    private void Awake(){
        _eventManager.OnItemPut += OnItemPut;
        _eventManager.OnItemPicked += OnItemPicked;
    }
    
    private void OnItemPut(){
        var rocket = GameObject.FindWithTag("Rocket").GetComponent<Rocket>();
        var nextItemType = rocket.NextItem;
        
        UpdatePathStoppers(nextItemType, true);
    }

    private void OnItemPicked(){
        var rocket = GameObject.FindWithTag("Rocket").GetComponent<Rocket>();
        var nextItemType = rocket.NextItem;
        
        UpdatePathStoppers(nextItemType, false);
    }

    private void UpdatePathStoppers(TypeItem typeItem, bool isEnter){
        foreach (var pathStopper in PathStoppers){
            if (pathStopper.TypeItem == typeItem){
                pathStopper.Hide(isEnter);
            }
            else{
                pathStopper.Show();
            }
        }
    }
}
