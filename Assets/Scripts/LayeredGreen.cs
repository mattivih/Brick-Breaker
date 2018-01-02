using UnityEngine;
using System.Collections;

public class LayeredGreen : MonoBehaviour {

	void Start()
     {
          StartCoroutine("DestroyMe");
     }
 
     IEnumerator DestroyMe()
     {
          yield return new WaitForSeconds(0.3f);
          Destroy(gameObject);
     }
}
