using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RenderCube : MonoBehaviour {

	// Use this for initialization
	void Start () {
       /* QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("Hello World", QRCodeGenerator.ECCLevel.Q);
        UnityQRCode qrCode = new UnityQRCode(qrCodeData);
        Texture2D qrCodeAsTexture2D = qrCode.GetGraphic(20);
        GetComponent<Renderer>().material.mainTexture = qrCodeAsTexture2D;
        */
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.up, 20 * Time.deltaTime);
    }
}
