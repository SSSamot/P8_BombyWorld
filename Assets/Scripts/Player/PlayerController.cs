using System.Collections;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerController : MonoBehaviour
{
    public Animator anim;

    [Range(1f, 50f)]
    [SerializeField] private float _rayMaxDistance = 20f;

    [SerializeField] LayerMask _groundLayer;

    private Camera _mainCamera;
    private NavMeshAgent _agent;

    private bool isDie = false;

    Material mat;

    void Start()
    {
        _mainCamera = Camera.main;    
        _agent = GetComponent<NavMeshAgent>();
        mat = GetComponentInChildren<Renderer>().material;
    }

    void hit() // call to trigger shader color
    {
        mat.SetFloat("_LastHit", Time.time+1);
    }
   
    void Update()
    {
        if (!isDie)
        {
            if (_agent.remainingDistance > 1f)
                anim.SetFloat("Run", 1.5f);
            else
                anim.SetFloat("Run", 0f);

            Shader.SetGlobalVector("_PlayerPosition", transform.position);
            if (!Input.GetMouseButtonDown(0))
                return;

            Ray cameraRay = _mainCamera.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitInfo;
            if (Physics.Raycast(cameraRay, out hitInfo, _rayMaxDistance, _groundLayer.value))
            {
                _agent.SetDestination(hitInfo.point);
            }
        }
    }

    public void HitPlayer()
    {
        isDie = true;
        StartCoroutine(KillPlayer());
    }

    IEnumerator KillPlayer()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
