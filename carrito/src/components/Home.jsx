import { Outlet, Link } from "react-router-dom";
const Home = () =>{
    return <div>
      <h2>Hola soy el Home</h2>
      <ul>
        <li>
            <Link to="/login">Iniciar sesión</Link>
        </li>
        <li>
            <Link to="/producto">Producto</Link>
        </li>
      </ul>
      <Outlet/>
    </div>;
}
export default Home;