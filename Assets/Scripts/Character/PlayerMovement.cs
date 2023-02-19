using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Dreamteck.Splines;

namespace Character
{
    [System.Serializable]
    public class PlayerMovement
    {
        public SplineFollower follower;
        public bool canMove;
        public float forwardSpeed = 5f;
        public float sideMoveLimit = 1f;
        public float sideSpeed = 1f;
        public float rotationSpeed = 20f;

        public void Move()
        {
            if (!canMove)
            {
                follower.follow = false;
                return;
            }
            ForwardMove();
            SideMove();
        }

        public void StopMovement()
        {
            canMove = false;
        }

        private void ForwardMove()
        {
            follower.follow = true;
        }

        private void SideMove()
        {
            var xMove = Player.Ins.joystick.Horizontal * (sideSpeed * Time.deltaTime);

            var pos = Vector3.zero;
            pos.x = Player.Ins.playerBody.localPosition.x + xMove;
            pos.x = Mathf.Clamp(pos.x, -sideMoveLimit, sideMoveLimit);
            Player.Ins.playerBody.localPosition = pos;

            var isMoved = Mathf.Abs(xMove) < 0.01f;
            var targetVal = isMoved ? Vector3.zero : Vector3.up * (60 * Mathf.Sign(xMove));
            var curSpeed = rotationSpeed * Time.deltaTime;
            if (isMoved)
                curSpeed /= 2f;

            var targetAngle = Quaternion.Euler(targetVal);
            var rotation = Quaternion.Lerp(Player.Ins.playerBody.localRotation, targetAngle, curSpeed);
            Player.Ins.playerBody.localRotation = rotation;
        }
    }
}

