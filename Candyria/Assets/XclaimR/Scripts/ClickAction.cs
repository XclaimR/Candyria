using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ClickAction : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        //Debug.Log(eventData.pointerCurrentRaycast.gameObject.name);
        if(eventData.pointerCurrentRaycast.gameObject.name == "Again")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (eventData.pointerCurrentRaycast.gameObject.name == "Leave")
        {
            Application.Quit();
        }
    }
}
