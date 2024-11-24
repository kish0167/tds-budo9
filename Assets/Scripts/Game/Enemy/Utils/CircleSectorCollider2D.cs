using System.Collections.Generic;
using UnityEngine;

namespace TDS.Game.Enemy.Utils
{
    [RequireComponent(typeof(PolygonCollider2D))]
    public class CircleSectorCollider2D : MonoBehaviour
    {
        #region Variables

        [Header("Sector Parameters")]
        [SerializeField] [Range(3, 360)] private int _segments = 36;
        [SerializeField] [Range(0, 360)] private float _angle = 90f;
        [SerializeField] private float _radius = 5f;

        private PolygonCollider2D _polygonCollider;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _polygonCollider = GetComponent<PolygonCollider2D>();
            UpdateCollider();
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            Vector3 origin = transform.position;
            float angleStep = _angle / _segments;
            
            float angledif = Vector2.SignedAngle(Vector2.right, transform.up);

            Vector3 previousPoint = origin;
            for (int i = 0; i <= _segments; i++)
            {
                float currentAngle = Mathf.Deg2Rad * (-_angle / 2 + i * angleStep + angledif);
                float x = Mathf.Cos(currentAngle) * _radius;
                float y = Mathf.Sin(currentAngle) * _radius;
                Vector3 currentPoint = origin + new Vector3(x, y, 0);
                Gizmos.DrawLine(previousPoint, currentPoint);
                previousPoint = currentPoint;
            }

            Gizmos.DrawLine(previousPoint, origin);
        }

        private void OnValidate()
        {
            UpdateCollider();
        }

        #endregion

        #region Private methods

        private void UpdateCollider()
        {
            if (_polygonCollider == null)
            {
                return;
            }

            float angledif = Vector2.SignedAngle(Vector2.right, transform.up);
            
            List<Vector2> points = new() { Vector2.zero };
            
            float angleStep = _angle / _segments;
            for (int i = 0; i <= _segments; i++)
            {
                float currentAngle = Mathf.Deg2Rad * (-_angle / 2 + i * angleStep + angledif);
                float x = Mathf.Cos(currentAngle) * _radius;
                float y = Mathf.Sin(currentAngle) * _radius;
                points.Add(new Vector2(x, y));
            }
            
            _polygonCollider.points = points.ToArray();
        }

        #endregion
    }
}