using UnityEngine;

namespace Drone
{
    public class PropellersAnimation : MonoBehaviour
    {
        [SerializeField] Transform propeller1;
        [SerializeField] Transform propeller2;
        [SerializeField] Transform propeller3;
        [SerializeField] Transform propeller4;

        [SerializeField] float spinSpeed = 1000;

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            propeller1.transform.Rotate( 0, 0, -spinSpeed * Time.deltaTime );
            propeller2.transform.Rotate( 0, 0, spinSpeed * Time.deltaTime );
            propeller3.transform.Rotate( 0, 0, spinSpeed * Time.deltaTime );
            propeller4.transform.Rotate( 0, 0, -spinSpeed * Time.deltaTime );
        }
    }
}
