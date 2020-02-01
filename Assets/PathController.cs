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
    }
    
    private void OnItemPut(){
        var rocket = GameObject.FindWithTag("Rocket").GetComponent<Rocket>();
        var nextItemType = rocket.NextItem;
        
        UpdatePathStoppers(nextItemType);
    }

    private void UpdatePathStoppers(TypeItem typeItem){
        foreach (var pathStopper in PathStoppers){
            if (pathStopper.TypeItem == typeItem){
                pathStopper.Hide();
            }
            else{
                pathStopper.Show();
            }
        }
    }
}
