using UnityEngine;
using System.Collections;

public class EnergyPoint : MonoBehaviour {

	void Start()
     {
          StartCoroutine("DestroyMe");
     }
 
     IEnumerator DestroyMe()
     {
          yield return new WaitForSeconds(0.2f);
          Destroy(gameObject);
     }
}
