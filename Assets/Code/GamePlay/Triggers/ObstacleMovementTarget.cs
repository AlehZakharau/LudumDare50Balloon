using UnityEngine;

namespace Code.GamePlay.Triggers
{
    public class ObstacleMovementTarget : MonoBehaviour
    {
        public Transform end;
        public float speed;

        private Vector3 endPosition;

        private void Start()
        {
            endPosition = end.position;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, endPosition, speed * Time.deltaTime);
        }
    }
}