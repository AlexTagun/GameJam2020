
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathStopper : MonoBehaviour
{
    [SerializeField] private TypeItem _typeItem;
    public TypeItem TypeItem => _typeItem;
    
    [SerializeField] List<GameObject> EnterParts = new List<GameObject>();
    
    [SerializeField] List<GameObject> ExitParts = new List<GameObject>();

    public void Show(){
        Show(EnterParts);
        Show(ExitParts);
    }

    private void Show(List<GameObject> parts){
        foreach (var part in parts){
            SpriteRenderer spriteRenderer = part.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null){
                spriteRenderer.DOFade(1f, 1f);
            }

            Collider2D collider2D = part.GetComponent<Collider2D>();
            if (collider2D != null){
                collider2D.enabled = true;
            }
        }
    }

    public void Hide(bool isEnter){
        if (isEnter){
            Hide(EnterParts);
            Show(ExitParts);
        }
        else{
            Hide(ExitParts);
            Show(EnterParts);
        }
    }

    private void Hide(List<GameObject> parts){
        foreach (var part in parts){
            SpriteRenderer spriteRenderer = part.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null){
                spriteRenderer.DOFade(0f, 1f);
            }

            Collider2D collider2D = part.GetComponent<Collider2D>();
            if (collider2D != null){
                collider2D.enabled = false;
            }
        }
    }
}