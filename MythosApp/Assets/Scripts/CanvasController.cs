using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour {

    Stack canvasStack = new Stack();
    public Canvas mainMenu;
    public Canvas[] allCanvases;
    
	void Start () {
        canvasStack.Push(mainMenu);
        ShowCanvas();
	}
	
	void Update () {
		
	}

    //Pushes a canvas onto the stack then shows the now-top one
    public void PushCanvas(Canvas canvas)
    {
        canvasStack.Push(canvas);
        ShowCanvas();
    }

    //Pops a canvas off the stack then shows the now-top one
    public void PopCanvas()
    {
        canvasStack.Pop();
        ShowCanvas();
    }

    public void ShowCanvas()
    {
        //Disable all canvases, then enable the top canvas
        foreach (Canvas canvas in allCanvases)
        {
            canvas.gameObject.SetActive(false);
        }
        //Look at the top canvas
        Canvas topCanvas = (Canvas)canvasStack.Peek();
        //And set it to active
        topCanvas.gameObject.SetActive(true);
    }

    //Change the color of a button based off a previous choice
    public void ChangeColor(Color color, Image image)
    {
        image.color = color;
    }

}
