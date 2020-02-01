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

    public int itemToWin = 3;
    private int curItem = 0;
     public void PutItem(TypeItem typeItem)
     {
        if (typeItem == TypeItem.wood)
        {
            Debug.Log("Предмет дерево принят");
            curItem++;
            snowSlideOnWoodRoad.SetActive(true);
            cam.AnimShake();
        }
        if (typeItem == TypeItem.rock)
        {
            Debug.Log("Предмет камень принят");
            curItem++;
            snowSlideOnRockRoad.SetActive(true);
            cam.AnimShake();
        }
        if (typeItem == TypeItem.sand)
        {
            Debug.Log("Предмет песок принят");
            curItem++;
            snowSlideOnSandRoad.SetActive(true);
            cam.AnimShake();
        }
        
        _eventManager.HandleItemPut();

        if(curItem == 3)
        {
            _eventManager.HandleWin();
        }

     }

    /* void ShowLandSlide()
    {

    } */
}
