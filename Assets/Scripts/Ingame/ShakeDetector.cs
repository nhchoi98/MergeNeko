using UnityEngine;

[RequireComponent(typeof(PhysicsController))]
public class ShakeDetector : MonoBehaviour
{

    public float ShakeDetectionThreshold;
    public float MinShakeInterval;

    private float sqrShakeDetectionThreshold;
    private float timeSinceLastShake;

    private PhysicsController physicsController;

    void Start()
    {
        sqrShakeDetectionThreshold = Mathf.Pow(ShakeDetectionThreshold, 2);
        physicsController = GetComponent<PhysicsController>();
    }

    void Update()
    {
        if (ScoreManager.instance.isFeverTime) //�ǹ�Ÿ���� ��쿡��
        {
            if (Input.acceleration.sqrMagnitude >= sqrShakeDetectionThreshold && Time.unscaledTime >= timeSinceLastShake + MinShakeInterval)
            {
                physicsController.ShakeRigidbodies(Input.acceleration);
                timeSinceLastShake = Time.unscaledTime;
            }
        }
    }


}