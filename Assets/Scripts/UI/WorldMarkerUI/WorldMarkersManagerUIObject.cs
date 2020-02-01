using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WorldMarkersManagerUIObject : MonoBehaviour
{
    List<WorldMarkerBeaconComponent> _theBeacons = new List<WorldMarkerBeaconComponent>();
    
    private void Awake(){
        _theBeacons = FindObjectsOfType<WorldMarkerBeaconComponent>().ToList();
    }

    public void ShowMarker(HintType hintType){
        bool isShown = false;
        
        foreach (var theBeacon in _theBeacons){
            bool theIsCreated;
            WorldMarkerUIObject theWorldMarkerObject = theBeacon.getMarker(out theIsCreated);

            if (theIsCreated){
                theWorldMarkerObject.GetComponent<RectTransform>().SetParent(transform, false);
            }
            
            if (isShown){
                theWorldMarkerObject.gameObject.SetActive(false);
            }
            else{
                if (theBeacon.getHintType == hintType){
                    theWorldMarkerObject.gameObject.SetActive(true);
                    isShown = true;
                }
                else{
                    theWorldMarkerObject.gameObject.SetActive(false);
                }
            }
        }
    }

    private void Update() {
        foreach (WorldMarkerBeaconComponent theBeacon in _theBeacons) {
                bool theIsCreated;
                WorldMarkerUIObject theWorldMarkerObject = theBeacon.getMarker(out theIsCreated);
                RectTransform theMarkerRectTransform = theWorldMarkerObject.GetComponent<RectTransform>();
                if (theIsCreated){
                    theMarkerRectTransform.SetParent(transform, false);
                }

                if (theBeacon != null){
                    updateMarkerTransform(theWorldMarkerObject, theBeacon.transform.position);
                }
        }
    }

    private void updateMarkerTransform(WorldMarkerUIObject inMarker, Vector2 theWorldPointToAttachMarker) {
        Vector2 thePosition = Camera.main.WorldToViewportPoint(theWorldPointToAttachMarker);

        Vector2 theOffsetInViewport = Camera.main.ScreenToViewportPoint(_positionOffset);
        thePosition.x = Mathf.Clamp(thePosition.x, theOffsetInViewport.x, 1f - theOffsetInViewport.x);
        thePosition.y = Mathf.Clamp(thePosition.y, theOffsetInViewport.y, 1f - theOffsetInViewport.y);

        RectTransform theMarkerTransform = inMarker.GetComponent<RectTransform>();
        theMarkerTransform.anchorMin = thePosition;
        theMarkerTransform.anchorMax = thePosition;

        Vector2 theCenter = new Vector2(0.5f, 0.5f);
        float theRotation = Quaternion.FromToRotation(Vector2.right, thePosition - theCenter).eulerAngles.z;
        inMarker.setRotation(theRotation);

        Vector2 theAlphaOffsetInViewport = Camera.main.ScreenToViewportPoint(_alphaOffset);

        thePosition = Camera.main.WorldToViewportPoint(theWorldPointToAttachMarker);
        float theAlpha = (thePosition.x > 0f && thePosition.x < 1f) && (thePosition.y > 0f && thePosition.y < 1f)
            ? 0f : 1f;
        inMarker.setAlpha(theAlpha);
    }

    [SerializeField] private Vector2 _positionOffset = new Vector2(50f, 50f);
    [SerializeField] private Vector2 _alphaOffset = new Vector2(50f, 50f);
}
