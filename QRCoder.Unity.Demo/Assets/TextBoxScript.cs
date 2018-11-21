using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QRCoder;
using QRCoder.Unity;

public class TextBoxScript : MonoBehaviour {

    public InputField mainInputField;


    // Use this for initialization
    void Start () {
        mainInputField.onValueChange.AddListener(delegate { ValueChangeCheck(); });
        mainInputField.text = "Hello World";
    }

    public void ValueChangeCheck()
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(mainInputField.text, QRCodeGenerator.ECCLevel.Q);
        UnityQRCode qrCode = new UnityQRCode(qrCodeData);
        Texture2D qrCodeAsTexture2D = qrCode.GetGraphic(20);
        GameObject.Find("Cube").GetComponent<Renderer>().material.mainTexture = qrCodeAsTexture2D;
    }
}
