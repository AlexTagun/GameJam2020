using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeObstacle : MonoBehaviour
{
    [SerializeField] private readonly float FREEZING_PLAYER_TIME = 1f;
    [SerializeField] private readonly float RELOAD_FREEZE_TIME = 3f;

    private bool _isReloaded;
    private float _currentReloadTime = 0f;
    
    private void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.tag == "Player" && !_isReloaded){
            StartCoroutine(StartFreezing());
        }
    }

    private IEnumerator StartFreezing(){
        var player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        player.SetSpeedModifier(0f);
        
        
        yield return new WaitForSeconds(FREEZING_PLAYER_TIME);
        
        player.SetSpeedModifier(1f);
        _isReloaded = true;
    }

    private void Update(){
        if (_isReloaded){
            _currentReloadTime += Time.deltaTime;

            if (RELOAD_FREEZE_TIME <= _currentReloadTime){
                _currentReloadTime = 0f;
                _isReloaded = false;
            }
        }
    }
}
