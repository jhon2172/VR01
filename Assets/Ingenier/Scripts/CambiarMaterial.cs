using UnityEngine;

public class CambiarMaterial : MonoBehaviour
{
    public GameObject objetoACambiar; // Objeto cuyo material se cambiará
    public Material materialNuevo; // El nuevo material que deseas aplicar
    private Material materialOriginal; // El material original del objeto
    private bool clickeado = false; // Variable para controlar el estado de clic

    void Start()
    {
        // Obtener el material original del objeto
        Renderer rend = objetoACambiar.GetComponent<Renderer>();
        if (rend != null)
        {
            materialOriginal = rend.material;
        }
        else
        {
            Debug.LogWarning("El objeto no tiene un componente Renderer para cambiar el material.");
        }

        // Agregar un collider al objeto Empty si no lo tiene
        if (GetComponent<Collider>() == null)
        {
            gameObject.AddComponent<BoxCollider>();
        }
    }

    void Update()
    {
        // Verificar si se hizo clic
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // Si se hizo clic en un collider
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == gameObject) // Si se clickeó en el objeto con este script
                {
                    // Cambiar el material dependiendo del estado
                    if (!clickeado)
                    {
                        CambiarAMaterialNuevo();
                        clickeado = true;
                    }
                    else
                    {
                        CambiarAMaterialOriginal();
                        clickeado = false;
                    }
                }
            }
        }
    }

    void CambiarAMaterialNuevo()
    {
        // Cambiar al material nuevo
        if (objetoACambiar != null)
        {
            Renderer rend = objetoACambiar.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = materialNuevo;
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente Renderer para cambiar el material.");
            }
        }
    }

    void CambiarAMaterialOriginal()
    {
        // Cambiar al material original
        if (objetoACambiar != null)
        {
            Renderer rend = objetoACambiar.GetComponent<Renderer>();
            if (rend != null)
            {
                rend.material = materialOriginal;
            }
            else
            {
                Debug.LogWarning("El objeto no tiene un componente Renderer para cambiar el material.");
            }
        }
    }
}
