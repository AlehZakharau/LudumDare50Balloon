using Code.UI.Windows;
using UnityEngine;
using VContainer;

namespace Code.GamePlay.Triggers
{
    public class ObstacleMovementTarget : MonoBehaviour
    {
        public Transform end;
        public float speed;

        private Vector3 endPosition;
        
        private IStage stage;
        [Inject]
        public void Construct(IStage stage)
        {
            this.stage = stage;
        }

        private void Start()
        {
            endPosition = new Vector3(transform.position.x, transform.position.y, -40);
        }

        private void Update()
        {
            if(stage.CurrentStage == EStage.Pause) return;
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
    }
}