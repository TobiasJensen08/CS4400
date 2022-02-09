using UnityEngine;

public class AlignWithTarget : MonoBehaviour
{
    public float speed = 1 ;

    private Transform target ;


    private void Start()
    {
        target = FindTarget();
    }

    private void Update()
    {
        if( target != null )
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, (float)speed);
        }
    }

    public void NextTarget()
    {
            target = FindTarget();
            transform.position = Vector3.MoveTowards(transform.position, target.position, (float)speed);
            Debug.Log(target.transform.position);
    }

    public Transform FindTarget()
    {
        GameObject[] candidates = GameObject.FindGameObjectsWithTag("Target");
        float minDistance = Mathf.Infinity;
        Transform closest ;
    
        if ( candidates.Length == 0 )
            return null;

        closest = candidates[0].transform;
        for ( int i = 1 ; i < candidates.Length ; ++i )
        {
            float distance = (candidates[i].transform.position - transform.position).sqrMagnitude;

            if ( distance < minDistance )
            {
                closest = candidates[i].transform;
                minDistance = distance;
            }
        }    
        return closest;
    }    

        //Listening for Events
    private void Awake() {
        Messenger.AddListener("PAUSE", Pause);
        Messenger.AddListener("UNPAUSE",Unpause);
    }
    private void OnDestroy() {
        Messenger.RemoveListener("PAUSE", Pause);
        Messenger.RemoveListener("UNPAUSE", Unpause);
    }
    private void Pause(){
        this.speed = 0.0f;
    }
    private void Unpause(){
        this.speed=1.0f;
    }
}
