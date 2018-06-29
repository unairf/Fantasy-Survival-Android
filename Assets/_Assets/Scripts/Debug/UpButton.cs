﻿using UnityEngine;
using UnityEngine.EventSystems;

namespace TouchControlsKit
{
    public class UpButton : ControllerBase,
        IPointerExitHandler, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerClickHandler
    {
        public GameObject player;
        private bool pulsado;
        public FloatReference velocidad;


        public bool swipeOut = false;

        [Label("Normal Button")]
        public Sprite normalSprite;
        [Label("Pressed Button")]
        public Sprite pressedSprite;

        public Color32 pressedColor = new Color32(255, 255, 255, 165);

        int pressedFrame = -1
            , releasedFrame = -1
            , clickedFrame = -1;


        // isPRESSED
        internal bool isPRESSED { get { return touchDown; } }
        // isDOWN
        internal bool isDOWN { get { return (pressedFrame == Time.frameCount - 1); } }
        // isUP
        internal bool isUP { get { return (releasedFrame == Time.frameCount - 1); } }
        // isCLICK
        internal bool isCLICK { get { return (clickedFrame == Time.frameCount - 1); } }



        // Update Position
        protected override void UpdatePosition(Vector2 touchPos)
        {
            base.UpdatePosition(touchPos);

            if (touchDown == false)
            {
                touchDown = true;
                touchPhase = ETouchPhase.Began;
                pressedFrame = Time.frameCount;

                ButtonDown();
            }
        }


        // Button Down
        protected void ButtonDown()
        {
            baseImage.sprite = pressedSprite;
            baseImage.color = visible ? pressedColor : (Color32)Color.clear;
        }

        // Button Up
        protected void ButtonUp()
        {
            baseImage.sprite = normalSprite;
            baseImage.color = visible ? baseImageColor : (Color32)Color.clear;
        }

        // Control Reset
        protected override void ControlReset()
        {
            base.ControlReset();

            releasedFrame = Time.frameCount;
            ButtonUp();
        }

        // OnPointer Down
        public void OnPointerDown(PointerEventData pointerData)
        {
            if (touchDown == false)
            {
                touchId = pointerData.pointerId;
                UpdatePosition(pointerData.position);
            }
        }

        // OnDrag
        public void OnDrag(PointerEventData pointerData)
        {
            if (Input.touchCount >= touchId && touchDown)
            {
                UpdatePosition(pointerData.position);
            }
        }

        // OnPointer Exit
        public void OnPointerExit(PointerEventData pointerData)
        {
            if (swipeOut == false)
            {
                OnPointerUp(pointerData);
            }
        }

        // OnPointer Up
        public void OnPointerUp(PointerEventData pointerData)
        {
            ControlReset();
            pulsado = false;
        }

        // OnPointer Click
        public void OnPointerClick(PointerEventData pointerData)
        {
            clickedFrame = Time.frameCount;
        }

        void Update() {
            if (pulsado)
                MoverArriba();
        }

        void MoverArriba() {
            player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + velocidad.Variable.Value * Time.deltaTime);
        }

    };
}