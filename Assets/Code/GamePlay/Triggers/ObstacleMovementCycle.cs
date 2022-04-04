using System;
using Code.UI.Windows;
using UnityEngine;
using VContainer;

namespace Code.GamePlay.Triggers
{
    public class ObstacleMovementCycle : MonoBehaviour
    {
        public Transform start;
        public Transform end;
        public float speed;

        private Vector3 startPosition;
        private Vector3 endPosition;

        private IStage stage;
        [Inject]
        public void Construct(IStage stage)
        {
            this.stage = stage;
        }

        private void Start()
        {
            startPosition = start.position;
            endPosition = end.position;
        }


        private void Update()
        {
            if(stage.CurrentStage == EStage.Pause) return;
            var timeScale = 1 / (Vector3.Distance(startPosition, endPosition) / speed);
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, Mathf.Abs(Time.time * timeScale % 2 - 1));
        }
    }
}