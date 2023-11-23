import { useState } from "react";
import { ApiUrl } from "../services/apirest";
import axios from 'axios';
import { useNavigate } from "react-router-dom";

const Login = () =>{
    const navigate = useNavigate();
    const datosUsuarioIniciales = {
        email: "",
        password: ""
    }
    const [datos, setDatos] = useState({
        transaccion: "autenticarUsuario",
        datosUsuario: datosUsuarioIniciales
    })
    const handleInputChange = (e) => {
        let {name, value} = e.target;
        let newDatos = {...datos.datosUsuario, [name]: value};
        setDatos(prevState => ({
            ...prevState,
            datosUsuario: newDatos
        }));
    }
    const handleSubmit = async(e) => {
        e.preventDefault();
        try {
            const res = await axios.post(ApiUrl + "usuarios", datos);
            if(res.data.token){
                localStorage.setItem('token',res.data.token);
                navigate('/producto', {replace: true});
            }
            console.log(res.data);
        } catch (error) {
            console.error("Error:", error);
        }
    }
    return  <div id="fromLogin">
                <form onSubmit={handleSubmit}>
                <label htmlFor="email">Usuario:</label>
                <input type="text" id="email" name="email" onChange={handleInputChange} value={datos.datosUsuario.email}/>
                <br />
                <label htmlFor="password">Contraseña:</label>
                <input type="password" id="password" name="password" onChange={handleInputChange} value={datos.datosUsuario.password}/>
                <br />
                <input type="submit" value="Iniciar sesión"/>   
                </form>
            </div>
    }
 export default Login;