using UnityEngine;
using UnityEngine.UI;

public class ScrollingBackground : MonoBehaviour
{
    [SerializeField] private RawImage bgImage;
    [SerializeField] private float bx, by;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bgImage.uvRect = new Rect(bgImage.uvRect.position + new Vector2(bx, by) * Time.deltaTime, bgImage.uvRect.size);
    }
}
