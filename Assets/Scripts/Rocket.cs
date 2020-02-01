using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Rocket : MonoBehaviour
{
    [Inject] private EventManager _eventManager;

    [SerializeField] private PlayerCamera cam;
    public GameObject snowSlideOnWoodRoad;
    public GameObject snowSlideOnRockRoad;
    public GameObject snowSlideOnSandRoad;
     public void PutItem(TypeItem typeItem)
     {
        if (typeItem == TypeItem.wood)
        {
            Debug.Log("Предмет дерево принят");
            snowSlideOnWoodRoad.SetActive(true);
            cam.AnimShake();
        }
        if (typeItem == TypeItem.rock)
        {
            Debug.Log("Предмет камень принят");
            snowSlideOnRockRoad.SetActive(true);
            cam.AnimShake();
        }
        if (typeItem == TypeItem.sand)
        {
            Debug.Log("Предмет песок принят");
            snowSlideOnSandRoad.SetActive(true);
            cam.AnimShake();
        }
        
        _eventManager.HandleItemPut();

     }

    /* void ShowLandSlide()
    {

    } */
}
