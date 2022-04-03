using System;
using UnityEngine;

namespace Code.GamePlay.Triggers
{
    public class ObstacleMovementCycle : MonoBehaviour
    {
        public Transform start;
        public Transform end;
        public float speed;

        private Vector3 startPosition;
        private Vector3 endPosition;

        private void Start()
        {
            startPosition = start.position;
            endPosition = end.position;
        }


        private void Update()
        {
            var timeScale = 1 / (Vector3.Distance(startPosition, endPosition) / speed);
            transform.position = Vector3.Lerp(startPosition, endPosition, Mathf.Abs(Time.time * timeScale % 2 - 1));
        }
    }
}