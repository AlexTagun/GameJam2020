using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerWithDirectionUIObject : WorldMarkerUIObject
{
    public override void setAlpha(float inAlpha) {
        Color theColor = _image.color;
        theColor.a = inAlpha;
        _image.color = theColor;

        theColor = _iconImage.color;
        theColor.a = inAlpha;
        _iconImage.color = theColor;
    }

    public override void setRotation(float inRotation) {
        Vector2 theCenter = new Vector2(0.5f, 0.5f);
        Vector3 theRotation = _markerTransform.rotation.eulerAngles;
        theRotation.z = inRotation;
        _markerTransform.rotation = Quaternion.Euler(theRotation);
    }

    //Fields
    [SerializeField] private RectTransform _markerTransform = null;
    [SerializeField] private UnityEngine.UI.Image _image = null;
    [SerializeField] private UnityEngine.UI.Image _iconImage = null;
}
