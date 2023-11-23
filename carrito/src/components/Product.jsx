import { useEffect, useState } from "react";
import { ApiUrl } from "../services/apirest";

const Product = () =>{
    const url = ApiUrl+'productos';
    const [productos, setProductos] = useState()
    const apiFetch = async () => {
        const response = await fetch(url)
        const {data} = await response.json()
        setProductos(data)
    }
    useEffect(() => {
        apiFetch()
    }, [])
    return <div>
        {
            !productos ? 'Cargando productos...': 
            productos.map((producto,index)=>{
            return  <div key={index}>
                        <p>{producto.description}</p>
                        <p>{producto.price}</p>
                        <p>{producto.detail}</p>
                        <img src={producto.image} alt="Imagen no disponible" width="200" height="200"></img>
                    </div> 
            })
        }
    </div>;
}
export default Product;