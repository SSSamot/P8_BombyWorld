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

    public bool isDie = false;
    [SerializeField]
    private float dissolve;
    private bool killing = false;

    Material mat;

    void Start()
    {
        _mainCamera = Camera.main;    
        _agent = GetComponent<NavMeshAgent>();
        mat = GetComponentInChildren<Renderer>().sharedMaterial;
        mat.SetFloat("_Cutoff_Height", 5);
        dissolve = 1.5f;
    }
   
    void Update()
    {
        Shader.SetGlobalVector("_PlayerPosition", transform.position);
        //mat.SetFloat("_Cutoff_Height", dissolve);
        //dissolve -= 0.02f;
        if (!isDie)
        {
            if (_agent.remainingDistance > 1f)
                anim.SetFloat("Run", 1.5f);
            else
                anim.SetFloat("Run", 0f);

            
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

    private void FixedUpdate()
    {
        if (killing)
        {
            mat.SetFloat("_Cutoff_Height", dissolve);
            dissolve -= 0.01f;
        }
    }

    public void HitPlayer()
    {
        isDie = true;
        anim.SetFloat("Run", 0f);
        _agent.isStopped = true;
        StartCoroutine(KillPlayer());
    }

    IEnumerator KillPlayer()
    {
        anim.SetTrigger("Die");
        yield return new WaitForSeconds(1f);
        killing = true;
        //Destroy(gameObject);
    }
}
