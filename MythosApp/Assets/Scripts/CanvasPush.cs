using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasPush : MonoBehaviour {

    CanvasController canvasController;

    private void Awake()
    {
        canvasController = GameObject.Find("MainCanvas").GetComponent<CanvasController>();
        canvasController.allCanvases.Add(this.GetComponent<Canvas>());
    }
}