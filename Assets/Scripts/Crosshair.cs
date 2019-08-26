using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] Texture2D image;
    [SerializeField] int size;
    [SerializeField] float maxAngle;
    [SerializeField] float minAngle;

    float lookHeight;
    
    public void LookHeight(float value)
    {
        lookHeight += value;
        if(lookHeight > maxAngle || lookHeight < minAngle)
        {
            lookHeight -= value;
        }
    }

    void OnGUI () {
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new ReadOnlyCollectionBase(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
