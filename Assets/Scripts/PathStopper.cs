
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PathStopper : MonoBehaviour
{
    [SerializeField] private TypeItem _typeItem;
    public TypeItem TypeItem => _typeItem;
    
    [SerializeField] List<GameObject> Parts = new List<GameObject>();

    public void Show(){
        foreach (var part in Parts){
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

    public void Hide(){
        foreach (var part in Parts){
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