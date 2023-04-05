using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    // Start is called before the first frame update

    SpriteRenderer sr;
    Transform bg;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        bg = GetComponent<Transform>();
    }
    void Start()
    {
        //t�nh t? l? m�n h�nh game d?a theo camera
        float worldHeight = Camera.main.orthographicSize * 2;
        float worldWidth = worldHeight * (Screen.width / Screen.height);

        float xScaler = worldWidth / sr.bounds.size.x;
        float yScaler = worldHeight / sr.bounds.size.y;


        Vector3 scale = transform.localScale;
        scale.x *= xScaler;
        scale.y *= yScaler;

        transform.localScale = scale;
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
