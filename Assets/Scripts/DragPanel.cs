using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class DragPanel : MonoBehaviour, IPointerDownHandler, IDragHandler
{

    public Vector2 originalLocalPointerPosition;
    public Vector3 originalPanelLocalPosition;
    public RectTransform panelRectTransform;
    public RectTransform parentRectTransform;

    void Awake()
    {
        panelRectTransform = transform.parent as RectTransform;
        parentRectTransform = panelRectTransform.parent as RectTransform;
    }

    public void OnPointerDown(PointerEventData data)
    {
        originalPanelLocalPosition = panelRectTransform.localPosition;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out originalLocalPointerPosition);
    }

    public void OnDrag(PointerEventData data)
    {
        if (panelRectTransform == null || parentRectTransform == null)
            return;
        Debug.Log("OnDrag");
        Vector2 localPointerPosition;
        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(parentRectTransform, data.position, data.pressEventCamera, out localPointerPosition))
        {
            Vector3 offsetToOriginal = localPointerPosition - originalLocalPointerPosition;
            panelRectTransform.localPosition = originalPanelLocalPosition + offsetToOriginal;
        }

        ClampToWindow();
    }

    // Clamp panel to area of parent
    void ClampToWindow()
    {
        Vector3 pos = panelRectTransform.localPosition;
        Debug.Log($"{parentRectTransform.rect.min}减{panelRectTransform.rect.min}anchoredPosition:{parentRectTransform.anchoredPosition}anchoredPosition3D:{parentRectTransform.anchoredPosition3D}");
        Debug.Log($"{parentRectTransform.rect.max}减{panelRectTransform.rect.max}anchoredPosition:{parentRectTransform.anchoredPosition}anchoredPosition3D:{parentRectTransform.anchoredPosition3D}");
        Debug.Log(parentRectTransform.rect.x + "    "+parentRectTransform.rect.y+ "^^^^center:" + parentRectTransform.rect.center+ "rect.size"+parentRectTransform.rect.size );
        Debug.Log(parentRectTransform.localPosition);
        Vector3 minPosition = parentRectTransform.rect.min - panelRectTransform.rect.min;
        Vector3 maxPosition = parentRectTransform.rect.max - panelRectTransform.rect.max;
        //Debug.Log($"{minPosition}-----{maxPosition}");
        pos.x = Mathf.Clamp(panelRectTransform.localPosition.x, minPosition.x, maxPosition.x);
        pos.y = Mathf.Clamp(panelRectTransform.localPosition.y, minPosition.y, maxPosition.y);

        panelRectTransform.localPosition = pos;
    }
}
