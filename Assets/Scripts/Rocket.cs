using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class Rocket : MonoBehaviour
{
    [Inject] private EventManager _eventManager;

    [SerializeField] private PlayerCamera cam;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] Sprite firstRepair;
    [SerializeField] Sprite secondRepair;
    [SerializeField] Sprite thirdRepair;
    [SerializeField] ParticleSystem _particleRepair;

    [SerializeField] private ParticleSystem _LeftEngine;
    [SerializeField] private ParticleSystem _RightEngine;
    [SerializeField] private ParticleSystem _LeftSparks;
    [SerializeField] private ParticleSystem _RightSparks;

    private TypeItem _nextItem = TypeItem.wood;
    public TypeItem NextItem =>  _nextItem;

    public int itemToWin = 3;
    private int curItem = 0;
     public void PutItem(TypeItem typeItem)
     {
        if (typeItem == TypeItem.wood)
        {
            Debug.Log("Предмет дерево принят");
            curItem++;
            // spriteRenderer.sprite = firstRepair;
            _nextItem = TypeItem.sand;
            StartCoroutine(StartRepairAnim(firstRepair));
            // cam.AnimShake();
            _LeftEngine.Stop();
            _LeftSparks.Stop();
        }
        if (typeItem == TypeItem.rock)
        {
            Debug.Log("Предмет камень принят");
            curItem++;
            // spriteRenderer.sprite = secondRepair;
            _nextItem = TypeItem.none;
            StartCoroutine(StartRepairAnim(thirdRepair));
            _RightEngine.Stop();
            _RightSparks.Stop();
        }
        if (typeItem == TypeItem.sand)
        {
            Debug.Log("Предмет песок принят");
            curItem++;
            // spriteRenderer.sprite = thirdRepair;
            _nextItem = TypeItem.rock;
            StartCoroutine(StartRepairAnim(secondRepair));
            // cam.AnimShake();
        }
        
        _eventManager.HandleItemPut();

        if(curItem == 3)
        {
            _eventManager.HandleWin();
        }

     }

     private IEnumerator StartRepairAnim(Sprite sprite) {
         _particleRepair.Play();
         yield return new WaitForSeconds(1f);
         spriteRenderer.sprite = sprite;
         yield return new WaitForSeconds(1f);
         _particleRepair.Stop();
         cam.AnimShake();
     }

    /* void ShowLandSlide()
    {

    } */
}
