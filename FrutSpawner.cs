
using UnityEngine;

public class FrutSpawner : MonoBehaviour
{
    private const int FructConst = 3;

    public GameObject ApplePrefab;
    public GameObject PotatoPrefab;
    public GameObject TomatPrefab;

    public GameObject BombPrefab;
    public float BomberChance = 0.2f;

    public float MinDelay = 0.7f;
    public float MaxDelay = 2f;

    public float AngleOfRotation = 30f;

    public float LifeTime = 6f;

    public float MinForce = 15f;
    public float MaxForce = 25f;

    private float _currentDelay = 0f;

    private Collider _collider;

    private bool _isActive;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        Activate(true );
    }

    private void Update()
    {
        if (_isActive == false)
            return;

        TrySpawnObject();
    }

    public void Activate(bool value)
    {
        _isActive = value;
    }

    private void TrySpawnObject()
    {
        _currentDelay -= Time.deltaTime;

        if (_currentDelay <= 0)
        {
            float random = Random.value;

            if (random < BomberChance)
            {
                SpawnBomb();
            }
            else
            {
                SpuwnerFruct();
            }

            SetNewDelay();
        }
    }

    private void SpawnBomb()
    {
        SpawnObject(BombPrefab);
    }

    private void SetNewDelay()
    {
        _currentDelay = Random.Range(MinDelay, MaxDelay);
    }

    private void SpuwnerFruct()
    {

        SpawnObject(GetRadomFruit());
    }

    private void SpawnObject(GameObject prefab)
    {
        GameObject NewObject = Instantiate(prefab, GetSpawnPosition(), GetRandomRotation());

        float Force = Random.Range(MinForce, MaxForce);

        NewObject.GetComponent<Rigidbody>().AddForce(NewObject.transform.up * Force, ForceMode.VelocityChange);

        Destroy(NewObject, LifeTime);
    }

    
    
    private GameObject GetRadomFruit()
    {
        int frutnum = Random.Range(0, FructConst);


        if (frutnum == 0)
            return ApplePrefab;
        else if (frutnum == 1)
            return PotatoPrefab;
        else if (frutnum == 2)
            return TomatPrefab;
        return null;
    }

    private Quaternion GetRandomRotation()
    {
        return Quaternion.Euler( 0, 0, Random.Range(-AngleOfRotation, AngleOfRotation) );
    }

    private Vector3 GetSpawnPosition() 
    {
        Vector3 SpawnPoint = Vector3.zero;

        SpawnPoint.x = Random.Range(_collider.bounds.min.x, _collider.bounds.max.x);
        SpawnPoint.y = Random.Range(_collider.bounds.min.y, _collider.bounds.max.y);
        SpawnPoint.z = Random.Range(_collider.bounds.min.z, _collider.bounds.max.z);

        return SpawnPoint;
    }
}
