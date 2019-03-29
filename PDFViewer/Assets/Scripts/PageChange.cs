using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class PageChange : MonoBehaviour 
{

	private List<Sprite> images;
	private SpriteRenderer spriteRenderer;
    private int currentPageNumber = 0;
    private MLInputController controller;
    private bool pressed = false;
	void Start () 
	{
        MLInput.Start();
        MLInput.OnControllerButtonDown += OnButtonDown;
        MLInput.OnControllerButtonUp += OnButtonUp;
		images = Resources.LoadAll<Sprite>("Pictures").ToList();
        controller = MLInput.GetController(MLInput.Hand.Left);
		spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.sprite = images[currentPageNumber];
	}

    void OnButtonDown(byte controllerID, MLInputControllerButton button)
    {
        if (button == MLInputControllerButton.Bumper)
        {
            pressed = true;
        }
    }

    void OnButtonUp(byte controllerID, MLInputControllerButton button)
    {
        if (pressed && button == MLInputControllerButton.Bumper)
        {
            currentPageNumber++;
            spriteRenderer.sprite = images[currentPageNumber];
            pressed = false;
        }
    }
}
