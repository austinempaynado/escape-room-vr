using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.InputSystem.XR;
using UnityEngine.XR.Interaction.Toolkit.Inputs;
using UnityEngine.XR.Interaction.Toolkit;

namespace UnityEngine.XR.Interaction.Toolkit
{
    public class GoGoController : ActionBasedController
    {
        public Transform player;
        public float closeDistance; //minimum distance the controller will be to considered close to the player, when close tracking behaves the same way before, when beyond, we start gogo controller behaviour
        public float speed; //factor at which we have the controller move away when outside the close distance
        public float accelVectorDist; //a minimum amount that the controller has to move to be able to do something with it

        private float startDist = 0; //start the distance at 0
        private Vector3 prevPos = Vector3.zero; //constantly checking where the previous position is to determine which direction to move controller in

        protected override void UpdateTrackingInput(XRControllerState controllerState)
        {
            base.UpdateTrackingInput(controllerState);

            var posAction = positionAction.action;
            var hasPositionAction = posAction != null;

            // Update position
            if (hasPositionAction && (controllerState.inputTrackingState & InputTrackingState.Position) != 0)
            {
                var pos = posAction.ReadValue<Vector3>();

                if (prevPos == Vector3.zero) prevPos = pos; //initialize prev position to the current position

                var dist = Vector3.Distance(player.position, pos); //distance between controller and player camera

                if (dist > closeDistance)
                {
                    //start doing gogo calculations here
                    if (startDist == 0)
                    {
                        startDist = dist;
                        prevPos = pos;
                    }
                    //calculate vector where we wanna move the controller from
                    var translatePoint = (dist - startDist) * speed * (pos - prevPos).normalized; //want magnitude of the vector to be 1
                    controllerState.position = pos + translatePoint;
                }
                else
                {
                    startDist = 0;
                }
                if(Vector3.Distance(prevPos, pos)> accelVectorDist)
                {
                    //set previous position to current position, so it doesn't jump around for no reason
                    prevPos = pos;
                }
            }
        }
        
    }

}