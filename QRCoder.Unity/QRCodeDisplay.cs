#if ENABLE_UIELEMENTS_CONTROLS
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace QRCoder.Unity
{
    public class QRCodeDisplay : VisualElement
    {
        public QRCodeDisplay()
        {
            value = null;
            style.unityBackgroundScaleMode = ScaleMode.ScaleToFit;
        }

        public void Update(string value, QRCodeGenerator.ECCLevel eccLevel, int pixelsPerModule)
        {
            _value = value;
            _eccLevel = eccLevel;
            _pixelsPerModule = pixelsPerModule;
            RegenerateImage();
        }

        public QRCodeGenerator.ECCLevel eccLevel
        {
            get => _eccLevel;
            set
            {
                if (_eccLevel == value)
                    return;
                _eccLevel = value;
                RegenerateImage();
            }
        }

        public int pixelsPerModule
        {
            get => _pixelsPerModule;
            set
            {
                if (_pixelsPerModule == value)
                    return;
                _pixelsPerModule = value;
                RegenerateImage();
            }
        }

        private string _value;
        private Texture2D _image;
        private QRCodeGenerator.ECCLevel _eccLevel = QRCodeGenerator.ECCLevel.Q;
        private int _pixelsPerModule = 8;

        public string value
        {
            get => _value;
            set
            {
                if (_value == value)
                    return;
                _value = value;
                RegenerateImage();
            }
        }

        private void RegenerateImage()
        {
            if (_image != null)
                Object.DestroyImmediate(_image, true);

            _image = null;

            if (value == null)
                return;

            using var generator = new QRCodeGenerator();
            using var data = generator.CreateQrCode(value, eccLevel);
            var unityCode = new UnityQRCode(data);
            _image = unityCode.GetGraphic(pixelsPerModule);
            _image.name = "Generated QR code";

            style.backgroundImage = _image;
        }

        public new class UxmlFactory : UxmlFactory<QRCodeDisplay, UxmlTraits>
        {
        }

        public new class UxmlTraits : VisualElement.UxmlTraits
        {
            private UxmlStringAttributeDescription m_Value = new() { name = "value" };

            private UxmlEnumAttributeDescription<QRCodeGenerator.ECCLevel> m_ECCLevel = new()
                { name = "ecc-level", defaultValue = QRCodeGenerator.ECCLevel.Q };

            private UxmlIntAttributeDescription m_PixelsPerModule = new()
                { name = "pixels-per-module", defaultValue = 8 };

            public override IEnumerable<UxmlChildElementDescription> uxmlChildElementsDescription
            {
                get { yield break; }
            }

            public override void Init(VisualElement ve, IUxmlAttributes bag, CreationContext cc)
            {
                base.Init(ve, bag, cc);

                var qr = (QRCodeDisplay)ve;
                qr.Update(m_Value.GetValueFromBag(bag, cc),
                    m_ECCLevel.GetValueFromBag(bag, cc),
                    m_PixelsPerModule.GetValueFromBag(bag, cc));
            }
        }
    }
}
#endif