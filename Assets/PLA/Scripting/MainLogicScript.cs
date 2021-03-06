using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainLogicScript : MonoBehaviour
{

    public GameObject SubtaskModal;
    private Player player;
    [SerializeField] private soundController soundcontrol;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo = new RaycastHit();
            bool hit = Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hitInfo);
            if (hit && hitInfo.transform.gameObject.tag == "interactable") 
            {
                SubtaskModal.SetActive(true);
                soundcontrol.PlaySFXOneshot("sfx-open");
            }
            if (hit && hitInfo.transform.gameObject.tag == "storeitem") 
            {
                string productName = hitInfo.transform.gameObject.transform.parent.name;
                player.SetProduct(productName);
                soundcontrol.PlaySFXOneshot("rumble");
                hitInfo.transform.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
    }
}
